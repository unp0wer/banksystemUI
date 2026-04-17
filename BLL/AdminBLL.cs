using System.Collections.Generic;
using Model;
using DAL; // 引用DAL层

namespace BLL
{
    public class AdminBLL
    {
        // 实例化DAL层对象（BLL唯一调用DAL的地方）
        private AdminDAL adminDAL = new AdminDAL();

        #region 分页属性（直接封装DAL的分页，UI通过BLL访问）
        public int currentPage
        {
            get { return adminDAL.currentPage; }
            set { adminDAL.currentPage = value; }
        }

        public int totalPage
        {
            get { return adminDAL.totalPage; }
        }

        public int pageSize
        {
            get { return adminDAL.pageSize; }
            set { adminDAL.pageSize = value; }
        }

        public int totalCount
        {
            get { return adminDAL.totalCount; }
        }

        public static Admin CurrentAdmin { get; set; }
        #endregion

        #region 业务方法（增删改查+分页查询）
        /// <summary>
        /// 获取所有管理员（分页）
        /// </summary>
        public List<Admin> GetAllAdmin(string where = null,int ID = -1,string Account = null)
        {
            return adminDAL.GetAllAdmin(where, ID, Account);
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        public bool DeleteAdmin(int adminId)
        {
            // 这里可以加业务逻辑：比如不能删除超级管理员
            return adminDAL.Delete(adminId) ;
        }


        // 新增到 AdminBLL 类中
        /// <summary>
        /// 普通管理员登录
        /// </summary>
        public bool Login(string account, string password)
        {
            return adminDAL.Login(account, password);
        }

        /// <summary>
        /// 查询普通管理员对象
        /// </summary>
        public Admin FindAdmin(string account, string password)
        {
            return adminDAL.Find(account, password);
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        public List<Admin> SearchAdmin(int? id, string account)
        {
            var list = adminDAL.GetAllAdmin(null);
            if (id.HasValue)
                list = list.FindAll(a => a.Id == id.Value);
            if (!string.IsNullOrWhiteSpace(account))
                list = list.FindAll(a => a.account.Contains(account));
            return list;
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        public bool AddAdmin(Admin admin)
        {
            if (string.IsNullOrWhiteSpace(admin.account)) return false;
            return adminDAL.Add(admin);
        }

        /// <summary>
        /// 修改管理员
        /// </summary>
        public bool UpdateAdmin(Admin admin)
        {
            return adminDAL.Change(admin);
        }
        #endregion
    }
}