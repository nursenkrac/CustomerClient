using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerClient.Models
{
    public class SaveCustomer
    {
        [Required(ErrorMessage = "Lütfen bir kimlik no giriniz!")]
        [StringLength(maximumLength: 11, ErrorMessage = "En fazla 100 karakter girebilirisiniz!")]
        public string IdentityNo { get; set; }
        [Required(ErrorMessage = "Lütfen bir isim giriniz!")]
        [StringLength(maximumLength: 100, ErrorMessage = "En fazla 100 karakter girebilirisiniz!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen bir soy isim giriniz!")]
        [StringLength(maximumLength: 100, ErrorMessage = "En fazla 100 karakter girebilirisiniz!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen doğum tarihi giriniz!")]
        public DateTime BirthDate { get; set; }

    }
   
}
