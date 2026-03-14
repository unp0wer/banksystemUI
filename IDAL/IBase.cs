using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public  interface IBase<T>
    {
        bool Add(T adder);
        bool Delete(int id);
        bool Change(T changer);
        T Find(int id);
    }



}
