using APIService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CognizantTestAPI.Controllers
{
    public class TaskController : ApiController
    {
        private ApiService service = new ApiService();
        
        [HttpGet]
        public IEnumerable<TaskModel> Get()
        {
            return service.GetTaskList();
        }

        [HttpGet]
        public TaskDescriptionAndParams Get(int id)
        {
            return service.GetTaskDescriptionAndParams(id);
        }

        [HttpPost]
        public ResultModel Post([FromBody] CompletedTaskModel body)
        {
            var result = new ResultModel();
            result = service.SolvePlayerSolution(body);
            return result;
        }
    }
}
