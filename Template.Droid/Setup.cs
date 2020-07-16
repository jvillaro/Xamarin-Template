using Android.App;
using MvvmCross.Forms.Platforms.Android.Core;

#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif

namespace Template.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.MvxApp, Core.App>
    {
    }
}