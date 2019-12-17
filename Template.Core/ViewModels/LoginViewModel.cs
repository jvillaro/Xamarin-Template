#region --- usings ---

using MvvmCross.Logging;
using MvvmCross.Navigation;

#endregion

namespace Template.Core.ViewModels
{
    /// <summary>
    /// Login view model
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region --- Constructor ---

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
        }

        #endregion
    }
}
