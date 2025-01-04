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
        private bool HeavyArmor;
        private readonly View programview;
        public Dwarf(string nameWarrior, int pointOfLife, int nbOfAttac, View view) : base(nameWarrior, pointOfLife, nbOfAttac, view)
        {
            // Choix aléatoire pour l'armure lourde
            Random random = new Random();
            HeavyArmor = random.Next(0, 1) == 0;  // 0 ou 1, 0 pour false (pas d'armure lourde), 1 pour true (armure lourde)

            // Afficher le résultat
            this.programview = view;

                if (HeavyArmor)
                {
                    programview.MessageHeavyTrue(nameWarrior);
                }
                else
                {
                    programview.MessageHeavyFalse(nameWarrior);
                }
            
        }

        public override void UndergoDamage(int damage)
        {
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
