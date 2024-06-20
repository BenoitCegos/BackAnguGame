using System ;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AnguGameNew.Models

{
    public class JeuDTO
    {
        public int Id { get; set; }
        public string nomJeu { get; set; }

        public string taille { get; set; }


        public JeuDTO()
        {

        }
        /*public ConvertJeuVersDTO (Jeu monJeu)
        {
            //  int i = (int)Convert.ChangeType(d, typeof(int));
            var monJeuDTO= new JeuDTO();
            monJeuDTO=(JeuDTO)Convert.ChangeType(monJeu, typeof(JeuDTO));
            return monJeuDTO;
        }*/
    }
}

