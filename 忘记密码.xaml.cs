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
using System.Windows.Shapes;
using WpfApp1.ef;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// 忘记密码.xaml 的交互逻辑
    /// </summary>
    public partial class 忘记密码 : Window
    {
        public 忘记密码()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "旧密码"|| textBox.Text=="账号"|| textBox.Text == "新密码" || textBox.Text == "新账号")
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
                textBox.Text = "旧密码";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void TextBox_LostFocus1(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "账号";
                textBox.Foreground = Brushes.Gray;
            }
        }
         private void TextBox_LostFocus2(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "新密码";
                textBox.Foreground = Brushes.Gray;
            }
        }
        private void TextBox_LostFocus3(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "新账号";
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isNameValid = Regex.IsMatch(name.Text, "^[a-zA-Z0-9]+$");
            bool isXzhValid = Regex.IsMatch(xzh.Text, "^[a-zA-Z0-9]+$");
          
           
                if (!isNameValid)
                { 
                    MessageBox.Show("请输入正确账号", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                   textBox.Text = "账号";
                textBox.Foreground = Brushes.Gray; return;
                }   
            
            else if (!Regex.IsMatch(textBox.Text, "^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("请输入正确旧密码", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox.Text = "旧密码";
                textBox.Foreground = Brushes.Gray; return;
            }
            else if (password.Text == "新密码" && xzh.Text == "新账号")
            {
                MessageBox.Show("请选择修改账号或密码","提示",MessageBoxButton.OK, MessageBoxImage.None);
                return;
            }

            else if (!isXzhValid && xzh.Text != "新账号")
            {
                MessageBox.Show("新账号由数字或字母组成", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                xzh.Text = "新账号";
                xzh.Foreground = Brushes.Gray;
            }
            else if (!Regex.IsMatch(password.Text, "^[a-zA-Z0-9]+$") && password.Text != "新密码")
            {
                MessageBox.Show("新密码由数字或字母组成", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                password.Text = "新密码";
                password.Foreground = Brushes.Gray; return;
            }
            else
            {
                using (var context = new MyDbContext())
                {
                    var zh = context._登录.FirstOrDefault(p => p.Name == name.Text);
                    if (zh == null) 
                    { MessageBox.Show("账号不存在"); return; }
                   if( context._登录.Any(p => p.Name == xzh.Text))
                    {
                        MessageBox.Show("账号已经存在", "提示");
                        return;
                    }
                    if (zh.Passde != textBox.Text) { MessageBox.Show("旧密码不正确"); return; }
                    zh.Name= xzh.Text=="新账号" ?zh.Name: xzh.Text;
                    zh.Passde = password.Text!="新密码"?password.Text:zh.Passde;
                    context.SaveChanges();
                    MessageBox.Show("设置成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                  
                }
            }
        }
    }
}
