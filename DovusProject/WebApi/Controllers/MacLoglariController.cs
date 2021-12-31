using System.Threading.Tasks;
using DovusProject.Business.Handlers.MacLoglari.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DovusProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MacLoglariController : BaseApiController
    {
        [HttpGet("getbyid")]
        public async Task<IActionResult> Get([FromBody] GetMacLogQuery getMacLogQuery)
        {
            var result = await Mediator.Send(getMacLogQuery);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetMacLoglariQuery());
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}
