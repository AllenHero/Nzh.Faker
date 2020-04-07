﻿using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.IRepository
{
    public interface IDonationRepository : IBaseRepository<DonationModel>
    {
        /// <summary>
        /// 获得捐赠排行榜
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        IEnumerable<DonationModel> GetSumPriceTop(int num);
        /// <summary>
        /// 获得控制台显示数字
        /// </summary>
        /// <returns></returns>
        DonationModel GetConsoleNumShow();
    }
}
