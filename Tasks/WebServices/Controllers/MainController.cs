using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpPost]
        [Route("administrator")]
        public bool CheckAdministrator(Database.Model.Administrator administrator)
        {
            Database.Action.AdministratorAction adminAction = new Database.Action.AdministratorAction();
            return adminAction.AdministratorAccessValidation(administrator);
        }

        [HttpGet]
        [Route("tasks")]
        public List<Database.Model.Task> TaskSelectAll()
        {
            List<Database.Model.Task> tasks = new List<Database.Model.Task>();
            Database.Action.TaskAction taskAction = new Database.Action.TaskAction();

            tasks = taskAction.TaskSelectAll();

            return tasks;
        }

        [HttpGet]
        [Route("task/{id}")]
        public Database.Model.Task TaskSelect(int id)
        {
            Database.Model.Task task = new Database.Model.Task();
            Database.Action.TaskAction taskAction = new Database.Action.TaskAction();

            task = taskAction.TaskSelect(id);

            return task;
        }

        [HttpPost]
        [Route("taskInsert")]
        public bool TaskInsert(Database.Model.Task task)
        {
            Database.Action.TaskAction taskAction = new Database.Action.TaskAction();
            return taskAction.TaskInsert(task);
        }

        [HttpPut]
        [Route("taskUpdate")]
        public bool TaskUpdate(Database.Model.Task task)
        {
            Database.Action.TaskAction taskAction = new Database.Action.TaskAction();
            return taskAction.TaskUpdate(task);
        }

        [HttpDelete]
        [Route("taskDelete/{id}")]
        public bool TaskDelete(int id)
        {
            Database.Action.TaskAction taskAction = new Database.Action.TaskAction();
            return taskAction.TaskDelete(id);
        }
    }
}