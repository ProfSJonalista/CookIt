using CookIt.Models.ViewModels;
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
	public partial class RecipeViewPage : ContentPage
	{
        private RecipeViewModel Recipe;
        private RecipeService _recipeService;
		public RecipeViewPage (RecipeViewModel recipe)
		{
			InitializeComponent();

            Recipe = recipe;
            SetupUI();
            _recipeService = new RecipeService();

            BindingContext = Recipe;
        }

        private void SetupUI()
        {
            PreperationTimeLabel.Text = Strings.PreparationTime + " " + Recipe.PreparationTime;
            NoOfPortionsLabel.Text = Strings.NoOfPortions + " " + Recipe.NoOfPortions;
            IngredientsLabel.Text = Strings.Ingredient;
            CookButton.Text = Strings.Cook;
            SaveButton.Text = Strings.SaveForLater;
            ClearAllButton.Text = Strings.ClearAll;
        }

        private void IngredientListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            
            ((ListView)sender).SelectedItem = null;
        }

        private async void CookButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new StepViewPage(Recipe.Steps));

        //TODO - refresh view
        private void ClearAllButton_Clicked(object sender, EventArgs e)
        {
            Recipe.Ingredients.ForEach(x => x.ForLater = false);

            BindingContext = Recipe;

            _recipeService.SaveIngredientsForLater(Recipe);
        }

        private void SaveButton_Clicked(object sender, EventArgs e) =>_recipeService.SaveIngredientsForLater(Recipe);
    }
}