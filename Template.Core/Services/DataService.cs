#region --- using ---

using Microsoft.AppCenter.Crashes;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Template.Core.Constants;
using Template.Core.Entities;
using Template.Core.Interfaces;
using Xamarin.Essentials;

#endregion

namespace Template.Core.Services
{
    /// <summary>
    /// Data service
    /// </summary>
    public class DataService : IDataService
    {
        #region --- Variables ---

        private SQLiteAsyncConnection database;
        
        #endregion


        #region --- Properties ---

        /// <summary>
        /// Database path
        /// </summary>
        public string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseConstants.DatabaseName);


        #endregion


        #region --- Constructor ---

        /// <summary>
        /// Constructor
        /// </summary>
        public DataService()
        {
            CreateDatabase();
        }

        #endregion


        #region --- CreateDatabase ---

        /// <summary>
        /// Create the database and tables if they don´t exist
        /// </summary>
        /// <returns></returns>
        public Task CreateDatabase()
        {
            return Task.Run(async () => 
            {
                try
                {
                    database = new SQLiteAsyncConnection(DatabasePath);

                    await database.CreateTableAsync<Test>(); // TODO: This is just for testing purposes, please remove when developing an actual app
                }
                catch (Exception ex)
                {
                    Crashes.TrackError(ex, new Dictionary<string, string>
                    {
                        { "File", "DataService" },
                        { "Method", "CreateDatabase" },
                        { "Error message", ex.Message }
                    });
                }
            });
        }

        #endregion


        #region --- InsertAsync ---

        /// <summary>
        /// Insert an object in to the database
        /// </summary>
        /// <param name="item">Item to insert</param>
        /// <returns></returns>
        public async Task<int> InsertAsync(object item) 
        {
            try
            {
                return await database.InsertAsync(item);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "File", "DataService" },
                    { "Method", "InsertAsync" },
                    { "Error message", ex.Message }
                });

                return 0;
            }
        }

        #endregion


        #region --- InsertOrReplaceAsync ---

        /// <summary>
        /// Insert or replace an object in to the database
        /// </summary>
        /// <param name="item">Item to insert</param>
        /// <returns></returns>
        public async Task<int> InsertOrReplace(object item)
        {
            try
            {
                return await database.InsertOrReplaceAsync(item);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "File", "DataService" },
                    { "Method", "Insert" },
                    { "Error message", ex.Message }
                });

                return 0;
            }
        }

        #endregion


        #region --- InsertAllAsync ---

        /// <summary>
        /// Inserts many objects in to the database
        /// </summary>
        /// <param name="items">Items to insert in the database</param>
        /// <param name="runIntransaction">Run inserts wrapped in a transaction. Default is true</param>
        /// <returns></returns>
        public async Task<int> InsertAllAsync(IEnumerable<object> items, bool runIntransaction = true)
        {
            try
            {
                return await database.InsertAllAsync(items, runIntransaction);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "File", "DataService" },
                    { "Method", "InsertAllAsync" },
                    { "Error message", ex.Message }
                });

                return 0;
            }
        }

        #endregion


        #region --- UpdateAsync ---

        /// <summary>
        /// Update an object in the database
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="item">Item to insert</param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(object item)
        {
            try
            {
                return await database.UpdateAsync(item);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "File", "DataService" },
                    { "Method", "UpdateAsync" },
                    { "Error message", ex.Message }
                });

                return 0;
            }
        }

        #endregion


        #region --- UpdateAllAsync ---

        /// <summary>
        /// Updates many objects in the database
        /// </summary>
        /// <param name="items">Items to update in the database</param>
        /// <param name="runIntransaction">Run updates wrapped in a transaction. Default is true</param>
        /// <returns></returns>
        public async Task<int> UpdateAllAsync(IEnumerable<object> items, bool runIntransaction = true)
        {
            try
            {
                return await database.UpdateAllAsync(items, runIntransaction);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "File", "DataService" },
                    { "Method", "UpdateAllAsync" },
                    { "Error message", ex.Message }
                });

                return 0;
            }
        }

        #endregion


        #region --- DeleteAsync ---

        /// <summary>
        /// Delete an item in the database
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="item">Item to insert</param>
        /// <returns></returns>
        public async Task<int> DeleteAsync<T>(object item)
        {
            try
            {
                return await database.DeleteAsync(item);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "File", "DataService" },
                    { "Method", "DeleteAsync" },
                    { "Error message", ex.Message }
                });

                return 0;
            }
        }

        #endregion


        #region --- DeleteAllAsync ---

        /// <summary>
        /// Deletes all rows in the specified table
        /// </summary>
        /// <typeparam name="T">Table to delete content</typeparam>
        /// <returns></returns>
        public async Task<int> DeleteAllAsync<T>()
        {
            try
            {
                return await database.DeleteAllAsync<T>();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "File", "DataService" },
                    { "Method", "DeleteAllAsync" },
                    { "Error message", ex.Message }
                });

                return 0;
            }
        }

        #endregion


        #region --- AddTestAsync ---

        /// <summary>
        /// This is just for testing purposes, please remove when developing an actual app
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AddTestAsync(Test test)
        {
            return await InsertAsync(test) > 0 ? true : false;
        }

        #endregion


        #region --- GetTestAsync ---

        /// <summary>
        /// Get the specified test
        /// This is just for testing purposes, please remove when developing an actual app
        /// </summary>
        /// <param name="id">Id of the test to get</param>
        /// <returns></returns>
        public async Task<Test> GetTestAsync(int id)
        {
            return await database.GetAsync<Test>(id);
        }

        #endregion


        #region --- GetTestsAsync ---

        /// <summary>
        /// Gets all the tests
        /// This is just for testing purposes, please remove when developing an actual app
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Test>> GetTestsAsync()
        {
            return await database.Table<Test>().ToListAsync();
        }

        #endregion
    }
}
