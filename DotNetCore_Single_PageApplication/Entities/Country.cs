using System.ComponentModel.DataAnnotations;

namespace DotNetCore_Single_PageApplication.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string countryName { get; set; }
    }
}
