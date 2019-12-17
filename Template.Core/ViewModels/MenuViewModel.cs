#region --- using ---

using MobileTemplate.Core.Messages;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Template.Core.Enums;
using Template.Core.Messages;
using Template.Core.Models;
using Template.Models;

#endregion

namespace Template.Core.ViewModels
{
    /// <summary>
    /// Menu viewmodel
    /// </summary>
    public class MenuViewModel : BaseViewModel
    {
        #region --- Variables ---

        private MenuItem selectedMenuItem;
        private MvxSubscriptionToken userUpdatedSubscriptionToken;

        #endregion


        #region --- Properties ---

        /// <summary>
        /// User
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Collection of menu items
        /// </summary>
        public ObservableCollection<MenuItem> MenuItems { get; set; }

        
        /// <summary>
        /// Selected menu item
        /// </summary>
        public MenuItem SelectedMenuItem
        {
            get => selectedMenuItem;
            set 
            {
                this.selectedMenuItem = value;
                if (value?.Command == null) return;
                this.selectedMenuItem = null;
                RaisePropertyChanged(() => SelectedMenuItem);
                value.Command.Execute(null);
            }
        }

        #endregion


        #region --- Prepare ---

        /// <summary>
        /// Prepares the local variables
        /// </summary>
        public override void Prepare()
        {
            SubscribeToUserUpdatedMessage();
            this.MenuItems = new ObservableCollection<MenuItem>();
        }

        #endregion


        #region --- Constructor ---

        /// <summary>
        /// Gets by DI the required services
        /// </summary>
        public MenuViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
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
                        Name = "Home",
                        //Name = GetText("Home"),
                        Description = string.Empty,
                        Icon = "",
                        Command = new MvxCommand(async () =>
                        {
                            if (!IsBusy)
                            {
                                await NavigationService.Navigate<HomeViewModel>();
                            }
                        })
                    },
                    new MenuItem
                    {
                        Name = "DataTests",
                        Description = string.Empty,
                        Icon = "",
                        Command = new MvxCommand(async () =>
                        {
                            if (!IsBusy)
                            {
                                await NavigationService.Navigate<DataTestViewModel>();
                            }
                        })
                    },
                    new MenuItem
                    {
                        Name = "Logout",
                        Description = string.Empty,
                        Icon = "",
                        Command = new MvxCommand(async () =>
                        {
                            if (!IsBusy)
                            {
                                await NotificationService.ConfirmAsync("Confirmación", "¿Desea cerrar sesión?", "Si", "No",async result =>
                                {
                                    if (result)
                                    {
                                        await NavigationService.Navigate<LoginViewModel>();
                                    }
                                });
                            }
                        })
                    }
                };
            });
        }

        #endregion


        #region --- SubscribeToUserUpdatedMessage ---

        /// <summary>
        /// Subscribes the viewmodel to handle theme updated messages 
        /// </summary>
        public void SubscribeToUserUpdatedMessage()
        {
            this.userUpdatedSubscriptionToken = this.MessengerService.Subscribe<UserUpdatedMessage>(message =>
            {
                this.User = message.User;
                RaisePropertyChanged(() => this.User);
            });
        }

        #endregion


        #region --- Release ---

        /// <summary>
        /// Release the inner objects
        /// </summary>
        public void Release()
        {
            if (userUpdatedSubscriptionToken == null) return;
            this.MessengerService.Unsubscribe<UserAuthenticatedMessage>(userUpdatedSubscriptionToken);
            this.userUpdatedSubscriptionToken = null;
        }

        #endregion
    }
}
