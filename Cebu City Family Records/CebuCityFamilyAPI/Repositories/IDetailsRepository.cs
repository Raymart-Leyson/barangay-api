using CebuCityFamilyAPI.Models;

namespace CebuCityFamilyAPI.Repositories
{
    public interface IDetailsRepository
    {
        /// <summary>
        /// A method that gets all Details
        /// </summary>
        /// <returns>
        /// All Details
        /// </returns>
        public Task<IEnumerable<Details>> GetAllDetails();

        /// <summary>
        /// A method that gets details by <paramref name="id"/>
        /// </summary>
        /// <param name="id">
        /// Represents the Id of a Details Entity
        /// </param>
        /// <returns>
        /// Details with the id <paramref name="id"/>
        /// </returns>
        public Task<IEnumerable<Details>> GetDetails(int id);

        /// <summary>
        /// A method that creates a new Details entity
        /// </summary>
        /// <param name="details">
        /// Represents all the fields needed to create the entity
        /// </param>
        /// <returns>
        /// The Id or Primary Key of the newly created Details
        /// </returns>
        public Task<int> CreateDetails(Details details);

        /// <summary>
        /// A method that updates details of a family member
        /// </summary>
        /// <param name="details">
        /// Represents all the fields needed to update the entity
        /// </param>
        /// <returns>
        /// updated detail
        /// </returns>
        public Task<Details> UpdateDetails(Details details);

        /// <summary>
        /// A method that deletes a Details entity by <paramref name="id"/>
        /// </summary>
        /// <param name="id">
        /// Represents the id of a Details entity
        /// </param>
        /// <returns>
        /// An integer type that represents the number of rows affected
        /// </returns>
        public Task<int> DeleteDetails(int id);
    }
}
