#region --- using ---

using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Platforms.Android.Views;
using System.Threading.Tasks;

#endregion

namespace Template.Droid.Activities
{
    /// <summary>
    /// Splash screen
    /// </summary>
    [Activity(
        Label = "@string/app_name"
        , Icon = "@mipmap/ic_launcher"
        , Theme = "@style/AppTheme.Splash"
        , MainLauncher = true
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreenActivity : MvxFormsSplashScreenActivity<Setup, Core.App, Core.UI.App>
    {
        protected override Task RunAppStartAsync(Bundle bundle)
        {
            StartActivity(typeof(MainActivity));
            return Task.CompletedTask;
        }
    }
}