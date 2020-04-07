﻿using Nzh.Faker.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Model
{
    [Table("Donation")]
    public class DonationModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key(true)]
        public int Id { get; set; }
        /// <summary>
        /// 捐赠人
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 捐赠金额
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 捐赠方式
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Detail { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 捐赠总金额
        /// </summary>
        [Computed]
        public string TotalPrice { get; set; }
        /// <summary>
        /// 捐赠总次数
        /// </summary>
        [Computed]
        public string TotalNum { get; set; }
        /// <summary>
        /// 单笔最大金额
        /// </summary>
        [Computed]
        public string MaxPrice { get; set; }
        /// <summary>
        /// 捐赠人数
        /// </summary>
        [Computed]
        public string PeopleNum { get; set; }
    }
}
