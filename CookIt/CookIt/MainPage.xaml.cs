using CookIt.Resources.strings;
using CookIt.Views;
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
            
            RecipeSearchButton.Text = Strings.RecipeSearch;
            ViewAllRecipesButton.Text = Strings.ViewAllRecipes;
		}

        private async void RecipeSearchButton_ClickedAsync(object sender, EventArgs e) => await Navigation.PushAsync(new IngredientChoosePage());


        private void ViewAllRecipes_Clicked(object sender, EventArgs e)
        {

        }
    }
}
