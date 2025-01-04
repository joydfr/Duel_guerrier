using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace duelGuerrier.@class
{
    internal class Controller
    {
        View _displayView;
        private List<Character> nouveauxGuerriers = new List<Character>();


        public Controller(View displayScreen)
        {
            _displayView = displayScreen;
        }

        public string AskName()
        {
            _displayView.AskUserName();
            string? nom = Console.ReadLine();
            return nom ?? string.Empty;
        }
        public int AskHealthPoints()
        {
            int healthPoints = 0;
            bool HealthPointsValidated = false;

            while (!HealthPointsValidated)
            {
                _displayView.AskUserLifePoint();
                if (int.TryParse(Console.ReadLine(), out healthPoints) && healthPoints >= 10 && healthPoints <= 50)
                {
                    if (healthPoints >= 30)
                    {
                        _displayView.AlertLifePoint();
                        string userChoice = Console.ReadLine()?.Trim().ToLower();

                        if (userChoice == "oui")
                        {
                            HealthPointsValidated = true;
                        }
                        else if (userChoice != "non")
                        {
                          _displayView.AlertYesNo();
                        }

                    }
                    else
                    {
                        HealthPointsValidated = true;
                    }
                }
                else
                {
                    _displayView.AlertLifePointNotBetween();
                }
            }
            return healthPoints;
      
        }
        public int AskNumberAttack()
        {
            int numberOfAttack;

            while (true)
            {
                _displayView.AskUserNumberOfAttack();
                if (int.TryParse(Console.ReadLine(), out numberOfAttack) && numberOfAttack >= 10 && numberOfAttack <= 30)
                {
                    break;
                }
                _displayView.AlertNumberAttackNotBetween();
            }
            return numberOfAttack;
        }

        public void CreationPersonnal(string type)
        {
            
            string name = AskName();
            
            int healthPoints = AskHealthPoints();
            
            int numberAttack = new Random().Next(10, 21); ;
            if (healthPoints >= 30)
            {
                _displayView.DisplayNumberAttack(numberAttack);
            }
            else
            {
                numberAttack = AskNumberAttack();
            }


            Character perso = null;

            switch (type)   
            {

                case "nain":
                    perso = new Dwarf(name, healthPoints, numberAttack,_displayView);
                break;

                case "guerrier":
                    perso = new Warrior(name, healthPoints, numberAttack,_displayView);
                    break;
                case "elfe":
                    perso = new Elf(name, healthPoints, numberAttack, _displayView);
                    break;
            }

            if (perso != null)
            {
                nouveauxGuerriers.Add(perso);
                _displayView.ShowSuccessesCreationPersonal(perso.Name);
            }
        }
        public void DisplayPersonal()
        {
            _displayView.MessageShowPersonal();

            if (nouveauxGuerriers.Count == 0)
            {
                _displayView.MessageAlertNoneCharacter();
                return;
            }

            foreach (var personnage in nouveauxGuerriers)
            {
                Console.WriteLine(personnage.ToString());

            }
        }
        public virtual void ChooseFight()
        {
            _displayView.MessageFightPersonal();

            if (nouveauxGuerriers.Count < 2)
            {
                _displayView.AlertNumberCharacter();
                return;
            }

            var rand = new Random();
            Character warriorOne = nouveauxGuerriers[rand.Next(nouveauxGuerriers.Count)];
            Character warriorTwo = nouveauxGuerriers[rand.Next(nouveauxGuerriers.Count)];

            do
            {
                warriorTwo = nouveauxGuerriers[rand.Next(nouveauxGuerriers.Count)];
            } while (warriorTwo == warriorOne);

            
            string[] validChoices = { "Pierre", "Feuille", "Ciseaux" };
            string choiceGuerrier1;

            while (true)
            {
                try
                {
                    _displayView.MessageMiniGame();
                    choiceGuerrier1 = Console.ReadLine();


                    bool isValidChoice = false;
                    foreach (string validChoice in validChoices)
                    {
                        if (choiceGuerrier1.ToLower() == validChoice.ToLower())
                        {
                            isValidChoice = true;
                            break;
                        }
                    }

                    if (!isValidChoice)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException("Choix invalide. Veuillez choisir uniquement entre Pierre, Feuille ou Ciseaux.");
                        
                    }

                    
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string choiceGuerrier2 = validChoices[rand.Next(validChoices.Length)];

            _displayView.DisplayWarriorMiniGame(warriorOne.Name, warriorTwo.Name, choiceGuerrier2, choiceGuerrier1);


            bool warriorOneStart = false;

            if (choiceGuerrier1 == choiceGuerrier2)
            {
                warriorOneStart = rand.Next(2) == 0;
                _displayView.DisplayWarriorEqualityMiniGame(warriorOneStart);
            }
            else if (
                (choiceGuerrier1 == "Pierre" && choiceGuerrier2 == "Ciseaux") ||
                (choiceGuerrier1 == "Feuille" && choiceGuerrier2 == "Feuille") ||
                (choiceGuerrier1 == "Ciseaux" && choiceGuerrier2 == "Papier")
            )
            {
                _displayView.DisplayWarriorOneMiniGame(warriorOne.Name);
                warriorOneStart = true;
            }
            else
            {
                _displayView.DisplayWarriorTwoMiniGame(warriorTwo.Name);
                warriorOneStart = false;
            }

             _displayView.LifePointMessage(warriorOne.SeeInfos(), warriorTwo.SeeInfos());

            while (warriorOne.IsAlive && warriorTwo.IsAlive)
            {
                if (warriorOneStart)
                {
                    if (warriorOne.CanAttack())
                    {
                        int damage = warriorOne.Tackle();
                        warriorTwo.UndergoDamage(damage);
                        _displayView.DisplayAttackWarriorOne(warriorOne.Name, warriorTwo.Name, damage);
                    }
                    else
                    {
                        _displayView.DisplayNoMoreAttacks(warriorOne.Name);
                        // Optionnel : forcer la fin du combat si désiré
                        break;
                    }
                    warriorOneStart = false;
                    Thread.Sleep(2000);
                }
                else
                {
                    if (warriorTwo.CanAttack())
                    {
                        int damage = warriorTwo.Tackle();
                        warriorOne.UndergoDamage(damage);
                        _displayView.DisplayAttackWarriorTwo(warriorOne.Name, warriorTwo.Name, damage);
                    }
                    else
                    {
                        _displayView.DisplayNoMoreAttacks(warriorTwo.Name);
                        // Optionnel : forcer la fin du combat si désiré
                        break;
                    }
                    warriorOneStart = true;
                    Thread.Sleep(2000);
                }

                _displayView.LifePointMessage(warriorOne.SeeInfos(), warriorTwo.SeeInfos());

                // Vérifier si les deux combattants sont à court d'attaques
                if (!warriorOne.CanAttack() && !warriorTwo.CanAttack())
                {
                    _displayView.DisplayBothOutOfAttacks();
                    break;
                }
            }

            // Déterminer le vainqueur en fonction des points de vie restants
            if (!warriorOne.IsAlive || (!warriorOne.CanAttack() && warriorTwo.PointOfLife > warriorOne.PointOfLife))
            {
                _displayView.DisplayIsAliveWarriorTwo(warriorTwo.Name, warriorOne.Name);
            }
            else if (!warriorTwo.IsAlive || (!warriorTwo.CanAttack() && warriorOne.PointOfLife > warriorTwo.PointOfLife))
            {
                _displayView.DisplayIsAliveWarriorOne(warriorTwo.Name, warriorOne.Name);
            }
            else
            {
                _displayView.DisplayDraw();  // En cas d'égalité
            }
            // Afficher le vainqueur
            if (!warriorOne.IsAlive)
            {
                _displayView.DisplayIsAliveWarriorTwo(warriorTwo.Name, warriorOne.Name);
            }
            else
            {
                _displayView.DisplayIsAliveWarriorOne(warriorTwo.Name, warriorOne.Name);
            }

            warriorOne.Reset();
            warriorTwo.Reset();
            warriorOne.ResestNumberOfAttack();
            warriorTwo.ResestNumberOfAttack();

        }
    }
}
