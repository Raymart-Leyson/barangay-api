using CebuCityFamilyAPI.Dtos;

namespace CebuCityFamilyAPI.Services
{
    public interface IRegistrationService
    {

        /// <summary>
        /// A method that registers a Family to a Barangay
        /// </summary>
        /// <param name="BId">
        /// Represents the Barangay Id of the newly registered Family
        /// </param>
        /// <param name="family">
        /// Represents the fields needed to register a Family
        /// </param>
        /// <returns>
        /// The Id or Primary Key of the newly registered Family
        /// </returns>
        public Task<int> Register(int BId, FamilyCreationDto family);

        /// <summary>
        /// A method that registers a Family Member to a Family
        /// </summary>
        /// <param name="FId">
        /// Represents the Family Id of the newly registered Family Member
        /// </param>
        /// <param name="familyMember">
        /// Represents the fields needed to register a Family Member
        /// </param>
        /// <returns>
        /// The Id or Primary Key of the newly registered Family Member
        /// </returns>
        public Task<int> RegisterFamilyMember(int FId, FamilyMembersCreationDto familyMember);

        /// <summary>
        /// A method that registers Details to a Family Member
        /// </summary>
        /// <param name="fmId">
        /// Represents the Family Member Id of the newly registered Details
        /// </param>
        /// <param name="details">
        /// Represents the fields needed to register Details
        /// </param>
        /// <returns>
        /// The Id or Primary Key of the newly registered Details
        /// </returns>
        public Task<int> RegisterFamilyMemberInformation(int fmId, DetailsCreationDto details);
    }
}
