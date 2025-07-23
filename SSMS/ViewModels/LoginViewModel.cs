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
using SSMS.BLL;

namespace SSMS.ViewModels
{
    public class LoginViewModel
    {
        public Student Student { get; set; } = new Student() { Name="admin",Password="123456"};
        
        public DelegateCommand LoginCommand { get; }
        public DelegateCommand RegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(OnLoginCommand);
            RegisterCommand = new DelegateCommand(OnRegisterCommand);
        }

        private void OnRegisterCommand()
        {
            new RegisterWindow().ShowDialog();
        }

        /// <summary>
        /// 实现登录命令
        /// </summary>
        /// <param name="loginWindow">要关闭的登录界面</param>
        private void OnLoginCommand(object loginWindow)
        {
            List<Student> students = StudentService.Instance.Login(Student);

            if(students.Count > 0)
            {
                AppDate.Instance.CurrentUser = students[0];

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                if(loginWindow is LoginWindow _loginWindow)
                {
                    _loginWindow.Close();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("您好,用户名或密码错误!"); 
            }
        }
    }

}
