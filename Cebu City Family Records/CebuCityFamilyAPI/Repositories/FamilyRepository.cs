using CebuCityFamilyAPI.Context;
using CebuCityFamilyAPI.Models;
using Dapper;
using System.Data;

namespace CebuCityFamilyAPI.Repositories
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly DapperContext _context;

        public FamilyRepository(DapperContext con)
        {
            _context = con;
        }

        public async Task<int> CreateFamily(Family family)
        {
            var proc = "spFamily_CreateFamily";

            using ( var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(proc,
                    new
                    {
                        family.Name,
                        family.Sitio,
                        family.BId
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        /*public async Task<int> DeleteFamily(String name)
        {
            var proc = "spFamily_DeleteFamily";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(proc, new { name }, commandType: CommandType.StoredProcedure);
            }
        }*/

        public async Task<IEnumerable<Family>> GetAllFamilies()
        {
            var sql = "SELECT * FROM Family";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Family>(sql);
            }
        }

        public async Task<IEnumerable<Family>> GetFamilyByBarangayId(int id)
        {
            var sql = "SELECT * FROM Family as f WHERE f.BId = @id;";
            
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Family>(sql, new { id });
            }
        }

        public async Task<Family> GetFamilyById(int id)
        {
            var sql = "SELECT * FROM Family WHERE Id = @id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<Family>(sql, new { id });
            }
        }

        public async Task<IEnumerable<Family>> GetFamilyByName(string name)
        {
            var proc = "spFamily_GetAllByBarangayName";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Family>(proc, new { name }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Family> UpdateFamily(Family family)
        {
            var proc = "spFamily_UpdateFamily";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<Family>(proc, new { family.Id, family.Sitio }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> DeleteFamilyById(int id)
        {
            var proc = "spFamily_DeleteFamilyById";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(proc, new { id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

