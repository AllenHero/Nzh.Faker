using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.IService.Permissions
{
    public interface IMenuService : IBaseService<MenuModel>
    {
        dynamic GetModuleList(int roleId);

        IEnumerable<TreeSelect> GetModuleTreeSelect();

        IEnumerable<MenuModel> GetModuleButtonList(int roleId);
    }
}
