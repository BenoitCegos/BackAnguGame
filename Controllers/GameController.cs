using AnguGameNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnguGameNew.Controllers
{
    public class GameController : Controller
    {
        private readonly GameContext _DB;

        public GameController(GameContext context)
        {
            _DB = context;
        }

       
        [HttpGet("jeux")]
        public async Task<ActionResult<IEnumerable<Jeu>>> Getjeux()
        {
            return await _DB.jeux.ToListAsync();
        }

  
        [HttpGet("{id}")]
        public async Task<ActionResult<Jeu>> Getjeu(int id)
        {
            var jeu = await _DB.jeux.FindAsync(id);
            if (jeu == null)
            {
                return NotFound();
            }
            return jeu;
        }
        //Put
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJeu(int id, Jeu jeu)
        {
            if (id != jeu.Id)
            {
                return BadRequest();
            }

            _DB.Entry(jeu).State = EntityState.Modified;

            try
            {
                await _DB.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!jeuExists(id))
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

        // POST: api/jeu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jeu>> Postjeu(Jeu jeu)
        {
            _DB.jeux.Add(jeu);
            await _DB.SaveChangesAsync();

            return CreatedAtAction("Getjeu", new { id = jeu.Id }, jeu);
        }

        // DELETE: api/jeu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletejeu(int id)
        {
            var jeu = await _DB.jeux.FindAsync(id);
            if (jeu == null)
            {
                return NotFound();
            }

            _DB.jeux.Remove(jeu);
            await _DB.SaveChangesAsync();

            return NoContent();
        }

        private bool jeuExists(int id)
        {
            return _DB.jeux.Any(e => e.Id == id);
        }
    }
}
