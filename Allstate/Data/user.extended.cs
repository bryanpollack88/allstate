using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Allstate.Data
{
    public partial class user
    {
        public static user GetUser(string username)
        {
            using(AllstateEntities e = new AllstateEntities())
            {
                user user = e.users.SingleOrDefault(u => u.username == username);

                return user;
            }
        }

        public static user GetUser(int id)
        {
            using (AllstateEntities e = new AllstateEntities())
            {
                user user = e.users.SingleOrDefault(u => u.id == id);

                return user;
            }
        }
    }
}