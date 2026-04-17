using System.Collections.Generic;
using Model;
using DAL;

namespace BLL
{
    public class AdressBLL
    {
        private readonly AdressDAL adressDAL = new AdressDAL();

        #region 分页属性
        public int currentPage
        {
            get => adressDAL.currentPage;
            set => adressDAL.currentPage = value;
        }
        public int totalPage => adressDAL.totalPage;
        public int pageSize
        {
            get => adressDAL.pageSize;
            set => adressDAL.pageSize = value;
        }
        public int totalCount => adressDAL.totalCount;
        #endregion

        #region 带条件查询
        public List<Adress> GetAllAdress(string where, int id, string keyword)
        {
            return adressDAL.GetAllAdress(where, id, keyword);
        }
        #endregion

        #region 增删改业务方法
        public bool DeleteAdress(int id)
        {
            return adressDAL.Delete(id);
        }

        /// <summary>
        /// 添加地址（兼容你的DAL写法）
        /// </summary>
        public bool AddAdress(Adress model)
        {
            if (string.IsNullOrWhiteSpace(model.Province)) return false;
            int newId = adressDAL.GetAllAdress(null).Count + 1;
            return adressDAL.Add(model);
        }

        /// <summary>
        /// 修改地址（兼容你的DAL写法）
        /// </summary>
        public bool UpdateAdress(int id, Adress model)
        {
            return adressDAL.Change(id, model);
        }
        #endregion
    }
}