using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Walle_WEB.Data.Repositories;
using Walle_WEB.Model;
using Microsoft.AspNetCore.Mvc;

namespace Walle_WEB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeelerBitacoraController : Controller
    {
        private readonly IPeelerRepository _peelerRepository;

        public PeelerBitacoraController(IPeelerRepository peelerRepository)
        {
            _peelerRepository = peelerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeeler()
        {
            return Ok(await _peelerRepository.GetAllPeeler());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPeelerDetails(int id)
        {
            return Ok(await _peelerRepository.GetPeelerDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePeeler([FromBody] PeelerBitacora peelerbitacora)
        {
            if (peelerbitacora == null)
                return BadRequest();

            if (peelerbitacora.NoDeLote.Trim() == string.Empty)
            {
                ModelState.AddModelError("NoDeLote", "Category Name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _peelerRepository.InsertPeeler(peelerbitacora);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] PeelerBitacora peelerbitacora)
        {
            if (peelerbitacora == null)
                return BadRequest();

            if (peelerbitacora.NoDeLote.Trim() == string.Empty)
            {
                ModelState.AddModelError("NoDeLote", "Category name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _peelerRepository.UpdatePeeler(peelerbitacora);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeeler(int id)
        {
            if (id == 0)
                return BadRequest();

            await _peelerRepository.DeletePeeler(id);

            return NoContent(); //success
        }
    }
}