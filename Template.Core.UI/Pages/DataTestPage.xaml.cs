using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Template.Core.UI.Pages
{
    /// <summary>
    /// Home view 
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Detail, NoHistory = true, Title = "Tests")]
    public partial class DataTestPage : MvxContentPage<DataTestViewModel>
    {
        public DataTestPage()
        {
            InitializeComponent();
        }
    }
}