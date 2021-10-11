using APIService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CognizantTestAPI.Controllers
{
    public class StatisticController : ApiController
    {

        private ApiService service = new ApiService();

        public IEnumerable<PlayerStatisticModel> Get()
        {

            return service.GetStatistic();
        }
    }
}
