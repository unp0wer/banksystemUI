using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IAdmin:IBase<Admin>
    {
        List<Admin> Admins { get; set; }
        bool Login(string account, string password);
        bool Logout();
    }
}
