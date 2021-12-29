using System.Threading.Tasks;
using DovusProject.Business.Handlers.SavasLoglari.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DovusProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SavasLoglariController : BaseApiController
    {
        [HttpGet("get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Mediator.Send(new GetSavasLogQuery(){Id = id});
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetSavaslariLoglari());
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}
