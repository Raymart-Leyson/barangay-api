using CebuCityFamilyAPI.Dtos;
using CebuCityFamilyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CebuCityFamilyAPI.Controllers
{
    [Route("api/familymembers")]
    [ApiController]
    public class FamilyMembersController : ControllerBase
    {
        private readonly IFamilyMembersService _familyMembersService;
        private readonly IDetailsService _detailService;
        private readonly IRegistrationService _registrationService;

        public FamilyMembersController(IFamilyMembersService fmService, IDetailsService detailService, IRegistrationService registrationService)
        {
            _familyMembersService = fmService;
            _detailService = detailService;
            _registrationService = registrationService;
        }
        /// <summary>
        /// Gets All Family Members
        /// </summary>
        /// <returns>Family Members</returns>
        [HttpGet(Name = "GetAllFamilyMembers")]
        public async Task<IActionResult> GetAllFamilyMembers()
        {
            try
            {
                var task = await _familyMembersService.GetAllFamilyMembers();
                if (task.IsNullOrEmpty())
                {
                    return NoContent();
                }
                return Ok(task);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        /// <summary>
        /// Gets a Family Member with their Details by their ID
        /// </summary>
        /// <returns>Family Members</returns>
        [HttpGet("{id}/details", Name = "GetFamilyMembersById")]
        public async Task<IActionResult> GetFamilyMembersById(int id)
        {
            try
            {
                var familyMember = await _familyMembersService.GetFamilyMembersById(id);
                if (familyMember == null)
                    return NotFound($"Family Member with id {id} does not exist.");

                var details = await _familyMembersService.GetFamilyMemberDetailsById(id);
                return Ok(details);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }
        /// <summary>
        /// Gets a Family Member with their Details by their Name
        /// </summary>
        /// <returns>Family Members</returns>
        [HttpGet("search", Name = "GetFamilyMembersByName")]
        public async Task<IActionResult> GetFamilyMembersByName([FromQuery] String name)
        {
            try
            {
                var familyMember = await _familyMembersService.GetFamilyMembersByName(name);
                if (familyMember == null)
                    return NotFound($"{name} does not exist.");

                var details = await _familyMembersService.GetFamilyMemberDetailsByName(name);
                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Adds a Family Member's Information
        /// </summary>
        /// <param name="newDetail">details</param>
        /// <returns>Returns family member information</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///      POST api/FamilyMembersController/5/registerinformation
        ///     {
        ///         "age": 20,
        ///         "civilStatus": "Married",
        ///         "occupation": "Network Engineer",
        ///         "phoneNumber": "+63-923-345-1234",
        ///         "religion": "Roman Catholic",
        ///         "fmId": 1
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully added Family member details</response>
        /// <response code="400">Family Member Details are invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("{id}/details/register", Name = "FamilyMemberInformation")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(FamilyDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddFamilyMemberInformation(int id, [FromBody] DetailsCreationDto newDetail)
        {
            try
            {
                var familyMember = await _familyMembersService.GetFamilyMembersById(id);
                if (familyMember == null)
                {
                    return NotFound($"Family Member with ID {id} does not exist");
                }
                var newFamilyMemberId = await _registrationService.RegisterFamilyMemberInformation(id, newDetail);
                return CreatedAtAction(
                    nameof(DetailsController.GetAllDetails),
                    "Details",
                    new { id = newFamilyMemberId },
                    $"Successfully registered details");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Updates a Family Member
        /// </summary>
        /// <param name="familyMembersToUpdate">details</param>
        /// <returns>Returns updated family member</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///      PUT api/FamilyMembersController/5
        ///     {
        ///         "name": "EJ Gauson"
        ///     }
        /// 
        /// </remarks>
        /// <response code="202">Successfully updated a family member</response>
        /// <response code="400">Updated Family member are invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}", Name = "UpdateFamilyMembers")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(FamilyDto), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateFamilyMembers(int id, [FromBody] FamilyMembersUpdationDto familyMembersToUpdate)
        {
            try
            {

                var updateFamilyMember = await _familyMembersService.GetFamilyMembersById(id);

                if (updateFamilyMember == null)
                    return NotFound();

                var updatedFamily = await _familyMembersService.UpdateFamilyMembers(id, familyMembersToUpdate);
                return Ok(updatedFamily);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// Deletes a Family Member by their Name
        /// </summary>
        /// <returns>Deleted Family Members</returns>
        /// <response code="202">Successfully deleted a family member</response>
        /// <response code="400">Family member name invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{name}", Name = "DeleteFamilyMembers")]
        [ProducesResponseType(typeof(FamilyDto), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteFamilyMembers(string name)
        {
            try
            {
                var dbFamilyMember = await _familyMembersService.GetFamilyMemberByName(name);
                if (dbFamilyMember == null)
                {
                    return NotFound();
                }
                await _familyMembersService.DeleteFamilyMembers(name);
                return Ok("Family member successfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
