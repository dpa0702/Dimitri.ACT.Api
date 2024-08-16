using Dimitri.ACT.Api.Services.Interfaces;
using Dimitri.ACT.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Dimitri.ACT.Api.Controllers
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

        [HttpPost]
        public async Task<IActionResult> NewEntry([FromBody] NewEntryDTO dto)
        {
            try
            {
                await _entryService.NewEntry(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
