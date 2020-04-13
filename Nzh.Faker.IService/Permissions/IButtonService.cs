using Nzh.Faker.Common;
using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.IService
{
    public interface IButtonService : IBaseService<ButtonModel>
    {
        IEnumerable<ButtonModel> GetButtonListByRoleIdMenuId(int roleId, int menuId, PositionEnum position);

        string GetButtonListHtmlByRoleIdMenuId(int roleId, int menuId);
    }
}
