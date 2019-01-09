using CookIt.Resources.strings;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace CookIt
{
	public partial class App : Application
	{
        public static string DatabaseLocation = string.Empty;

		public App ()
		{
			InitializeComponent();

            //TODO - create service to get culture info
            var cultureInfo = new System.Globalization.CultureInfo("pl");
            Strings.Culture = cultureInfo;
            Ingredients.Culture = cultureInfo;
            
			MainPage = new NavigationPage(new MainPage());
		}

        public App(string dbPath)
        {
            InitializeComponent();

            //TODO - create service to get culture info
            var cultureInfo = new System.Globalization.CultureInfo("pl");
            Strings.Culture = cultureInfo;
            Ingredients.Culture = cultureInfo;

            DatabaseLocation = dbPath;

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
