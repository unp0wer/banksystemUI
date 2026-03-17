using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
namespace DAL
{
    public class AdminDAL : IAdmin
    {
        private static List<Admin> Admins { get; set; } = new List<Admin>()
        {
            new Admin()
            {
                Id = 1,
                account="admin",
                password="admin",
            },
            new Admin()
            {   Id = 2,
                account="admin2",
                password="admin2",
            },
            new Admin()
            {
                Id = 3,
                account="admin3",
                password="admin3",
            },
            new Admin()
            {
                Id = 4,
                account="admin4",
                password="admin4",
            }
        };
        public List<Admin> GetAllAdmin()
        {
            return Admins;
        }
        public override string ToString()
        {
            string str = "";
            foreach (var admin in Admins)
            {
                str += admin.ToString() + "\n";
            }
            return str;

        }
        public bool Add(Admin adder)//增加
        {
            if (Admins.Find(item => item.account == adder.account) == null)
            {
                Admins.Add(adder);
                return true;
            }
            return false;
        }

        public bool Delete(int id)//删除
        {
            if (Admins.Remove(Admins.Find(item => item.Id == id)))
            {
                return false;
            }
            return true;
        }

        public bool Change(Admin Admin)//修改
        {
            Delete(Admin.Id);
            Add(Admin);
            return true;
        }

        public Admin Find(int id)//查询
        {
            return Admins.Find(item => item.Id == id);
        }
        public Admin Find(string account, string password)
        {
            return Admins.Find(item => item.account == account && item.password == password);
        }
        public static Admin CurrentAdmin { get; set; }
        public bool Login(string account, string password)
        {
            CurrentAdmin = Find(account, password);
            if (CurrentAdmin == null)
            {
                return false;
            }
            return true;
        }

        public bool Logout()
        {
            CurrentAdmin = null;
            return true;
        }


    }
}
