using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CustomValidationFromDateToDate.CustomValidations
{
    public class RangeValidatorAttribute : ValidationAttribute
    {
        public string OtherProperty { get; set; }
        public RangeValidatorAttribute(string otherProperty)
        {
            OtherProperty = otherProperty;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                //to date
                DateTime toDate = (DateTime)value;
                //from date
                PropertyInfo? anotherProperty =  validationContext.ObjectType.GetProperty(OtherProperty);

                if(anotherProperty != null)
                {
                    DateTime fromDate = Convert.ToDateTime(anotherProperty.GetValue(validationContext.ObjectInstance));
                    if(toDate < fromDate)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
