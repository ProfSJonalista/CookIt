using CookIt.Resources.strings;
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
        public MainPage()
		{
			InitializeComponent();
            RecipeSearchButton.Text = AppResources.RecipeSearch;
            ViewAllRecipesButton.Text = AppResources.ViewAllRecipes;
		}

        private void RecipeSearchButton_Clicked(object sender, EventArgs e)
        {

        }

        private void ViewAllRecipes_Clicked(object sender, EventArgs e)
        {

        }
    }
}
