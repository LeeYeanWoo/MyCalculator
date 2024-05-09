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

namespace MyCalculator
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isHistoryVisible = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleHistoryVisibility()
        {
            if (isHistoryVisible)
            {
                historyGrid.Visibility = Visibility.Collapsed;
                keyPadGrid.Visibility = Visibility.Visible;
                isHistoryVisible = false;
            }
            else
            {
                historyGrid.Visibility = Visibility.Visible;
                keyPadGrid.Visibility = Visibility.Collapsed;
                isHistoryVisible = true;
            }
        }

        private void HistoryButtonClick(object sender, RoutedEventArgs e)
        {
            // 히스토리 표시창 토글
            ToggleHistoryVisibility();
        }
    }
}
