using Nzh.Faker.Common;
using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.IRepository
{
    public interface IButtonRepository : IBaseRepository<ButtonModel>
    {
        IEnumerable<ButtonModel> GetButtonListByRoleIdMenuId(int roleId, int menuId, PositionEnum position);

        IEnumerable<ButtonModel> GetButtonListByRoleIdMenuId(int roleId, int menuId, out IEnumerable<ButtonModel> selectList);
    }
}
