using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UserManagmentModule.DatabaseConnection.Common;
using UserManagmentModule.DatabaseConnection.Handler;

namespace UserManagmentModule.DatabaseConnection.Factory
{
    public sealed class DatabaseFactory
    {
       // public static DatabaseFactorySectionHandler sectionHandler = (DatabaseFactorySectionHandler)ConfigurationManager.GetSection("DatabaseFactoryConfiguration");
        private DatabaseFactory() { }
        public static Database CreateDatabase()
        {
            // Verify a DatabaseFactoryConfiguration line exists in the web.config.
            if ("ConnectionOne".Length == 0)
            {
                throw new Exception("Database name not defined in DatabaseFactoryConfiguration section of web.config.");
            }
            try
            {
                // Find the class
                Type database = Type.GetType("UserManagmentModule.DatabaseConnection.DBClasses.PostgrSQLDatabase");
                // Get it's constructor
                ConstructorInfo constructor = database.GetConstructor(new Type[] { });
                // Invoke it's constructor, which returns an instance.
                Database createdObject = (Database)constructor.Invoke(null);
                // Initialize the connection string property for the database.
                createdObject.connectionString = "Server=127.0.0.1;Port=5432;Database=first;User Id=postgres;Password=123456;";
                // Pass back the instance as a Database
                return createdObject;
            }
            catch (Exception excep)
            {
                //throw new Exception("Error instantiating database " + sectionHandler.Name + ". " + excep.Message);
                throw excep;
            }
        }
    }
}
