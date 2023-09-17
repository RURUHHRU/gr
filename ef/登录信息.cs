using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ef
{
   public class 登录信息
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Passde { set; get; }
    }
    public class 管理列表
    {
        [Key]
        public int Id { set; get; }
        public string ?_1 { set; get; }
        public string? _2 { set; get; }
        public string? _3 { set; get; }
        public string? _4 { set; get; }
        public string? _5 { set; get; }
        public string? _6 { set; get; }
        public string? _7 { set; get; }
        public string? _8 { set; get; }
        public string? _9 { set; get; }

    }

    public class 床位
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string 科室 { set; get; }
        public string 床位1 { set; get; }
        public string 床位号 { set; get; }
    }
    public class 管理绑定表
    {
        [Key]
     
        public string _1 { set; get; }
        public string _2 { set; get; }
        public string _3 { set; get; }
        public string _4 { set; get; }
        public string _5 { set; get; }
        public string _6 { set; get; }
        public string _7 { set; get; }
        public string _8 { set; get; }
        public string _9 { set; get; }

    }
}
