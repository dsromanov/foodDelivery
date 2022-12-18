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
    public class TypesController : ControllerBase
    {
        private readonly ITypesService TypesService;
        private readonly IMapper mapper;

        /// <summary>
        /// Types controller
        /// </summary>
        public TypesController(ITypesService TypesService, IMapper mapper)
        {
            this.TypesService = TypesService;
            this.mapper = mapper;
        }
        // <summary>
        /// create Types
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateTypes([FromBody] TypesModel types)
        {
            var response = TypesService.CreateTypes(types);
            return Ok(response);
        }


        /// <summary>
        /// Get Types by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetTypess([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = TypesService.GetTypess(limit, offset);

            return Ok(mapper.Map<PageResponse<TypesResponse>>(pageModel));
        }
        /// <summary>
        /// Delete Types
        /// </summary>

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTypes([FromRoute] Guid id)
        {
            try
            {
                TypesService.DeleteTypes(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Get Types
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTypes([FromRoute] Guid id)
        {
            try
            {
                var TypesModel = TypesService.GetTypes(id);
                return Ok(mapper.Map<TypesResponse>(TypesModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /// <summary>
        /// Update Types
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTypes([FromRoute] Guid id, [FromBody] UpdateTypesRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = TypesService.UpdateTypes(id, mapper.Map<UpdateTypesModel>(model));
                return Ok(mapper.Map<TypesResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }

}