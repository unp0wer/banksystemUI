using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
namespace DAL
{
    public class AdminDAL : IAdmin

    {
        public int pageSize = 5;
        public int totalCount;
        public int _currentPage = 1;
        public int currentPage
        {
            get => _currentPage;
            set
            {
                if (value < 1)
                {
                    _currentPage = 1;
                }
                else if (value > totalPage)
                {
                    _currentPage = totalPage;
                }
                else
                {
                    _currentPage = value;
                }
            }
        }
        public int totalPage => totalCount / pageSize + (totalCount % pageSize == 0 ? 0 : 1);

        public AdminDAL()
        {
            // 构造函数中可以添加一些初始化操作
            GetAllAdmin(null); // 初始化时获取一次数据，计算 totalCount 和 totalPage
        }

        private static string connectionString = ConfigurationManager.ConnectionStrings["SystemBankInfo"].ConnectionString;
        //连接数据库

        public static Admin CurrentAdmin { get; set; }

        public bool Add(Admin adder)
        {
            string sql = "insert into AdminInfo(account,password) values(@account,@password)";
            SqlParameter[] pms = {
            new SqlParameter("@account", adder.account),
            new SqlParameter("@password", adder.password)
            };
            int rows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql, pms);
            if (rows > 0) return true;
            return false;

        }

        public bool Change(Admin changer)
        {
            string sql = "update AdminInfo set account=@account,password=@password where id=@id";
            SqlParameter[] pms = {
            new SqlParameter("@account", changer.account),
            new SqlParameter("@password", changer.password),
            new SqlParameter("@id", changer.Id)
            };
            int rows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql, pms);
            if (rows > 0) return true;
            return false;

        }

        public bool Delete(int id)
        {

            string sql = "delete from AdminInfo where id=@id";
            SqlParameter[] pms = {
            new SqlParameter("@id", id)
            };
            int rows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql, pms);
            if (rows > 0) return true;
            return false;
        }

        public Admin Find(int id)
        {
            string sql = "select * from AdminInfo where id=@id";
            SqlParameter[] pms = {
            new SqlParameter("@id", id)
            };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql))
            {
                // 只读取一行，性能最高
                if (reader.Read())
                {
                    return new Admin
                    {
                        Id = (int)reader["id"],
                        account = reader["account"].ToString(),
                        password = reader["password"].ToString()
                    };
                }
            }
            return null;
        }


        public List<Admin> GetAllAdmin(string where, int ID = -1, string Account = null)
        {
            string countSql = "SELECT COUNT(*) FROM AdminInfo" + where;

            List<Admin> list = new List<Admin>();
            string sql = $"select * from AdminInfo {where} order by id offset (@currentPage-1) * @pageSize rows fetch next @pageSize rows only";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                totalCount = connection.ExecuteScalar<int>(countSql, new { ID, Account, currentPage, pageSize });
                var result = connection.Query<Admin>(sql, new { ID, Account, currentPage, pageSize });
                list = result.ToList();
            }
            return list;

        }
        //直接用 SqlHelper 拿 DataReader
        //using (SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql))
        //{

        //    // 逐行读取
        //    //while (reader.Read())
        //    //{
        //    //    Admin admin = new Admin();
        //    //    admin.Id = (int)reader["Id"];
        //    //    admin.account = reader["account"].ToString();
        //    //    admin.password = reader["password"].ToString();
        //    //    list.Add(admin);
        //    //}
        //}

        // 使用 dapper进行分页

        public bool Login(string account, string password)
        {
            CurrentAdmin = Find(account, password);
            if (CurrentAdmin == null)
            {
                return false;
            }
            return true;
        }

        public Admin Find(string account, string password)
        {
            string sql = "select * from AdminInfo where account=@account and password=@password";

            // 参数
            SqlParameter[] pms = {
                new SqlParameter("@account", account),
                new SqlParameter("@password", password)
            };
            //using (SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql))
            //{
            //    // 判断是否查到数据
            //    if (reader.Read())
            //    {
            //        return new Admin
            //        {
            //            Id = (int)reader["Id"],
            //            account = reader["account"].ToString(),
            //            password = reader["password"].ToString()
            //        };
            //    }
            //}


            //使用dapper
            using (var connection = new SqlConnection(connectionString))
            {
                var param = new { account, password };
                var result = connection.QuerySingleOrDefault<Admin>(sql, param);
                return result;
            }

                // 没查到返回 null
                return null;
        }

        public bool Logout()
        {
            CurrentAdmin = null;
            return true;
        }
    }
}
