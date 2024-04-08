using CebuCityFamilyAPI.Dtos;
using CebuCityFamilyAPI.Models;

namespace CebuCityFamilyAPI.Services
{
    public interface IBarangayService
    {
        /// <summary>
        /// A method that returns all barangays.
        /// </summary>
        /// <returns>
        /// An IEnumerable of Barangay entities.
        /// </returns>
        public Task<IEnumerable<BarangayDto>> GetAllBarangays();

        /// <summary>
        /// A method that returns a barangay with a specific value of <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// Represents the Id or Primary Key of a barangay.
        /// </param>
        /// <returns>
        /// A Barangay entity.
        /// </returns>
        public Task<IEnumerable<BarangayDto>> GetBarangayById(int id);

        /// <summary>
        /// A method that returns a barangay with the name <paramref name="name"/>.
        /// </summary>
        /// <param name="name">
        /// Represents the Name of a barangay.
        /// </param>
        /// <returns>
        /// A Barangay entity.
        /// </returns>
        public Task<IEnumerable<BarangayDto>> GetBarangayByName(String name);


        /// <summary>
        /// A method that creates a Barangay entity.
        /// </summary>
        /// <param name="barangayToCreate">
        /// Represents all the fields needed to create the entity.
        /// </param>
        /// <returns>
        /// The newly created Barangay entity.
        /// </returns>
        public Task<BarangayDto> CreateBarangay(BarangayCreationDto barangayToCreate);

        /// <summary>
        /// A method that updates the Name and Captain of a Barangay entity.
        /// </summary>
        /// <param name="id">
        /// Represents the Id or Primary Key of the Barangay entity to be updated.
        /// </param>
        /// <param name="barangayToUpdate">
        /// Represents the new values to replace the old values from the Barangay entity.
        /// </param>
        /// <returns>
        /// The new state of the Barangay entity after updating.
        /// </returns>
        public Task<BarangayDto> UpdateBarangay(int id, BarangayUpdationDto barangayToUpdate);

        /// <summary>
        /// A method that deletes a Barangay entity with the name <paramref name="name"/>.
        /// </summary>
        /// <param name="name">
        /// Represents the Name of a barangay.
        /// </param>
        public Task DeleteBarangay(String name);

        /// <summary>
        /// A method that counts the number of specific barangays with the name <paramref name="name"/>.
        /// </summary>
        /// <param name="name">
        /// Represents the Name of a barangay.
        /// </param>
        /// <returns>
        /// An integer representing the count of specific barangays with the name <paramref name="name"/>.
        /// </returns>
        public Task<int> CountBarangayName(String name);
    }
}
