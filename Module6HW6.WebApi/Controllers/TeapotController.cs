using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Module6HW5.Exceptions;
using Module6HW5.Interfaces;
using Module6HW5.Models;
using Module6HW5.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Module6HW5.Controllers
{
    [Route("api")]
    [ApiController]
    public class TeapotController : ControllerBase
    {
        private readonly ITeapotService _teapotService;

        public TeapotController(ITeapotService teapotService)
        {
            _teapotService = teapotService;
        }

        [Authorize]
        [HttpGet("teapots")]
        public async Task<IActionResult> GetTeapots()
        {
            List<Teapot> teapots = null;
            
            try
            {
                teapots = await _teapotService.GetTeapots();
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.Message });
            }

            return Ok(teapots);
        }

        [Authorize]
        [HttpGet("teapots/{id}")]
        public async Task<IActionResult> GetTeapotById([FromRoute] Guid id)
        {
            Teapot teapot = null;

            try
            {
                teapot = await _teapotService.GetTeapotById(id);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.Message });
            }

            return Ok(teapot);
        }

        [Authorize]
        [HttpPost("teapots")]
        public async Task<IActionResult> AddTeapot([FromBody] TeapotViewModel teapotFromBody)
        {
            await _teapotService.AddTeapot(teapotFromBody);

            return Ok(new {SuccessMessage = "Teapot has been added!"});
        }

        [Authorize]
        [HttpPut("teapots/{id}")]
        public async Task<IActionResult> EditTeapotById([FromRoute] Guid id, [FromBody] TeapotViewModel teapotFromBody)
        {
            try
            {
                await _teapotService.EditTeapotById(id, teapotFromBody);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.Message });
            }

            return Ok(new { SuccessMessage = "The teapot has been changed!" });
        }

        [Authorize]
        [HttpDelete("teapots/{id}")]
        public async Task<IActionResult> DeleteTeapotById([FromRoute] Guid id)
        {
            try
            {
                await _teapotService.DeleteTeapotById(id);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.Message });
            }

            return Ok(new { SuccessMessage = "The teapot has been removed!" });
        }
    }
}
