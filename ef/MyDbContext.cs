using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;

namespace WpfApp1.ef
{
    public class MyDbContext : DbContext
    {
        public DbSet<登录信息> _登录 { get; set; }
        public DbSet<管理列表> _管理列表 { get; set; }
        public DbSet<床位> _床位 { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=;User ID=sa;Password=;Database=桌面应用1;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }

}
