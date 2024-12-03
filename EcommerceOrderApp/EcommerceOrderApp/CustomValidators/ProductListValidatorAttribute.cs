using EcommerceOrderApp.Models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceOrderApp.CustomValidators
{
    public class ProductListValidatorAttribute : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "Order should have at least one product";
        public ProductListValidatorAttribute() { }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                List<Product> products = (List<Product>)value;
                if(products.Count > 0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage ?? DefaultErrorMessage, new string[] { nameof(validationContext.MemberName) });
                }
            }
            return new ValidationResult(ErrorMessage ?? DefaultErrorMessage, new string[] { nameof(validationContext.MemberName) });
        }
    }
}
