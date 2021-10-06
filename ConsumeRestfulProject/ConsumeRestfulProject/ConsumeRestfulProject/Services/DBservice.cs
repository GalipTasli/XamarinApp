using ConsumeRestfulProject.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeRestfulProject.Services
{
    public class DBservice
    {

        private SQLiteAsyncConnection database;

        public SQLiteAsyncConnection Database { get => database; set => database = value; }


        public DBservice(string path)
        {
            Database = new SQLiteAsyncConnection(path);
            Database.CreateTableAsync<USER>();
            Database.CreateTableAsync<CAR>();
        }


        public Task<int> AddCar(CAR car)
        {
            return Database.InsertAsync(car);
        }

        public Task<List<CAR>> GetCars()
        {
            return Database.Table<CAR>().ToListAsync();

        }

        public Task<int> DeleteCar(int id)
        {
            return Database.DeleteAsync<CAR>(id);

        }

        public Task<USER> GetUserByName(string username)
        {

            return Database.Table<USER>().Where(i => i.USERNAME.Equals(username)).FirstOrDefaultAsync();
        }


        public Task<int> AddUser(USER user)
        {
            if (user.USERID == 0)
            {
                return Database.InsertAsync(user);
            }
            else
            {
                return Database.UpdateAsync(user);

            }

        }

        public Task<USER> LoginFunction(string username, string password)
        {
            return Database.Table<USER>().Where(x => x.USERNAME.Equals(username) && x.PASSWORD.Equals(password)).FirstOrDefaultAsync();

        }
    }
}
