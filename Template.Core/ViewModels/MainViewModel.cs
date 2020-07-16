#region --- usings ---

using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

#endregion

namespace Template.Core.ViewModels
{
    /// <summary>
    /// Main viewmodel
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region --- Variables ---

        private bool viewAppeared;

        #endregion


        #region --- Constructor ---

        /// <summary>
        /// Gets by DI the required services
        /// </summary>
        public MainViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
        }

        #endregion


        #region --- ViewAppearing ---

        /// <summary>
        /// View appearing
        /// </summary>
        public override void ViewAppeared()
        {
            if (viewAppeared) return;
            MvxNotifyTask.Create(async () =>
            {
                this.viewAppeared = true;
                await NavigationService.Navigate<MenuViewModel>();
                await NavigationService.Navigate<HomeViewModel>();
            });
        }

        #endregion
    }
}
