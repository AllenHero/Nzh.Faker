using Nzh.Faker.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyAttribute = Nzh.Faker.Extension.KeyAttribute;

namespace Nzh.Faker.Model
{
    [Table("LogonLog")]
    public class LogonLogModel
    {

        [Key(true)]
        public int Id { get; set; }

        public string LogType { get; set; }

        public string Account { get; set; }

        public string RealName { get; set; }

        public string Description { get; set; }

        public string IPAddress { get; set; }

        public string IPAddressName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Computed]
        public string StartEndDate { get; set; }
    }
}
