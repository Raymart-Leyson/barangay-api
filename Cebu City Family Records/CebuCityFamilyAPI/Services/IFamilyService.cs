using CebuCityFamilyAPI.Dtos;
using CebuCityFamilyAPI.Models;
using CebuCityFamilyAPI.Repositories;
using System.Collections.Generic;

namespace CebuCityFamilyAPI.Services
{
    public interface IFamilyService
    {
        /// <summary>
        /// Gets all Families
        /// </summary>
        /// <returns>All Families</returns>
        public Task<IEnumerable<FamilyDto>> GetAllFamilies();

        /// <summary>
        /// Gets a Family using their specific Barangay <paramref name="id"/>
        /// </summary>
        /// <param name="id">Integer ID</param>
        /// <returns>A Family</returns>
        public Task<IEnumerable<FamilyDto>> GetFamilyByBarangayId(int id);

        /// <summary>
        /// Gets a Family using their specific <paramref name="id"/>
        /// </summary>
        /// <param name="id">Integer ID representing a Barangay</param>
        /// <returns>A Family</returns>
        public Task<Family> GetFamilyById(int id);

        /// <summary>
        /// Gets a Family by their family <paramref name="name"/>
        /// </summary>
        /// <param name="name">The Name of the Family</param>
        /// <returns>A Family</returns>
        public Task<IEnumerable<FamilyDto>> GetFamilyByName(String name);

        /// <summary>
        /// Creates a Family
        /// </summary>
        /// <param name="familyToCreate">Family to be Created</param>
        /// <returns>The newly created Family</returns>
        public Task<Family> CreateFamily(FamilyCreationDto familyToCreate);
        
        /// <summary>
        /// Updates a Family
        /// </summary>
        /// <param name="id">Specific ID of the Family</param>
        /// <param name="familyToUpdate">Family to be Updated</param>
        /// <returns>The Updated Family</returns>
        public Task<FamilyDto> UpdateFamily(int id, FamilyUpdationDto familyToUpdate);
        
        /*/// <summary>
        /// Deletes a Family using their Family <paramref name="name"/>
        /// </summary>
        /// <param name="name">Name of the Family</param>
        public Task DeleteFamily(String name);*/

        /// <summary>
        /// Deletes a Family using their specific Family <paramref name="id"/>
        /// </summary>
        /// <param name="id">Specific ID of the Family</param>
        public Task DeleteFamilyById(int id);
    }
}
