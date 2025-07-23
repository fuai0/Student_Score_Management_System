using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SSMS.Helper
{
    /// <summary>
    /// 遮盖助手
    /// </summary>
    public class Marker
    {
        public static Marker Instance = new Lazy<Marker>(() => new Marker()).Value;

        public Grid Grid { get; private set; }

        public void Init(Grid grid)
        {
            Grid = grid;
        }


        public void Show()
        {
            Grid.Visibility = System.Windows.Visibility.Visible;
        }
        
        public void Hide()
        {
            Grid.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
