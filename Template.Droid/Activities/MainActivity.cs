#region --- usings ---

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using MvvmCross.Forms.Platforms.Android.Views;
using System.Globalization;
using System.Threading;
using Template.Core.ViewModels;

#endregion

namespace Template.Droid.Activities
{
    /// <summary>
    /// Main activity
    /// </summary>
    [Activity(
        Label = "@string/AppName",
        Icon = "@mipmap/ic_launcher",
        Theme = "@style/AppTheme",
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        LaunchMode = LaunchMode.SingleTask)]
    public class MainActivity : MvxFormsAppCompatActivity<StartUpViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Xamarin.Essentials.Platform.Init(this, bundle);
        }


        /// <summary>
        /// Forms and plug ins initialization
        /// </summary>        
        public override void InitializeForms(Bundle bundle)
        {
            base.InitializeForms(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        /// <summary>
        /// OnResume
        /// Forces the culture to es-UY
        /// </summary>
        protected override void OnResume()
        {
            var selectedCulture = new CultureInfo("es-UY");
            Thread.CurrentThread.CurrentCulture = selectedCulture;
            base.OnResume();
        }
    }
}