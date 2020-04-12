using Dapper;
using Nzh.Faker.Common;
using Nzh.Faker.IRepository;
using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Repository
{
    public class ButtonRepository : BaseRepository<ButtonModel>, IButtonRepository
    {
        public IEnumerable<ButtonModel> GetButtonListByRoleIdModuleId(int roleId, int moduleId, PositionEnum position)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                string sql = @"SELECT b.* FROM roleauthorize a
                            INNER JOIN button b ON a.ButtonId=b.Id
                            WHERE a.RoleId=@RoleId
                            and a.ModuleId=@ModuleId
                            and b.Location=@Location
                            ORDER BY b.SortCode";
                return conn.Query<ButtonModel>(sql, new { RoleId = roleId, ModuleId = moduleId, Location = (int)position });
            }
        }

        public IEnumerable<ButtonModel> GetButtonListByRoleIdModuleId(int roleId, int moduleId, out IEnumerable<ButtonModel> selectList)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(@"SELECT Id,FullName FROM button a
                            INNER JOIN roleauthorize b ON a.Id = b.ButtonId
                            WHERE b.RoleId = @RoleId and b.ModuleId = @ModuleId;");
                sb.AppendLine(@"SELECT Id, FullName FROM button");
                using (var reader = conn.QueryMultiple(sb.ToString(), new { RoleId = roleId, ModuleId = moduleId }))
                {
                    selectList = reader.Read<ButtonModel>();
                    return reader.Read<ButtonModel>();
                }
            }
        }
    }
}
