#region --- using ---

using System.Collections.Generic;
using Template.Core.Entities;

#endregion

namespace Template.Core.Interfaces
{
    /// <summary>
    /// Data Service interface
    /// </summary>
    public interface IDataService
    {
        int Insert(object item);


        int InsertOrReplace(object item);


        int InsertAll(IEnumerable<object> items, bool runIntransaction = true);


        int Update(object item);


        int UpdateAll(IEnumerable<object> items, bool runIntransaction = true);


        int Delete<T>(object item);


        int DeleteAll<T>();

        /// <summary>
        /// Add a test to the database
        /// This is just for testing purposes, please remove when developing an actual app
        /// </summary>
        /// <returns></returns>
        bool AddTest(Test test);


        /// <summary>
        /// Get the specified test
        /// This is just for testing purposes, please remove when developing an actual app
        /// </summary>
        /// <param name="id">Id of the test to get</param>
        /// <returns></returns>
        Test GetTest(int id);


        /// <summary>
        /// Gets all the tests
        /// This is just for testing purposes, please remove when developing an actual app
        /// </summary>
        /// <returns></returns>
        IEnumerable<Test> GetTests();
    }
}
