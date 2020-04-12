using Dapper;
using Nzh.Faker.IRepository;
using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Repository
{
    public class ModuleRepository : BaseRepository<ModuleModel>, IModuleRepository
    {
        public IEnumerable<ModuleModel> GetModuleListByRoleId(string sql, int roleId)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                sql += @" WHERE 1=1
                        and a.RoleId = @RoleId
                        GROUP BY a.ModuleId
                        ORDER BY b.SortCode ASC";
                return conn.Query<ModuleModel>(sql, new { RoleId = roleId });
            }
        }
    }
}
