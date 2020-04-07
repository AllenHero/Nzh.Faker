﻿using Nzh.Faker.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyAttribute = Nzh.Faker.Extension.KeyAttribute;

namespace Nzh.Faker.Model
{
    public class Entity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key(true)]
        public int Id { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        public virtual int SortCode { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        public int CreateUserId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "修改时间")]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 修改用户主键
        /// </summary>
        public int UpdateUserId { get; set; }
        /// <summary>
        /// 查询时间范围
        /// </summary>
        [Computed]
        public string StartEndDate { get; set; }
    }
}
