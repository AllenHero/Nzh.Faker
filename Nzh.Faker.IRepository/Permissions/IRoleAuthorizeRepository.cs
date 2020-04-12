using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.IRepository
{
    public interface IRoleAuthorizeRepository : IBaseRepository<RoleAuthorizeModel>
    {
        int SavePremission(IEnumerable<RoleAuthorizeModel> entitys, int roleId);
    }
}
