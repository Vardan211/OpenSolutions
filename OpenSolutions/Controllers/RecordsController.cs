using Microsoft.AspNetCore.Mvc;
using OpenSolutions.DataAccess.Entities;
using OpenSolutions.Domain;
using System.Threading.Tasks;

namespace OpenSolutions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordService _recordService;

        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(SortState sort, int skip = 0, int take = 10)
        {
            var result = await _recordService.GetAll(sort, skip, take);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await _recordService.GetById(id);

            if (record == null)
            {
                return NotFound();
            }

            return Ok(new {data = record});
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(RecordEntity record)
        {
            await _recordService.Add(record);
            return Ok();
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(RecordEntity record)
        {
            await _recordService.Delete(record);
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(RecordEntity record)
        {
            await _recordService.Update(record);
            return Ok();
        }

        [HttpGet("avg-age")]
        public async Task<IActionResult> GetAvgAge()
        {
            var avgAge = await _recordService.GetAvgAge();

            return Ok(new { avgAge });
        }
    }
}
