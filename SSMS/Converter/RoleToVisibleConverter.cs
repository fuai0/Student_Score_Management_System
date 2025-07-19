using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SSMS.Converter
{
    /// <summary>
    /// 将角色为0的字段,转换为控件显示
    /// </summary>
    public class RoleToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = Visibility.Collapsed;
            if (value == null) return result;
            if(int.TryParse(value.ToString(),out int r))
            {
                result = r == 0 ? Visibility.Visible : Visibility.Collapsed;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
