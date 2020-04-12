using Nzh.Faker.IRepository;
using Nzh.Faker.IService;
using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Service
{
    public class RoleAuthorizeService : BaseService<RoleAuthorizeModel>, IRoleAuthorizeService
    {
        public IRoleAuthorizeRepository RoleAuthorizeRepository { get; set; }

        public dynamic GetListByFilter(RoleAuthorizeModel filter, PageInfo pageInfo)
        {
            throw new NotImplementedException();
        }

        public int SavePremission(IEnumerable<RoleAuthorizeModel> entitys, int roleId)
        {
            return RoleAuthorizeRepository.SavePremission(entitys, roleId);
        }

        public IEnumerable<RoleAuthorizeModel> GetListByRoleIdModuleId(int roleId, int moduleId)
        {
            string where = "where RoleId=@RoleId and ModuleId=@ModuleId";
            return GetByWhere(where, new { RoleId = roleId, ModuleId = moduleId });
        }
    }
}
