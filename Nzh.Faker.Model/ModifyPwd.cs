using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Model
{
    public class ModifyPwd
    {
        public string UserName { get; set; }

        public string OldPassword { get; set; }

        public string Password { get; set; }

        public string Repassword { get; set; }
    }
}
