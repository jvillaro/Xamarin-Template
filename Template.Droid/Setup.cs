#region --- usings --- 

using Android.App;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Presenters;
using MvvmCross.Logging;
using Template.Core.Interfaces;
using Template.Droid.Services;

#endregion

#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif

namespace Template.Droid
{
    /// <summary>
    /// Android setup class
    /// </summary>
    public class Setup : MvxFormsAndroidSetup<Core.App, Core.UI.App>
    {
        /// <summary>
        /// Sets the log provider
        /// </summary>
        /// <returns></returns>
        public override MvxLogProviderType GetDefaultLogProviderType() => MvxLogProviderType.Console;


        /// <summary>
        /// Register the form presenter (MvvmCross)
        /// </summary>        
        protected override IMvxFormsPagePresenter CreateFormsPagePresenter(IMvxFormsViewPresenter viewPresenter)
        {
            var formsPresenter = base.CreateFormsPagePresenter(viewPresenter);
            Mvx.IoCProvider.RegisterSingleton(formsPresenter);
            return formsPresenter;
        }


        /// <summary>
        /// Initializes the platform services
        /// </summary>
        protected override void InitializeFirstChance()
        {
            Mvx.IoCProvider.RegisterSingleton<IPlatformService>(new PlatformService());
            base.InitializeFirstChance();
        }
    }
}