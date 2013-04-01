using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatch.Services
{
    public class ServiceResponse<T>
    {

        /// <summary>
        /// Gets a value indicating if the service call threw an exception while executing
        /// </summary>
        public bool HasError { get; internal set; }

        /// <summary>
        /// Gets the exception that was thrown, if any
        /// </summary>
        public Exception Exception { get; internal set; }

        /// <summary>
        /// Gets the result of the service call
        /// </summary>
        public T Result { get; internal set; }

    }
}
