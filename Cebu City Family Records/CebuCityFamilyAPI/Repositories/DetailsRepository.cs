using CebuCityFamilyAPI.Context;
using CebuCityFamilyAPI.Models;
using Dapper;
using System.Data;

namespace CebuCityFamilyAPI.Repositories
{
    public class DetailsRepository : IDetailsRepository
    {
        private readonly DapperContext _context;

        public DetailsRepository(DapperContext con)
        {
            _context = con;
        }

        public async Task<int> CreateDetails(Details details)
        {
            var procedure = "[spDetails_CreateDetails]";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(procedure, new
                {
                    details.Age,
                    details.CivilStatus,
                    details.DateOfBirth,
                    details.Gender,
                    details.Occupation,
                    details.PhoneNumber,
                    details.Religion,
                    details.FmId
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> DeleteDetails(int id)
        {
            var procedure = "[spDetails_DeleteDetails]";
            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(procedure, new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Details>> GetAllDetails()
        {
            var procedure = "SELECT * FROM Details";

            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<Details>(procedure);
                return result.ToList();
            }
        }
        public async Task<IEnumerable<Details>> GetDetails(int id)
        {
            var procedure = "SELECT * FROM Details WHERE Details.Id = @id";
            using (var con = _context.CreateConnection())
            {
                 return await con.QueryAsync<Details>(procedure, new { id });
            }
        }

        public async Task<Details> UpdateDetails(Details details)
        {
            var procedure = "spDetails_UpdateDetails";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<Details>(procedure, new
                {
                    details.Id,
                    details.Age,
                    details.CivilStatus,
                    details.Occupation,
                    details.PhoneNumber,
                    details.Religion
                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
