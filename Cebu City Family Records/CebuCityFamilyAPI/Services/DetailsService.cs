using CebuCityFamilyAPI.Dtos;
using CebuCityFamilyAPI.Models;
using CebuCityFamilyAPI.Repositories;
using System.Reflection;

namespace CebuCityFamilyAPI.Services
{
    public class DetailsService : IDetailsService
    {
        private readonly IDetailsRepository _repository;

        public DetailsService(IDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<DetailsDto> CreateDetails(DetailsCreationDto detailstoCreate)
        {
            var detailsModel = new Details
            {
                Age = detailstoCreate.Age,
                CivilStatus = detailstoCreate.CivilStatus,
                DateOfBirth = detailstoCreate.DateOfBirth,
                Gender = detailstoCreate.Gender,
                Occupation = detailstoCreate.Occupation,
                PhoneNumber = detailstoCreate.PhoneNumber,
                Religion = detailstoCreate.Religion
            };

            detailsModel.Id = await _repository.CreateDetails(detailsModel);

            return new DetailsDto
            {
                Age = detailsModel.Age,
                CivilStatus = detailsModel.CivilStatus,
                DateOfBirth = detailsModel.DateOfBirth,
                Gender = detailsModel.Gender,
                Occupation = detailsModel.Occupation,
                PhoneNumber = detailsModel.PhoneNumber,
                Religion= detailsModel.Religion,

            };
        }

        public async Task DeleteDetails(int id)
        {
            await _repository.DeleteDetails(id);
        }

        public async Task<IEnumerable<DetailsDto>> GetAllDetails()
        {
            var detailModel = await _repository.GetAllDetails();

            return detailModel.Select(model => new DetailsDto
            {
                Id = model.Id,
                Age = model.Age,
                CivilStatus = model.CivilStatus,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Occupation = model.Occupation,
                PhoneNumber = model.PhoneNumber,
                Religion = model.Religion
            });
        }

        public async Task<IEnumerable<DetailsDto>> GetDetails(int id)
        {
            var detailModels = await _repository.GetDetails(id);

            return detailModels.Select(model => new DetailsDto
            {
                Id = model.Id,
                Age = model.Age,
                CivilStatus = model.CivilStatus,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Occupation = model.Occupation,
                PhoneNumber = model.PhoneNumber,
                Religion = model.Religion
            });
        }

        public async Task<DetailsDto> UpdateDetails(int id, DetailsUpdationDto details)
        {
            var detailsModel = new Details
            {
                Id = id,
                Age = details.Age,
                CivilStatus = details.CivilStatus,
                Occupation = details.Occupation,
                PhoneNumber = details.PhoneNumber,
                Religion = details.Religion
            };

            var updatedDetails = await _repository.UpdateDetails(detailsModel);

            return new DetailsDto
            {
                Id = updatedDetails.Id,
                Age = updatedDetails.Age,
                CivilStatus = updatedDetails.CivilStatus,
                DateOfBirth = updatedDetails.DateOfBirth,
                Gender = updatedDetails.Gender,
                Occupation = updatedDetails.Occupation,
                PhoneNumber = updatedDetails.PhoneNumber,
                Religion = updatedDetails.Religion
            };
        }
    }
}
