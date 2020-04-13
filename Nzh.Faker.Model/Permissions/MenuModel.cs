using Nzh.Faker.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Model
{
    [Table("Menu")]
    public class MenuModel : Entity
    {
        public int ParentId { get; set; }

        public string FullName { get; set; }

        public string FontFamily { get; set; }

        public string Icon { get; set; }

        public string UrlAddress { get; set; }

        [Computed]
        public string ModuleButtonHtml { get; set; }

        [Computed]
        public bool IsChecked { get; set; }
    }
}
