using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.IService
{
    public interface IModuleService : IBaseService<ModuleModel>
    {
        dynamic GetModuleList(int roleId);

        IEnumerable<TreeSelect> GetModuleTreeSelect();

        IEnumerable<ModuleModel> GetModuleButtonList(int roleId);
    }
}
