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
    public class Student
    {
		private int id;
		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string password;
		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		private bool sex;
		public bool Sex
		{
			get { return sex; }
			set { sex = value; }
		}

		private string city;
		public string City
		{
			get { return city; }
			set { city = value; }
		}

		private DateTime insertDate;
		public DateTime InsertDate
		{
			get { return insertDate; }
			set { insertDate = value; }
		}


	}
}
