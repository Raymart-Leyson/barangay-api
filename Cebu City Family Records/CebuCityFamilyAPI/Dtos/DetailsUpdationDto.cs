using System.ComponentModel.DataAnnotations;

namespace CebuCityFamilyAPI.Dtos
{
    public class DetailsUpdationDto
    {
        [Required(ErrorMessage = "Age is Required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "CivilStatus is Required")]
        public string CivilStatus { get; set; }
        [Required(ErrorMessage = "Occupation  is Required")]
        public string Occupation { get; set; }
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Religion  is Required")]
        public string Religion { get; set; }
    }
}
