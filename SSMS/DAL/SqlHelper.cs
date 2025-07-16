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
        public string ConnectionString { get; }

        public SqlHelper()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["StudentDBString"].ConnectionString;
        }

        /// <summary>
        /// 执行SQL命令并返回DataSet,适用于需要返回多个结果集或离线数据处理的场景。
        /// </summary>
        /// <param name="connection">数据库连接对象</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">SQL命令文本</param>
        /// <param name="parameters">SQL参数数组</param>
        /// <returns>包含查询结果的DataSet对象,包含零个或多个DataTable</returns>
        /// <exception cref="ArgumentNullException">当connection参数为null时抛出</exception>
        public DataSet ExecuteDataset(SqlConnection connection,CommandType commandType,string commandText,params SqlParameter[] parameters)
        {
            if (connection == null) throw new ArgumentNullException("SqlConnection不能为空!");
            SqlCommand sqlCommand = connection.CreateCommand();

            if (connection.State != ConnectionState.Open) connection.Open();

            sqlCommand.CommandType = commandType;
            sqlCommand.CommandText = commandText;
            using(SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
            {
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                connection.Close();
                return dataSet;
            }
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
