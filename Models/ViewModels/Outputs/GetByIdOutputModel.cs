using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerClient.Models.ViewModels.Outputs
{
    public class GetByIdOutputModel
    {
        public DataSearch data { get; set; }
        public bool isSuccess { get; set; }
        public object message { get; set; }
        public List<object> messages { get; set; }
    }
    public class DataSearch
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string birthDate { get; set; }
        public string nationalIdentifier { get; set; }
        public bool isActive { get; set; }
        public DateTime deletedDate { get; set; }

    }

   
}
