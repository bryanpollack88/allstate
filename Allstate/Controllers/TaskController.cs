using System;
using System.Collections.Generic;
using System.Web.Http;
using Allstate.Data;
using Allstate.Models;

namespace Allstate.Controllers
{
    /// <summary>
    /// Controller to handle task actions
    /// </summary>
    [Authorize]
    public class TaskController : ApiController
    {
        /// <summary>
        /// Create a task with date due and description
        /// </summary>
        /// <param name="due">Due date of task</param>
        /// <param name="description">Description of task</param>
        /// <returns>Returns if the task was created successfully</returns>
        [HttpPost]
        [ActionName("create")]
        public bool CreateTask(DateTime due, string description)
        {
            bool res = usertask.AddTask(User.Identity.Name, due, description);

            return res;
        }

        /// <summary>
        /// Create a task with date due and description
        /// </summary>
        /// <param name="task">JSON object consisting of DateTime: DueDate and String:Description</param>
        /// <returns>Returns if the task was created successfully</returns>
        [HttpPost]
        [ActionName("create")]
        public bool CreateTask([FromBody]TaskModel task)
        {
            bool res = usertask.AddTask(User.Identity.Name, task.DueDate, task.Description);

            return res;
        }

        /// <summary>
        /// Returns all of a user's tasks
        /// </summary>
        /// <returns>Returns the usertasks associated with the logged on user</returns>
        [HttpGet]
        [ActionName("get-tasks")]
        public List<usertask> GetTasks()
        {
            var res = usertask.GetTasks(User.Identity.Name);

            return res;
        }

        /// <summary>
        /// Deletes the specified user task, if it belongs to the user
        /// </summary>
        /// <param name="id">Task ID</param>
        /// <returns>Returns if the task was successfully deleted</returns>
        [HttpDelete]
        [ActionName("delete-task")]
        public bool DeleteTask(int id)
        {
            bool res = usertask.DeleteTask(User.Identity.Name, id);

            return res;
        }

        /// <summary>
        /// Sets the specified user task as complete, if it belongs to the user
        /// </summary>
        /// <param name="id">Task ID</param>
        /// <returns>Returns if the task was successfully set as complete</returns>
        [HttpPut]
        [ActionName("set-task-complete")]
        public bool SetTaskComplete(int id)
        {
            bool res = usertask.SetTaskState(User.Identity.Name, id, true);

            return res;
        }
    }
}