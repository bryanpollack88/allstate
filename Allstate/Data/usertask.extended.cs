using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Allstate.Data
{
    public partial class usertask
    {
        /// <summary>
        /// Get a user's tasks by username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns></returns>
        public static List<usertask> GetTasks(string username)
        {
            try
            {
                using (AllstateEntities e = new AllstateEntities())
                {
                    return e.usertasks.Where(u => u.user.username == username).ToList();
                }
            }
            catch (Exception)
            {
                return new List<usertask>();
            }
        }

        /// <summary>
        /// Get a user task by task ID
        /// </summary>
        /// <param name="id">Task ID</param>
        /// <returns></returns>
        public static usertask GetTask(int id)
        {
            try
            {
                using (AllstateEntities e = new AllstateEntities())
                {
                    return e.usertasks.SingleOrDefault(u => u.id == id);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Add a new task for user with a due date and description
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="due">Date due</param>
        /// <param name="description">Description</param>
        /// <returns></returns>
        public static bool AddTask(string username, DateTime due, string description)
        {
            try
            {
                using (AllstateEntities e = new AllstateEntities()) {
                    user asUser = user.GetUser(username);

                    if (asUser == null)
                        return false;

                    var task = new usertask
                    {
                        completedate = due,
                        userid = asUser.id,
                        taskcomplete = false,
                        title = description
                    };

                    e.usertasks.Add(task);

                    return e.SaveChanges() == 1;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Change the state (complete/incomplete) of a task
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="id">Task ID</param>
        /// <param name="isComplete">Status to set task to</param>
        /// <returns></returns>
        public static bool SetTaskState(string username, int id, bool isComplete)
        {
            try
            {
                using (AllstateEntities e = new AllstateEntities())
                {
                    usertask task = e.usertasks.SingleOrDefault(u => u.id == id && u.user.username == username);

                    if (task == null)
                    {
                        return false;
                    }

                    task.taskcomplete = isComplete;

                    return e.SaveChanges() == 1;

                    /* return e.Database.ExecuteSqlCommand(
                        "UPDATE dbo.usertasks SET taskcomplete = 1 WHERE id = {0} AND userid = (SELECT userid FROM dbo.user WHERE username = {1})",
                        id, username) == 1; */
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete a task based on task ID and the logged on user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="id">Task ID</param>
        /// <returns></returns>
        public static bool DeleteTask(string username, int id)
        {
            try
            {
                using (AllstateEntities e = new AllstateEntities())
                {
                    usertask task = e.usertasks.SingleOrDefault(u => u.id == id && u.user.username == username);

                    if (task == null)
                    {
                        return false;
                    }

                    e.usertasks.Remove(task);

                    return e.SaveChanges() == 1;

                    /* return e.Database.ExecuteSqlCommand(
                        "DELETE FROM dbo.usertasks WHERE id = {0} AND userid = (SELECT userid FROM dbo.user WHERE username = {1})",
                        id, username) == 1; */
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}