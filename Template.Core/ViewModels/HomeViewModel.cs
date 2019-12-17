#region --- usings ---

using MvvmCross.Logging;
using MvvmCross.Navigation;

#endregion

namespace Template.Core.ViewModels
{
    /// <summary>
    /// Initial view model to show
    /// </summary>
    public class HomeViewModel : BaseViewModel
    {
        #region --- Constructor ---

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
        }

        #endregion
    }
}
