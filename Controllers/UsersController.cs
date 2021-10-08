using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserItem>>> GetUserItems([FromQuery]int perfil, [FromQuery]int empresa)
        {
            if(perfil>0 && empresa>0){
                return await _context.UserItems.Where(x => x.PerfilUsu == perfil && x.EmpresaUsu == empresa).ToListAsync();
            }else if(perfil>0 && empresa<=0){ 
                return await _context.UserItems.Where(x => x.PerfilUsu == perfil).ToListAsync();
            }else if(perfil<=0 && empresa>0){ 
                return await _context.UserItems.Where(x => x.EmpresaUsu == empresa).ToListAsync();
            }else{
                return await _context.UserItems.ToListAsync();
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserItem>> GetUserItem(int id)
        {
            var userItem = await _context.UserItems.FindAsync(id);

            if (userItem == null)
            {
                return NotFound();
            }

            return userItem;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserItem(int id, UserItem userItem)
        {
            if (id != userItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(userItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserItem>> PostUserItem(UserItem userItem)
        {
            _context.UserItems.Add(userItem);
            await _context.SaveChangesAsync();
            

            //return CreatedAtAction("GetUserItem", new { id = userItem.Id }, userItem);
            return CreatedAtAction(nameof(GetUserItem), new { id = userItem.Id }, userItem);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserItem(int id)
        {
            var userItem = await _context.UserItems.FindAsync(id);
            if (userItem == null)
            {
                return NotFound();
            }

            _context.UserItems.Remove(userItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserItemExists(int id)
        {
            return _context.UserItems.Any(e => e.Id == id);
        }
    }
}
