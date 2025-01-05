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
        // Attribut pour rappeller la view afin d'appeller les fonctions de message dans la view. 
        private View programview;

        // dans le constructeur j'affecte la vue afin de pouvoir rappeller mes fonctions message dans la vue 
        public Elf(string nameWarrior, int pointOfLife, int nbOfAttac, View view) : base(nameWarrior, pointOfLife, nbOfAttac,view)
        {
            programview = view;
        }

        // Je redéfini ma fonction Tackle héritée de ma classe Character pour qu'elle soit propre au pouvoir de mon elfe
        
        public override int Tackle()
        {
            // J'utilise un condition if pour savoir si mon joueurs a toujours un nombre d'attaque suffisant si oui il peut alors 
            //utiliser la spécilité d'attaque de l'elfe

            if (!CanAttack())
            {
                programview.DisplayNoMoreAttacks(Name);
                return 0;
            }
            // La spécilité de l'elfe est qu'il est obliger d'attaquer de un quand les autres personnage peuvent n'infligés aucun dégat
            // je réalise donc un random 
            Random ran = new Random();

            // Mais contrairement aux autres personnage son ran.Next sera de (1,7) afin qu'il attaque de 1 au minimun 

            int damage = ran.Next(1, 7);
            programview.MessageTackle(damage, Name);
            // décrémentation du nombre d'attaque pour la fonction CanAttack
            NbOfAttac--;
            return damage;
        }
    }
    
}
