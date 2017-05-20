using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UserManagmentModule.DatabaseConnection.Workers;

namespace UserManagmentModule.Api.Manages
{
    public class CustomManager: DataWorker,IDisposable
    {
        private static IDbConnection _connection = database.CreateOpenConnection();
         

        public static IDictionary<int, string> AllScreens()
        {
            //_connection.Open();

            Dictionary<int, string> screens = new Dictionary<int, string>();
            using (IDataReader reader = database.CreateCommand("SELECT * FROM screen", _connection).ExecuteReader())
            {
                while (reader.Read())
                {
                    int key = (int)reader["id"];
                    string value = reader["screenname"].ToString();
                    screens.Add(key, value);
                }
            }
            return screens;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}


       
    