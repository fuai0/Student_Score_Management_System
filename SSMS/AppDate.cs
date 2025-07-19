using SSMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS
{
    public class AppDate
    {
        public string Name => "学生成绩管理系统";

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public Student CurrentUser { get; set; }

        /// <summary>
        /// 单例
        /// </summary>
        public static AppDate Instance = new Lazy<AppDate>(() => new AppDate()).Value;
    }
}
