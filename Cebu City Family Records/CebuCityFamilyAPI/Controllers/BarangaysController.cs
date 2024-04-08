using CebuCityFamilyAPI.Dtos;
using CebuCityFamilyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CebuCityFamilyAPI.Controllers
{
    [Route("api/barangays")]
    [ApiController]
    public class BarangaysController : ControllerBase
    {
        private readonly IBarangayService _barangayService;
        private readonly IFamilyService _familyService;
        private readonly IRegistrationService _registrationService;

        public BarangaysController(IBarangayService barangayService, IRegistrationService registrationService, IFamilyService familyService)
        {
            _barangayService = barangayService;
            _registrationService = registrationService;
            _familyService = familyService;
        }
        /// <summary>
        /// Gets all Barangays
        /// </summary>
        /// <returns>Barangays</returns>
        [HttpGet(Name = "GetAllBarangays")]
        public async Task<IActionResult> GetBarangays()
        {
            try
            {
                var barangays = await _barangayService.GetAllBarangays();
                if (barangays.IsNullOrEmpty())
                {
                    return NoContent();
                }
                return Ok(barangays);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Gets the Families living in the Barangay by ID
        /// </summary>
        /// <returns>Barangay</returns>
        [HttpGet("{id}/families", Name = "GetBarangayById")]
        public async Task<IActionResult> GetBarangayById(int id)
        {
            try
            {
                var barangay = await _barangayService.GetBarangayById(id);
                if (barangay == null)
                    return NotFound($"Barangay with id {id} does not exist.");

                var families = await _familyService.GetFamilyByBarangayId(id);
                return Ok(families);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Gets the Families living in the Barangay by the Barangay Name
        /// </summary>
        /// <returns>Barangay</returns>
        [HttpGet("search", Name = "GetBarangayByName")]
        public async Task<IActionResult> GetBarangayByName([FromQuery] String name)
        {
            try
            {
                var barangay = await _barangayService.GetBarangayByName(name);
                if (barangay == null)
                    return NotFound($"Barangay {name} does not exist.");

                var families = await _familyService.GetFamilyByName(name);
                return Ok(families);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Creates a Barangay
        /// </summary>
        /// <param name="barangayDto">barangay details</param>
        /// <returns>Returns the newly created barangay</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///      POST api/Barangays
        ///     {
        ///         "name": "Cansojong",
        ///         "captain": "Delwin Mateo Gauson"
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully created a Barangay</response>
        /// <response code="400">Barangay details are invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpPost(Name = "CreateBarangay")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BarangayDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBarangay([FromBody] BarangayCreationDto barangayDto)
        {
            try
            {
                var count = await _barangayService.CountBarangayName(barangayDto.Name);
                if (count > 0)
                {
                    return StatusCode(409, "Barangay already exists");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            try
            {
                var newBarangay = await _barangayService.CreateBarangay(barangayDto);
                return CreatedAtRoute("GetBarangayById", new { id = newBarangay.Id }, newBarangay);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Registers a Family to a Barangay
        /// </summary>
        /// <param name="newFamily">family details</param>
        /// <returns>Returns the newly registered family to barangay</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///      POST /api/Barangays/1/register
        ///     {
        ///         "name": "Gauson",
        ///         "sitio": "Ibacan"
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Successfully registered a Family in Barangay</response>
        /// <response code="400">Family details are invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("{id}/family/register", Name = "RegisterFamilyToBarangay")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BarangayDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterFamily(int id, [FromBody] FamilyCreationDto newFamily)
        {
            try
            {
                var barangay = await _barangayService.GetBarangayById(id);
                if(barangay == null)
                {
                    return NotFound($"Barangay with ID {id} does not exist");
                }
                var newFamilyId = await _registrationService.Register(id, newFamily);
                return CreatedAtAction(
                    nameof(FamiliesController.GetFamilies),
                    "Families",
                    new { id = newFamilyId },
                    $"Successfully registered {newFamily.Name} Family");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Updates a Barangay
        /// </summary>
        /// <param name="barangay">barangay details</param>
        /// <returns>Returns the updated barangay</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///      PUT api/Barangays/5
        ///     {
        ///         "name": "Tisa",
        ///         "captain": "Phillip Savior Zafra"
        ///     }
        /// 
        /// </remarks>
        /// <response code="202">Successfully updated a Barangay</response>
        /// <response code="400">Updated Barangay details are invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}", Name = "UpdateBarangay")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BarangayDto), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBarangay(int id, [FromBody] BarangayUpdationDto barangay)
        {
            try
            {
                var dbBarangay = await _barangayService.GetBarangayById(id);
                if (dbBarangay == null)
                    return NotFound();
                var updatedBarangay = await _barangayService.UpdateBarangay(id, barangay);
                return Ok(updatedBarangay);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Deletes a Barangay by Name
        /// </summary>
        /// <returns>Deleted Barangay</returns>
        /// /// <response code="202">Successfully deleted a Barangay</response>
        /// <response code="400">Barangay Name invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{name}", Name = "DeleteBarangay")]
        [ProducesResponseType(typeof(BarangayDto), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBarangay(String name)
        {
            try
            {
                var dbBarangay = await _barangayService.GetBarangayByName(name);
                if (dbBarangay == null)
                    return NotFound();
                await _barangayService.DeleteBarangay(name);
                return Ok("Barangay successfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
