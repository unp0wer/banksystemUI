using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL : IUser
    {
        public  List<User> Users { get; set; } = new List<User>()
        {
            new User()
            {
                Id = 1,
                account="lihua",
                password="admin",
            },
           new User()
           {
                Id = 2,
                account="lihua2",
                password="admin2",
           },
           new User()
           {
                Id = 3,
                account="lihua3",
                password="admin3",
           }
        };
        public override string ToString()
        {
            string str="";
            foreach (var user in Users)
            {
                str += user.ToString()+"\n";
            }
            return str;

        }
        public static User CurrentUser { get; set; }

        public bool Add(User adder)//增加
        {
            if (Users.Find(item => item.account == adder.account) == null)
            {
                Users.Add(adder);
                return true;
            }
            return false;
        }

        public  bool Delete(int id)//删除
        {
            if (Users.Remove(Users.Find(item => item.Id == id)))
            {
                return false;
            }
            return true;
        }

        public  bool Change(User user)//修改
        {
            Delete(user.Id);
            Add(user);
            return true;

        }

        public  User Find(int id)//查询
        {
          return Users.Find(item=> item.Id == id);
        }

        public  bool Login(string username, string password)
        {
            CurrentUser = Users.Find(item => item.account == username && item.password == password);
            if (CurrentUser == null)
                return false;
            else
            {
                return true;
            }
        }
        public  bool Logout(string username, string password)
        {
            CurrentUser = null;
            return true;
        }
    }
}
