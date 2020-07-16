#region --- usings ---

using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Template.Core.ViewModels;
using Xamarin.Forms.Xaml;

#endregion

namespace Template.Core.Pages
{
    /// <summary>
    /// Home view 
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Home")]
    public partial class HomePage : MvxContentPage<HomeViewModel>
    {
        public HomePage()
        {
            InitializeComponent();
        }
    }
}