using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;
using WpfApp1.ef;

namespace WpfApp1
{
    /// <summary>
    /// 管理_弹出.xaml 的交互逻辑
    /// </summary>
    public partial class 管理_弹出 : Window
    {
       
        public 管理_弹出(object T)
        {
            InitializeComponent();
            this.DataContext = T;
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dataRow = DataContext as 管理列表;//接收传来的数据
            if (dataRow != null)
            {
                using (var context = new MyDbContext())
                {
                    var myEntity = context._管理列表.FirstOrDefault(e => e.Id == dataRow.Id);
                    if (myEntity == null) throw new Exception("ID不存在");
                    if (MessageBox.Show("\t是否保存", "提示", MessageBoxButton.OKCancel,
                        MessageBoxImage.Information)
                        == MessageBoxResult.OK)
                    {
                    myEntity._1 = _1.Text ?? myEntity._1;myEntity._2 = _2.Text ?? myEntity._2;
                    myEntity._3 = _3.Text ?? myEntity._3;myEntity._4 = _4.Text ?? myEntity._4;
                    myEntity._8 = _8.Text ?? myEntity._8; myEntity._5 = _5.Text ?? myEntity._5;
                    myEntity._6 = _6.Text ?? myEntity._6;myEntity._7 = _7.Text ?? myEntity._7;
                     myEntity._9= _9.Text ?? myEntity._9;
                    context.SaveChanges();
                    }
                }
                Window.GetWindow(this).DialogResult = true;
                DataContext = dataRow;
            }
            else throw new Exception("\t管理_弹出窗口报错，转换失败");  
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dataRow = DataContext as 管理列表;//接收传来的数据
            _1.Text = dataRow._1;
            _2.Text = dataRow._2;
            _3.Text = dataRow._3;
            _4.Text = dataRow._4;
            _5.Text = dataRow._5;
            _6.Text = dataRow._6;
            _7.Text = dataRow._7;
            _8.Text = dataRow._8;
            _9.Text = dataRow._9;
        }
    }
}
