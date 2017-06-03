using Xamarin.Forms;
using System;

namespace mori9
{
    public partial class App : Application
    {
        public NavigationPage NavPage { get; set; }

		public static Action<string> OnFacebookAuthSuccess;
		public static Action OnFacebookAuthFailed;

        public App()
        {
            InitializeComponent();

			NavPage = new NavigationPage(new ItemListPage());

			MainPage = NavPage;
        }

		public void UpdateMainPage(ContentPage page)
		{
			NavPage = new NavigationPage(page);
			MainPage = NavPage;
		}

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
