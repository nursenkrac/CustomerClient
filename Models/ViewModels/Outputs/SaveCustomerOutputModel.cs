using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerClient.Models.ViewModels.Outputs
{
    public class SaveCustomerOutputModel
    {
        public Data data { get; set; }
        public bool isSuccess { get; set; }
        public object message { get; set; }
        public List<object> messages { get; set; }
    }

    public class Data
    {
        public bool Status { get; set; }
        public string Token { get; set; }
    }
}
