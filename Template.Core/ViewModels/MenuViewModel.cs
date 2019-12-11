#region --- using ---

using MvvmCross.Commands;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Template.Core.Enums;
using Template.Core.Models;

#endregion

namespace Template.Core.ViewModels
{
    /// <summary>
    /// Menu viewmodel
    /// </summary>
    public class MenuViewModel : BaseViewModel
    {
        #region --- Variables ---

        private ObservableCollection<MenuItem> menuItems;
        private MenuItem selectedMenuItem;

        #endregion


        #region --- Properties ---

        /// <summary>
        /// Collection of menu items
        /// </summary>
        public ObservableCollection<MenuItem> MenuItems
        {
            get => menuItems;
            set => SetProperty(ref menuItems, value);
        }

        
        /// <summary>
        /// Selected menu item
        /// </summary>
        public MenuItem SelectedMenuItem
        {
            get => selectedMenuItem;
            set 
            {
                SetProperty(ref selectedMenuItem, value);
                Task.Run(async () => await MenuItemActionAsync());
            }
        }

        #endregion
                

        #region --- Initialize ---

        /// <summary>
        /// Initialize the viewmodel
        /// </summary>
        /// <returns></returns>
        public override Task Initialize()
        {
            return Task.Run( () => 
            {
                MenuItems = new ObservableCollection<MenuItem>
                {
                    new MenuItem
                    {
                        Key = MenuItemKey.Home,
                        Name = "Home",
                        Description = "Go to home",
                        Icon = ""
                    },
                    new MenuItem
                    {
                        Key = MenuItemKey.DataTests,
                        Name = "Data Tests",
                        Description = "Test data",
                        Icon = ""
                    },
                    new MenuItem
                    {
                        Key = MenuItemKey.Logout,
                        Name = "Log out",
                        Description = "Log out of the app",
                        Icon = ""
                    }
                };
            });
        }

        #endregion


        #region --- MenuItemActionAsync ---

        /// <summary>
        /// Actions to execute when a menu item is selected
        /// </summary>
        /// <returns></returns>
        private async Task MenuItemActionAsync()
        {
            switch (SelectedMenuItem.Key)
            {
                case MenuItemKey.Home:
                    await NavigationService.Navigate<HomeViewModel>();
                    break;
                case MenuItemKey.DataTests:
                    await NavigationService.Navigate<DataTestViewModel>();
                    break;
                case MenuItemKey.Logout:
                    await NavigationService.Navigate<LoginViewModel>();
                    //await ShowConfirmationAsync("Confirmación", "¿Desea cerrar sesión?", async result =>
                    //{
                    //    if (result)
                    //    {
                    //        await LogOutUser();
                    //    }
                    //});
                    break;
                default:
                    break;
            }

            if (Xamarin.Forms.Application.Current.MainPage is Xamarin.Forms.MasterDetailPage masterDetailPage)
            {
                masterDetailPage.IsPresented = false;
            }
            else if (Xamarin.Forms.Application.Current.MainPage is Xamarin.Forms.NavigationPage navigationPage
                     && navigationPage.CurrentPage is Xamarin.Forms.MasterDetailPage nestedMasterDetail)
            {
                nestedMasterDetail.IsPresented = false;
            }
        }

        #endregion
    }
}
