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
using System.Windows.Navigation;
using System.Data;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1
{
    /// <summary>
    /// 管理.xaml 的交互逻辑
    /// </summary>
    public partial class 管理 : Window
    {
        private int pageSize = 15;
        public int currentPage = 1;
        int pageCount;
        List<管理列表> list;
        public string totalCount2 => $"{currentPage}页";
        public string totalCount1 => $"共{pageCount}页";
        public 管理()
        {
            InitializeComponent();

            using (var context = new MyDbContext())
            {
                int startIndex = (currentPage - 1) * pageSize;
                list = context._管理列表.OrderByDescending(x => x.Id).ToList();
                int totalCount = context._管理列表.ToList().Count;
                list.ForEach(x =>
                {
                    if (x._6 == null) x._6 = "未出院";
                });
                pageCount = (int)Math.Ceiling((double)totalCount / pageSize);
                列表.ItemsSource = list.Skip(startIndex).Take(pageSize);
                label2.Content = totalCount2;
                label1.Content = totalCount1;
            }
        }

        private void UpdateData()
        {
            int startIndex = (currentPage - 1) * pageSize;
            using (var context = new MyDbContext())
            {
                list = context._管理列表.OrderByDescending(x => x.Id).ToList();
                list.ForEach(x => 
                {
                    if (x._6 == null) x._6 = "未出院";
                });
                列表.ItemsSource = list.Skip(startIndex).Take(pageSize);
                label2.Content = totalCount2;
                label1.Content = totalCount1;
            }
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                UpdateData();
            }
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage < pageCount)
            {
                currentPage++;
                UpdateData();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            bool T = true;
            int startIndex = (currentPage - 1) * pageSize;
            MyDbContext context = new MyDbContext();
            var query = context._管理列表.AsQueryable();

            if (!string.IsNullOrEmpty(_1.Text))
            {
                if (context._管理列表.FirstOrDefault(x => x._1 == _1.Text) == null) T = false;
                query = query.Where(x => x._1 == _1.Text);
            }

            if (!string.IsNullOrEmpty(_2.Text))
            {
                if (context._管理列表.FirstOrDefault(x => x._2 == _2.Text) == null) T = false;
                query = query.Where(x => x._2 == _2.Text);
            }

            if (!string.IsNullOrEmpty(_3.Text))
            {
                if (context._管理列表.FirstOrDefault(x => x._3 == _3.Text) == null) T = false;
                query = query.Where(x => x._3 == _3.Text);
            }

            if (!string.IsNullOrEmpty(_4.Text))
                
            {
                if (context._管理列表.FirstOrDefault(x => x._4 == _4.Text) == null) T = false;
                query = query.Where(x => x._4 == _4.Text);
            }
            if (!string.IsNullOrEmpty(_5.Text))
            {
                if (context._管理列表.FirstOrDefault(x => x._5== _5.Text) == null) T = false;
                query = query.Where(x => x._5 == _5.Text);
            }              
            if (!string.IsNullOrEmpty(_6.Text))
            {
                if (context._管理列表.FirstOrDefault(x => x._6 == _6.Text) == null) T = true;
                 query = query.Where(x => x._6 == _6.Text);
            }
            if (!string.IsNullOrEmpty(_7.Text))
            {
                if (context._管理列表.FirstOrDefault(x => x._7== _7.Text) == null) T = false;
                 query = query.Where(x => x._7 == _7.Text);
            }
              
            if (!string.IsNullOrEmpty(_8.Text))
            {
                if (context._管理列表.FirstOrDefault(x => x._8 == _8.Text) == null) T = false;
                query = query.Where(x => x._8 == _8.Text);
            }               
            if (!string.IsNullOrEmpty(_9.Text))
            {
                if (context._管理列表.FirstOrDefault(x => x._9 == _9.Text) == null) T = false;
                query = query.Where(x => x._9 == _9.Text);
            }
            if (!T) { MessageBox.Show("\t无信息", "提示"); return; }
             list = query.ToList();
            list.ForEach(x =>
            {
                if (x._6 == null) x._6 = "未出院";
            });
            列表.ItemsSource = list.OrderByDescending(x=>x.Id).Skip(startIndex).Take(pageSize);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _9.Text=string.Empty;
            _8.Text = string.Empty;
            _7.Text = string.Empty;
            _6.Text = string.Empty;
            _5.Text = string.Empty;
            _4.Text = string.Empty;
            _3.Text = string.Empty;
            _2.Text = string.Empty;
            _1.Text = string.Empty;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (sender is Button editButton)
            {
                if (editButton.DataContext is 管理列表 dataRow)
                {
                  
                    管理_弹出 editWindow = new 管理_弹出(dataRow);
                    editWindow._1.Text = dataRow._1;
                    editWindow._2.Text = dataRow._2;
                    editWindow._3.Text = dataRow._3;
                    editWindow._4.Text = dataRow._4;
                    editWindow._5.Text = dataRow._5;
                    editWindow._6.Text = dataRow._6;
                    editWindow._7.Text = dataRow._7;
                    editWindow._8.Text = dataRow._8;
                    editWindow._9.Text = dataRow._9;
                    editWindow.DataContext = dataRow;
                    if (editWindow.ShowDialog()==true)
                    {
                        UpdateData();
                    }
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            if (sender is Button editButton)
            {
                if (editButton.DataContext is 管理列表 dataRow)
                {
                    using (var dbContext = new MyDbContext())
                    {
                        var entityToDelete = dbContext._管理列表.Find(dataRow.Id);

                        if (entityToDelete != null)
                        {
                            if (MessageBox.Show("\t是否删除", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk) == MessageBoxResult.OK)
                            {
                            dbContext._管理列表.Remove(entityToDelete); 
                            dbContext.SaveChanges();
                            UpdateData();
                            }
                                
                        }
                    }
                }
            }    
        }
    }
}
