using CebuCityFamilyAPI.Dtos;
using CebuCityFamilyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CebuCityFamilyAPI.Controllers
{
    [Route("api/details")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly IDetailsService _detailsService;

        public DetailsController(IDetailsService detailsService)
        {
            _detailsService = detailsService;
        }

        /// <summary>
        /// Gets All Details
        /// </summary>
        /// <returns>Details</returns>
        [HttpGet(Name = "GetAllDetails")]
        public async Task<IActionResult> GetAllDetails()
        {
            try
            {
                var details = await _detailsService.GetAllDetails();
                if (details.IsNullOrEmpty())
                {
                    return NoContent();
                }
                return Ok(details);
               
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        /// <summary>
        /// Updates a Family Member's Details
        /// </summary>
        /// <param name="details">details</param>
        /// <returns>Returns the updated details</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///      PUT api/DetailsController/5
        ///     {
        ///         "age": 20,
        ///         "civilStatus": "Single",
        ///         "occupation": "Network Engineer",
        ///         "phoneNumber": "+63-923-345-1234",
        ///         "religion": "Roman Catholic"
        ///     }
        /// 
        /// </remarks>
        /// <response code="202">Successfully updated Details</response>
        /// <response code="400">Updated details are invalid</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}", Name = "UpdateDetails")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DetailsDto), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDetails(int id, [FromBody] DetailsUpdationDto details)
        {
                var dbDetails = await _detailsService.GetDetails(id);
                if (dbDetails == null)
                    return NotFound();
                var updatedBarangay = await _detailsService.UpdateDetails(id, details);
                return Ok(updatedBarangay);
        }
    }
}
