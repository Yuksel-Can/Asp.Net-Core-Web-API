using FluentValidation;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.ValidationRules.FluentValidation
{
    public class ShippingDetailValidator: AbstractValidator<ShippingDetail>
    {
        public ShippingDetailValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().WithMessage("Adı gereklidir");
            RuleFor(s => s.FirstName).MinimumLength(2);
            RuleFor(s => s.LastName).NotEmpty();
            RuleFor(s => s.Address).NotEmpty();

            RuleFor(s => s.City).NotEmpty().When(s => s.Age < 18);  //konuyu anlamak için yazıldı ama saçma kural
           // RuleFor(s => s.FirstName).Must(StartWithA); //kendi metodumuzu kendimiz yazdık A ile başlama zorunluluğu koyduk
                                                        //amaç yazabiliyor olduğumuzu görmek
        }
       
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
