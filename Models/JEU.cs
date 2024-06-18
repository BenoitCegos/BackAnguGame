
using System;
namespace AnguGameNew.Models
{
        public class Jeu
        {
            public int Id { get; set; }
            public string nomJeu { get; set; }
            public DateTime dateSortie { get; set; }

            public string taille { get; set; }

            public Jeu()
            {
                dateSortie = DateTime.Now;
            }
        }
    }