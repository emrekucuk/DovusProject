using System.Threading.Tasks;
using DovusProject.Business.Handlers.GecmisMaclar.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DovusProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GecmisMaclarController : BaseApiController
    {
        [HttpGet("getbyid")]
        public async Task<IActionResult> Get([FromBody] GetGecmisMacQuery getGecmisMacQuery)
        {
            var result = await Mediator.Send(getGecmisMacQuery);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetGecmisMaclarQuery());
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        
    }
}
