using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockWatch.Models;

namespace StockWatch.Services
{
    public class ModelService :BaseService
    {
        public ModelService(IModelContext context, ILog log)
            : base(context, log)
        {
        }

        public ServiceResponse<List<StockModel>> GetAllStocks()
        {
            Func<List<StockModel>> func = delegate
            {
                return this.context.AsQueryable<StockModel>().ToList();
            };
            return this.Execute(func);
        }


        public ServiceResponse<StockModel> GetStock(int id)
        {
            Func<StockModel> func = delegate
            {
                StockModel stock = this.context.Get<StockModel>(id);
                stock.Prices = this.context.AsQueryable<PriceModel>().Where(pm => pm.StockId == stock.Id).OrderBy(pm => pm.HistoryDate);
                return stock;

            };
            return this.Execute(func);
        }

        public ServiceResponse<StockModel> SaveStock(StockModel entity)
        {
            Func<StockModel> func = delegate
            {
                return this.context.Save(entity);
            };
            return this.Execute(func);
        }

        public ServiceResponse<bool> DeleteStock(int id)
        {
            Func<bool> func = delegate
            {
                return this.context.Delete<StockModel>(id);
            };
            return this.Execute(func);
        }

    }
}
