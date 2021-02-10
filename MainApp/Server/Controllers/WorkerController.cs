using System.Threading.Tasks;
using MainApp.Server.Data;
using MainApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MainApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public WorkerController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var wors = await _context.Workers.ToListAsync();
            return Ok(wors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var wors = await _context.Workers.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(wors);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Worker worker)
        {
            _context.Add(worker);
            await _context.SaveChangesAsync();
            return Ok(worker.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Worker worker)
        {
            _context.Entry(worker).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var wors = new Worker { Id = id };
            _context.Remove(wors);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
