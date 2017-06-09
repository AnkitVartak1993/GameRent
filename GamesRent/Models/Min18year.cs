using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GamesRent.Models
{
    public class Min18year: ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 1 || customer.MembershipTypeId == 0)
                return ValidationResult.Success;
            if (customer.BirthDate == null)
                return new ValidationResult("Please Enter Birthdate");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return age>=18 ?  ValidationResult.Success : new ValidationResult("Only 18 years and above person is eligible for this membership");
          
        }

    }
}