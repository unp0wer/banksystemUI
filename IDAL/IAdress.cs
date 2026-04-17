using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAL
{
    public interface IAdress
    {


        bool Add(Adress adress);//增加


        bool Delete(int id);//删除

        bool Change(int id, Adress adress);//修改


        Adress Find(int id);//查询
        List<Adress> GetAllAdress(string where, int ID = -1, string Account = null);
    }
}
