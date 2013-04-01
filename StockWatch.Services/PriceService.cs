using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockWatch.Models;

namespace StockWatch.Services
{
    public class PriceService :BaseService
    {
        public PriceService(IModelContext context, ILog log)
            : base(context, log)
        {
        }

        public ServiceResponse<PriceModel> GetCurrentPrice(PriceModel entity)
        {
            Func<PriceModel> func = delegate
            {
                return this.context.AsQueryable<PriceModel>().OrderBy(ph => ph.HistoryDate).First();

            };
            return this.Execute(func);
        }

        public ServiceResponse<PriceModel> SavePrice(PriceModel entity)
        {
            Func<PriceModel> func = delegate
            {
                entity.HistoryDate = DateTime.Now;
                return this.context.Save(entity);
            };
            return this.Execute(func);
        }


        
    }
}
