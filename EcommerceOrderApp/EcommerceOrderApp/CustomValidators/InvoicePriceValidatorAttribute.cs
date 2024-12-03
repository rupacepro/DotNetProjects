using EcommerceOrderApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EcommerceOrderApp.CustomValidators
{
    public class InvoicePriceValidatorAttribute : ValidationAttribute
    {
        public InvoicePriceValidatorAttribute() { }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           if(value != null)
            {
                //get InvoiceTotal
                double invoiceTotal = (double)value;

                //get products using reflection
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));
                if (otherProperty != null)
                {
                    List<Product>? products = (List<Product>)otherProperty.GetValue(validationContext.ObjectInstance)!;
                    //calculate total price
                    if (products != null)
                    {
                        double? total = 0;
                        foreach (Product product in products)
                        {
                            total += product.Price * product.Quantity;
                        }
                        if (total > 0)
                        {
                            if (total != invoiceTotal)
                            {
                                return new ValidationResult($"Invoice price should be equal to the total cost of all products (i.e. {total}) in the order.");
                            }
                        }
                        else
                        {
                            return new ValidationResult("No products found to validate invoice price");
                        }
                        return ValidationResult.Success;
                    }
                    
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
