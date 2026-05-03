using Covide.Application.Interfaces;
using Covide.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Covide.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConversionController : ControllerBase
    {
        private readonly IColorConversionService _service;

        public ConversionController(IColorConversionService service)
        {
            _service = service;
        }

        [HttpGet("{hex}")]
        public ActionResult<ColorResult> Get(string hex)
        {
            if (!_service.IsValidHex(hex))
                return BadRequest("Invalid HEX format");

            var result = _service.Convert(hex);

            return Ok(result);
        }
    }
}
