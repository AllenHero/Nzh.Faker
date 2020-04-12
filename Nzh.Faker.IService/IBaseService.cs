using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.IService
{
    public interface IBaseService<T> where T : class, new()
    {
        T GetById(int Id);

        bool Insert(T model);

        bool UpdateById(T model);

        bool UpdateById(T model, string updateFields);

        bool DeleteById(int Id);

        bool DeleteByIds(object Ids);

        bool DeleteByWhere(string where);

        dynamic GetListByFilter(T filter, PageInfo pageInfo);

        IEnumerable<T> GetAll(string returnFields = null, string orderby = null);

        IEnumerable<T> GetByWhere(string where = null, object param = null, string returnFields = null, string orderby = null);
    }
}
