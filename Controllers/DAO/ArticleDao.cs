/*using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exemple.Models;
using exemple.Data;


namespace exemple.Models;

public class JeuDao
{
    private readonly ApplicationDbContext _context;

    public JeuDao(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Jeu>> GetJeus()
    {
        return await _context.Jeus.ToListAsync();
    }

    public async Task<Jeu> GetJeu(int id)
    {
        return await _context.Jeus.FindAsync(id);
    }

    public async Task<Jeu> AddJeu(Jeu Jeu)
    {
        _context.Jeus.Add(Jeu);
        await _context.SaveChangesAsync();
        return Jeu;
    }

    public async Task<Jeu> UpdateJeu(Jeu Jeu)
    {
        _context.Entry(Jeu).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Jeu;
    }

    public async Task<bool> DeleteJeu(int id)
    {
        var Jeu = await _context.Jeus.FindAsync(id);
        if (Jeu == null) return false;

        _context.Jeus.Remove(Jeu);
        await _context.SaveChangesAsync();
        return true;
    }
}
*/