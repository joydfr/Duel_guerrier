using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duelGuerrier.@class
{
    internal class Character
    {
        private readonly View _programmeEcran;
        private int _initialPointOfLife;
        private int _initialNumberOfAttac;
        public Character(string name, int pointOfLife, int nbOfAttac, View view)
        {
            Name = name;
            PointOfLife = pointOfLife;
            NbOfAttac = nbOfAttac;
            _programmeEcran = view ?? throw new ArgumentNullException(nameof(view));
            _initialPointOfLife = pointOfLife;
        }

        public string Name { get; protected set; }
        public int PointOfLife { get; set; }
        public int NbOfAttac { get; set; }

        public void Reset()
        {
            PointOfLife = _initialPointOfLife;
        }
        public void ResestNumberOfAttack()
        {
            NbOfAttac = _initialNumberOfAttac;
        }
        public bool CanAttack()
        {
            return NbOfAttac > 0;
        }

        public virtual int Tackle()
        {
            if (!CanAttack())
            {
                _programmeEcran.DisplayNoMoreAttacks(Name);  
                return 0;
            }
            Random ran = new Random();
            int damage = ran.Next(0, 7);
            _programmeEcran.MessageTackle(damage, Name);
            NbOfAttac--;
            return damage;
        }

        public virtual void UndergoDamage(int damage)
        {
            int newPointOfLife = PointOfLife - damage;
            _programmeEcran.MessageUndergoDamage(Name, newPointOfLife);
            PointOfLife = newPointOfLife;
            
        }

        public virtual bool IsAlive => PointOfLife > 0;

        public override string ToString()
        {
            return $"Votre personnage {Name} (PV: {PointOfLife}, ATQ: {NbOfAttac})";
        }

        public string SeeInfos()
        {
            return $"{Name} (Pv = {PointOfLife}) (ATQ = {NbOfAttac})";
        }


        
       
    }

}
