using SSMS.DAL;
using SSMS.Models;
using SSMS.MVVM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using SSMS.Views;

namespace SSMS.ViewModels
{
    public class LoginViewModel
    {
        public Student Student { get; set; } = new Student();
        
        public DelegateCommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(Button_Click);
        }

        private void Button_Click()
        {
            SqlHelper sqlHelper = new SqlHelper();
            DataSet dataSet = sqlHelper.ExecuteDataset(new SqlConnection(sqlHelper.ConnectionString), System.Data.CommandType.Text, $"select * from student where Name = '{Student.Name}' and Password = '{Student.Password}'");

            var table = dataSet.Tables[0];
            var row = table.Rows[0];

            // ORM数据库和数据实体的映射关系实现
            List<Student> students = sqlHelper.DataSetToList<Student>(dataSet);

            if(students.Count > 0)
            {
                MessageBox.Show($"{Student.Name},恭喜你登录成功!");

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("您好,用户名或密码错误!"); 
            }


            //dataGrid.ItemsSource = dataSet.Tables[0].DefaultView;


            //var vm = this.DataContext;
            //var student = (vm as LoginViewModel).Student;
            //MessageBox.Show(student.Name);
        }
    }

}
