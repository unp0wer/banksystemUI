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
        bool Login(string account, string password);
        bool Logout();
        List<Admin> GetAllAdmin();
    }
}
