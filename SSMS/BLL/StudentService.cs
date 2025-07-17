using SSMS.DAL;
using SSMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.BLL
{

    /// <summary>
    /// 学生表的增删改查
    /// </summary>
    public class StudentService
    {
        /// <summary>
        /// 登录用户
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public List<Student> Login(Student student)
        {
            SqlHelper sqlHelper = new SqlHelper();
            DataSet dataSet = sqlHelper.ExecuteDataset($"select * from student where Name = '{student.Name}' and Password = '{student.Password}'");

            // ORM数据库和数据实体的映射关系实现
            List<Student> students = sqlHelper.DataSetToList<Student>(dataSet);

            return students;
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int Regsiter(Student student)
        {
            if (student == null) return -1;
            if (String.IsNullOrEmpty(student.Name)) return -1;
            if (String.IsNullOrEmpty(student.Password)) return -1;

            // 写入数据库
            SqlHelper sqlHelper = new SqlHelper();
            string sql = $"insert into Student (Name,Password,City,Sex,InsertDate,Role) values(@Name,@Password,@City,@Sex,@InsertDate,@Role)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name",student.Name),
                new SqlParameter("@Password",student.Password),
                new SqlParameter("@City",student.City),
                new SqlParameter("@Sex",student.Sex),
                new SqlParameter("@InsertDate",student.InsertDate),
                new SqlParameter("@Role",student.Role)
            };
            return sqlHelper.ExecuteNonQuery(sql,CommandType.Text,parameters);
        }

    }
}
