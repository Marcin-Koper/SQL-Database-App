using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SQL_Database
{
    /// <summary>
    /// Public static class helps with connection to database.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Method which gets connection string to database from App.config
        /// </summary>
        /// <param name="name">Name of a connection string to the database.</param>
        /// <returns>Connection string to the database</returns>
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

    }
}
