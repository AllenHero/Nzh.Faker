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
    public class Entity
    {
        [Key(true)]
        public int Id { get; set; }

        public virtual int SortCode { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        public int CreateUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "修改时间")]
        public DateTime UpdateTime { get; set; }

        public int UpdateUserId { get; set; }

        [Computed]
        public string StartEndDate { get; set; }
    }
}
