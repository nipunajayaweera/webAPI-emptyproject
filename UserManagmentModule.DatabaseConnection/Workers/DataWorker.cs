using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentModule.DatabaseConnection.Common;
using UserManagmentModule.DatabaseConnection.Factory;

namespace UserManagmentModule.DatabaseConnection.Workers
{
    public class DataWorker
    {
        private static Database _database = null;
        static DataWorker()
        {
            try
            {
                if (_database == null) {
                    _database = DatabaseFactory.CreateDatabase();                    
                }
            }
            catch (Exception excep)
            {
                throw excep;
            }
        }
        public static Database database
        {
            get { return _database; }
        }
    }
}
