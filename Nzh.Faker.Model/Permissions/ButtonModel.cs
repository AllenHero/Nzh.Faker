using Nzh.Faker.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Model
{
    [Table("Button")]
    public class ButtonModel : Entity
    {
        public string EnCode { get; set; }

        public string FullName { get; set; }

        public int Location { get; set; }

        public string ClassName { get; set; }

        public string Icon { get; set; }
    }
}
