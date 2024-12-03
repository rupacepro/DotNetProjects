using CustomValidationFromDateToDate.CustomValidations;

namespace CustomValidationFromDateToDate.Models
{
    public class Bill
    {
        public DateTime? FromDate { get; set; }

        [RangeValidator("FromDate", ErrorMessage = "From date must be older or same to the to date")]
        public DateTime? ToDate { get; set;}
    }
}
