
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Data.Entity;
using System.Linq;
using StockWatch.Models;


namespace StockWatch.Data
{
    public class ModelContext : DbContext, StockWatch.Services.IModelContext
    {

        public ModelContext() { }

        public DbSet<StockModel> Stocks { get; set; }
        public DbSet<PriceModel> Prices { get; set; }



        public PriceModel GetPrice(int stockID)
        {
            return this.Set<PriceModel>().Single(pm => pm.StockId == stockID);
        }

        public IQueryable<T> AsQueryable<T>(params string[] includes) where T : Entity
        {
            var query = this.Set<T>().AsQueryable();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query;
        }

        public T Get<T>(int id, params string[] includes) where T : Entity
        {
            if (includes == null)
                return this.Set<T>().Single(x => x.Id == id);
            else
                return this.AsQueryable<T>(includes).Single(x => x.Id == id);
        }

        public T Find<T>(int id, params string[] includes) where T : Entity
        {
            if (includes == null)
                return this.Set<T>().Find(id);
            else
                return this.AsQueryable<T>(includes).SingleOrDefault(x => x.Id == id);
        }

        public bool Delete<T>(int id) where T : Entity
        {
            var entity = this.Find<T>(id);
            return this.Delete(entity);
        }

        public bool Delete<T>(T entity) where T : Entity
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "Entity can not be null when calling delete(entity)");

            this.Set<T>().Remove(entity);
            return this.SaveChanges() > 0;
        }
        public T Save<T>(T entity) where T : Entity
        {
            if (entity.Id > 0)
            {
                this.Entry(entity).State = System.Data.EntityState.Modified;
            }
            else
            {
                this.Set<T>().Add(entity);
            }
            this.SaveChanges();
            return entity;
        }



        
    }

   

}
