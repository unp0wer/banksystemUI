using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAL
{
    public class AdressDAL : IAdress
    {
        public Dictionary<int, Adress> Adresses { get; set; } = new Dictionary<int, Adress>()
        {
         {
            0, new Adress()
            {
                Provice = "北京市",
                City = "北京市",
                County = "东城区",
                Road = "东长安街",
                Number = "1号"
            }
        },
        // 第二个地址：上海市浦东新区
        {
            1, new Adress()
            {
                Provice = "上海市",
                City = "上海市",
                County = "浦东新区",
                Road = "世纪大道",
                Number = "100号"
            }
        },
        // 第三个地址：广东省深圳市南山区
        {
            2, new Adress()
            {
                Provice = "广东省",
                City = "深圳市",
                County = "南山区",
                Road = "科技园路",
                Number = "88号"
            }
        },
        // 第四个地址：江苏省南京市秦淮区（部分字段示例）
        {
            3, new Adress()
            {
                Provice = "江苏省",
                City = "南京市",
                County = "秦淮区",
                Road = "中山南路"
                // Number字段留空，展示可选赋值
            }
        }
            };

        public bool Add(int id, Adress adress)//增加
        {
            if (!Adresses.ContainsKey(id))
            {
                Adresses.Add(id, adress);
                return true;
            }
            return false;
        }

        public bool Delete(int id)//删除
        {
            return Adresses.Remove(id);
        }

        public bool Change(int id, Adress adress)//修改
        {
            if (Adresses.ContainsKey(id))
            {
                Adresses[id] = adress;
                return true;
            }
            return false;
        }

        public Adress Find(int id)//查询
        {
            if (Adresses.ContainsKey(id))
            { return Adresses[id]; }
            return null;
        }
        public override string ToString()
        {
            string result = "";
            foreach (var adress in Adresses)
            {
                result += $"id为{adress.Key}的用户地址为：{adress.Value.ToString()}";
            }
            return result;
        }

    }
}
