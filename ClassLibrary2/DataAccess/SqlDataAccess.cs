using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary.DataAccess
{
    public static class SqlDataAccess
    {

        private static string GetConnectionString()
        {
            return "ConnectionString";
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                return cnn.Query<T>(sql).ToList();
        }
        public static List<T> LoadData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                return cnn.Query<T>(sql, data).ToList();
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                return cnn.Execute(sql, data);
        }

    }
}

