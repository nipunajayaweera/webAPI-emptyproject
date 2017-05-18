using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserManagmentModule.DatabaseConnection.Workers;

namespace UserManagmentModule.Api.Controller
{
    public class CustomController : ApiController
    {

        

        [Route("api/custom/get")]
        [HttpGet]
        public string Get()
        {
            using (IDbConnection connection = DataWorker.database.CreateOpenConnection())
            {
                

                using (IDbCommand command = DataWorker.database.CreateCommand("SELECT * FROM screen where id =1", connection))
                {
                    using (IDataReader reader = command.ExecuteReader())
                    {


                        while(reader.Read())
                        {
                            var a = reader.GetValue(1);
                        }
                       
                    }
                }
            }
            return "Hello World";
        }
    }
}
