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

        Dictionary<int, Adress> Adresses { get; set; }//用户id 和地址

        bool Add(int id, Adress adress);//增加


        bool Delete(int id);//删除

        bool Change(int id, Adress adress);//修改


        Adress Find(int id);//查询

    }
}
