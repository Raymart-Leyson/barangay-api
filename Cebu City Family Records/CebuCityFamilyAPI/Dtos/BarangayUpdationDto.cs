using System.ComponentModel.DataAnnotations;

namespace CebuCityFamilyAPI.Dtos
{
    public class BarangayUpdationDto
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Captain is Required")]
        public string Captain { get; set; }
    }
}
