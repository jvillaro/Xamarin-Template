#region --- using ---

using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;

#endregion

namespace Template.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<MvxFormsIosSetup<Core.MvxApp, Core.UI.App>, Core.MvxApp, Core.UI.App>
    {
        
    }
}


