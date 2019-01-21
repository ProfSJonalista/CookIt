using CookIt.Resources.strings;
using CookIt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CookIt.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
        private LanguageService _languageService;
        private string _cultureCode;

		public SettingsPage ()
		{
			InitializeComponent ();

            ChooseLanguageLabel.Text = Strings.ChooseLang;
            EnglishLangLabel.Text = Strings.English;
            PolishLangLabel.Text = Strings.Polish;

            _languageService = new LanguageService();
            _cultureCode = _languageService.GetCultureInfo().ToString();
            UpdateUI(_cultureCode);
		}

        private void UpdateUI(string cultureCode)
        {
            switch (cultureCode)
            {
                case "en":
                    EnglishLangSwitch.IsToggled = true;
                    PolishLangSwitch.IsToggled = false;
                    _cultureCode = "en";
                    break;
                case "pl":
                    EnglishLangSwitch.IsToggled = false;
                    PolishLangSwitch.IsToggled = true;
                    _cultureCode = "pl";
                    break;
            }
        }
    }
}