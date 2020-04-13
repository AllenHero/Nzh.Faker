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
        public int RoleId { get; set; }

        public int MenuId { get; set; }

        public int ButtonId { get; set; }
    }
}
