#region --- using ---

using MvvmCross.Commands;
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
            addTest = new MvxCommand(async () =>
            {
                await DataService.AddTestAsync(new Test { Text = string.Format("Test {0}", tests.Count+1) });
                Tests = await GetTests();
            }));


        public MvxCommand RemoveTestCommand => removeTest ?? (
            removeTest = new MvxCommand(async () =>
            {
                await DataService.DeleteAsync<Test>(SelectedTest);
                Tests = await GetTests();
            }));

        #endregion


        #region --- Initialize ---

        /// <summary>
        /// Initialize the viewmodel
        /// </summary>
        /// <returns></returns>
        public override Task Initialize()
        {
            base.Initialize();

            return Task.Run(async () =>
            {
                Tests = await GetTests();
            });
        }

        #endregion


        #region --- GetTests ---

        /// <summary>
        /// Get the test from the database
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<Test>> GetTests() 
        {
            return new ObservableCollection<Test>(await DataService.GetTestsAsync());
        }

        #endregion
    }
}
