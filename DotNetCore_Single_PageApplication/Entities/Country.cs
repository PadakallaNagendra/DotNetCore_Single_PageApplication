using System.ComponentModel.DataAnnotations;

namespace DotNetCore_Single_PageApplication.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string countryName { get; set; }
        public string customername { get; set; }
         public string city { get; set; }
        public string email { get; set; }
    }
}
