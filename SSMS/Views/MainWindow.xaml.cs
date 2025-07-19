using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SSMS.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if(AppDate.Instance.CurrentUser.Role == 0)
            {
                container.Content = new StudentView();
            }
            else
            {
                container.Content = new IndexView();
            }
        }

        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;

            if (button != null)
            {
                if (button.Content.ToString() == "首页")
                    container.Content = new IndexView();
                else if (button.Content.ToString() == "用户管理")
                    container.Content = new StudentView();
            }
        }
    }
}
