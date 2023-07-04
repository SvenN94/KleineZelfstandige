using KleineZelfstandige.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KleineZelfstandige.SqlLite
{
    public class LoginDb
    {
        SQLiteAsyncConnection Database;
        public LoginDb()
        {
                
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Login>();
            
        }
        public async Task<List<Login>> GetLoginsAsync()
        {
            await Init();
            return await Database.Table<Login>().ToListAsync();
        }
        public async Task<Login> GetLoginAsync(string username, string password)
        {
            await Init();
            return await Database.Table<Login>().Where(i => i.Username == username && i.Password == password).FirstOrDefaultAsync();
        }
        public async Task<int> SaveLoginAsync(Login login)
        {
            await Init();
            if (login.Id != 0)
            {
                return await Database.UpdateAsync(login);
            }
            else
            {               
               return await Database.InsertAsync(login);               
            }
        }
        public async Task<int> DeleteLoginAsync(Login login)
        {
            await Init();
            return await Database.DeleteAsync(login);
        }
    }
}
