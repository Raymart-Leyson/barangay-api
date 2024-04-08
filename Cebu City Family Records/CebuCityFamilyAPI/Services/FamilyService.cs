using CebuCityFamilyAPI.Dtos;
using CebuCityFamilyAPI.Models;
using CebuCityFamilyAPI.Repositories;

namespace CebuCityFamilyAPI.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _repository;

        public FamilyService(IFamilyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Family> CreateFamily(FamilyCreationDto familyToCreate)
        {
            var familyModel = new Family
            {
                Name = familyToCreate.Name,
                Sitio = familyToCreate.Sitio
            };

            familyModel.Id = await _repository.CreateFamily(familyModel);

            return familyModel;
        }

        /*public async Task DeleteFamily(String name)
        {
            await _repository.DeleteFamily(name);
        }*/

        public async Task DeleteFamilyById(int id)
        {
            await _repository.DeleteFamilyById(id);
        }

        public async Task<IEnumerable<FamilyDto>> GetAllFamilies()
        {
            var familyModel =  await _repository.GetAllFamilies();

            return familyModel.Select(family => new FamilyDto
            {
                Id = family.Id,
                Name = family.Name,
                Sitio = family.Sitio

            });
        }

        public async Task<IEnumerable<FamilyDto>> GetFamilyByBarangayId(int id)
        {
            var familyModels = await _repository.GetFamilyByBarangayId(id);

            return familyModels.Select(model => new FamilyDto
            {
                Id = model.Id,
                Name = model.Name,
                Sitio = model.Sitio
            });
        }

        public async Task<Family> GetFamilyById(int id)
        {
            return await _repository.GetFamilyById(id);
        }

        public async Task<IEnumerable<FamilyDto>> GetFamilyByName(string name)
        {
            var familyModels = await _repository.GetFamilyByName(name);

            return familyModels.Select(model => new FamilyDto
            {
                Id = model.Id,
                Name = model.Name,
                Sitio = model.Sitio
            });
        }

        public async Task<FamilyDto> UpdateFamily(int id, FamilyUpdationDto familyToUpdate)
        {
            var familyModel = new Family
            {
                Id = id,
                Sitio = familyToUpdate.Sitio
            };

            var updatedFam = await _repository.UpdateFamily(familyModel);

            return new FamilyDto
            {
                Id = updatedFam.Id,
                Name = updatedFam.Name,
                Sitio = updatedFam.Sitio
            };
        }
    }
}
