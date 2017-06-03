using Amazon.DynamoDBv2.DataModel;

using System;

using Xamarin.Forms;


namespace mori9
{
    public class ItemPage : ContentPage
    {


        public ItemPage(bool isAdd = false )
        {
            
            this.SetBinding(TitleProperty, "Name");
			NavigationPage.SetHasNavigationBar(this, true);

			var nameLabel = new Label { Text = "Name" };
			var nameEntry = new DoneEntry { Keyboard = Keyboard.Text };
			nameEntry.SetBinding(Entry.TextProperty, "Name");

			var imageLabel = new Label { Text = "Image" };
			var imageEntry = new DoneEntry { Keyboard = Keyboard.Text };
			imageEntry.SetBinding(Entry.TextProperty, "Image");

			var quantityLabel = new Label { Text = "Quantity" };
            var quantityEntry = new DoneEntry { Keyboard = Keyboard.Numeric };
			quantityEntry.SetBinding(Entry.TextProperty, "Quantity");

			var categoryLabel = new Label { Text = "Category" };
			Picker catPicker = new Picker{ Title = "Select Category"};
            catPicker.Items.Add("Book");
			catPicker.Items.Add("Food");
			catPicker.Items.Add("IT");
			catPicker.Items.Add("Kitchen");
			catPicker.Items.Add("Tool");
			catPicker.SetBinding( Picker.SelectedItemProperty ,"Category");

            var expiredLabel = new Label { Text = "Expired :" };
            DatePicker expiredPicker = new DatePicker
            {
                Format = "D",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                MinimumDate = DateTime.Today,  
                MaximumDate = DateTime.Today.AddDays(30)

			};
            expiredPicker.SetBinding(DatePicker.DateProperty, "ExpiredDate");

			#region button
			string saveBtn = !isAdd ? "Save" : "Add" ;

                
            var saveButton = new Button { Text = saveBtn };
			saveButton.Clicked += async (sender, e) =>
			{
                var myItem = (Models.Inventory)BindingContext;

				DynamoDBOperationConfig config = new DynamoDBOperationConfig
				{
					IgnoreNullValues = false
				};

                // Check for new item
                if (string.IsNullOrEmpty(myItem.Id))
				{
                    // get userId 
					var userId = await Utils.AmazonUtils.Credentials.GetIdentityIdAsync();
					
                    // get random id
                    var id = Guid.NewGuid().ToString();

                    myItem.Id = id;
					myItem.UserId = userId;
				}

                await Utils.AmazonUtils.DDBContext.SaveAsync<Models.Inventory>(myItem, config);
				Navigation.PopAsync();
			};

			var deleteButton = new Button { Text = "Delete", BorderColor = Color.Red, BorderRadius = 2 };
			deleteButton.Clicked += async (sender, e) =>
			{
				var myItem = (Models.Inventory)BindingContext;
                if (!string.IsNullOrEmpty(myItem.Id))
				{
					await Utils.AmazonUtils.DDBContext.DeleteAsync<Models.Inventory>(myItem);
				}

				Navigation.PopAsync();
			};

			var cancelButton = new Button { Text = "Cancel", BorderColor = Color.Gray, BorderRadius = 2 };
			cancelButton.Clicked += (sender, e) =>
			{
				Navigation.PopAsync();
			};
			#endregion button



			var scroll = new ScrollView();
            scroll.BackgroundColor = Color.Gray;
            Content = scroll;

			var layout = new StackLayout();

			layout.VerticalOptions = LayoutOptions.StartAndExpand;
			layout.Padding = new Thickness(20);

			layout.Children.Add(nameLabel);
			layout.Children.Add(nameEntry);

			layout.Children.Add(imageLabel);
			layout.Children.Add(imageEntry);

			layout.Children.Add(quantityLabel);
			layout.Children.Add(quantityEntry);

            layout.Children.Add(categoryLabel);
            layout.Children.Add(catPicker);

			layout.Children.Add(expiredLabel);
			layout.Children.Add(expiredPicker);

            layout.Children.Add(saveButton);

            if (!isAdd) layout.Children.Add(deleteButton);

			layout.Children.Add(cancelButton);

            scroll.Content = layout;

        }
    }
}

