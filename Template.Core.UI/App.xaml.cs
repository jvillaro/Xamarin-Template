#region ---usings ---

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Template.Core.Constants;
using Xamarin.Forms;

#endregion

namespace Template.Core.UI
{
    /// <summary>
    /// Application start
    /// </summary>
    public partial class App : Application
    {
        #region --- Constructor ---

        /// <summary>
        /// Constructor
        /// </summary>
        public App()
        {
            InitializeComponent();

            Xamarin.Essentials.VersionTracking.Track();
        }

        #endregion


        #region --- OnStart ---

        /// <summary>
        /// On start
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();

            // Enabling use of App Center to track crashes and analytics
            AppCenter.Start(AppEnvironment.AppCenterAndroidId + AppEnvironment.AppCenteriOSId,
                    typeof(Analytics), typeof(Crashes));
        }

        #endregion
    }
}