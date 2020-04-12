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
        IEnumerable<ButtonModel> GetButtonListByRoleIdModuleId(int roleId, int moduleId, PositionEnum position);

        IEnumerable<ButtonModel> GetButtonListByRoleIdModuleId(int roleId, int moduleId, out IEnumerable<ButtonModel> selectList);
    }
}
