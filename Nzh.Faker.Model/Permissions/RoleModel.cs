﻿using Nzh.Faker.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Model
{
    [Table("Role")]
    public class RoleModel : Entity
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int TypeClass { get; set; }
        /// <summary>
        /// 角色类型
        /// </summary>
        [Computed]
        public string TypeName { get; set; }
    }
}
