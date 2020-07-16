#region --- usings ---

using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Template.Core.ViewModels;
using Xamarin.Forms.Xaml;

#endregion

namespace Template.Core.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Master, WrapInNavigationPage = false, Title = "HamburgerMenu Demo")]
    public partial class MenuPage : MvxContentPage<MenuViewModel>
    {
        public MenuPage()
        {
            InitializeComponent();
        }
    }
}