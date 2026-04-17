using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAL
{
    public interface IUser:IBase<User>
    {
        List<User> GetAllUser(string where, int ID = -1, string Account = null, DateTime? StartTime = null, DateTime? EndTime = null);
    }
}
