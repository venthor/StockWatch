using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatch.Services
{
    public class BaseService
    {
        protected IModelContext context;
        protected ILog log;

        public BaseService(IModelContext context, ILog log)
        {
            this.context = context;
            this.log = log;
        }

        protected ServiceResponse<T> Execute<T>(Func<T> func)
        {
            var response = new ServiceResponse<T>();
            try
            {
                response.Result = func.Invoke();
                response.HasError = false;
                response.Exception = null;
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                response.Result = default(T);
                response.HasError = true;
                response.Exception = ex;
            }
            return response;
        }




    }
}
