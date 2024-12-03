using System.ComponentModel.DataAnnotations;

namespace EcommerceOrderApp.CustomValidators
{
    public class MinimumDateValidatorAttribute : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "Order Date should be greater than or equal to {0}";
        public DateTime MinimumDate { get; set; }
        public MinimumDateValidatorAttribute() { }

        public MinimumDateValidatorAttribute(string minimumDateString)
        {
            MinimumDate = Convert.ToDateTime(minimumDateString);
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime orderDate = (DateTime)value;
                if (orderDate < MinimumDate)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumDate.Year.ToString()));
                }
                return ValidationResult.Success;
            }
            return null;
        }
    }
}
