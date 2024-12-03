using EcommerceOrderApp.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace EcommerceOrderApp.Models
{
    public class Order
    {
        public int? OrderNo { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        //[MinimumDateValidator("2000-01-01", ErrorMessage = "Order date should be greater than or equal to 2000")]
        [MinimumDateValidator("2001-01-01")]
        public DateTime? OrderDate { get; set; }


        [Required(ErrorMessage = "{0} can't be blank")]
        [InvoicePriceValidator]
        [Range(0, double.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public double? InvoicePrice { get; set; }

        //[Required]
        [ProductListValidator]
        public List<Product>? Products { get; set; }
    }
}
