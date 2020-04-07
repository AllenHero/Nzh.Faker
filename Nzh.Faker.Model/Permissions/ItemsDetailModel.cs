using Nzh.Faker.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Model
{
    [Table("ItemsDetail")]
    public class ItemsDetailModel : Entity
    {
        /// <summary>
        /// 主表主键
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 字典分类
        /// </summary>
        [Computed]
        public string ItemType { get; set; }
    }
}
