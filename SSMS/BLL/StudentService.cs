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
        public static StudentService Instance = new Lazy<StudentService>(() => new StudentService()).Value;

        /// <summary>
        /// 登录用户
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public List<Student> Login(Student student)
        {
            DataSet dataSet = SqlHelper.Instance.ExecuteDataset($"select * from student where Name = '{student.Name}' and Password = '{student.Password}'");

            // ORM数据库和数据实体的映射关系实现
            List<Student> students = SqlHelper.Instance.DataSetToList<Student>(dataSet);

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
            return SqlHelper.Instance.ExecuteNonQuery(sql,CommandType.Text,parameters);
        }

        /// <summary>
        /// 获取所有用户数据
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAll()
        {

            string sql = "select * from student";

            DataSet dataSet = SqlHelper.Instance.ExecuteDataset(sql);
            List<Student> students = SqlHelper.Instance.DataSetToList<Student>(dataSet);
            return students;
        }

    }
}
