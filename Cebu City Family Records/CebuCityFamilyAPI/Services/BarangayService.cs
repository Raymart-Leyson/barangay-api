using CebuCityFamilyAPI.Dtos;
using CebuCityFamilyAPI.Models;
using CebuCityFamilyAPI.Repositories;

namespace CebuCityFamilyAPI.Services
{
    public class BarangayService : IBarangayService
    {
        private readonly IBarangayRepository _repository;

        public BarangayService(IBarangayRepository repository)
        {
            _repository = repository;
        }

        public async Task<BarangayDto> CreateBarangay(BarangayCreationDto barangayToCreate)
        {
            var barangayModel = new Barangay
            {
                Name = barangayToCreate.Name,
                Captain = barangayToCreate.Captain
            };

            barangayModel.Id = await _repository.CreateBarangay(barangayModel);

            return new BarangayDto
            {
                Id = barangayModel.Id,
                Name = barangayModel.Name,
                Captain = barangayModel.Captain
            };
        }

        public async Task<IEnumerable<BarangayDto>> GetAllBarangays()
        {
            var barangayModels = await _repository.GetAllBarangays();
            return barangayModels.Select(barangay => new BarangayDto
            {
                Id = barangay.Id,
                Name = barangay.Name,
                Captain = barangay.Captain
            });
        }

        public async Task<IEnumerable<BarangayDto>> GetBarangayById(int id)
        {
            var barangayModels = await _repository.GetBarangayById(id);

            return barangayModels.Select(model => new BarangayDto
            {
                Id = model.Id,
                Name = model.Name,
                Captain = model.Captain
            });
        }

        public async Task<IEnumerable<BarangayDto>> GetBarangayByName(string name)
        {
            var barangayModels = await _repository.GetBarangayByName(name);

            return barangayModels.Select(model => new BarangayDto
            {
                Id = model.Id,
                Name = model.Name,
                Captain = model.Captain
            });
        }

        public async Task<BarangayDto> UpdateBarangay(int id, BarangayUpdationDto barangayToUpdate)
        {
            var barangayModel = new Barangay
            {
                Id = id,
                Name = barangayToUpdate.Name,
                Captain = barangayToUpdate.Captain
            };

            var updatedBarangay = await _repository.UpdateBarangay(barangayModel);

            return new BarangayDto
            {
                Id = updatedBarangay.Id,
                Name = updatedBarangay.Name,
                Captain = updatedBarangay.Captain
            };
        }

        public async Task DeleteBarangay(String name)
        {
            await _repository.DeleteBarangay(name);
        }

        public async Task<int> CountBarangayName(string name)
        {
            return await _repository.CountBarangayName(name);
        }
    }
}
