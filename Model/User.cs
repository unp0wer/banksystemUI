using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public int Id { get; set; }
        public string account { get; set; }
        public string password { get; set; }
        public  DateTime CreatTime { get; set; }= DateTime.Now;
        public override string ToString()
        {
            return $"用户Id为{Id}，用户账户为{account}，用户密码为{password}，用户创建时间为{CreatTime.ToString("yyyy年-MM月-dd日-HH时-mm分-ss秒")}";
        }
    }
}
