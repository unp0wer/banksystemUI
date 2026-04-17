using Model;
using DAL;

namespace BLL
{
    public class SuperBLL
    {
        // 仅调用DAL
        private readonly SuperDAL _superDAL = new SuperDAL();

        public static SuperAdmin CurrentSuperAdmin { get; set; }

        /// <summary>
        /// 超级管理员登录验证
        /// </summary>
        public bool Login(string account, string password)
        {
            return _superDAL.Login(account, password);
        }

        /// <summary>
        /// 查询超级管理员对象
        /// </summary>
        public SuperAdmin FindSuper(string account)
        {
            return _superDAL.find(account);
        }
    }
}