using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserManagmentModule.Api.Manages;
using UserManagmentModule.DatabaseConnection.Workers;

namespace UserManagmentModule.Api.Controller
{
    public class CustomController : ApiController
    {

        

        [Route("api/custom/get")]
        [HttpGet]
        public IDictionary<int ,string> Get()
        {          
            return CustomManager.AllScreens();
        }
    }
}
