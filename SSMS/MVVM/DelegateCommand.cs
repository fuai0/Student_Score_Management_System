using SSMS.DAL;
using SSMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SSMS.MVVM
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action Action { get;}
        private Action<object> ObjectAction { get;}

        public DelegateCommand(Action action)
        {
            Action = action;
        }

        public DelegateCommand(Action<object> objectAction)
        {
            ObjectAction = objectAction;
        }

        public bool CanExecute(object parameter)
        {
            // 判断是否可以往下执行
            return true;
        }

        public void Execute(object parameter)
        {
            // 真正执行的代码
            Action?.Invoke();
            ObjectAction?.Invoke(parameter);
        }
    }
}
