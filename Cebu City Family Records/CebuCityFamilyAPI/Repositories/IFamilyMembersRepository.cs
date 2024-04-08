using CebuCityFamilyAPI.Models;

namespace CebuCityFamilyAPI.Repositories
{
    public interface IFamilyMembersRepository
    {
        /// <summary>
        /// Gets all FamilyMembers from the Database
        /// </summary>
        /// <returns>An IEnumerable of all FamilyMembers</returns>
        public Task<IEnumerable<FamilyMembers>> GetAllFamilyMembers();

        /// <summary>
        /// Gets a FamilyMember from the Database using a specific value of <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Integer Id representing a FamilyMember</param>
        /// <returns>A FamilyMember specified by <paramref name="id"/></returns>
        public Task<IEnumerable<FamilyMembers>> GetFamilyMembersById(int id);

        /// <summary>
        /// Gets a FamilyMember with his/her Details from the Database using a specific value of <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Integer Id representing a FamilyMember</param>
        /// <returns>The FamilyMember with his/her Details specified by <paramref name="id"/></returns>
        public Task<IEnumerable<FamilyMembers>> GetFamilyMemberDetailsById(int id);

        /// <summary>
        /// Gets a FamilyMember from the Database using a specific string of <paramref name="name"/>.
        /// </summary>
        /// <param name="name">A String representing the FamilyMember Name</param>
        /// <returns>A FamilyMember specified by <paramref name="name"/> </returns>
        public Task<IEnumerable<FamilyMembers>> GetFamilyMembersByName(String name);

        /// <summary>
        /// Gets a FamilyMember from the Database using a specific string of <paramref name="name"/>.
        /// </summary>
        /// <param name="name">A String representing the FamilyMember Name</param>
        /// <returns>A FamilyMember specified by <paramref name="name"/> </returns>
        public Task<FamilyMembers> GetFamilyMemberByName(string name);

        /// <summary>
        /// Gets a FamilyMember with his/her Details from the Database using a specific value of <paramref name="name"/>.
        /// </summary>
        /// <param name="name">A String representing the FamilyMember Name</param>
        /// <returns>The FamilyMember with his/her Details specified by <paramref name="name"/></returns>
        public Task<IEnumerable<FamilyMembers>> GetFamilyMemberDetailsByName(string name);

        /// <summary>
        /// Creates a FamilyMember in the Database
        /// </summary>
        /// <param name="familyMembers">The values needed to create the entity</param>
        /// <returns>The ID of the newly created FamilyMember</returns>
        public Task<int> CreateFamilyMembers(FamilyMembers familyMembers);

        /// <summary>
        /// Updates an existing FamilyMember in the Database
        /// </summary>
        /// <param name="familyMembers">The values needed to update the entity</param>
        /// <returns>The Updated FamilyMember</returns>
        public Task<FamilyMembers> UpdateFamilyMembers(FamilyMembers familyMembers);

        /// <summary>
        /// Deletes an existing FamilyMember in the Database
        /// </summary>
        /// <param name="name">A String representing the FamilyMember Name</param>
        /// <returns>The number of row(s) affected in the Database</returns>
        public Task<int> DeleteFamilyMembers(String name);
    }
}
