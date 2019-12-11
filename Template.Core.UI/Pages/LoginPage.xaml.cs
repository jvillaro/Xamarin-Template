#region --- usings ---

using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Template.Core.ViewModels;
using Xamarin.Forms.Xaml;

#endregion

namespace Template.Core.UI.Pages
{
    /// <summary>
    /// Login page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Login")]
    public partial class LoginPage : MvxContentPage<LoginViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}