using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaMVC.Model
{
    /// <summary>
    /// 商品类型
    /// </summary>
    public class GoodsType
    {
        /// <summary>
        /// 商品主键
        /// </summary>
        public int GTId { get; set; }
        /// <summary>
        /// 商品类别名称
        /// </summary>
        public string GTName { get; set; }
    }
}
