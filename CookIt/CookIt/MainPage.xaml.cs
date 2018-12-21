using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CookIt
{
	public partial class MainPage : ContentPage
	{
        int i = 0;

		public MainPage()
		{
			InitializeComponent();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            string text = string.Empty;
            switch (i)
            {
                case 0:
                    text = i.ToString();
                    i = 1;
                    break;
                case 1:
                    text = i.ToString();
                    i = 0;
                    break;
            }

            MainLabel.Text = text;
        }
    }
}
