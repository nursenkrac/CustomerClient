using CustomerClient.Models.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerClient.Models
{
    public class GetCustomer
    {
        public GetCustomerById CustomerById  {get; set; }
        public GetByIdOutputModel outputModel { get; set; }
    }
    public class GetCustomerById
    {
        [Required(ErrorMessage = "Lütfen bir Id no giriniz!")]
        public int Id { get; set; }
    }


}
