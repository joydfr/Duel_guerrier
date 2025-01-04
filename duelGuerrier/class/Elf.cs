using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace duelGuerrier.@class
{
    internal class Elf : Character
    {
        private View programview;
        public Elf(string nameWarrior, int pointOfLife, int nbOfAttac, View view) : base(nameWarrior, pointOfLife, nbOfAttac,view)
        {
            programview = view;
        }



        public override int Tackle()
        {
            if (!CanAttack())
            {
                programview.MessageNoMoreAttacks(Name);  // Vous devrez ajouter cette méthode dans votre View
                return 0;
            }
            Random ran = new Random();
            int damage = ran.Next(1, 7);

            programview.MessageTackle(damage, Name);
            NbOfAttac--;
            return damage;
        }
    }
    
}
