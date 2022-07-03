using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Data;
using Api.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Repositories;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevController : ControllerBase
    {

        private readonly ILogger<DevController> _logger;

        public DevController(ILogger<DevController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromServices] IDevRepository devRepository)
        {
            return Ok(await devRepository.ObterTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dev>> ObterPorId([FromServices] IDevRepository devRepository, int id)
        {
            return Ok(await devRepository.ObterPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> GravarDev([FromServices] IDevRepository devRepository, [FromBody] Dev dev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            devRepository.Adicionar(dev);
            return Ok(await devRepository.Gravar());
        }

        [HttpPut]
        public async Task<IActionResult> AlterarDev([FromServices] IDevRepository devRepository, [FromBody] Dev dev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            devRepository.Alterar(dev);
            return Ok(await devRepository.Gravar());
        }
    }
}
