# aws-sdk-cshape-example
This mobile platform project demonstrate how to use Amazon SDK for .Net(c#) to access Amazon Web Service  
It has been customize from  https://github.com/awslabs/aws-sdk-net-samples


# Prerequisites
1. Create an AWS account
2. Install Visual Studio 2017(include Xamarin platform) , I use for Mac


# Step 1 Obtain AWS Credentials
To make calls to AWS in your application, you must first obtain AWS credentials. You do this by using Amazon Cognito, an AWS service that allows your application to access the services in the SDK without having to embed your private AWS credentials in the application.

To get started with Amazon Cognito, you need to create an identity pool. An identity pool is a store of information that is specific to your account and is identified by a unique identity pool ID

  1. Log in to the Amazon Cognito Console , choose Manage Federated Identities, and then choose Create new identity pool.
  2. Enter a name for your identity pool and select the checkbox to enable access to unauthenticated identities. Choose Create Pool to create your identity pool.
  3. Choose Allow to create the two default roles associated with your identity pool, one for unauthenticated users and one for authenticated users. These default roles provide your identity pool access to Amazon Cognito Sync and Amazon Mobile Analytics.
  4. After finnish, you will see 'Identity Pool ID' in the sample code , look like this : us-east-1:4232332223c-56ad-4680-9e46-8xxxxxxxxxx
  
Typically, you will only use one identity pool per application.

After you create your identity pool, you obtain AWS credentials by creating a CognitoAWSCredentials object (passing it your identity pool ID) and then passing it to the constructor of an AWS client . 

  5. Enter Identity Pool ID and your cognito region in this file : /mori9/Utils/Constants.cs 


# Step 2 Set Permissions
You need to set permissions for every AWS service that you want to use in your application. First, you need to understand how AWS views the users of your application.

When someone uses your application and makes calls to AWS, AWS assigns that user an identity. The identity pool that you created in Step 1 is where AWS stores these identities. There are two types of identities: authenticated and unauthenticated. Authenticated identities belong to users who are authenticated by a public login provider (e.g., Facebook, Amazon, Google). Unauthenticated identities belong to guest users.

Every identity is associated with an AWS Identity and Access Management role. In Step 1, you created two IAM roles, one for authenticated users and one for unauthenticated users. Every IAM role has one or more policies attached to it that specify which AWS services the identities assigned to that role can access.

To set permissions for the AWS services that you want to use in your application, simply modify the policy attached to the roles.

Go to the IAM Console and choose Roles. Type your identity pool name into the search box. Choose the IAM role that you want to configure. If your application allows both authenticated and unauthenticated users, you need to grant permissions for both roles.
Click Attach Policy, select the policy you want, and then click Attach Policy. The default policies for the IAM roles that you created provide access to Amazon Cognito Sync and Mobile Analytics.


# Step 3 Create a DynamoDB Table
Before you can read and write data to a DynamoDB database, you must create a table. When creating a table you must specify the primary key.

  1. Go to the DynamoDB Console and click Create Table. The Create Table wizard appears.

  2. Specify your table name, primary key and type .In this project I set up as follow :
  table name : Inventory
  Primary Key : Id
  type : String
  
  3. Leave the rest as default, then Click Create .May take a few minutes for your table to be created.

  4. When done, scroll down the right panel , in the bottom you will see Amazon Resource Name (ARN). Copy this ARN , you will use in the next step	


# Step 4 Add permission for DynamoDB
In order for your identity pool to access Amazon DynamoDB, you must modify the identity pool's roles.

  1. Navigate to the Identity and Access Management Console and click Roles in the left-hand pane. Search for your identity pool name - two roles will be listed one for unauthenticated users and one for authenticated users.

  2. Click the role for unauthenticated users (it will have "unauth" appended to your identity pool name) and click Create Role Policy.

  3. Select Policy Generator and click Select.

  4. On the Edit Permissions page, enter the settings :
  
  Effect : Allow
  AWS service : Amazon DynamoDB
  Actions : All Actions Selected
  Amazon Resource Name (ARN) : [ARN of your DynamoDB table]
  
  The Amazon Resource Name (ARN) of a DynamoDB table looks like arn:aws:dynamodb:us-west-2:123456789012:table/Inventory and is composed of the region in which the table is located, the owner's AWS account number, and the name of the table in the format table/Inventory

  5. Click Add Statement, and then click Next Step. The Wizard will show you the configuration generated.

  6. Click Apply Policy.


# Step 5 Install the AWS Mobile SDK for .NET and Xamarin

  In Visual Studio
Right-click the Packages folder in the project, and then click Add Packages.
Search for the package name that you want to add to your project. To include the prelease NuGet packages, choose Include Prelease. You can find a complete list of AWS service packages at AWS SDK packages on NuGet.
Choose the package, and then choose Add package.

In this project I use packages as follow :
AWSSDK - Core Runtime
AWSSDK - Amazon Cognito Identity
AWSSDK - Amazon DynamoDB


That's it. Now you can run this project. Next step , I will use S3 to store image and keep ID in DynamoDB

your grace,
\mong

# Ref

Setting Up the AWS Mobile SDK for .NET and Xamarin : http://docs.aws.amazon.com/mobile/sdkforxamarin/developerguide/setup.html

Store and Retrieve Data with DynamoDB : http://docs.aws.amazon.com/mobile/sdkforxamarin/developerguide/getting-started-store-retrieve-data.html
