﻿using System.Threading.Tasks;
using DovusProject.Business.Handlers.DovuscuOzellikleri.Commands;
using DovusProject.Business.Handlers.DovuscuOzellikleri.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DovusProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DovuscuOzellikleriController : BaseApiController
    {
        [HttpGet("getbyid")]
        public async Task<IActionResult> Get([FromBody] GetDovuscuOzellikQuery getDovuscuOzellikQuery)
        {
            var result = await Mediator.Send(getDovuscuOzellikQuery);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetDovuscuOzellikleriQuery());
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateDovuscuOzellikleri([FromBody] UpdateDovuscuOzellikleriCommand updateDovuscuOzellikleri)
        {
            var result = await Mediator.Send(updateDovuscuOzellikleri);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
    }
}
