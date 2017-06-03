using System;

using Xamarin.Forms;

namespace mori9
{
    public class ItemCell : ViewCell
    {
        public ItemCell()
        {

			var label = new Label
			{
                VerticalTextAlignment = TextAlignment.Center
			};

			label.SetBinding(Label.TextProperty, "Name");

			var layout = new StackLayout
			{
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { label }
			};

			View = layout;            
        }

		protected override void OnBindingContextChanged()
		{
			View.BindingContext = BindingContext;
			base.OnBindingContextChanged();
		}
    }
}
