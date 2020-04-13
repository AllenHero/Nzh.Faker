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
        dynamic GetMenuList(int roleId);

        IEnumerable<TreeSelect> GetMenuTreeSelect();

        IEnumerable<MenuModel> GetMenuButtonList(int roleId);
    }
}
