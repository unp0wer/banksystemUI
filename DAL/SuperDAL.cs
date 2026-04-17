using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class SuperDAL : ISuperAdmin
    {
        // 统一数据库连接字符串
        private static string connectionString = ConfigurationManager.ConnectionStrings["SystemBankInfo"].ConnectionString;

        // 当前超级管理员
        public static SuperAdmin CurrentSuperAdmin { get; set; }

        /// <summary>
        /// 超级管理员登录
        /// </summary>
        public bool Login(string username, string password)
        {
            CurrentSuperAdmin = FindByAccountAndPwd(username, password);
            return CurrentSuperAdmin != null;
        }

        /// <summary>
        /// 根据用户名查询
        /// </summary>
        public SuperAdmin find(string username)
        {
            return FindByAccount(username);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public bool Logout()
        {
            CurrentSuperAdmin = null;
            return true;
        }

        #region 私有辅助方法
        /// <summary>
        /// 根据账号+密码查询
        /// </summary>
        public SuperAdmin FindByAccountAndPwd(string account, string password)
        {
            string sql = "select * from SuperAdminInfo where account=@account and password=@password";
            SqlParameter[] pms = {
                new SqlParameter("@account", account),
                new SqlParameter("@password", password)
            };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql, pms))
            {
                if (reader.Read())
                {
                    return new SuperAdmin
                    {
                        Id = (int)reader["Id"],
                        account = reader["account"].ToString(),
                        password = reader["password"].ToString()
                    };
                }
            }
            return null;
        }

        /// <summary>
        /// 根据账号查询
        /// </summary>
        public SuperAdmin FindByAccount(string account)
        {
            string sql = "select * from SuperAdminInfo where account=@account";
            SqlParameter[] pms = {
                new SqlParameter("@account", account)
            };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql, pms))
            {
                if (reader.Read())
                {
                    return new SuperAdmin
                    {
                        Id = (int)reader["Id"],
                        account = reader["account"].ToString(),
                        password = reader["password"].ToString()
                    };
                }
            }
            return null;
        }
        #endregion
    }
}