using Dapper;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DAL
{
    public class UserDAL : IUser
    {

        public int pageSize = 5;
        public int totalCount;
        public int currentPage = 1;
        public int totalPage => totalCount / pageSize + (totalCount % pageSize == 0 ? 0 : 1);
        // 从配置文件读取连接字符串（和 AdminDAL 保持一致）
        private static string connectionString = ConfigurationManager.ConnectionStrings["SystemBankInfo"].ConnectionString;

        // 当前登录用户
        public static User CurrentUser { get; set; }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        public List<User> GetAllUser(string where, int ID = -1, string Account = null, DateTime? StartTime = null, DateTime? EndTime = null)
        {
            string countSql = "SELECT COUNT(*) FROM UserInfo"+ where;

            List<User> list = new List<User>();

            string sql = $"select * from UserInfo {where} order by id offset (@currentPage-1) * @pageSize rows fetch next @pageSize rows only";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                totalCount = connection.ExecuteScalar<int>(countSql, new { ID, Account, StartTime, EndTime, currentPage, pageSize });
                var result = connection.Query<User>(sql, new { ID, Account, StartTime, EndTime, currentPage, pageSize });
                list = result.ToList();
            }
            return list;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        public bool Add(User adder)
        {
            // 先判断账号是否存在
            if (FindByAccount(adder.account) != null)
            {
                return false;
            }

            string sql = "insert into Userinfo(account,password) values(@account,@password)";
            SqlParameter[] pms = {
                new SqlParameter("@account", adder.account),
                new SqlParameter("@password", adder.password)
            };

            int rows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql, pms);
            return rows > 0;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        public bool Delete(int id)
        {
            string sql = "delete from Userinfo where id=@id";
            SqlParameter[] pms = {
                new SqlParameter("@id", id)
            };

            int rows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql, pms);
            return rows > 0;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        public bool Change(User user)
        {
            string sql = "update Userinfo set account=@account,password=@password where id=@id";
            SqlParameter[] pms = {
                new SqlParameter("@account", user.account),
                new SqlParameter("@password", user.password),
                new SqlParameter("@id", user.Id)
            };

            int rows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql, pms);
            return rows > 0;
        }

        /// <summary>
        /// 根据 ID 查询
        /// </summary>
        public User Find(int id)
        {
            string sql = "select * from Userinfo where id=@id";
            SqlParameter[] pms = {
                new SqlParameter("@id", id)
            };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql, pms))
            {
                if (reader.Read())
                {
                    return new User
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
        /// 登录
        /// </summary>
        public bool Login(string username, string password)
        {
            CurrentUser = FindByAccountAndPwd(username, password);
            return CurrentUser != null;
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public bool Logout(string username, string password)
        {
            CurrentUser = null;
            return true;
        }

        #region 私有辅助方法
        /// <summary>
        /// 根据账号+密码查询（登录用）
        /// </summary>
        private User FindByAccountAndPwd(string account, string password)
        {
            string sql = "select * from Userinfo where account=@account and password=@password";
            SqlParameter[] pms = {
                new SqlParameter("@account", account),
                new SqlParameter("@password", password)
            };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql, pms))
            {
                if (reader.Read())
                {
                    return new User
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
        /// 根据账号查询（判断重复用）
        /// </summary>
        private User FindByAccount(string account)
        {
            string sql = "select * from Userinfo where account=@account";
            SqlParameter[] pms = {
                new SqlParameter("@account", account)
            };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql, pms))
            {
                if (reader.Read())
                {
                    return new User
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