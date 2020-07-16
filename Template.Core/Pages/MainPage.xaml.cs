#region --- usings ---

using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Template.Core.ViewModels;
using Xamarin.Forms.Xaml;

#endregion

namespace Template.Core.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Root, WrapInNavigationPage = false)]
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}