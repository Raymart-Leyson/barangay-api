using CebuCityFamilyAPI.Dtos;
using CebuCityFamilyAPI.Models;
using CebuCityFamilyAPI.Repositories;
using System.Reflection;

namespace CebuCityFamilyAPI.Services
{
    public class FamilyMembersService : IFamilyMembersService
    {
        private readonly IFamilyMembersRepository _repository;

        public FamilyMembersService(IFamilyMembersRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteFamilyMembers(string name)
        {
            await _repository.DeleteFamilyMembers(name);
        }

        public async Task<IEnumerable<FamilyMemberDto>> GetAllFamilyMembers()
        {
            var familyMembersModels = await _repository.GetAllFamilyMembers();
            return familyMembersModels.Select(familyMembers => new FamilyMemberDto
            {
                Id = familyMembers.Id,
                Name = familyMembers.Name,
            });
        }

        public async Task<IEnumerable<FamilyMembersDto>> GetFamilyMembersById(int id)
        {
            var familyMembersModels = await _repository.GetFamilyMembersById(id);
            return familyMembersModels.Select(model => new FamilyMembersDto
            {
                Id = model.Id,
                Name = model.Name,
                Details = model.Detail.Contains(null)? new List<FamilyMemberDetailsDto>() : model.Detail.Select(d => new FamilyMemberDetailsDto
                {
                    Age = d.Age,
                    CivilStatus = d.CivilStatus,
                    DateOfBirth = d.DateOfBirth,
                    Gender = d.Gender,
                    Occupation = d.Occupation,
                    PhoneNumber = d.PhoneNumber,
                    Religion = d.Religion
                })               
            });
        }

        public async Task<IEnumerable<FamilyMembersDto>> GetFamilyMemberDetailsById(int id)
        {
            var familyMembersModels = await _repository.GetFamilyMemberDetailsById(id);
            return familyMembersModels.Select(model => new FamilyMembersDto
            {
                Id = model.Id,
                Name = model.Name,
                Details = model.Detail.Contains(null) ? new List<FamilyMemberDetailsDto>() : model.Detail.Select(d => new FamilyMemberDetailsDto
                {
                    Age = d.Age,
                    CivilStatus = d.CivilStatus,
                    DateOfBirth = d.DateOfBirth,
                    Gender = d.Gender,
                    Occupation = d.Occupation,
                    PhoneNumber = d.PhoneNumber,
                    Religion = d.Religion
                })
            });
        }

        public async Task<IEnumerable<FamilyMembersDto>> GetFamilyMembersByName(string name)
        {
            var familyMembersModels = await _repository.GetFamilyMembersByName(name);
            return familyMembersModels.Select(model => new FamilyMembersDto
            {
                Id = model.Id,
                Name = model.Name,
                Details = model.Detail.Contains(null) ? new List<FamilyMemberDetailsDto>() : model.Detail.Select(d => new FamilyMemberDetailsDto
                {
                    Age = d.Age,
                    CivilStatus = d.CivilStatus,
                    DateOfBirth = d.DateOfBirth,
                    Gender = d.Gender,
                    Occupation = d.Occupation,
                    PhoneNumber = d.PhoneNumber,
                    Religion = d.Religion
                })
            });
        }

        public async Task<IEnumerable<FamilyMembersDto>> GetFamilyMemberDetailsByName(string name)
        {
            var familyMembersModels = await _repository.GetFamilyMemberDetailsByName(name);
            return familyMembersModels.Select(model => new FamilyMembersDto
            {
                Id = model.Id,
                Name = model.Name,
                Details = model.Detail.Contains(null) ? new List<FamilyMemberDetailsDto>() : model.Detail.Select(d => new FamilyMemberDetailsDto
                {
                    Age = d.Age,
                    CivilStatus = d.CivilStatus,
                    DateOfBirth = d.DateOfBirth,
                    Gender = d.Gender,
                    Occupation = d.Occupation,
                    PhoneNumber = d.PhoneNumber,
                    Religion = d.Religion
                })
            });
        }

        public async Task<FamilyMembers> GetFamilyMemberByName(string name)
        {
            return await _repository.GetFamilyMemberByName(name);
        }

        public async Task<FamilyMemberDto> UpdateFamilyMembers(int id, FamilyMembersUpdationDto familyMembersToUpdate)
        {
            var familyMembersModel = new FamilyMembers
            {
                Id = id,
                Name = familyMembersToUpdate.Name
            };
            var updatedMember = await _repository.UpdateFamilyMembers(familyMembersModel);
            return new FamilyMemberDto
            {
                Id = updatedMember.Id,
                Name = updatedMember.Name
            };
        }
    }
}
