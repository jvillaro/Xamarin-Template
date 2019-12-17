#region --- using ---

using Microsoft.AppCenter.Crashes;
using MvvmCross;
using MvvmCross.Plugin.File;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        private readonly SQLiteConnection database;
        private static HttpClient httpClient;

        #endregion


        #region --- Constructor ---

        /// <summary>
        /// Constructor
        /// </summary>
        public DataService()
        {
            var fileStore = Mvx.IoCProvider.GetSingleton<IMvxFileStore>();
            database = CreateDatabase(fileStore.NativePath(string.Empty));
        }

        #endregion


        #region --- Database methods ---
        
        #region --- CreateDatabase ---

        /// <summary>
        /// Create the database and tables if they don´t exist
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection CreateDatabase(string filePath)
        {
            try
            {
                var databasePath = filePath + DatabaseConstants.DatabaseName;
                var database = new SQLiteConnection(databasePath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.FullMutex);
                return database;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "File", "DataService" },
                    { "Method", "CreateDatabase" },
                    { "Error message", ex.Message }
                });
                return null;
            }
        }

        #endregion


        #region --- Insert ---

        /// <summary>
        /// Insert an object in to the database
        /// </summary>
        /// <param name="item">Item to insert</param>
        /// <returns></returns>
        public int Insert(object item) 
        {
            try
            {
                return database.Insert(item);
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


        #region --- InsertOrReplace ---

        /// <summary>
        /// Insert or replace an object in to the database
        /// </summary>
        /// <param name="item">Item to insert</param>
        /// <returns></returns>
        public int InsertOrReplace(object item)
        {
            try
            {
                return database.InsertOrReplace(item);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "File", "DataService" },
                    { "Method", "InsertOrReplace" },
                    { "Error message", ex.Message }
                });

                return 0;
            }
        }

        #endregion


        #region --- InsertAll ---

        /// <summary>
        /// Inserts many objects in to the database
        /// </summary>
        /// <param name="items">Items to insert in the database</param>
        /// <param name="runIntransaction">Run inserts wrapped in a transaction. Default is true</param>
        /// <returns></returns>
        public int InsertAll(IEnumerable<object> items, bool runIntransaction = true)
        {
            try
            {
                return database.InsertAll(items, runIntransaction);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "File", "DataService" },
                    { "Method", "InsertAll" },
                    { "Error message", ex.Message }
                });

                return 0;
            }
        }

        #endregion


        #region --- Update ---

        /// <summary>
        /// Update an object in the database
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="item">Item to insert</param>
        /// <returns></returns>
        public int Update(object item)
        {
            try
            {
                return database.Update(item);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "File", "DataService" },
                    { "Method", "Update" },
                    { "Error message", ex.Message }
                });

                return 0;
            }
        }

        #endregion


        #region --- UpdateAll ---

        /// <summary>
        /// Updates many objects in the database
        /// </summary>
        /// <param name="items">Items to update in the database</param>
        /// <param name="runIntransaction">Run updates wrapped in a transaction. Default is true</param>
        /// <returns></returns>
        public int UpdateAll(IEnumerable<object> items, bool runIntransaction = true)
        {
            try
            {
                return database.UpdateAll(items, runIntransaction);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "File", "DataService" },
                    { "Method", "UpdateAll" },
                    { "Error message", ex.Message }
                });

                return 0;
            }
        }

        #endregion


        #region --- Delete ---

        /// <summary>
        /// Delete an item in the database
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="item">Item to insert</param>
        /// <returns></returns>
        public int Delete<T>(object item)
        {
            try
            {
                return database.Delete(item);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "File", "DataService" },
                    { "Method", "Delete" },
                    { "Error message", ex.Message }
                });

                return 0;
            }
        }

        #endregion


        #region --- DeleteAll ---

        /// <summary>
        /// Deletes all rows in the specified table
        /// </summary>
        /// <typeparam name="T">Table to delete content</typeparam>
        /// <returns></returns>
        public int DeleteAll<T>()
        {
            try
            {
                return database.DeleteAll<T>();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "File", "DataService" },
                    { "Method", "DeleteAll" },
                    { "Error message", ex.Message }
                });

                return 0;
            }
        }

        #endregion

        #endregion


        #region --- HTTP client methods ---

        #region --- CreateHttpClient ---

        /// <summary>
        /// Creates and configures the HTTP client
        /// </summary>
        private void CreateHttpClient()
        {
            // Disables the default cache
            if (httpClient != null)
            {
                httpClient.DefaultRequestHeaders.IfModifiedSince = DateTimeOffset.Now;
            }
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.IfModifiedSince = DateTimeOffset.Now;
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.Timeout = new TimeSpan(0, 0, 5, 0);
        }

        #endregion


        #region --- PostAsync ---

        /// <summary>
        /// Post data 
        /// </summary>
        protected async Task<T> PostAsync<T>(object postData, string uri, JsonSerializerSettings settings = null)
        {
            CreateHttpClient();
            var data = JsonConvert.SerializeObject(postData);
            var contentPost = new StringContent(data, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(uri, contentPost);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"Error in PostAsync: {result.StatusCode}");
            }
            var response = await result.Content.ReadAsStringAsync();
            var resultData = JsonConvert.DeserializeObject<T>(response, settings);
            return resultData;
        }

        #endregion


        #region --- GetAsync ---

        /// <summary>
        /// Executes a GET method to the service
        /// </summary>
        protected async Task<T> GetAsync<T>(string uri, JsonSerializerSettings settings = null)
        {

            var result = await httpClient.GetAsync(uri);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"Error in GetAsync: {result.StatusCode}");
            }
            var response = await result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(response);
            return data;
        }

        #endregion

        #endregion


        /*--- App methods ---*/

        #region --- CreateTables ---

        /// <summary>
        /// Create the necessary tables
        /// </summary>
        public void CreateTables()
        {
            // TODO: This is just for testing purposes, please remove when developing an actual app
            database.CreateTable<Test>(); 
        }

        #endregion


        #region --- AddTest ---

        /// <summary>
        /// This is just for testing purposes, please remove when developing an actual app
        /// </summary>
        /// <returns></returns>
        public bool AddTest(Test test)
        {
            return Insert(test) > 0 ? true : false;
        }

        #endregion


        #region --- GetTest ---

        /// <summary>
        /// Get the specified test
        /// This is just for testing purposes, please remove when developing an actual app
        /// </summary>
        /// <param name="id">Id of the test to get</param>
        /// <returns></returns>
        public Test GetTest(int id)
        {
            return database.Get<Test>(id);
        }

        #endregion


        #region --- GetTests ---

        /// <summary>
        /// Gets all the tests
        /// This is just for testing purposes, please remove when developing an actual app
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Test> GetTests()
        {
            return database.Table<Test>().ToList();
        }

        #endregion
    }
}
