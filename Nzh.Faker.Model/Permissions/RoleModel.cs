using Nzh.Faker.Extension;
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
        public string EnCode { get; set; }

        public string FullName { get; set; }

        public int TypeClass { get; set; }

        [Computed]
        public string TypeName { get; set; }
    }
}
