using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Allstate.Models
{
    /// <summary>
    /// Passed in to create a new task
    /// </summary>
    public class TaskModel
    {
        /// <summary>
        /// Due date of a task
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Description of a task
        /// </summary>
        public string Description { get; set; }
    }
}