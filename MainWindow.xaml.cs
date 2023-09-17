using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            name.Text = config.AppSettings.Settings["Username"].Value;
            password.Text = config.AppSettings.Settings["Password"].Value;
          
        }


        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            创建账号 _dl = new 创建账号();
            parentWindow.Content = _dl;
        }
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
              忘记密码 密码 = new();
               密码.ShowDialog();
            密码.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(name.Text, "^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("\t请输入正确账号", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        
            if (!Regex.IsMatch(password.Text, "^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("\t请输入正确密码", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            using (var context = new MyDbContext())
            {
                if (context._登录.FirstOrDefault(p => p.Name == name.Text) != null)
                {
                    if (context._登录.FirstOrDefault(p => p.Name == name.Text) != null)
                    {
                        Window parentWindow = Window.GetWindow(this);
                        登录 _dl = new();
                        parentWindow.Content = _dl;
                        _dl.zh.Text = name.Text;
                    }
                    else MessageBox.Show("\t密码错误", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("\t账号不存在", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Username"].Value = name.Text;
            config.AppSettings.Settings["Password"].Value = password.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
