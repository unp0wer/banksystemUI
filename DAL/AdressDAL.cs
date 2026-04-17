using Dapper;
using Dapper;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
namespace DAL
{
    public class AdressDAL : IAdress
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

        // 统一数据库连接字符串
        private static string connectionString = ConfigurationManager.ConnectionStrings["SystemBankInfo"].ConnectionString;

        /// <summary>
        /// 获取所有地址
        /// </summary>
        public List<Adress> GetAllAdress(string where, int ID = -1, string Account = null)
        {
            string countSql = "SELECT COUNT(*) FROM AddressInfo " + where;

            List<Adress> list = new List<Adress>();

            string sql = $"select * from AddressInfo {where} order by id offset (@currentPage-1) * @pageSize rows fetch next @pageSize rows only";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                totalCount = connection.ExecuteScalar<int>(countSql, new { ID, Account, currentPage, pageSize });
                var result = connection.Query<Adress>(sql, new { ID, Account, currentPage, pageSize });
                list = result.ToList();
            }
            return list;

        }

        /// <summary>
        /// 添加地址
        /// </summary>
        public bool Add(Adress adress)
        {
            // 判断ID是否已存在
            if (Find(adress.Id) != null)
            {
                return false;
            }

            string sql = "insert into AddressInfo(Id, Province, City, County, Road, Number) values(@Id,@Province,@City,@County,@Road,@Number)";
            SqlParameter[] pms = {
                new SqlParameter("@Id", adress.Id),
                new SqlParameter("@Province", adress.Province),
                new SqlParameter("@City", adress.City),
                new SqlParameter("@County", adress.County),
                new SqlParameter("@Road", adress.Road),
                new SqlParameter("@Number", adress.Number)
            };

            int rows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql, pms);
            return rows > 0;
        }

        /// <summary>
        /// 删除地址
        /// </summary>
        public bool Delete(int id)
        {
            string sql = "delete from AddressInfo where Id=@Id";
            SqlParameter[] pms = {
                new SqlParameter("@Id", id)
            };

            int rows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql, pms);
            return rows > 0;
        }

        /// <summary>
        /// 修改地址
        /// </summary>
        public bool Change(int id, Adress adress)
        {
            string sql = "update AddressInfo set Province=@Province,City=@City,County=@County,Road=@Road,Number=@Number where Id=@Id";
            SqlParameter[] pms = {
                new SqlParameter("@Province", adress.Province),
                new SqlParameter("@City", adress.City),
                new SqlParameter("@County", adress.County),
                new SqlParameter("@Road", adress.Road),
                new SqlParameter("@Number", adress.Number),
                new SqlParameter("@Id", id)
            };

            int rows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql, pms);
            return rows > 0;
        }

        /// <summary>
        /// 根据ID查询地址
        /// </summary>
        public Adress Find(int id)
        {
            string sql = "select * from AddressInfo where Id=@Id";
            SqlParameter[] pms = {
                new SqlParameter("@Id", id)
            };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql, pms))
            {
                if (reader.Read())
                {
                    return new Adress
                    {
                        Id = (int)reader["Id"],
                        Province = reader["Province"].ToString(),
                        City = reader["City"].ToString(),
                        County = reader["County"].ToString(),
                        Road = reader["Road"].ToString(),
                        Number = reader["Number"].ToString()
                    };
                }
            }
            return null;
        }

        public void GetPageInfo(out int currentPage, out int totalPage, out int pageSize, out int totalCount)
        {
            currentPage = this.currentPage;
            totalPage = this.totalPage;
            pageSize = this.pageSize;
            totalCount = this.totalCount;

        }
    }
}