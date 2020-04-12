using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.IRepository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        T GetById(int Id);

        int Insert(T model);

        int UpdateById(T model);

        int UpdateById(T model, string updateFields);

        int DeleteById(int Id);

        int DeleteByIds(object Ids);

        int DeleteByWhere(string where);

        IEnumerable<T> GetByPage(SearchFilter filter, out long total);

        IEnumerable<T> GetByPageUnite(SearchFilter filter, out long total);

        IEnumerable<T> GetAll(string returnFields = null, string orderby = null);

        IEnumerable<T> GetByWhere(string where = null, object param = null, string returnFields = null, string orderby = null);
    }
}
