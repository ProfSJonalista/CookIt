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
    public partial class MainMasterDetail : MasterDetailPage
    {
        public MainMasterDetail()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        //views new DetailPage
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMasterDetailMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(GetDetailPage(item.Id))
            {
                BarBackgroundColor = Color.FromHex("#DB5701"),
                BarTextColor = Color.White
            };

            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

        //returns appropiate Page based on itemId
        private Page GetDetailPage(int itemId)
        {
            switch (itemId)
            {
                case 0:
                    return new MainMasterDetailDetail();
                case 1:
                    return new RecipeListViewPage(true);
                case 2:
                    return new SettingsPage();
                default:
                    return new MainMasterDetailDetail();
            }
        }
    }
}