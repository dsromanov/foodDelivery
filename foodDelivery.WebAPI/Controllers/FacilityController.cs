using AutoMapper;
using foodDelivery.Services.Abstract;
using foodDelivery.Services.Models;
using foodDelivery.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace foodDelivery.WebAPI.Controllers
{
    /// <summary>
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityService FacilityService;
        private readonly IMapper mapper;

        /// <summary>
        /// Facility controller
        /// </summary>
        public FacilityController(IFacilityService FacilityService, IMapper mapper)
        {
            this.FacilityService = FacilityService;
            this.mapper = mapper;
        }
         /// <summary>
        /// create Facility
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateFacility([FromQuery]Guid CityId, [FromQuery]Guid TypeId,[FromBody] FacilityModel facility)
        {
            var response = FacilityService.CreateFacility(CityId, TypeId, facility);
            return Ok(response);
        }

        /// <summary>
        /// Get Facility by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetFacilitys([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = FacilityService.GetFacilitys(limit, offset);

            return Ok(mapper.Map<PageResponse<FacilityResponse>>(pageModel));
        }
        /// <summary>
        /// Delete Facility
        /// </summary>

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteFacility([FromRoute] Guid id)
        {
            try
            {
                FacilityService.DeleteFacility(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get Facility
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetFacility([FromRoute] Guid id)
        {
            try
            {
                var FacilityModel = FacilityService.GetFacility(id);
                return Ok(mapper.Map<FacilityResponse>(FacilityModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update Facility
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateFacility([FromRoute] Guid id, [FromBody] UpdateFacilityRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = FacilityService.UpdateFacility(id, mapper.Map<UpdateFacilityModel>(model));
                return Ok(mapper.Map<FacilityResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }

}