using AuthTreaning.ViewModel.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AuthTreaning.Core
{
    public class DbManager
    {
        private OnlineGameStoreEntities db;

        public DbManager()
        {
            db = new OnlineGameStoreEntities();
        }
        public async Task<bool> PostUser(User user)
        {
            foreach (User item in await db.User.ToListAsync())
            {
                if (item.Password == user.Password || item.Mail == user.Mail)
                {
                    return false;
                }
            }
            db.User.Add(user);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AuthUser(string login, string password)
        {
            if(await db.User.FirstOrDefaultAsync(u => u.Login == login && u.Password == password) != null)
                return true;

            return false;
        }
    }
}
