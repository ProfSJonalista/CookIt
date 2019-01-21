using CookIt.Resources.strings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CookIt.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterDetailMaster : ContentPage
    {
        public ListView ListView;

        public MainMasterDetailMaster()
        {
            InitializeComponent();

            BindingContext = new MainMasterDetailMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainMasterDetailMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainMasterDetailMenuItem> MenuItems { get; set; }

            public MainMasterDetailMasterViewModel()
            {
                //sets items in hamburger menu
                MenuItems = new ObservableCollection<MainMasterDetailMenuItem>(new[]
                {
                    new MainMasterDetailMenuItem { Id = 0, Title = Strings.MainPage },
                    new MainMasterDetailMenuItem { Id = 1, Title = Strings.Saved },
                    new MainMasterDetailMenuItem { Id = 2, Title = Strings.Settings },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}