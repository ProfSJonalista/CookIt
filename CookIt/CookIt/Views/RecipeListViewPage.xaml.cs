using CookIt.Models.ViewModels;
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

        public RecipeListViewPage()
        {
            InitializeComponent();
            Items = _filterService.GetUnfilteredRecipes();
            MyListView.ItemsSource = Items;
        }

        public RecipeListViewPage(bool userFavorite)
        {
            InitializeComponent();
            Items = _filterService.GetFilteredRecipes(userFavorite);
            MyListView.ItemsSource = Items;
        }

        public RecipeListViewPage(List<IngredientChooseViewModel> filterList)
        {
            InitializeComponent();
            Items = _filterService.GetFilteredRecipes(filterList);
            MyListView.ItemsSource = Items;
        }

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
