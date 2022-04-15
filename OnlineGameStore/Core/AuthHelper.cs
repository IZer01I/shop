using OnlineGameStore.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGameStore.Core
{
    public class AuthHelper
    {
        private OGSEntities db;

        public AuthHelper()
        {
            db = new OGSEntities();
        }

        public async Task<bool> AuthHelp(string login, string password)
        {
            var userList = await db.User.ToListAsync();
            foreach (var item in userList)
            {
                if (item.Login == login.GetHashCode() && item.Password == password.GetHashCode()) return true;
            }
            return false;
        }
    }
}

