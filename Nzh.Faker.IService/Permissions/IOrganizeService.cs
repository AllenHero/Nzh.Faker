using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.IService
{
    public interface IOrganizeService : IBaseService<OrganizeModel>
    {
        IEnumerable<OrganizeModel> GetOrganizeList();

        IEnumerable<TreeSelect> GetOrganizeTreeSelect();
    }
}
