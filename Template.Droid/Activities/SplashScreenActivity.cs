#region --- using ---

using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using System.Threading.Tasks;

#endregion

namespace Template.Droid.Activities
{
    /// <summary>
    /// Splash screen
    /// </summary>
    [Activity(
        Label = "@string/AppName"
        , Icon = "@mipmap/ic_launcher"
        , Theme = "@style/Theme.Splash"
        , MainLauncher = true
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreenActivity : MvxFormsSplashScreenActivity<Setup, Core.App, Core.UI.App>
    {
        /// <summary>
        /// Starts the main activity
        /// </summary>  
        protected override Task RunAppStartAsync(Bundle bundle)
        {
            StartActivity(typeof(MainActivity));
            return base.RunAppStartAsync(bundle);
        }
    }
}