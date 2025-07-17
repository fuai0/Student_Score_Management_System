using SSMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.ViewModels
{
    public class MainViewModel
    {
        public Student CurrentUser => AppDate.Instance.CurrentUser;
    }
}
