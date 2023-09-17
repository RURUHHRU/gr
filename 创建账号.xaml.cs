using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WpfApp1.ef;

namespace WpfApp1
{
    /// <summary>
    /// 创建账号.xaml 的交互逻辑
    /// </summary>
    public partial class 创建账号 : Page
    {
       
        public 创建账号()
        {
            InitializeComponent();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "确定密码"|| textBox.Text == "密码:字母或数字组成" || textBox.Text == "账号:字母或数字组成")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "密码:字母或数字组成";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void TextBox_LostFocus1(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "账号:字母或数字组成";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void TextBox_LostFocus2(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "确定密码";
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(name.Text, "^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("请输入正确账号", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                name.Text = "账号:字母或数字组成";
                name.Foreground = Brushes.Gray; return;
            }
            else if (!Regex.IsMatch(password.Text, "^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("请输入正确密码", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox.Text = "密码:字母或数字组成";
                textBox.Foreground = Brushes.Gray; return;
            }
            else if (password.Text != textBox.Text)
            {
                MessageBox.Show("两次密码错误","提示",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                using (var context = new MyDbContext())
                {
                    if (context._登录.FirstOrDefault(p => p.Name == name.Text) != null) { MessageBox.Show("账号已存在"); return; }
                    context._登录.Add(new 登录信息
                    {
                        Name=name.Text,
                        Passde=password.Text,
                    } );
                    context.SaveChanges();

                    MessageBox.Show("创建成功,返回登录", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow _dl = new MainWindow();
                    _dl.Show();
                    _dl.name.Text = name.Text;
                    _dl.password.Text = password.Text;
                    Window.GetWindow(this)?.Close();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow _dl = new MainWindow();
            _dl.Show();
            Window.GetWindow(this)?.Close();
        }
    }

    
}
