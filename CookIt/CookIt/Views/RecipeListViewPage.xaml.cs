using CookIt.Models.ViewModels;
using CookIt.Resources.strings;
using CookIt.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CookIt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeListViewPage : ContentPage
    {
        public List<RecipeViewModel> Items { get; set; }
        private FilterService _filterService = new FilterService();

        //gets unfiltered recipes
        public RecipeListViewPage()
        {
            InitializeComponent();
            Items = _filterService.GetUnfilteredRecipes();
            MyListView.ItemsSource = Items;
            SetItemVisibility();
        }

        //gets saved for later recipes
        public RecipeListViewPage(bool savedForLater)
        {
            InitializeComponent();
            Items = _filterService.GetSavedForLaterRecipes(savedForLater);
            MyListView.ItemsSource = Items;
            SetItemVisibility();
        }

        //constructor with filter list - gets recipes based on requirements in filterlist
        public RecipeListViewPage(List<IngredientChooseViewModel> filterList)
        {
            InitializeComponent();
            Items = _filterService.GetFilteredRecipes(filterList);
            MyListView.ItemsSource = Items;
            SetItemVisibility();
        }

        //if there is no items in list
        //ListView is hidden and information is shown
        //there is no Recipes on current filter requirements
        private void SetItemVisibility()
        {
            if(Items == null || Items.Count == 0)
            {
                NoRecipeLabel.IsVisible = true;
                NoRecipeLabel.Text = Strings.NoRecipes;

                MyListView.IsVisible = false;
            }
            else
            {
                NoRecipeLabel.IsVisible = false;
                MyListView.IsVisible = true;
            }
        }

        //opens RecipeViewPage
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var recipeToTransfer = (RecipeViewModel)e.Item;
            ((ListView)sender).SelectedItem = null;

            await Navigation.PushAsync(new RecipeViewPage(recipeToTransfer));
        }
    }
}
