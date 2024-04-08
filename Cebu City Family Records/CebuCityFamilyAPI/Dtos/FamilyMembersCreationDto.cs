using System.ComponentModel.DataAnnotations;

namespace CebuCityFamilyAPI.Dtos
{
    public class FamilyMembersCreationDto
    {
        [Required(ErrorMessage = "Name is Required")]
        public string? Name { get; set; }
    }
}
