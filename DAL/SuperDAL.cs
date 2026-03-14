using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;
namespace DAL
{
    public class SuperDAL : ISuperAdmin
    {
        private static List<SuperAdmin> SuperAdmins { get ; set; }= new List<SuperAdmin>()
        {
            new SuperAdmin()
            {
                Id =1,
                account="SuperAdmin",
                password="123456"
            },
            new SuperAdmin()
            {
                Id =2,
                account="SuperAdmin2",
                password="123456"
            }
        };

        public bool Login(string username, string password)
        {
            if (SuperAdmins.Find(item => item.account == username && item.password == password) != null) 
            {
                return true;
            }
            else { return false; }
        }
        public static SuperAdmin CurrentSuperAdmin { get; set; }
        public SuperAdmin find (string username)
        {
            return SuperAdmins.Find(item => item.account == username);
        }
        public bool Logout()
        {
            CurrentSuperAdmin = null;
            return true;
        }
    }
}
