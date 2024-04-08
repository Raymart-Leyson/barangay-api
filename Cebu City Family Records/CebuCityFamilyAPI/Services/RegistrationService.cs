using CebuCityFamilyAPI.Dtos;
using CebuCityFamilyAPI.Models;
using CebuCityFamilyAPI.Repositories;
using System.Security.Cryptography;

namespace CebuCityFamilyAPI.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IFamilyRepository _familyRepository;
        private readonly IFamilyMembersRepository _familyMembersRepository;
        private readonly IDetailsRepository _detailRepository;
        public RegistrationService(IFamilyRepository familyRepository, IDetailsRepository detailRepository, IFamilyMembersRepository familyMembersRepository)
        {
            _familyRepository = familyRepository;
            _detailRepository = detailRepository;
            _familyMembersRepository = familyMembersRepository;
        }
        public async Task<int> Register(int BId, FamilyCreationDto family)
        {
            var model = new Family
            {
                Name = family.Name,
                Sitio = family.Sitio,
                BId = BId,
                Barangay = new Barangay
                {
                    Id = BId
                }
            };
            return await _familyRepository.CreateFamily(model);
        }

        public  async Task<int> RegisterFamilyMember(int FId, FamilyMembersCreationDto familyMember)
        {
            var model = new FamilyMembers
            {
                Name = familyMember.Name,
                FId = FId,
                Family = new Family
                {
                    Id = FId
                }
            };
            return await _familyMembersRepository.CreateFamilyMembers(model);
        }

        public async Task<int> RegisterFamilyMemberInformation(int fmId, DetailsCreationDto details)
        {
            var model = new Details
            {
                Age = details.Age,
                CivilStatus = details.CivilStatus,
                DateOfBirth = details.DateOfBirth,
                Gender = details.Gender,
                Occupation = details.Occupation,
                PhoneNumber = details.PhoneNumber,
                Religion = details.Religion,
                FmId = fmId,
                FamilyMembers = new FamilyMembers
                {
                    Id = fmId
                }
            };
            return await _detailRepository.CreateDetails(model);
        }
    }
}
