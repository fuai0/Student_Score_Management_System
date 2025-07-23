using SSMS.BLL;
using SSMS.DAL;
using SSMS.Models;
using SSMS.MVVM;
using SSMS.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SSMS.ViewModels
{
    public class RegisterViewModel
    {
        public Student Student { get; set; } = new Student();

        public bool IsBoy { get; set; } = true;
        public bool IsGril { get; set; } = false;

        public DelegateCommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new DelegateCommand(OnRegisterCommand);
        }


        /// <summary>
        /// 实现注册新用户命令
        /// </summary>
        private void OnRegisterCommand()
        {
            Student.Sex = IsBoy;
            Student.InsertDate = DateTime.Now;
            Student.Role = 1;

            int count = StudentService.Instance.Regsiter(Student);
            if(count == -1)
            {
                System.Windows.MessageBox.Show("请填写内容!");
            }
            else if(count == 0)
            {
                System.Windows.MessageBox.Show($"未能成功注册!");
            }
            else
            {
                System.Windows.MessageBox.Show($"{Student.Name},恭喜你成功注册!");
            }
        }
    }
}
