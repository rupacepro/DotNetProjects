using ModelBinding.CustomValidator;

namespace ModelBinding.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[MinimumYearValidator(ErrorMessage = "error message from model class")]
        [MinimumYearValidator(2005)]
        public DateTime BirthDate { get; set; }
    }
}
