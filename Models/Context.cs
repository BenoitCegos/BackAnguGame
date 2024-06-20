using Microsoft.EntityFrameworkCore;
using AnguGameNew.Models;

namespace AnguGameNew.Models
{
        public class GameContext : DbContext
        {

            public GameContext(DbContextOptions<GameContext> options) : base(options)
            {
            }
            public DbSet<Jeu> jeux { get; set; }

           //public DbSet<JeuxDTO>jeuDTO { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("Server=tcp:ngugameserver.database.windows.net,1433;Initial Catalog=BDDJEUX;Persist Security Info=False;User ID=bendufBDDSQLServer;Password=Zorglub12!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"); // Chaine de conexionb AVEC le mdp
                }
            }
    } 
}