using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustDoIt.Models;

namespace JustDoIt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly AplicationContext _context;

        public NotesController(AplicationContext context)
        {
            _context = context;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notes>>> Get()
        {
            List<Users> users = await _context.Users.ToListAsync();
            List<Notes> notes = await _context.Notes.ToListAsync();
            for(int i = 0; i < notes.Count; i++)
            {
                notes[i].User = users.FirstOrDefault(x=> x.Id == notes[i].UserId);
            }
            return notes;
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notes>> Get(int id)
        {
            var notes = await _context.Notes.FindAsync(id);
            Users user = await _context.Users.FirstOrDefaultAsync(x => x.Id == notes.UserId);
            notes.User = user;

            if (notes == null)
            {
                return NotFound();
            }

            return new ObjectResult(notes);
        }

        // PUT: api/Notes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Notes notes)
        {
            //if (id != notes.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(notes).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!NotesExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
            if (notes == null)
            {
                return BadRequest();
            }
            if (!_context.Notes.Any(x => x.Id == notes.Id))
            {
                return NotFound();
            }

            _context.Update(notes);
            await _context.SaveChangesAsync();
            return Ok(notes);
        }

        // POST: api/Notes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Notes>> Post(Notes notes)
        {
            if (notes == null)
            {
                return BadRequest();
            }
            notes.Date = DateTime.Now;
            _context.Notes.Add(notes);
            await _context.SaveChangesAsync();
            return Ok(notes);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notes>> Delete(int id)
        {
            var notes = await _context.Notes.FindAsync(id);
            if (notes == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(notes);
            await _context.SaveChangesAsync();

            return notes;
        }

        
    }
}
