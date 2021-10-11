using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CognizantTestAPI.Controllers
{
    public class TaskController : ApiController
    {

        [HttpGet]
        public object Get()
        {
            return null;
        }
        // GET api/values/5
        [HttpGet]
        public object Get(int id)
        {
            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] object body)
        {

        }
    }
}
