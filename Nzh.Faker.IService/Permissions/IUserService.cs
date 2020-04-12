using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.IService
{
    public interface IUserService : IBaseService<UserModel>
    {
        UserModel LoginOn(string username, string password);

        int ModifyUserPwd(ModifyPwd model, int userId);
    }
}
