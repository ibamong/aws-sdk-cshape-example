using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

using System;

namespace mori9.Utils
{
    public class AmazonUtils
    {
		private static CognitoAWSCredentials _credentials;

		public static CognitoAWSCredentials Credentials
		{
			get
			{
				if (_credentials == null)
					_credentials = new CognitoAWSCredentials(Constants.COGNITO_IDENTITY_POOL_ID, Constants.COGNITO_REGION);
				return _credentials;
			}
		}

		public static AmazonDynamoDBClient _client;

		public static AmazonDynamoDBClient DynamoDBClient
		{
			get
			{
				if (_client == null)
					_client = new AmazonDynamoDBClient(Credentials, Constants.DYNAMODB_REGION);
				return _client;
			}
		}


		private static DynamoDBContext _context;

		public static DynamoDBContext DDBContext
		{
			get
			{
				if (_context == null)
					_context = new DynamoDBContext(DynamoDBClient);
				return _context;
			}
		}
    }
}
