using System;
using System.Collections.Generic;
using Week_04.MenuItems;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Week_04.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        List<MasterPageItem> DropDownMenu = new List<MasterPageItem>();
        public MasterPage()
        {
            InitializeComponent();
            FillMenuList();
            MenuList.ItemsSource = DropDownMenu;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPage)));
        }

        private void FillMenuList()
        {
            DropDownMenu.Add(new MasterPageItem { Icon = "Images/MoviesAndSeries.png", Title = "Movies & Series", TargetType = typeof(MainPage) });
            DropDownMenu.Add(new MasterPageItem { Icon = "Images/Favorite.png", Title = "Favorites", TargetType = typeof(FavoritePage) });
            DropDownMenu.Add(new MasterPageItem { Icon = "Images/AddIcon.png", Title = "Add Movie or Serie", TargetType = typeof(AddPage) });
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = e.SelectedItem as MasterPageItem;
            Detail = new NavigationPage((Page)Activator.CreateInstance(selected.TargetType));
            IsPresented = false;
        }
    }
}