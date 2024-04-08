using CebuCityFamilyAPI.Context;
using CebuCityFamilyAPI.Models;
using Dapper;
using System.Data;

namespace CebuCityFamilyAPI.Repositories
{
    public class FamilyMembersRepository : IFamilyMembersRepository
    {
        private readonly DapperContext _context;

        public FamilyMembersRepository(DapperContext con)
        {
            _context = con;
        }

        public async Task<int> CreateFamilyMembers(FamilyMembers familyMembers)
        {
            var proc = "spFamilyMembers_CreateFamilyMembers";
            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(proc,
                    new
                    {
                        familyMembers.Name,
                        familyMembers.FId
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> DeleteFamilyMembers(String name)
        {
            var proc = "spFamilyMembers_DeleteFamilyMembers";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(proc, new { name }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<FamilyMembers>> GetAllFamilyMembers()
        {
            var sql = "SELECT * FROM FamilyMembers";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<FamilyMembers>(sql);
            }
        }

        public async Task<IEnumerable<FamilyMembers>> GetFamilyMembersById(int id)
        {
            var sql = "SELECT * FROM FamilyMembers as fm INNER JOIN Details as d ON fm.id = d.FmId WHERE fm.FId = @id;";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<FamilyMembers, Details, FamilyMembers>(sql, (fm,d) =>
                {
                    fm.Detail.Add(d);
                    return fm;
                }, new { id });
            }
        }

        public async Task<IEnumerable<FamilyMembers>> GetFamilyMemberDetailsById(int id)
        {
            var sql = "SELECT fm.Id, fm.Name, d.Id, d.Age, d.CivilStatus, d.DateOfBirth, d.Gender, d.Occupation, d.PhoneNumber, d.Religion FROM FamilyMembers as fm " +
                "INNER JOIN Details as d ON fm.Id = d.FmId WHERE fm.Id = @id;";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<FamilyMembers, Details, FamilyMembers>(sql, (fm, d) =>
                {
                    fm.Detail.Add(d);
                    return fm;
                }, new { id });
            }
        }

        public async Task<IEnumerable<FamilyMembers>> GetFamilyMembersByName(string name)
        {
            var proc = "spFamilyMembers_GetAllByFamilyName";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<FamilyMembers, Details, FamilyMembers>(proc, (fm, d) =>
                {
                    fm.Detail.Add(d);
                    return fm;
                }, new { name }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<FamilyMembers> GetFamilyMemberByName(string name)
        {
            var sql = "SELECT * FROM FamilyMembers WHERE Name = @name";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<FamilyMembers>(sql, new { name });
            }
        }

        public async Task<IEnumerable<FamilyMembers>> GetFamilyMemberDetailsByName(string name)
        {
            var sql = "SELECT fm.Id, fm.Name, d.Id, d.Age, d.CivilStatus, d.DateOfBirth, d.Gender, d.Occupation, d.PhoneNumber, d.Religion FROM FamilyMembers as fm " +
                "INNER JOIN Details as d ON fm.Id = d.FmId WHERE fm.Name = @name;";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<FamilyMembers, Details, FamilyMembers>(sql, (fm, d) =>
                {
                    fm.Detail.Add(d);
                    return fm;
                }, new { name });
            }
        }

        public async Task<FamilyMembers> UpdateFamilyMembers(FamilyMembers familyMembers)
        {
            var proc = "spFamilyMembers_UpdateFamilyMembers";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<FamilyMembers>(proc, new { familyMembers.Id, familyMembers.Name, familyMembers.FId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
