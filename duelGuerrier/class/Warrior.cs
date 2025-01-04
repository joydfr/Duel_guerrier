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
        private readonly View programview;
        private bool SwordOfLight;
        public Warrior(string name, int pointOfLife, int nbOfAttac, View view) : base(name, pointOfLife, nbOfAttac,view)
        {
            this.programview = view; // Initialisation de programview

            Random random = new Random();
            SwordOfLight = random.Next(0, 3) == 0;

            if (SwordOfLight)
            {
                programview.MessageSwordOfLightTrue(name);
            }
            else
            {
                programview.MessageSwordOfLightFalse(name);
            }
        }
    

        public override int Tackle()
        {
            if (SwordOfLight)
            {
                if (!CanAttack())
                {
                    programview.MessageNoMoreAttacks(Name);  // Vous devrez ajouter cette méthode dans votre View
                    return 0;
                }
                Random ran = new Random();
                int damage = ran.Next(0, 7);
                int newDamage = damage + 2;
                programview.TackleSwordofLight(Name,damage,newDamage);
                NbOfAttac--;
                return newDamage;
            }
            else
            {

                Random ran = new Random();
                int damage = ran.Next(0, 7);
                programview.MessageTackle(damage, Name);
                NbOfAttac--;
                return damage;
            }
        }






    }
}
