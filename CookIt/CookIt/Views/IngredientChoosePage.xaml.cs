using CookIt.Models.ViewModels;
using CookIt.Resources.strings;
using CookIt.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CookIt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientChoosePage : ContentPage
    {
        private IngredientService ingredientService;

        public List<IngredientChooseViewModel> IngredientList { get; set; }

        public IngredientChoosePage()
        {
            InitializeComponent();

            SetComponents();

            ingredientService = new IngredientService();
            IngredientList = ingredientService.GetIngredientList();
			MyListView.ItemsSource = IngredientList;
        }

        //sets text on UI controls
        private void SetComponents()
        {
            ChooseIngredientsLabel.Text = Strings.ChooseIngredients;
            SearchButton.Text = Strings.Search;
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        //opens new RecipeListViewPage
        private async void SearchButton_Clicked(object sender, EventArgs e) => 
            await Navigation.PushAsync(
                new RecipeListViewPage(
                    IngredientList.Where(x => x.Filter == true).ToList()));
    }
}
