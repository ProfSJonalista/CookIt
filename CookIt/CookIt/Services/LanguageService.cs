using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CookIt.Services
{
    public class LanguageService
    {
        //returns current CultureInfo
        public CultureInfo GetCultureInfo()
        {
            string cultureInfoCode;

            if (App.Current.Properties.ContainsKey("cultureInfoId"))
            {
                cultureInfoCode = (string)App.Current.Properties["cultureInfoId"];
            }
            else
            {
                cultureInfoCode = "en";
            }

            return new CultureInfo(cultureInfoCode);
        }

        public void SetNewCultureInfo(string cultureInfoCode)
        {
            App.Current.Properties["cultureInfoId"] = cultureInfoCode;
        }
    }
}
