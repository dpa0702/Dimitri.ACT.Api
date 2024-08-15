using Dimitri.ACT.Core.DTOs;
using Dimitri.ACT.EntryMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dimitri.ACT.EntryMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _entryService;

        public EntryController(IEntryService entryService)
        {
            _entryService = entryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct) => Ok(await _entryService.GetAll(ct));

        [HttpGet]
        [Route("ConsolidadoDiario")]
        public async Task<IActionResult> GetConsolidado(CancellationToken ct)
        {
            try
            {
                return Ok(await _entryService.GetAllDay(ct));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            try
            {
                return Ok(await _entryService.GetById(id, ct));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(NewEntryDTO entry, CancellationToken ct)
        {
            try
            {
                await _entryService.Add(entry, ct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
