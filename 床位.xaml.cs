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
    /// 床位.xaml 的交互逻辑
    /// </summary>
    public partial class 床位 : Window
    {
        public 床位()
        {
            InitializeComponent();
            var T = new MyDbContext();
            列表.ItemsSource = T._床位.OrderByDescending(x => x.Id).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_1.Text != string.Empty && _3.Text != string.Empty && _7.Text != string.Empty)
            {
                using (var T = new MyDbContext())
                {
                    T._床位.Add(new ef.床位
                    {
                        Name = _1.Text,
                        床位1 = _7.Text,
                        床位号 = _3.Text,
                        科室 = _2.Text,
                    });
                    T.SaveChanges();
                    列表.ItemsSource= T._床位.OrderByDescending(x => x.Id).ToList();
                }
            }
            else MessageBox.Show("请输入姓名，床位，床位号");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyDbContext context = new MyDbContext();
            var query = context._床位.AsQueryable();

            if (!string.IsNullOrEmpty(_1.Text))
            {
                query = query.Where(x => x.Name== _1.Text);
            }
            if (!string.IsNullOrEmpty(_7.Text))
            {
               
                query = query.Where(x => x.床位1 == _7.Text);
            }
            if (!string.IsNullOrEmpty(_3.Text))
            {
                query = query.Where(x => x.床位号 == _3.Text);
            }
            if (!string.IsNullOrEmpty(_2.Text))
            {
              
                query = query.Where(x => x.科室 == _2.Text);
            }
            列表.ItemsSource = query.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
                if (sender is Button editButton)
                {
                    if (editButton.DataContext is WpfApp1.ef.床位 dataRow)
                    {
                        using (var dbContext = new MyDbContext())
                        {
                            var entityToDelete = dbContext._床位.Find(dataRow.Id);

                            if (entityToDelete != null)
                            {
                                if (MessageBox.Show("\t是否删除", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk) == MessageBoxResult.OK)
                                {
                                    dbContext._床位.Remove(entityToDelete);
                                    dbContext.SaveChanges();
                                    列表.ItemsSource = dbContext._床位.OrderByDescending(x => x.Id).ToList();
                                }

                            }
                        }
                    }
                }
        }
    }
}
