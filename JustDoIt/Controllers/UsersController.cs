using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustDoIt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustDoIt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        AplicationContext db;
        public UsersController(AplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {
            return await db.Users.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(int id)
        {
            Users user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            Notes note = await db.Notes.FirstOrDefaultAsync(y => user.Id == y.UserId);
            List<Notes> notes = new List<Notes>();
            notes.Add(note);
            user.Notest = notes.Distinct().ToList();
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Users>> Post(Users user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Users>> Put(Users user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> Delete(int id)
        {
            Users user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}

