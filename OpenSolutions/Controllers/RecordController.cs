using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenSolutions.DataAccess;
using OpenSolutions.DataAccess.Entities;
using OpenSolutions.Domain;
using OpenSolutions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSolutions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordService _recordService;
        private readonly DataContext _context;

        public RecordController(IRecordService recordService, DataContext context)
        {
            _recordService = recordService;
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _recordService.GetAll();
            return Ok(result);
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
        public async Task<IActionResult> Change(RecordEntity record)
        {
            await _recordService.Change(record);
            return Ok();
        }
        [HttpGet("sort/{SortState}")]
        public IActionResult Sort(Enum SortState)
        {
            var result = _recordService.Sorting(SortState);
            return Ok(result);
        }
        [HttpGet("paging")]
        public IActionResult GetRecords()
        {
            var records = _recordService.GetRecords();

            //_logger.LogInfo($"Returned {owners.Count()} owners from database.");

            return Ok(records);
        }

    }
}
