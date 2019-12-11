#region --- usings ---

using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Template.Core.ViewModels;
using Xamarin.Forms.Xaml;

#endregion

namespace Template.Core.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Root, WrapInNavigationPage = false, Title = "MasterDetail Page")]
    public partial class MasterDetailPage : MvxMasterDetailPage<MasterDetailViewModel>
    {
        public MasterDetailPage()
        {
            InitializeComponent();
        }
    }
}