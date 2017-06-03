using Amazon.DynamoDBv2.DataModel;

using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace mori9
{
    public partial class ItemListPage : ContentPage
    {
        ListView listView;

        public ItemListPage()
        {
            InitializeComponent();

            Title = "My Inventory";

			NavigationPage.SetHasNavigationBar(this, true);

			listView = new ListView
			{
				RowHeight = 60,
				ItemTemplate = new DataTemplate(typeof(ItemCell))
			};

			listView.ItemSelected += (sender, e) =>
					  {
						  var myItem = (Models.Inventory)e.SelectedItem;
						  var itemPage = new ItemPage();
						  itemPage.BindingContext = myItem;
						  Navigation.PushAsync(itemPage);
					  };

			var layout = new StackLayout();

			layout.Children.Add(listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;

			ToolbarItem tbi = null;
            if ( Device.RuntimePlatform == Device.iOS)
			{
				tbi = new ToolbarItem("+", null, () =>
				{
                    var myItem = new   Models.Inventory();
                    bool isAdd = true;
					var itemPage = new ItemPage(isAdd);
					itemPage.BindingContext = myItem;
					Navigation.PushAsync(itemPage);
				}, 0, 0);
			}
			if (Device.RuntimePlatform == Device.Android)
			{
				tbi = new ToolbarItem("+", "plus", () =>
				{
                  var myItem = new Models.Inventory();
					var itemPage = new ItemPage();
					itemPage.BindingContext = myItem;
					Navigation.PushAsync(itemPage);
				}, 0, 0);
			}

			ToolbarItems.Add(tbi);
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			LoadItems().ContinueWith(task =>
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					listView.ItemsSource = task.Result;
				});
			});
		}

        Task<List<Models.Inventory>> LoadItems()
		{
			var context = Utils.AmazonUtils.DDBContext;
			List<ScanCondition> conditions = new List<ScanCondition>();
			var search = context.ScanAsync<Models.Inventory>(conditions);
			return search.GetNextSetAsync();
		}

	}
}
