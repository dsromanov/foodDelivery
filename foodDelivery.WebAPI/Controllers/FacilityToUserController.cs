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
    public class FacilityToUserController : ControllerBase
    {
        private readonly IFacilityToUserService FacilityToUserService;
        private readonly IMapper mapper;

        /// <summary>
        /// FacilityToUser controller
        /// </summary>
        public FacilityToUserController(IFacilityToUserService FacilityToUserService, IMapper mapper)
        {
            this.FacilityToUserService = FacilityToUserService;
            this.mapper = mapper;
        }
         /// <summary>
        /// create Facility
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateFacilityToUser([FromQuery]Guid UserId, [FromQuery]Guid FacilityId, [FromBody] FacilityToUserModel facilityToUser)
        {
            var response = FacilityToUserService.CreateFacilityToUser(UserId, FacilityId, facilityToUser);
            return Ok(response);
        }


        /// <summary>
        /// Get FacilityToUser by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetFacilityToUsers([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = FacilityToUserService.GetFacilityToUsers(limit, offset);

            return Ok(mapper.Map<PageResponse<FacilityToUserResponse>>(pageModel));
        }
        /// <summary>
        /// Delete FacilityToUser
        /// </summary>

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteFacilityToUser([FromRoute] Guid id)
        {
            try
            {
                FacilityToUserService.DeleteFacilityToUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get FacilityToUser
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetFacilityToUser([FromRoute] Guid id)
        {
            try
            {
                var FacilityToUserModel = FacilityToUserService.GetFacilityToUser(id);
                return Ok(mapper.Map<FacilityToUserResponse>(FacilityToUserModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update FacilityToUser
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateFacilityToUser([FromRoute] Guid id, [FromBody] UpdateFacilityToUserRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = FacilityToUserService.UpdateFacilityToUser(id, mapper.Map<UpdateFacilityToUserModel>(model));
                return Ok(mapper.Map<FacilityToUserResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }

}