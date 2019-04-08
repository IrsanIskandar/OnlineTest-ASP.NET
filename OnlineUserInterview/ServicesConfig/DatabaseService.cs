using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using System.Data;

namespace OnlineUserInterview.ServicesConfig
{
    public class DatabaseService
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["OnlineInterviewTest"].ConnectionString;
        private static MySqlConnection sqlConnection;

        public static MySqlConnection Connection()
        {
            if (sqlConnection == null)
            {
                sqlConnection = new MySqlConnection();
                sqlConnection.ConnectionString = connectionString;
            }
            else if (sqlConnection != null)
            {
                sqlConnection = new MySqlConnection();
                sqlConnection.ConnectionString = connectionString;
                sqlConnection.Open();
            }
            else
            {
                sqlConnection = null;
            }

            return sqlConnection;
        }

        public static MySqlParameter Parameters(string param, object objParam)
        {
            return new MySqlParameter(parameterName: param, value: objParam);
        }

        public static List<MySqlParameter> GetParameter(List<MySqlParameter> parameters)
        {
            List<MySqlParameter> param = new List<MySqlParameter>();

            foreach (var item in param)
            {
                parameters.Add(item);
            }

            return param;
        }

        public static DataSet GetDataSet(string spName)
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (MySqlConnection myConn = Connection())
                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = myConn;
                    command.CommandText = spName;
                    command.CommandTimeout = 30;
                    command.CommandType = CommandType.StoredProcedure;

                    myConn.Open();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dataSet);
                    myConn.Close();
                }
            }
            catch (MySqlException MyExceptionex)
            {
                throw MyExceptionex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dataSet;
        }
    }

    public class SqlHelper<T>
    {
        public static IEnumerable<T> GetDataCollection(string spName, object param = null)
        {
            IEnumerable<T> result = new List<T>();

            using (MySqlConnection conn = DatabaseService.Connection())
            {
                result = conn.Query<T>(sql: spName, param: param, commandType: CommandType.StoredProcedure);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return result;
        }

        public async static Task<IEnumerable<T>> GetDataCollectionAsync(string spName, object param = null)
        {
            IEnumerable<T> result = new List<T>();

            using (MySqlConnection conn = DatabaseService.Connection())
            {
                result = await conn.QueryAsync<T>(sql: spName, param: param, commandType: CommandType.StoredProcedure);
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return result;
        }

        public async static Task<T> GetDataCollectionSingleAsync(string spName, object param = null)
        {
            using (MySqlConnection conn = DatabaseService.Connection())
            {
                T result = await conn.QueryFirstOrDefaultAsync<T>(sql: spName, param: param, commandType: CommandType.StoredProcedure);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                return result;
            }
        }

        public async static Task ExecuteDataAsync (string spName, object param = null)
        {
            using (MySqlConnection conn = DatabaseService.Connection())
            {
                await conn.ExecuteAsync(sql: spName, param: param, commandType: CommandType.StoredProcedure);
                conn.Close();
            }
        }
    }
}