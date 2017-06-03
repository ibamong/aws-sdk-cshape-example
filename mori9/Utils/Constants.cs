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
		public const string COGNITO_IDENTITY_POOL_ID = "xxxxxxx";  //  Enter your ID
		public static RegionEndpoint COGNITO_REGION = RegionEndpoint.USEast1; // Enter your region
		public static RegionEndpoint DYNAMODB_REGION = RegionEndpoint.APSoutheast1; // Enter your region
	}
}
