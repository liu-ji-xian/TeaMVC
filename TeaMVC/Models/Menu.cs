using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaMVC.Model
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 菜单主键
        /// </summary>
        public int Mid { get; set; }
        /// <summary>
        /// 菜单路径
        /// </summary>
        public string MUrl { get; set; }
    }
}
