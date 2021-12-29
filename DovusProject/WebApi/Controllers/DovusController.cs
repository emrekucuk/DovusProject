using System.Threading.Tasks;
using DovusProject.Business.Handlers.Dovus.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DovusProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DovusController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateD([FromBody] DovuseBaslaCommand dovuseBasla)
        {
            var result = await Mediator.Send(dovuseBasla);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDovuscuOzellikleri([FromBody] DovuseDevamCommand dovuseDevam)
        {
            var result = await Mediator.Send(dovuseDevam);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
