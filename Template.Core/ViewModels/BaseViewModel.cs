#region --- usings ---

using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Template.Core.Interfaces;
using Template.Core.Services;

#endregion

namespace Template.Core.ViewModels
{
    /// <summary>
    /// Base view model 
    /// </summary>
    public class BaseViewModel : MvxViewModel
    {
        #region --- Variables ---

        private bool isBusy;

        #endregion


        #region --- Properties ---

        public string Title { get; set; }

        public IPlatformService PlatformService { get; }

        public IDataService DataService { get; }

        public IMvxNavigationService NavigationService { get; }
        
        /// <summary>
        /// Indicates if the viewmodel is busy
        /// </summary>
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                RaisePropertyChanged(() => IsBusy);
                RaisePropertyChanged(() => IsEnabled);
            }
        }

        
        /// <summary>
        /// Indicates if the viewmodel is enabled
        /// IsBusy = true => IsEnabled = false
        /// </summary>
        public bool IsEnabled
        {
            get => !isBusy;
            set
            {
                isBusy = !value;
                RaisePropertyChanged(() => IsEnabled);
                RaisePropertyChanged(() => IsBusy);
            }
        }
        
        #endregion


        #region --- Constructor ---

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseViewModel()
        {
            Title = "Title";

            NavigationService = Mvx.IoCProvider.GetSingleton<IMvxNavigationService>();
            PlatformService = Mvx.IoCProvider.GetSingleton<IPlatformService>();
            DataService = new DataService();
        }

        #endregion
    }
}
