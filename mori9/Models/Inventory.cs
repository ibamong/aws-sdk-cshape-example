using Amazon.DynamoDBv2.DataModel;

using System;

namespace mori9.Models
{
	[DynamoDBTable("Inventory")]
	public class Inventory
	{
		[DynamoDBHashKey]    // Hash Key
		public string Id { get; set; }
		public string UserId { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public int    Quantity { get; set; }
		public string Category { get; set; }
        public DateTime ExpiredDate { get; set; }


		//public string Status { get; set; }
		//public string Description { get; set; }
		//public string CategoryParent { get; set; }
		//public bool ExpiredAlarm { get; set; }
		//public string Location { get; set; }
		//public string SerialNo { get; set; }
		//public DateTime ToShop { get; set; }
		//public bool ToShopAlarm { get; set; }

	}
}