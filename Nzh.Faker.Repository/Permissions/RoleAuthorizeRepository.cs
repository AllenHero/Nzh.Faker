using Nzh.Faker.Extension.SQLExts.MySQLExt;
using Nzh.Faker.IRepository;
using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Repository
{
    public class RoleAuthorizeRepository : BaseRepository<RoleAuthorizeModel>, IRoleAuthorizeRepository
    {
        public int SavePremission(IEnumerable<RoleAuthorizeModel> entitys, int roleId)
        {
            int result = 0;
            using (var conn = MySqlHelper.GetConnection())
            {
                IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    //先删除当前角色所有权限
                    conn.DeleteByWhere<RoleAuthorizeModel>("where RoleId=@RoleId", new { RoleId = roleId }, transaction);
                    if (entitys != null)
                    {
                        //批量插入权限
                        conn.InsertBatch<RoleAuthorizeModel>(entitys, transaction);
                    }
                    result = 1;
                    transaction.Commit();
                }
                catch (Exception)
                {
                    result = -1;
                    transaction.Rollback();
                }
            }
            return result;
        }
    }
}
