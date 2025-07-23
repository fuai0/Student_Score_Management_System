using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.DAL
{
    /// <summary>
    /// sql server数据库操作类
    /// </summary>
    public class SqlHelper
    {
        public static SqlHelper Instance = new Lazy<SqlHelper>(() => new SqlHelper()).Value;

        public string ConnectionString { get; }
        public SqlConnection sqlConnection { get;}

        public SqlHelper()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["StudentDBString"].ConnectionString;
            sqlConnection = new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// 预处理命令
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private SqlCommand PrepareCommand(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            if (sqlConnection == null) throw new ArgumentNullException("SqlConnection不能为空!");
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            if (sqlConnection.State != ConnectionState.Open) sqlConnection.Open();

            sqlCommand.CommandType = commandType;
            sqlCommand.CommandText = commandText;

            if(parameters != null && parameters.Length > 0)
            {
                AttchParameters(sqlCommand, parameters);
            }

            return sqlCommand;
        }

        private void AttchParameters(SqlCommand sqlCommand, SqlParameter[] parameters)
        {
            if (sqlCommand == null) throw new ArgumentNullException("sqlCommand不得为空!");
            if (parameters == null) throw new ArgumentNullException("parameters不得为空!");

            foreach(var item in parameters)
            {
                if(item != null)
                {
                    if(item.Value == null)
                    {
                        item.Value = DBNull.Value;
                    }
                    sqlCommand.Parameters.Add(item);
                }
            }
        }


        /// <summary>
        /// 执行SQL查询命令并返回DataSet,适用于需要返回多个结果集或离线数据处理的场景。
        /// </summary>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">SQL命令文本</param>
        /// <param name="parameters">SQL参数数组</param>
        /// <returns>包含查询结果的DataSet对象,包含零个或多个DataTable</returns>
        /// <exception cref="ArgumentNullException">当connection参数为null时抛出</exception>
        public DataSet ExecuteDataset(string commandText, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            SqlCommand sqlCommand = PrepareCommand(commandText, commandType, parameters);

            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
            {
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlConnection.Close();
                return dataSet;
            }
        }

        /// <summary>
        /// 执行非查询SQL命令（如 INSERT、UPDATE、DELETE）
        /// </summary>
        /// <param name="commandText">SQL命令文本</param>
        /// <param name="commandType">命令类型，默认为SQL文本</param>
        /// <param name="parameters">SQL参数数组，可选</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string commandText, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            SqlCommand sqlCommand = PrepareCommand(commandText, commandType, parameters);

            return sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// 将DataSet中的数据转换为指定类型的对象列表
        /// </summary>
        /// <typeparam name="T">目标对象类型,需具有无参构造函数</typeparam>
        /// <param name="dataSet">包含数据的DataSet对象</param>
        /// <param name="index">要转换的DataTable在DataSet中的索引，默认为第一个表</param>
        /// <returns>转换后的对象列表</returns>
        public List<T> DataSetToList<T>(DataSet dataSet,int index = 0)
        {
            List<T> list = new List<T>();

            if (dataSet == null || index < 0 || index > dataSet.Tables.Count - 1)
            {
                return list;
            }

            DataTable dataTable = dataSet.Tables[index];
            for(int i = 0;i < dataTable.Rows.Count;i++)
            {
                T t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertyInfos = t.GetType().GetProperties();
                foreach(var p in propertyInfos)
                {
                    for(int j = 0;j < dataTable.Columns.Count;j++)
                    {
                        if (p.Name.Equals(dataTable.Columns[j].ColumnName))
                        {
                            if (dataTable.Rows[i][j] != DBNull.Value)
                            {
                                // 将当前行的当前列的值转换给t.p
                                try
                                { 
                                    p.SetValue(t, Convert.ChangeType(dataTable.Rows[i][j], p.PropertyType), null);
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
                list.Add(t);
            }

            return list;
        }
    }
}


