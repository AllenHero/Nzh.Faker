using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.IRepository
{
    public interface IMenuRepository : IBaseRepository<MenuModel>
    {
        IEnumerable<MenuModel> GetMenuListByRoleId(string sql, int roleId);
    }
}
