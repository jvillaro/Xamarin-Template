#region --- usings ---

using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Plugin.JsonLocalization;
using MvvmCross.ViewModels;
using System.Globalization;
using System.Threading.Tasks;
using Template.Core.Services;
using Template.Core.ViewModels;

#endregion

namespace Template.Core
{
    public class MvxApp : MvxApplication
    {
        /// <summary>
        /// Breaking change in v6: This method is called on a background thread. Use
        /// Startup for any UI bound actions
        /// </summary>
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            var currentCulture = CultureInfo.CreateSpecificCulture("es-UY");
            CultureInfo.DefaultThreadCurrentCulture = currentCulture;

            RegisterAppStart<MainViewModel>();
            InitializeTextProvider();
        }

        /// <summary>
        /// Do any UI bound startup actions here
        /// </summary>
        public override Task Startup()
        {
            return base.Startup();
        }

        /// <summary>
        /// If the application is restarted (eg primary activity on Android
        /// can be restarted) this method will be called before Startup
        /// is called again
        /// </summary>
        public override void Reset()
        {
            base.Reset();
        }


        /// <summary>
        /// Initializes the localization provider
        /// </summary>
        private void InitializeTextProvider()
        {
            var builder = new TextProviderBuilder();
            Mvx.IoCProvider.RegisterSingleton<IMvxTextProviderBuilder>(builder);
            Mvx.IoCProvider.RegisterSingleton(builder.TextProvider);
        }
    }
}
