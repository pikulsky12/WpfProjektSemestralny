using WpfProjektSemestralny.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjektSemestralny.Scripts
{
    public class User
    {
        StoreEntities db = new StoreEntities();

        public void Save(Users user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public void Update(Users user)
        {
            if(user != null)
            {
                Users editUser = db.Users.Find(user.UserID);
                editUser.UserID = user.UserID;
                editUser.UserName = user.UserName;
                editUser.Password = user.Password;
                editUser.PhoneNumber = user.PhoneNumber;
                editUser.BankName = user.BankName;
                editUser.BankAccountNumber = user.BankAccountNumber;
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
            db.SaveChanges();
        }
    }
}
