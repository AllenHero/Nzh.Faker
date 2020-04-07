using Nzh.Faker.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Model
{
    [Table("RoleAuthorize")]
    public class RoleAuthorizeModel
    {
        /// <summary>
        /// 角色主键
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 模块主键
        /// </summary>
        public int ModuleId { get; set; }
        /// <summary>
        /// 按钮主键
        /// </summary>
        public int ButtonId { get; set; }
    }
}
