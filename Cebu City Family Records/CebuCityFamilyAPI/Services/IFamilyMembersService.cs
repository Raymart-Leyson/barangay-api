using CebuCityFamilyAPI.Dtos;
using CebuCityFamilyAPI.Models;

namespace CebuCityFamilyAPI.Services
{
    public interface IFamilyMembersService
    {
        /// <summary>
        /// Gets all FamilyMembers
        /// </summary>
        /// <returns>All FamilyMembers</returns>
        public Task<IEnumerable<FamilyMemberDto>> GetAllFamilyMembers();

        /// <summary>
        /// Gets a FamilyMember using their specific <paramref name="id"/>
        /// </summary>
        /// <param name="id">Integer ID</param>
        /// <returns>A FamilyMember</returns>
        public Task<IEnumerable<FamilyMembersDto>> GetFamilyMembersById(int id);

        /// <summary>
        /// Gets a FamilyMember with his/her Details using their specific <paramref name="id"/>
        /// </summary>
        /// <param name="id">Integer ID</param>
        /// <returns>A FamilyMember with his/her Details</returns>
        public Task<IEnumerable<FamilyMembersDto>> GetFamilyMemberDetailsById(int id);

        /// <summary>
        /// Gets a FamilyMember by their familyMember <paramref name="name"/>
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A FamilyMember</returns>
        public Task<IEnumerable<FamilyMembersDto>> GetFamilyMembersByName(string name);

        /// <summary>
        /// Gets a FamilyMember by their familyMember <paramref name="name"/>
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A FamilyMember</returns>
        public Task<FamilyMembers> GetFamilyMemberByName(string name);

        /// <summary>
        /// Gets a FamilyMember with his/her Details using their specific <paramref name="name"/>
        /// </summary>
        /// <param name="name">Represents the name of the Family Member</param>
        /// <returns>A FamilyMember with his/her Details</returns>
        public Task<IEnumerable<FamilyMembersDto>> GetFamilyMemberDetailsByName(string name);

        /// <summary>
        /// Updates a FamilyMember
        /// </summary>
        /// <param name="id">Specific ID of the FamilyMember</param>
        /// <param name="familyMembersToUpdate">FamilyMember to be Updated</param>
        /// <returns>The Updated FamilyMember</returns>
        public Task<FamilyMemberDto> UpdateFamilyMembers(int id, FamilyMembersUpdationDto familyMembersToUpdate);

        /// <summary>
        /// Deletes a FamilyMember
        /// </summary>
        /// <param name="name">Name of the familyMember</param>
        public Task DeleteFamilyMembers(String name);
    }
}