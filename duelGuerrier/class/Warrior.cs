using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duelGuerrier.@class
{
    internal class Warrior : Character
    {
        // Attribut pour rappeller la view afin d'appeller les fonctions de message dans la view.
        private View programview;
        // Attribut pour la création de la spécialiter du warrior épée de lumière 
        private bool SwordOfLight;
        // Constructeur 
        public Warrior(string name, int pointOfLife, int nbOfAttac, View view) : base(name, pointOfLife, nbOfAttac,view)
        {
            // dans le constructeur j'affecte la vue afin de pouvoir rappeller mes fonctions message dans la vue 
            programview = view;
            // Afin d'éviter des personnages trop fort j'ai rendu l'épée de lumière en un choix aléatoire en utilisant un random
            Random random = new Random();
            //J'ai décidé que l'épee aurait une chance sur 3 : si c'est 0, il n'y a pas d'épée, et si c'est 1, il y a une épée.
            SwordOfLight = random.Next(0, 3) == 0;

            // je réalise une condition avec un if/else selon si mon guerrier à une épée ou non et j'affiche le message correpondant.
            if (SwordOfLight)
            {
                programview.MessageSwordOfLightTrue(name);
            }
            else
            {
                programview.MessageSwordOfLightFalse(name);
            }
        }
        // Je redéfini ma fonction Tackle héritée de ma classe Character pour qu'elle soit propre au pouvoir de mon guerrier
        public override int Tackle()
        {
        // Je réalise une première condition avec un if/else pour savoir si mon guerrier à l'épée de lumière 
            if (SwordOfLight)
            {
                // Si oui je vérifie avec une condition if si mon guerrier à encore un nombre d'attaque avec la fonction CanAttack
                if (!CanAttack())
                {
                    programview.DisplayNoMoreAttacks(Name);
                    return 0;
                }
                // Si il peut toujours attaque j'utilise la méthode Tackle à laquelle j'ai rajouté la variable newdammage qui infilge +2 dégats
                Random ran = new Random();
                int damage = ran.Next(0, 7);
                int newDamage = damage + 2;
                programview.TackleSwordofLight(Name,damage,newDamage);
                NbOfAttac--;
                return newDamage;
            }
            else
            {
                // Dans le cas contraire je revérifie si il peut attaquer et j'applique l'héritage de Character
                if (!CanAttack())
                {
                    programview.DisplayNoMoreAttacks(Name);
                    return 0;
                }

                Random ran = new Random();
                int damage = ran.Next(0, 7);
                programview.MessageTackle(damage, Name);
                NbOfAttac--;
                return damage;
            }
        }
    }
}
