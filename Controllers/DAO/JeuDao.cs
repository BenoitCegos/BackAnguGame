using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnguGameNew.Models;
using AnguGameNew.Controllers;
using AnguGameNew.Controllers.DAO;
//using AnguGameNew.Data;

namespace AnguGameNew.Controllers.DAO
{
    public class JeuDao

    {
        private readonly GameContext _DB;

        public JeuDao(GameContext context)
        {
            _DB = context;
        }

        public async Task<IEnumerable<Jeu>> GetJeux()
        {
            return await _DB.jeux.ToListAsync();
                   }

        public async Task<Jeu> GetJeu(int id)
        {
            return await _DB.jeux.FindAsync(id);
        }

        public async Task<Jeu> AddJeu(Jeu Jeu)
        {
            _DB.jeux.Add(Jeu);
            await _DB.SaveChangesAsync();
            return Jeu;
        }

        public async Task<Jeu> UpdateJeu(Jeu Jeu)
        {
            _DB.Entry(Jeu).State = EntityState.Modified;
            await _DB.SaveChangesAsync();
            return Jeu;
        }

        public async Task<bool> DeleteJeu(int id)
        {
            var Jeu = await _DB.jeux.FindAsync(id);
            if (Jeu == null) return false;

            _DB.jeux.Remove(Jeu);
            await _DB.SaveChangesAsync();
            return true;
        }
        /*
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.Include(u => u.Purchases)
                                       .ThenInclude(p => p.PurchaseJeus)
                                       .ThenInclude(pa => pa.Jeu)
                                       .ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.Include(u => u.Purchases)
                                       .ThenInclude(p => p.PurchaseJeus)
                                       .ThenInclude(pa => pa.Jeu)
                                       .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }*/
    }
}
