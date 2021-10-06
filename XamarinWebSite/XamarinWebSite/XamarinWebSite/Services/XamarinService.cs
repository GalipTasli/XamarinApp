using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebSite.Models;

namespace XamarinWebSite.Services
{
    public class XamarinService
    {
        public int addcar(CAR car)
        {

            using (var context = new MyDatabaseEntities1())
            {
                if (context.CAR.Where(x => x.BRAND == car.BRAND).FirstOrDefault() == null)
                {
                    CAR u = context.CAR.Add(car);
                    return u.CARID;
                }
                else
                {
                    return 0;

                }
            }
        }

        public int addUser(USER user) {
            
            using(var context= new MyDatabaseEntities1())
            {
                if(context.USER.Where(x=> x.USERNAME == user.USERNAME).FirstOrDefault() == null)
                {
                    USER u = context.USER.Add(user);
                    return u.USERID;
                }
                else
                {
                    return 0;

                }  
            }  
        }


        public int deleteUser(int id)
        {
              using(var context= new MyDatabaseEntities1())
            {
                USER u = context.USER.Where(x => x.USERID == id).FirstOrDefault();
                if (u== null)
                {
                    return 0;

                }
                else
                {
                    context.USER.Remove(u);
                    context.SaveChanges();
                    return 1;
                }  
            } 

        }

        public USER[] getUsers()
        {
            using (var context = new MyDatabaseEntities1())
            {
                USER[] users = context.USER.ToArray();
                if (users.Length > 0)
                    return users;
                else
                    return null;

            }

        }
        public CAR[] getCars()
        {
            using(var context = new MyDatabaseEntities1())
            {
                CAR[] cars = context.CAR.ToArray();
                if (cars.Length > 0)
                    return cars;
                else return null;
            }
        }
        public USER getUserByID(int id)
        {
            using (var context = new MyDatabaseEntities1())
            {
                return  context.USER.Where(x => x.USERID == id).FirstOrDefault();
                
            }

        }

        public USER loginFunction(string username,string password)
        {

            using(var context= new MyDatabaseEntities1())
            {
                return context.USER.Where(x => x.USERNAME.Equals(username) && x.PASSWORD.Equals(password)).FirstOrDefault();

            }
        }

    }
}