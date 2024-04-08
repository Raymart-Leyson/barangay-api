using CebuCityFamilyAPI.Dtos;
using CebuCityFamilyAPI.Models;

namespace CebuCityFamilyAPI.Services
{
    public interface IDetailsService
    {
        /// <summary>
        /// A method that creates a new Details entity
        /// </summary>
        /// <param name="detailstoCreate">
        /// Represents all the fields that will be outputted in the API
        /// </param>
        /// <returns>
        /// A DetailsDto object with selected fields from the entity itself
        /// </returns>
        public Task<DetailsDto> CreateDetails(DetailsCreationDto detailstoCreate);

        /// <summary>
        /// A method that gets all Details
        /// </summary>
        /// <returns>
        /// All Details
        /// </returns>
        public Task<IEnumerable<DetailsDto>> GetAllDetails();

        /// <summary>
        /// A method that gets details by <paramref name="id"/>
        /// </summary>
        /// <param name="id">
        /// Represents the Id of a Details entity
        /// </param>
        /// <returns>
        /// A DetailsDto object with selected fields from the entity itself
        /// </returns>
        public Task<IEnumerable<DetailsDto>> GetDetails(int id);

        /// <summary>
        /// A method that deletes a Details entity by <paramref name="id"/>
        /// </summary>
        /// <param name="id">
        /// Represents the id of a Details entity
        /// </param>
        public Task DeleteDetails(int id);

        /// <summary>
        /// A method that updates details of a family member
        /// </summary>
        /// <param name="id">
        /// Represents the Id of a Details entity
        /// </param>
        /// <param name="details">
        /// Represents all the fields needed to update the entity
        /// </param>
        /// <returns>
        /// A DetailsDto object with selected fields from the entity itself
        /// </returns>
        public Task<DetailsDto> UpdateDetails(int id, DetailsUpdationDto details);
    }
}
