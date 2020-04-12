using Nzh.Faker.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Model
{
    [Table("Organize")]
    public class OrganizeModel : Entity
    {
        public int ParentId { get; set; }

        public string EnCode { get; set; }

        public string FullName { get; set; }

        public int CategoryId { get; set; }

        [Computed]
        public string CategoryName { get; set; }
    }
}
