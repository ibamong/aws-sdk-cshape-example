﻿
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using System.Drawing;
using mori9;
using mori9.iOS;

[assembly: ExportRenderer(typeof(DoneEntry), typeof(DoneEntryRenderer))]
namespace mori9.iOS
{
	public class DoneEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			var toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, (float)Control.Frame.Size.Width, 44.0f));

			toolbar.Items = new[]
			{
				new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
				new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate { Control.ResignFirstResponder(); })
			};

			this.Control.InputAccessoryView = toolbar;
		}
	}
}
