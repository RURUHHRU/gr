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

namespace WpfApp1
{
    /// <summary>
    /// 登录.xaml 的交互逻辑
    /// </summary>
    public partial class 登录 : Page
    {
        public 登录()
        {
            InitializeComponent();
            this.Unloaded += (a, b) => {
                _gl?.Close();
                _gl1?.Close();
                _gl2?.Close();
                _gl3?.Close();
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("\t确定退出登录", "提示", MessageBoxButton.OKCancel, MessageBoxImage.None);
            if (result == MessageBoxResult.Cancel)
            {
                return;
            }
            else
            {
                MainWindow _dl = new MainWindow();
                _dl.Show();
                Window.GetWindow(this)?.Close();
                _gl?.Close();
                _gl1?.Close();
                _gl2?.Close();
                _gl3?.Close();
            }
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            忘记密码 密码 = new();
            密码.ShowDialog();
            密码.Focus();
        }
        private 管理 _gl1;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (_gl1 == null)
            {
                _gl1 = new 管理();
                _gl1.Closed += (s, args) => { _gl1 = null; };
                _gl1.Show();
            }
            else
            {
                _gl1.Focus();
            }
        }
          入院 _gl ;
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (_gl == null)
            {
                _gl = new 入院();
                _gl.Closed += (s, args) => { _gl = null; };
                _gl.Show();
            }
            else
            {
                _gl.Focus();
            }

        }
        出院 _gl2;
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (_gl2 == null)
            {
                _gl2 = new 出院();
                _gl2.Closed += (s, args) => { _gl2 = null; };
                _gl2.Show();
            }
            else
            {
                _gl2.Focus();
            }
        }
        床位 _gl3;
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (_gl3 == null)
            {
                _gl3 = new 床位();
                _gl3.Closed += (s, args) => { _gl3 = null; };
                _gl3.Show();
            }
            else
            {
                _gl3.Focus();
            }
        }
    }
}
