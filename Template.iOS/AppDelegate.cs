#region --- using ---

using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;

#endregion

namespace Template.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<MvxFormsIosSetup<Core.App, Core.UI.App>, Core.App, Core.UI.App>
    {
        
    }
}


