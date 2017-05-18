using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UserManagmentModule.Api
{
    public sealed class DatabaseFactorySectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("name")]
        public string Name
        {
            get { return (string)base["name"]; }
        }
        [ConfigurationProperty("ConnectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["ConnectionStringName"]; }
        }
        public string ConnectionString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
                }
                catch (Exception excep)
                {
                    throw new Exception("Connection string " + ConnectionStringName + " was not found in web.config. " + excep.Message);
                }
            }
        }
    }
}