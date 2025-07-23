using SSMS.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Models
{
	/// <summary>
	/// 学生表
	/// </summary>
    public class Student:ObservableObject
    {
		private int id;
		/// <summary>
		/// 主键Id
		/// </summary>
		public int Id
		{
			get { return id; }
			set { id = value; RaisePropertyChanged(); }
		}

		private string name;
		/// <summary>
		/// 姓名
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; RaisePropertyChanged(); }
        }

		private string password;
		/// <summary>
		/// 密码
		/// </summary>
		public string Password
		{
			get { return password; }
			set { password = value; RaisePropertyChanged(); }
        }

		private bool sex;
		/// <summary>
		/// 性别 true为男,false为女
		/// </summary>
		public bool Sex
		{
			get { return sex; }
			set { sex = value; RaisePropertyChanged(); }
        }

		private string city;
		/// <summary>
		/// 城市
		/// </summary>
		public string City
		{
			get { return city; }
			set { city = value; RaisePropertyChanged(); }
        }

		private DateTime insertDate;
		/// <summary>
		/// 插入日期
		/// </summary>
		public DateTime InsertDate
		{
			get { return insertDate; }
			set { insertDate = value; RaisePropertyChanged(); }
        }

		private int role;
		/// <summary>
		/// 权限,1为普通学生,0为管理员
		/// </summary>
		public int Role
		{
			get { return role; }
			set { role = value; RaisePropertyChanged(); }
        }

	}
}
