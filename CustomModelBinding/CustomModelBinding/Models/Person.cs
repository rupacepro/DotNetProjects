using System.ComponentModel.DataAnnotations;

namespace CustomModelBinding.Models
{
    public class Person
    {
        public int? Id { get; set; }
        public string? FullName {  get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone {  get; set; }
    }
}
