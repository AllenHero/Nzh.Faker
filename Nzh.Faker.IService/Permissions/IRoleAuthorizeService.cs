using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.IService
{
    public interface IRoleAuthorizeService : IBaseService<RoleAuthorizeModel>
    {
        int SavePremission(IEnumerable<RoleAuthorizeModel> entitys, int roleId);

        IEnumerable<RoleAuthorizeModel> GetListByRoleIdMenuId(int roleId, int menuId);
    }
}
