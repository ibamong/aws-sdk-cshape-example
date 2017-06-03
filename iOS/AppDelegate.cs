using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Xamarin.Forms;
using mori9;

namespace mori9.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private UIWindow _window;
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            _window = new UIWindow(UIScreen.MainScreen.Bounds);
            LoadApplication(new App());

            //base.FinishedLaunching(app, options);

            //return ApplicationDelegate.SharedInstance.FinishedLaunching(app, options);
            return base.FinishedLaunching(app, options);
        }

    }
}
