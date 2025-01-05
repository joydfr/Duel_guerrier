using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duelGuerrier.@class
{
    internal class Character
    {
        // La classe personnage sera notre classe mère qui fera l'héritage vers ses enfants 
        // Initialisation des attributs de la classe mère 
        private readonly View _programmeEcran;
        private int _initialPointOfLife;
        private int _initialNumberOfAttac;

        // création du constructeur du nom, des points de vie et du nombre d'attaques ainsi que de la view pour rappeller les fonctions messages 
        public Character(string name, int pointOfLife, int nbOfAttac, View view)
        {
            Name = name;
            PointOfLife = pointOfLife;
            NbOfAttac = nbOfAttac;
            // comme dans la classe mère la ligne me permet que d'inquer que la view ne peut être null sinon il lance une exception
            _programmeEcran = view ?? throw new ArgumentNullException(nameof(view));
            _initialPointOfLife = pointOfLife;
            _initialNumberOfAttac = nbOfAttac;
        }
        // Les propriétés 
        public string Name { get; protected set; }
        public int PointOfLife { get; set; }
        public int NbOfAttac { get; set; }
        // La fonction Reset me permet de remettre les points de vie à ce qu'à saisit l'utilisateur lors de la création à la fin d'un combat
        public void Reset()
        {
            PointOfLife = _initialPointOfLife;
        }
        // La fonction Reset me permet de remettre le nombre d'attaque à ce qu'à saisit l'utilisateur lors de la création à la fin d'un combat
        public void ResetNumberOfAttacks()
        {
            NbOfAttac = _initialNumberOfAttac;
        }
        // La fonction CanAttack permet de vérifier que le nombre d'attaque n'est pas inférieur à zéro pour qu'il puisse continuer 
        public bool CanAttack()
        {
            return NbOfAttac > 0;
        }
        // La fonction Tackle permets au joueur d'attaque son adverser si la condition CanAttack est rempli 
        public virtual int Tackle()
        {
            if (!CanAttack())
            {
                _programmeEcran.DisplayNoMoreAttacks(Name);  
                return 0;
            }
            // Pour que le nombre de dégat infligé, j'ai réalisé un aléatoire 
            Random ran = new Random();
            // Les personnages qui vont hérités de Tackle pour faire entre 0 et 7 de dégats sauf exception 
            int damage = ran.Next(0, 7);
            _programmeEcran.MessageTackle(damage, Name);
            // décrémentation du nombre d'attaque pour la fonction CanAttack
            NbOfAttac--;
            return damage;
        }
        // La fonction UndergoDamage permet de déduire le nombre de dégat au point de vie tout les personnages hériteront de cette classe sauf excpetion 
        public virtual void UndergoDamage(int damage)
        {
            // rédeclaration d'une variable newPointOfLife pour connaitre les nouveaux point de vie après les dégats
            int newPointOfLife = PointOfLife - damage;
            _programmeEcran.MessageUndergoDamage(Name, newPointOfLife);
            PointOfLife = newPointOfLife;
            
        }
        // La fonction IsAlive permet de savoir si les points de vie sont suppérieur à zéro dans ce cas le combat continu si non le combat s'arrête
        public virtual bool IsAlive => PointOfLife > 0;
       
        // La fonction SeeInfos permets lors du futur affichage des personnages de connaitre leurs nom, leurs nombre de point de vie et le nombre d'attaque.
        public string SeeInfos()
        {
            return $"{Name} (Pv = {PointOfLife}) (ATQ = {NbOfAttac})";
        }
       
    }

}
