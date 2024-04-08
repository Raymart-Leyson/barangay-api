using CebuCityFamilyAPI.Dtos;
using CebuCityFamilyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CebuCityFamilyAPI.Controllers
{
    [Route("api/families")]
    [ApiController]
    public class FamiliesController : ControllerBase
    {
        private readonly IFamilyService _familyService;
        private readonly IFamilyMembersService _familyMembersService;
        private readonly IRegistrationService _registrationService;

        public FamiliesController(IFamilyService familyService, IFamilyMembersService familyMembersService, IRegistrationService registrationService)
        {
            _familyService = familyService;
            _familyMembersService = familyMembersService;
            _registrationService = registrationService;
        }
        /// <summary>
        /// Gets all Families
        /// </summary>
        /// <returns>Families</returns>
        [HttpGet(Name = "GetAllFamilies")]
        public async Task<IActionResult> GetFamilies()
        {
            try
            {
                var families = await _familyService.GetAllFamilies();
                if (families.IsNullOrEmpty())
                {
                    return NoContent();
                }
                return Ok(families);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }
        /// <summary>
        /// Gets the Family Members with their Details by their Family ID
        /// </summary>
        /// <returns>Family</returns>
        [HttpGet("{id}/members", Name = "GetFamilyById")]
        public async Task<IActionResult> GetFamilyById(int id)
        {
            try
            {
                var family = await _familyService.GetFamilyByBarangayId(id);
                if (family == null)
                    return NotFound($"Family with ID {id} does not exist.");

                var familyMembers = await _familyMembersService.GetFamilyMembersById(id);
                return Ok(familyMembers);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Gets the Family Members with their Details by their Family Name
        /// </summary>
        /// <returns>Family</returns>
        [HttpGet("search",Name = "GetFamilyByName")]
        public async Task<IActionResult> GetFamilyByName([FromQuery] String name)
        {
            try
            {
                var family = await _familyService.GetFamilyByName(name);
            if (family == null)
                return NotFound($"{name} family does not exist.");

                var familyMembers = await _familyMembersService.GetFamilyMembersByName(name);
                return Ok(familyMembers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Register a Family Member to an existing Family
        /// </summary>
        /// <param name="newFamilyMember">details</param>
        /// <returns>Returns the registered family member</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///      POST /api/FamiliesController/1/Registerfamilymember
        ///     {
        ///         "name": "Roy Gauson"
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created a family member</response>
        /// <response code="400">Family member detail is invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("{id}/member/register", Name = "RegisterFamilyMemberToFamily")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(FamilyDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterFamilyMember(int id, [FromBody] FamilyMembersCreationDto newFamilyMember)
        {
            try
            {
                var family = await _familyService.GetFamilyById(id);
                if (family == null)
                {
                    return NotFound($"Family with ID {id} does not exist");
                }
                var newFamilyMemberId = await _registrationService.RegisterFamilyMember(id, newFamilyMember);
                return CreatedAtAction(
                    nameof(FamilyMembersController.GetAllFamilyMembers),
                    "FamilyMembers",
                    new { id = newFamilyMemberId },
                    $"Successfully registered {newFamilyMember.Name} to {family.Name} Family");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Updates where a Family lives
        /// </summary>
        /// <param name="familyToUpdate">details</param>
        /// <returns>Returns updated family</returns>
        /// <remarks>
        ///      PUT api/FamiliesController/5
        ///     {
        ///         "sitio": "Sidlakan"
        ///     }
        /// </remarks>
        /// <response code="202">Successfully updated a family</response>
        /// <response code="400">Updated family detail is invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}", Name = "UpdateFamily")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(FamilyDto), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateFamily(int id, [FromBody] FamilyUpdationDto familyToUpdate)
        {
            try
            {

                var updateFamily = await _familyService.GetFamilyById(id);

                if (updateFamily == null)
                    return NotFound();

                var updatedFamily = await _familyService.UpdateFamily(id, familyToUpdate);
                return Ok(updatedFamily);

            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        /*/// <summary>
        /// Deletes a Family by their Family Name
        /// </summary>
        /// <returns>Deleted Family</returns>
        /// <response code="202">Successfully deleted a family</response>
        /// <response code="400">Family Name invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{name}", Name = "DeleteFamily")]
        [ProducesResponseType(typeof(FamilyDto), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteFamily(String name)
        {
            try
            {
                var familyToDelete = await _familyService.GetFamilyByName(name);
                if (familyToDelete == null)
                    return NotFound();

                await _familyService.DeleteFamily(name);
                return Ok("Family Successfully Deleted!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }*/

        /// <summary>
        /// Deletes a Family by their ID
        /// </summary>
        /// <returns>Deleted Family</returns>
        /// <response code="202">Successfully deleted a family</response>
        /// <response code="400">Family id invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}", Name = "DeleteFamilyById")]
        [ProducesResponseType(typeof(FamilyDto), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteFamilyById(int id)
        {
            try
            {
                var familyToDelete = await _familyService.GetFamilyById(id);
                if (familyToDelete == null)
                    return NotFound();

                await _familyService.DeleteFamilyById(id);
                return Ok("Family Successfully Deleted!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
