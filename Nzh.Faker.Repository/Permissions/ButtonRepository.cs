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
        public IEnumerable<ButtonModel> GetButtonListByRoleIdMenuId(int roleId, int menuId, PositionEnum position)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                string sql = @"SELECT b.* FROM roleauthorize a
                            INNER JOIN button b ON a.ButtonId=b.Id
                            WHERE a.RoleId=@RoleId
                            and a.MenuId=@MenuId
                            and b.Location=@Location
                            ORDER BY b.SortCode";
                return conn.Query<ButtonModel>(sql, new { RoleId = roleId, MenuId = menuId, Location = (int)position });
            }
        }

        public IEnumerable<ButtonModel> GetButtonListByRoleIdMenuId(int roleId, int menuId, out IEnumerable<ButtonModel> selectList)
        {
            using (var conn = MySqlHelper.GetConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(@"SELECT Id,FullName FROM button a
                            INNER JOIN roleauthorize b ON a.Id = b.ButtonId
                            WHERE b.RoleId = @RoleId and b.MenuId = @MenuId;");
                sb.AppendLine(@"SELECT Id, FullName FROM button");
                using (var reader = conn.QueryMultiple(sb.ToString(), new { RoleId = roleId, MenuId = menuId }))
                {
                    selectList = reader.Read<ButtonModel>();
                    return reader.Read<ButtonModel>();
                }
            }
        }
    }
}
