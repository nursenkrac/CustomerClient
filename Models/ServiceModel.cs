using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerClient.Models
{
    public class ServiceModel<T>
    {
        public T Data { get; private set; }
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
    }
}
