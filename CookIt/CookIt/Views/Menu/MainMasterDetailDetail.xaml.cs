using CookIt.Resources.strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CookIt.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterDetailDetail : ContentPage
    {
        public MainMasterDetailDetail()
        {
            InitializeComponent();

            RecipeSearchButton.Text = Strings.RecipeSearch;
            ViewAllRecipesButton.Text = Strings.ViewAllRecipes;
        }
        
        //opens new IngredientChoosePage to choose filters
        private async void RecipeSearchButton_ClickedAsync(object sender, EventArgs e) => await Navigation.PushAsync(new IngredientChoosePage());

        //opens new RecipeListViewPage with no filters
        private async void ViewAllRecipes_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new RecipeListViewPage());
    }
}