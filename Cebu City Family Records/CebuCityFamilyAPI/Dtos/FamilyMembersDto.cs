using CebuCityFamilyAPI.Models;

namespace CebuCityFamilyAPI.Dtos
{
    public class FamilyMembersDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<FamilyMemberDetailsDto> Details { get; set; }
    }
}
