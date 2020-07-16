#region --- using ---

using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Template.Core.Entities;

#endregion

namespace Template.Core.ViewModels
{
    /// <summary>
    /// Data test viewmodel.
    /// This is just for testing purposes, please delete for an actual app
    /// </summary>
    public class DataTestViewModel : BaseViewModel
    {
        #region --- Variables ---

        private Test selectedTest;
        private ObservableCollection<Test> tests;
        private MvxCommand addTest;
        private MvxCommand removeTest;

        #endregion


        #region --- Properties ---

        public Test SelectedTest 
        { 
            get => selectedTest; 
            set => SetProperty(ref selectedTest, value); 
        }


        public ObservableCollection<Test> Tests 
        {
            get => tests;
            set => SetProperty(ref tests, value);
        }


        public MvxCommand AddTestCommand => addTest ?? (
            addTest = new MvxCommand( () =>
            {
                DataService.AddTest(new Test { Text = string.Format("Test {0}", tests.Count+1) });
                Tests = GetTests();
            }));


        public MvxCommand RemoveTestCommand => removeTest ?? (
            removeTest = new MvxCommand(() =>
            {
                DataService.Delete<Test>(SelectedTest);
                Tests = GetTests();
            }));

        #endregion


        #region --- Constructor ---

        public DataTestViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
        }

        #endregion


        #region --- Initialize ---

        /// <summary>
        /// Initialize the viewmodel
        /// </summary>
        /// <returns></returns>
        public override Task Initialize()
        {
            base.Initialize();

            return Task.Run(() =>
            {
                Tests = GetTests();
            });
        }

        #endregion


        #region --- GetTests ---

        /// <summary>
        /// Get the test from the database
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Test> GetTests() 
        {
            return new ObservableCollection<Test>(DataService.GetTests());
        }

        #endregion
    }
}
