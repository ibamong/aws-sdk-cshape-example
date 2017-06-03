using Amazon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mori9.Utils
{
	public class Constants
	{
		//public const string FB_APP_ID = "";
		//public const string FB_APP_NAME = "My Inventory";
		//public const string PROVIDER_NAME = "graph.facebook.com";

		public const string COGNITO_IDENTITY_POOL_ID = "us-east-1:976b965c-56ad-4680-9e46-8edef60b095c";
		public static RegionEndpoint COGNITO_REGION = RegionEndpoint.USEast1; // N. Virginia

		public static RegionEndpoint DYNAMODB_REGION = RegionEndpoint.APSoutheast1; // Singapore

	}
}
