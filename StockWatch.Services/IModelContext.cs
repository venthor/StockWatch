using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatch.Services
{
    public interface IModelContext :  IDisposable
    {
        System.Linq.IQueryable<T> AsQueryable<T>(params string[] includes) where T : StockWatch.Models.Entity;
        bool Delete<T>(int id) where T : StockWatch.Models.Entity;
        bool Delete<T>(T entity) where T : StockWatch.Models.Entity;
        T Find<T>(int id, params string[] includes) where T : StockWatch.Models.Entity;
        T Get<T>(int id, params string[] includes) where T : StockWatch.Models.Entity;
        T Save<T>(T entity) where T : StockWatch.Models.Entity;
        StockWatch.Models.PriceModel GetPrice (int stockId);

    }
}
