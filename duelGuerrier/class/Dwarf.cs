using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using duelGuerrier.@class;

using System;
using System.ComponentModel.Design;

namespace duelGuerrier.@class
{
    internal class Dwarf : Character
    {
        // Attribut pour indiquer si le nain possède une armure lourde, spécifique à sa classe 
       
        private bool HeavyArmor;
        
        // Attribut pour rappeller la view afin d'appeller les fonctions de message dans la view.  
        
        private  View programview;
        public Dwarf(string nameWarrior, int pointOfLife, int nbOfAttac, View view) : base(nameWarrior, pointOfLife, nbOfAttac, view)
        {
            
            // dans le constructeur j'affecte la vue afin de pouvoir rappeller mes fonctions message dans la vue 
           
            programview = view;
            
            // Afin d'éviter des personnages trop fort j'ai rendu l'armure lourde en un choix aléatoire en utilisant un random
            
            Random random = new Random();
            
            //// J'ai décidé que l'armure aurait une chance sur deux : si c'est 0, il n'y a pas d'armure, et si c'est 1, il y a une armure.
           
            HeavyArmor = random.Next(0, 2) == 0; 

            // je réalise une condition avec un if/else selon si mon nain à une armure ou non et j'affiche le message correpondant.
                if (HeavyArmor)
                {
                    programview.MessageHeavyTrue(nameWarrior);
                }
                else
                {
                    programview.MessageHeavyFalse(nameWarrior);
                }
            
        }
        // Je redéfini ma fonction UndergoDamage héritée de ma classe Character pour qu'elle soit propre au pouvoir de mon nain
        public override void UndergoDamage(int damage)
        {
            // Je réalise une nouvelle condition avec un if/else pour indiquer que si mon nain a une armure,
            // alors les dégâts subis seront divisés par deux. Dans le cas contraire, le comportement hérité de Character reste inchangé.
           
            if (HeavyArmor)
            {
                int newPointOfLife = PointOfLife - damage / 2;
                programview.MessageUndergoDamageHeavy(Name, newPointOfLife);
                PointOfLife = newPointOfLife;
            }
            else
            {
                int newPointOfLife = PointOfLife - damage;
                programview.MessageUndergoDamage(Name, newPointOfLife);
                PointOfLife = newPointOfLife;
            }
        }
    }
}
