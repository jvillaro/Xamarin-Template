#region --- usings ---

using MvvmCross.Logging;
using MvvmCross.Navigation;

#endregion

namespace Template.Core.ViewModels
{
    /// <summary>
    /// Root empty ViewModel for the AppCompact Activity
    /// </summary>
    public class StartUpViewModel : BaseViewModel
    {
        ///// <summary>
        ///// Gets by DI the required services
        ///// </summary>
        public StartUpViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
        }
    }
}
