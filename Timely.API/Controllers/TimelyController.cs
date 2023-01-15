using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Timely.API.Data;
using Timely.API.Models;

namespace Timely.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimelyController : Controller
    {
        // This controller creates HttpDelete, HttpPut, HttpGet and HttpPost requests

        private TimelyDbContext _timelyDbContext;

        public TimelyController(TimelyDbContext timelyDbContext)
        {
            _timelyDbContext = timelyDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _timelyDbContext.ProjEntries.ToListAsync();   
            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> AddEntry([FromBody] ProjEntry projEntry)
        {
            projEntry.Id= Guid.NewGuid();
            await _timelyDbContext.ProjEntries.AddAsync(projEntry);
            await _timelyDbContext.SaveChangesAsync();
            return Ok(projEntry);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEntry([FromRoute] Guid id)
        {
           var entry =  await _timelyDbContext.ProjEntries.FirstOrDefaultAsync(x => x.Id==id);
            if (entry == null)
            {
                return NotFound();
            }
            else return Ok(entry);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEntry([FromRoute] Guid id, ProjEntry updateProjEntry)
        {
            var entry = await _timelyDbContext.ProjEntries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Id = updateProjEntry.Id;
            entry.Name = updateProjEntry.Name;
            entry.StartTime = updateProjEntry.StartTime;
            entry.EndTime = updateProjEntry.EndTime;
            entry.Duration = updateProjEntry.Duration;
            entry.StartTimeDateMilisec = updateProjEntry.StartTimeDateMilisec;
            entry.EndTimeDateMilisec = updateProjEntry.EndTimeDateMilisec;

            await _timelyDbContext.SaveChangesAsync();
            return Ok(entry);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEntry([FromRoute] Guid id)
        {
            var entry = await _timelyDbContext.ProjEntries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }
            
            _timelyDbContext.ProjEntries.Remove(entry);
            await _timelyDbContext.SaveChangesAsync(); 
            return Ok(entry);
        }
    }
}
