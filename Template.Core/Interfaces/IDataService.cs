#region --- using ---

using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Core.Entities;

#endregion

namespace Template.Core.Interfaces
{
    /// <summary>
    /// Data Service interface
    /// </summary>
    public interface IDataService
    {
        Task<int> InsertAsync(object item);


        Task<int> InsertOrReplace(object item);


        Task<int> InsertAllAsync(IEnumerable<object> items, bool runIntransaction = true);


        Task<int> UpdateAsync(object item);


        Task<int> UpdateAllAsync(IEnumerable<object> items, bool runIntransaction = true);
        

        Task<int> DeleteAsync<T>(object item);


        Task<int> DeleteAllAsync<T>();


        /// <summary>
        /// Add a test to the database
        /// This is just for testing purposes, please remove when developing an actual app
        /// </summary>
        /// <returns></returns>
        Task<bool> AddTestAsync(Test test);


        /// <summary>
        /// Get the specified test
        /// This is just for testing purposes, please remove when developing an actual app
        /// </summary>
        /// <param name="id">Id of the test to get</param>
        /// <returns></returns>
        Task<Test> GetTestAsync(int id);


        /// <summary>
        /// Gets all the tests
        /// This is just for testing purposes, please remove when developing an actual app
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Test>> GetTestsAsync();
    }
}
