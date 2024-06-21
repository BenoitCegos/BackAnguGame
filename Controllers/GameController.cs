using AnguGameNew.Controllers.DAO;
using AnguGameNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AnguGameNew.Controllers
{
    public class GameController : Controller
    {
        private readonly JeuDao _DAO;

        public GameController(JeuDao dao)
        {
            _DAO = dao;
        }

        /*
               public <- accessibilité de la fonction
                async <- declarer la fonction comme asynchrone (elle est utiliser par un autre thread)
                Task<ActionResult<IEnumerable<Jeu>>>  <- Type de la valeur de retour de la fonction
                Getjeux <- nom de la fonction
                () <- parametres
                public async Task<ActionResult<IEnumerable<Jeu>>> Getjeux()
                {
                    return await _DB.jeux.ToListAsync();
                }
        
                Dans le cas ou je return un object DTO*/


                /*public async Task<ActionResult<IEnumerable<JeuDTO>>> Getjeux()
                {
                    var listeJeu = await _DB.jeux.ToListAsync();
                foreach (var Jeu in _DB.jeux)
                {
                   jeuxDTO.  
                }
                return jeuxDTO;
                }*/

                 //Dans le cas ou je recois un object DTO
         
                 /*public async Task<ActionResult<IEnumerable<Jeu>>> Getjeux()
                {
                    //Jeu classique = dto.toJeu();
                    foreach( Jeu varJeu in _DB.jeux)
                    {
                        
                    }
                    JeuDTO monJeu= new JeuDTO();
                    return await() ;
                }*/
         

        
        [HttpGet("jeux")]
        public async Task<ActionResult<IEnumerable<Jeu>>> Getjeux()
        {
            var reponse = await _DAO.GetJeux();
            return Ok(reponse);
        }

        [HttpGet("jeux/{id}")]
        public async Task<ActionResult<Jeu>> Getjeu(int id)
        {
            var jeu = await _DAO.GetJeu(id);
            return jeu;
            
        }

        [HttpPost]
        public async Task<ActionResult<Jeu>> PostJeu(Jeu jeu)
        {
            await _DAO.AddJeu(jeu);
            return CreatedAtAction("GetJeu", new { id = jeu.Id }, jeu);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutJeu(int id, Jeu jeu)
        {
            if (id != jeu.Id)
            {
                return BadRequest();
            }

            await _DAO.UpdateJeu(jeu);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJeu(int id)
        {
            var success = await _DAO.DeleteJeu(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        //DTO Version
        /*[HttpGet("jeux")]
        public async Task<ActionResult<IEnumerable<Jeu>>> Getjeux()
        {
          return await _DB.jeux.ToListAsync();
        }*/

        /*
        [HttpGet("list/{id}")]
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
        [HttpPut("put/{id}")]
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
        */
        /*private bool jeuExists(int id)
        {
            return _DB.jeux.Any(e => e.Id == id);
        }*/
    }
    }
