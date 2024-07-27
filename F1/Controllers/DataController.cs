using F1.Data;
using F1.Data.DTO;
using F1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace F1.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataService _service;

        public DataController(IDataService service)
        {
            _service = service;
        }

        [HttpPost("race")]
        public async Task<ActionResult<RaceDto>> PostNewRace([BindRequired] RaceDto raceInfo)
        {
            return Ok(raceInfo);
        }
    }
}