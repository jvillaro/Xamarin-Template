#region --- usings ---

using MvvmCross;
using MvvmCross.Localization;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.Plugin.JsonLocalization;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;
using Template.Core.Interfaces;
using Template.Core.Services;

#endregion

namespace Template.Core.ViewModels
{
    /// <summary>
    /// Base view model 
    /// </summary>
    public class BaseViewModel : MvxNavigationViewModel
    {
        #region --- Variables ---

        private bool isBusy;
        private readonly IMvxTextProviderBuilder textProviderBuilder;

        #endregion


        #region --- Properties ---

        /// <summary>
        /// Page title
        /// </summary>
        public string Title { get; set; }


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


        /// <summary>
        /// Data service
        /// </summary>
        public IDataService DataService { get; }


        /// <summary>
        /// Platform service
        /// </summary>
        public IPlatformService PlatformService { get; }


        /// <summary>
        /// Current messenger service
        /// </summary>
        protected IMvxMessenger MessengerService { get; }


        /// <summary>
        /// Notification service
        /// </summary>
        protected INotificationService NotificationService { get; }


        /// <summary>
        /// Source for localized texts
        /// </summary>
        public IMvxLanguageBinder TextSource =>
            new MvxLanguageBinder(TextProviderConstants.GeneralNamespace, TextProviderConstants.ClassName);

        #endregion


        #region --- Constructor ---

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
            this.isBusy = false;
            this.DataService = Mvx.IoCProvider.GetSingleton<IDataService>();
            this.textProviderBuilder = Mvx.IoCProvider.GetSingleton<IMvxTextProviderBuilder>();
            this.MessengerService = Mvx.IoCProvider.GetSingleton<IMvxMessenger>();
            this.PlatformService = Mvx.IoCProvider.GetSingleton<IPlatformService>();
            this.NotificationService = Mvx.IoCProvider.GetSingleton<INotificationService>();
        }

        #endregion


        #region --- GetText ---

        /// <summary>
        /// Helper method for getting a localized text
        /// </summary>
        /// <param name="text">Text to get</param>
        /// <returns>Localized text</returns>
        public string GetText(string text)
        {
            var outText = this.textProviderBuilder.TextProvider.GetText(
                TextProviderConstants.GeneralNamespace, TextProviderConstants.ClassName, text);

            return outText;
        }

        #endregion


        #region --- FromDate ---

        /// <summary>
        /// Converts a DateTime into a TimeSpan
        /// </summary>
        public static TimeSpan FromDate(DateTime date)
        {
            return new TimeSpan(date.Hour, date.Minute, date.Second);
        }

        #endregion


        #region --- FromTimeSpan ---

        /// <summary>
        /// Converts a TimeStan into a DateTime
        /// </summary>
        public static DateTime FromTimeSpan(TimeSpan timespan)
        {
            return new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, timespan.Hours,
                timespan.Minutes, timespan.Seconds);
        }

        #endregion
    }


    /// <summary>
    /// Base ViewModel with parameters
    /// </summary>
    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter> where TParameter : class
    {
        protected BaseViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
        }

        /// <summary>
        /// Called with the ViewModel's parameters
        /// </summary>
        public abstract void Prepare(TParameter parameter);
    }


    /// <summary>
    /// Base ViewModel with parameters and result
    /// </summary>
    public abstract class BaseViewModel<TParameter, TResult> : BaseViewModel, IMvxViewModel<TParameter, TResult>
        where TParameter : class
        where TResult : class
    {
        protected BaseViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
        }

        /// <summary>
        /// Called with the ViewModel's parameters
        /// </summary>
        public abstract void Prepare(TParameter parameter);

        public TaskCompletionSource<object> CloseCompletionSource { get; set; }
    }


    /// <summary>
    /// Base ViewModel with result
    /// </summary>
    public abstract class BaseViewModelResult<TResult> : BaseViewModel, IMvxViewModelResult<TResult>
        where TResult : class
    {
        protected BaseViewModelResult(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
        }

        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (viewFinishing && CloseCompletionSource != null && !CloseCompletionSource.Task.IsCompleted && !CloseCompletionSource.Task.IsFaulted)
                CloseCompletionSource?.TrySetCanceled();

            base.ViewDestroy(viewFinishing);
        }
    }
}
