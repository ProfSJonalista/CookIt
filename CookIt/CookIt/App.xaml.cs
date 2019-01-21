using CookIt.Resources.strings;
using CookIt.Services;
using CookIt.Views.Menu;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CookIt
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        private DatabaseInitiateService _databaseInitiateService = new DatabaseInitiateService();
        private LanguageService _languageService = new LanguageService();

        public App()
        {
            InitializeComponent();
            
            var cultureInfo = _languageService.GetCultureInfo();
            Strings.Culture = cultureInfo;
            Ingredients.Culture = cultureInfo;

            MainPage = new MainMasterDetail();
        }

        public App(string dbPath)
        {
            InitializeComponent();

            var cultureInfo = _languageService.GetCultureInfo();
            Strings.Culture = cultureInfo;
            Ingredients.Culture = cultureInfo;

            DatabaseLocation = dbPath;

            _databaseInitiateService.SetDatabase();

            MainPage = new MainMasterDetail();
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
