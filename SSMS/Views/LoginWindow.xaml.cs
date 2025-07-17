using SSMS.DAL;
using SSMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SSMS.Views
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //// 1.从配置文件中读取数据库连接字符串
            //var connectionString = ConfigurationManager.ConnectionStrings["StudentDBString"].ConnectionString;
            //// 2.创建 SQL Server 数据库连接对象
            //SqlConnection sqlConnection = new SqlConnection(connectionString);
            //// 3.打开数据库连接（与数据库建立物理连接）
            //sqlConnection.Open();

            //// 4.创建 SqlCommand 对象（关联到已打开的数据库连接）
            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //// 5.设置要执行的 SQL 命令文本
            //sqlCommand.CommandText = "select * from student";
            //// 6.指定命令类型为 SQL 文本（默认值，可省略）
            //sqlCommand.CommandType = System.Data.CommandType.Text;
            //// 7.显式关联命令到数据库连接（实际已通过 CreateCommand() 关联，可省略）
            //sqlCommand.Connection = sqlConnection;

            //// 8.创建 SqlDataAdapter，关联已配置好的 SqlCommand
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            //// 9.创建内存中的数据集容器
            //DataSet dataSet = new DataSet();
            //// 10.执行查询并将结果填充到 DataSet 中
            //sqlDataAdapter.Fill(dataSet);

            SqlHelper sqlHelper = new SqlHelper(); 
            DataSet dataSet = sqlHelper.ExecuteDataset("select * from student");

            
            var vm = this.DataContext;
            var student = (vm as LoginViewModel).Student;
            MessageBox.Show(student.Name);
        }
    }
}
