using CookIt.Models.ViewModels;
using CookIt.Resources.strings;
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
	public partial class RecipeViewPage : ContentPage
	{
        private RecipeViewModel Recipe;

		public RecipeViewPage (RecipeViewModel recipe)
		{
			InitializeComponent();

            Recipe = recipe;
            IngredientsLabel.Text = Strings.Ingredient;
            PreperationTimeLabel.Text = Strings.PreparationTime + " " + Recipe.PreparationTime;
            NoOfPortionsLabel.Text = Strings.NoOfPortions + " " + Recipe.NoOfPortions;
            CookButton.Text = Strings.Cook;

            BindingContext = Recipe;
        }

        private void IngredientListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            
            ((ListView)sender).SelectedItem = null;
        }

        private async void CookButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new StepViewPage(Recipe.Steps));
    }
}