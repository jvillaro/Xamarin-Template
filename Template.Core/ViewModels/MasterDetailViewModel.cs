#region --- usings ---



#endregion

namespace Template.Core.ViewModels
{
    /// <summary>
    /// Master detail viewmodel
    /// </summary>
    public class MasterDetailViewModel : BaseViewModel
    {
        #region --- ViewAppearing ---

        /// <summary>
        /// View appearing
        /// </summary>
        public override async void ViewAppearing()
        {
            base.ViewAppearing();

            await NavigationService.Navigate<MenuViewModel>();
            await NavigationService.Navigate<HomeViewModel>();
        }

        #endregion
    }
}
