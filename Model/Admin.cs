using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Admin
    {
        public int Id { get; set; }
        public string  account { get; set; }
        public string password { get; set; }
        public DateTime CreatTime = DateTime.Now;
        public override string ToString()
        {
            return $"管理员Id为{Id}，管理员账户为{account}，管理员密码为{password}，管理员创建时间为{CreatTime.ToString("yyyy年-MM月-dd日-HH时-mm分-ss秒")}";
        }
    }
}
