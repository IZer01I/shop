using OnlineGameStore.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGameStore.Core
{
    public class RegistryHelper
    {
        private OGSEntities db;

        public RegistryHelper()
        {
            db = new OGSEntities();
        }

        public async Task<bool> PostUser(User user)
        {
            List<User> userList = await db.User.ToListAsync();

            foreach (User item in userList)
            {
                if (item.Login == user.Login || item.UserName == user.UserName || item.Mail == user.Mail)
                {
                    return false;
                }
            }
            db.User.Add(user);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
