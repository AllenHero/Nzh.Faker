using Nzh.Faker.Common;
using Nzh.Faker.IService;
using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Service
{
    public class LogService : BaseService<LogModel>, ILogService
    {
        public dynamic GetListByFilter(LogModel filter, PageInfo pageInfo)
        {
            string _where = " where 1=1";
            if (!string.IsNullOrEmpty(filter.Account))
            {
                _where += " and Account=@Account";
            }
            if (!string.IsNullOrEmpty(filter.RealName))
            {
                _where += " and RealName=@RealName";
            }
            _where = CreateTimeWhereStr(filter.StartEndDate, _where);
            return GetListByFilter(filter, pageInfo, _where);
        }

        public int WriteDbLog(LogModel model)
        {
            model.IPAddress = Net.Ip;
            //model.IPAddressName = Net.GetLocation(model.IPAddress);
            model.CreateTime = DateTime.Now;
            return BaseRepository.Insert(model);
        }
    }
}
