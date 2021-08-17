using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class ShippingDetail
    {
       // [Required(ErrorMessage = "İsim Gerekli")]  //boş geçilemez demektir
        public string FirstName { get; set; }

       // [Required]
        public string LastName { get; set; }

       // [Required]
       // [DataType(DataType.EmailAddress)]   //mail adres olmalı dogrulaması
        public string Email { get; set; }

      //  [Required]
        public string City { get; set; }
  
        //[Required]
       // [MinLength(10, ErrorMessage ="Minimum 10 karakter olmalıdır"]
        public string Address { get; set; }

      //  [Required]
    //    [Range(18,65)]      //yaş için aralık verdik
        public int Age { get; set; }


    }
}
