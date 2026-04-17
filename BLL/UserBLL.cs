using System;
using System.Collections.Generic;
using Model;
using DAL;

namespace BLL
{
    public class UserBLL
    {
        // 实例化DAL，BLL仅调用DAL
        private readonly UserDAL userDAL = new UserDAL();

        #region 分页属性（UI通过BLL访问）
        public int currentPage
        {
            get => userDAL.currentPage;
            set => userDAL.currentPage = value;
        }
        public int totalPage => userDAL.totalPage;
        public int pageSize
        {
            get => userDAL.pageSize;
            set => userDAL.pageSize = value;
        }
        public int totalCount => userDAL.totalCount;
        #endregion

        #region 带条件查询（适配ID、账号、时间范围）
        public List<User> GetAllUser(string where, int id, string account, DateTime? startTime, DateTime? endTime)
        {
            return userDAL.GetAllUser(where, id, account, startTime, endTime);
        }
        #endregion

        #region 增删改业务方法
        public bool DeleteUser(int userId)
        {
            return userDAL.Delete(userId);
        }

        public bool AddUser(User model)
        {
            if (string.IsNullOrWhiteSpace(model.account)) return false;
            return userDAL.Add(model) ;
        }

        public bool UpdateUser(User model)
        {
            return userDAL.Change(model);
        }
        #endregion
    }
}