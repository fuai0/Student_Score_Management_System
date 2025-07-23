using SSMS.BLL;
using SSMS.Helper;
using SSMS.Models;
using SSMS.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MessageBox = SSMS.Views.MessageBox;

namespace SSMS.ViewModels
{
    public class StudentViewModel:ObservableObject
    {
        public List<Student> students;

        public List<Student> Students 
        {
            get { return students; }
            set { students = value; RaisePropertyChanged(); }
        }

        public ICommand LoadedCommand { get;}
        public ICommand MarkerCommand { get;}

        public StudentViewModel()
        {
            LoadedCommand = new DelegateCommand(OnLoadedCommand);
            MarkerCommand = new DelegateCommand(OnMarkerCommand);
        }

        private void OnLoadedCommand()
        {
            Students = StudentService.Instance.GetAll();
        }

        private void OnMarkerCommand()
        {
            MessageBox messageBox = new MessageBox();
            messageBox.ShowDialog();
        }
    }
}
