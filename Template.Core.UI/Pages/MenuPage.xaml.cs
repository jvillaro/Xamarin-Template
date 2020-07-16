#region --- usings ---

using MvvmCross.Forms.Presenters.Attributes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#endregion

namespace Template.Core.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Master)]
    public partial class MenuPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Hides the master page when an item is clicked
        /// </summary>
        public void ItemTapped(object sender, EventArgs e)
        {
            if (Parent is MasterDetailPage md)
            {
                md.MasterBehavior = MasterBehavior.Popover;
                md.IsPresented = !md.IsPresented;
            }
        }
    }
}