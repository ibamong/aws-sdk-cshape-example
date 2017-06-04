# aws-sdk-cshape-example
This mobile platform project demonstrate how to use Amazon SDK for .Net(c#) to access Amazon Web Service  
It has been customize from  https://github.com/awslabs/aws-sdk-net-samples


# Prerequisites
1. Create an AWS account
2. Install Visual Studio 2017(include Xamarin platform) , I use for Mac

# Step 1
To make calls to AWS in your application, you must first obtain AWS credentials. You do this by using Amazon Cognito, an AWS service that allows your application to access the services in the SDK without having to embed your private AWS credentials in the application.

To get started with Amazon Cognito, you need to create an identity pool. An identity pool is a store of information that is specific to your account and is identified by a unique identity pool ID

  1. Log in to the Amazon Cognito Console , choose Manage Federated Identities, and then choose Create new identity pool.
  2. Enter a name for your identity pool and select the checkbox to enable access to unauthenticated identities. Choose Create Pool to create your identity pool.
  3. Choose Allow to create the two default roles associated with your identity pool, one for unauthenticated users and one for authenticated users. These default roles provide your identity pool access to Amazon Cognito Sync and Amazon Mobile Analytics.
  4. After finnish, you will see 'Identity Pool ID' in the sample code , look like this : us-east-1:4232332223c-56ad-4680-9e46-8xxxxxxxxxx
  
Typically, you will only use one identity pool per application.

After you create your identity pool, you obtain AWS credentials by creating a CognitoAWSCredentials object (passing it your identity pool ID) and then passing it to the constructor of an AWS client . 

  5. Enter Identity Pool ID and your cognito region in this file : /mori9/Utils/Constants.cs 



# Ref

Setting Up the AWS Mobile SDK for .NET and Xamarin : http://docs.aws.amazon.com/mobile/sdkforxamarin/developerguide/setup.html

Store and Retrieve Data with DynamoDB : http://docs.aws.amazon.com/mobile/sdkforxamarin/developerguide/getting-started-store-retrieve-data.html
