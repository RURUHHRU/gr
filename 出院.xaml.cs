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
    /// 出院.xaml 的交互逻辑
    /// </summary>
    public partial class 出院 : Window
    {
        private int pageSize = 15;
        public int currentPage = 1;
        int pageCount;
        List<管理列表> list;
        public string totalCount2 => $"{currentPage}页";
        public string totalCount1 => $"共{pageCount}页";
        public 出院()
        {
            InitializeComponent();
            using (var context = new MyDbContext())
            {
                int startIndex = (currentPage - 1) * pageSize;
                list = context._管理列表.OrderByDescending(x => x.Id).Where(x=>x._6!=null).ToList();
                int totalCount = context._管理列表.ToList().Count;
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
                list = context._管理列表.OrderByDescending(x => x.Id).Where(x=>x._6!=null).ToList();
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
                if (context._管理列表.FirstOrDefault(x => x._5 == _5.Text) == null) T = false;
                query = query.Where(x => x._5 == _5.Text);
            }
           
            if (!string.IsNullOrEmpty(_7.Text))
            {
                if (context._管理列表.FirstOrDefault(x => x._7 == _7.Text) == null) T = false;
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
            list = query.Where(x=>x._6!=null).ToList();
            列表.ItemsSource = list.OrderByDescending(x => x.Id).Skip(startIndex).Take(pageSize);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _9.Text = string.Empty;
            _8.Text = string.Empty;
            _7.Text = string.Empty;
            _5.Text = string.Empty;
            _4.Text = string.Empty;
            _3.Text = string.Empty;
            _2.Text = string.Empty;
            _1.Text = string.Empty;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_1.Text) && !string.IsNullOrEmpty(_2.Text) && !string.IsNullOrEmpty(_4.Text)&&!String.IsNullOrEmpty(_5.Text))
            {
                using (MyDbContext context = new MyDbContext())
                {
                   var Y= context._管理列表.Where(x => x._1 == _1.Text).Where(x => x._2==_2.Text).Where(x => x._4 == _4.Text);
                    if (!Y.Any()) { MessageBox.Show("\t无消息"); return; }
                    Y.ToList().ForEach(x =>x._6=_5.Text);
                    context.SaveChanges();
                    MessageBox.Show("\t添加成功", "提示", MessageBoxButton.OK, MessageBoxImage.None);
                    UpdateData();
                    return;
                }
            }
            if (string.IsNullOrEmpty(_1.Text)) { MessageBox.Show("\t输入姓名", "提示", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (string.IsNullOrEmpty(_2.Text)) { MessageBox.Show("\t输入性别", "提示", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (string.IsNullOrEmpty(_4.Text)) { MessageBox.Show("\t输入病例科室", "提示", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (string.IsNullOrEmpty(_5.Text)) { MessageBox.Show("\t输入出院时间", "提示", MessageBoxButton.OK, MessageBoxImage.Error); return; }

        }
    }
}
