using Nzh.Faker.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Model
{
    [Table("Items")]
    public class ItemsModel : Entity
    {
        public int ParentId { get; set; }

        public string EnCode { get; set; }

        public string FullName { get; set; }
    }
}
