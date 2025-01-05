using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace duelGuerrier.@class
{
    internal class Controller
    {
        // Attribut pour rappeller la view afin d'appeller les fonctions de message dans la view.  
        private View _displayView;
        // Attribut pour stocker les nouveauxGuerrier créer par rapport à la class mère Character
        private List<Character> newWarriors = new List<Character>();

        // dans le constructeur j'affecte la vue afin de pouvoir rappeller mes fonctions message dans la vue 
        public Controller(View displayScreen)
        {
            _displayView = displayScreen;
        }
        // Fonction afin de demander à l'utilisateur de saisir un nom de personnage 
        public string AskName()
        {
            string name;
            do
            {
                // Demande à l'utilisateur de saisir quelque chose
                _displayView.AskUserName();
                name = Console.ReadLine();

                // Si l'utilisateur n'a pas saisi de nom (chaine vide ou null), on demande de saisir à nouveau
                if (string.IsNullOrEmpty(name))
                {
                    _displayView.AlerteNameNone();
                }

            } while (string.IsNullOrEmpty(name));  // Je continue la bousle tant que la saisie est vide ou null

            return name;
        }
        // Function permettant de demander à l'utilisateur de saisir son nombre d'attaque 
        public int AskHealthPoints()
        {
            // création d'une variable int healthPoints à 0 pour le stockage 
            int healthPoints = 0;
            // création d'une variable en bool pour la vérification des points de vie 
            bool HealthPointsValidated = false;
            // utilisation d'une boucle while pour vérifier si le nombre des points est saisie
            while (!HealthPointsValidated)
            {
                // affichage du message de la demande de point de vie 
                _displayView.AskUserLifePoint();
               // utilisation d'un if pour contraindre l'utilisateur a saisir un nombre entre 10 et 50
                if (int.TryParse(Console.ReadLine(), out healthPoints) && healthPoints >= 10 && healthPoints <= 50)
                {
                    // afin d'éviter que l'utilisateur ne créer que des personnage fort si le nombre de point de vie est supérieur à 30
                    // alors l'utilisateur se verra limiter dans le nombre d'attaque pour garantir une équité de combat
                    if (healthPoints >= 30)
                    {
                        // Suite à une saisie supérieur à 30, je laisse une chance à l'utilisateur de confirmer ou non
                        // son choix d'être limité dans son nombre d'attaque 
                        // Affichage de la question sur la limitation
                        _displayView.AlertLifePoint();
                        // je saisie sa reponse avec une console.readline avec une gestion des espaces en les supprimant avec trim
                        // et une gestion des Masjucule en convertisant en misnicule avec ToLower.
                        string userChoice = Console.ReadLine()?.Trim().ToLower();
                        // j'utilise une conditon avec un if/ elseif pour la réponse utilisateur si il saisit oui je sors de la boucle
                        // et les point d'attaque seront limité
                        if (userChoice == "oui")
                        {
                            HealthPointsValidated = true;
                        }
                        // si c'est non différent de "non" nous avons une contrainte utilisateur et un message d'alerte s'affiche
                        else if (userChoice != "non")
                        {
                          _displayView.AlertYesNo();
                        }

                    }
                    // par conséquant si l'utilisateur saisie "non" la boucle est égale à true recommence et demande à l'utilisateur son nombre de point de vie 
                    else
                    {
                        HealthPointsValidated = true;
                    }
                }
                // Le Esle est une contrainte utilisateur si les points de vie ne sont pas compris entre 10 et 30 alors un message d'erreur s'affiche
                else
                {
                    _displayView.AlertLifePointNotBetween();
                }
            }
            return healthPoints;
      
        }
        // Cette fonction permet de demander à l'utilisateur de saisir son nombre d'attaque 
        public int AskNumberAttack()
        {
            // création d'une variable int numberOfAttack pour le stockage
            int numberOfAttack;
            // utilisation d'une boucle while pour vérifier si le nombre du nombre d'attaque est saisie
            while (true)
            {
                // j'affiche la question pour le nombre d'attaque avec la fonction AskUserNumberOfAttack() de la view
                _displayView.AskUserNumberOfAttack();
                // utilisation d'un if pour contraindre l'utilisateur a saisir un nombre entre 10 et 30
                if (int.TryParse(Console.ReadLine(), out numberOfAttack) && numberOfAttack >= 10 && numberOfAttack <= 30)
                {
                    break;
                }
                // si ce n'est pas le cas alors un message d'alerte est appeler 
                _displayView.AlertNumberAttackNotBetween();
            }
            return numberOfAttack;
        }
        // Je créer une fonction CreationPersonnal qui me permettra d'utiliser toutes mes fonctions de création en une seule
        // pour l'appelle dans le program
        public void CreationPersonnal(string type)
        {
            // je réasigne name en lui indiquant d'utiliser la fonction AskName();
            string name = AskName();
            // Je fais la même chose pour la vairable healthPoint 
            int healthPoints = AskHealthPoints();
            // je créer un aléatoire entre 10 et 21 pour la condition de limitation
            int numberAttack = new Random().Next(10, 21); 
            // j'initie une condition mon utilisateur saisit un nombre supérieur à 30 alors
            // j'utilise ma varible numberAttack en random avec un message qui lui indique son nombre d'attaque limité
            if (healthPoints >= 30)
            {
                _displayView.DisplayNumberAttack(numberAttack);
            }
            // Dans le cas contraire numberAttack reprendra le nombre saisit dans la fonction AskNumberAttack()
            else
            {
                numberAttack = AskNumberAttack();
            }
            // Je déclare une nouvelle variable afin de stocker un personnage j'appelle la class mère Character et je la déclare en premier lieu à null
            Character perso = null;
            // Je réalise un switch afin que selon le personnage choisit par l'utilsateur soit stocker dans les bonnes classe
            // et ainsi puisse utiliser les bonnes caractéristiques hérité de sa classe  
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
            // j'utilise une condition if pour que si le Perso n'est pas null alors il peut l'ajouter à nos newWarriors
            // pour le stockage de tous les personnage créer
            if (perso != null)
            {
                newWarriors.Add(perso);
                // affichage que le personnage est bien créer 
                _displayView.ShowSuccessesCreationPersonal(perso.Name);
            }
        }
        // création d'une function pour la gestion d'affichage de personnage créer 
        public void DisplayPersonal()
        {
            // affichage du texte du menu d'affichage des personnage
            _displayView.MessageShowPersonal();
            // Utilisation d'un if pour la contrainte utilisateur lui indiquant qu'il n'y a pas de personnage si c'est égale à zéro
            if (newWarriors.Count == 0)
            {
                _displayView.MessageAlertNoneCharacter();
                return;
            }
            // dans le cas ou nous avons au moins un personnage alors je réalise un foreach pour le chercher dans la list et l'afficher
            foreach (var personnage in newWarriors)
            {
                Console.WriteLine(personnage.SeeInfos());

            }
        }
        // Fonction pour lancer un combat 
        public virtual void ChooseFight()
        {
            // Rappel de la fonction MessageFightPersonal() dans la vue pour le texte du menu 3 
            _displayView.MessageFightPersonal();
            // utilisation d'un if pour la contrainte utilisateur si il n'a pas créer plus de deux personnage alors une alerte est lancer
            if (newWarriors.Count < 2)
            {
                _displayView.AlertNumberCharacter();
                return;
            }
            // Je créer un random pour déterminer de façon aléatoire lesquel des personnages seront le joueur 1 et 2
            var rand = new Random();
            Character warriorOne = newWarriors[rand.Next(newWarriors.Count)];
            Character warriorTwo = newWarriors[rand.Next(newWarriors.Count)];
            // je créer une condition avec un do While pour éviter de prendre deux fois le même joueur 
            do
            {
                warriorTwo = newWarriors[rand.Next(newWarriors.Count)];
            } while (warriorTwo == warriorOne);

            // je créer une variable list en string pour les déterminées les choix possible de mon futur mini-jeu 
            string[] validChoices = { "Pierre", "Feuille", "Ciseaux" };
            // je créer une variable pour stocker le choix de mon guerrier 1
            string warriorOneChoice;
            // j'utilise une boucle while afin de rester dans mon mini jeu pierre, feuille  et ciseaux
            while (true)
            {
                // j'utilise un try/catch pour valider la saisi utilisateur 
                try
                {
                    // J'affiche le texte de mon mini jeu stocker dans ma vue 
                    _displayView.MessageMiniGame();
                    // Je réaffecte ma variable warriorOneChoice en stockant ma réponse utilisateur 
                    warriorOneChoice = Console.ReadLine();
                    // Je créer une variable bool pour savoir si mon choix est valide qui me permettra de savoir si mes conditions sont rempli
                    bool isValidChoice = false;
                    // Je réalise un foreach pour savoir si le choix de mon utilisateur sont égale par rapport à ma list
                    foreach (string validChoice in validChoices)
                    {
                        if (warriorOneChoice.ToLower() == validChoice.ToLower())
                        {
                            // si oui on sort de la condition 
                            isValidChoice = true;
                            break;
                        }
                    }
                    // Si le choix ne correpond pas alors un message d'alerte est envoyer 
                    if (!isValidChoice)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException("Choix invalide. Veuillez choisir uniquement entre Pierre, Feuille ou Ciseaux.");
                        
                    }                   
                    break;
                }
                catch (ArgumentException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new ArgumentException("Choix invalide. Veuillez choisir uniquement entre Pierre, Feuille ou Ciseaux.");
                }
            }
            // Je créer une varible pour stocker le choix du guerrier 2 et je créer un random afin de faire un choix aléatoire 
            string choiceGuerrier2 = validChoices[rand.Next(validChoices.Length)];
            // J'appelle ma fonction dans la vue pour afficher ce qu'on choisit chaque joueur
            _displayView.DisplayMiniGameResults(warriorOne.Name, warriorTwo.Name, choiceGuerrier2, warriorOneChoice);
            // j'utilise une varible bool afin de créer des conditions pour detérminer le gagnant du mini-jeu 
            bool warriorOneStart = false;
            // Avec le if/elseif/else je gére les conditions 
            if (warriorOneChoice == choiceGuerrier2)
                // si les choix sont égaux alors j'utilise un random pour choisir le premier qui commencera 
            {
                warriorOneStart = rand.Next(2) == 0;
                _displayView.DisplayWarriorEqualityMiniGame(warriorOneStart);
            }
            // dans le else if je gére les conditions de combats selon ce que le joueur 1 à choisi
            else if (
                (warriorOneChoice == "Pierre" && choiceGuerrier2 == "Ciseaux") ||
                (warriorOneChoice == "Feuille" && choiceGuerrier2 == "Pierre") ||
                (warriorOneChoice == "Ciseaux" && choiceGuerrier2 == "Papier")
            )
            {
                // si elle est vrai alors le joueurs un gagne 
                _displayView.DisplayWarriorOneMiniGame(warriorOne.Name);
                warriorOneStart = true;
            }
            else
            {
                // si c'est faux alors le joueurs deux gagne 
                _displayView.DisplayWarriorTwoMiniGame(warriorTwo.Name);
                warriorOneStart = false;
            }
            // Le combat peut commencer et je rapelle les information de chaque joueur 

             _displayView.LifePointMessage(warriorOne.SeeInfos(), warriorTwo.SeeInfos());
            // J'utilise une boucle while qui va me permettre de déterminer si les joueurs sont en vie ou si ils ont encore un nombre d'attaque
            while (warriorOne.IsAlive && warriorTwo.IsAlive)
            {
             // avec la condition if je détermine si c'est au joueur 1 d'attaquer par rapport au mini jeu 
                if (warriorOneStart)
                {
                    // Utilisation d'un if pour vérifier si le joueur 1 a encore assez d'attaque
                    // si oui il attaque et infilge des dégats au joueur 2 sinon un message nous indique qu'il n'a plus d'attaque 
                    if (warriorOne.CanAttack())
                    {
                        int damage = warriorOne.Tackle();
                        warriorTwo.UndergoDamage(damage);
                        _displayView.DisplayAttackWarriorOne(warriorOne.Name, warriorTwo.Name, damage);
                    }
                    else
                    {
                        _displayView.DisplayNoMoreAttacks(warriorOne.Name);
                        
                        break;
                    }
                    warriorOneStart = false;
                    // Tread.sleep permet un temps de lecture pendant de le combat 
                    Thread.Sleep(2000);
                }
                else
                // Utilisation d'un if pour vérifier si le joueur 2 a encore assez d'attaque
                // si oui il attaque et infilge des dégats au joueur 1 sinon un message nous indique qu'il n'a plus d'attaque 
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
                // affiche les points de vie et d'attaque à chaque boucle en retirant les dégats et diminue le nombre d'attaque 
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
                // si le nombre d'attaque est à zéro pour les deux joueurs mais que le joueur 2 à plus de point de vie il gange 
                _displayView.DisplayIsAliveWarriorTwo(warriorTwo.Name, warriorOne.Name);
            }
            else if (!warriorTwo.IsAlive || (!warriorTwo.CanAttack() && warriorOne.PointOfLife > warriorTwo.PointOfLife))
            {
                // si le nombre d'attaque est à zéro pour les deux joueurs mais que le joueur 1 à plus de point de vie il gange 
                _displayView.DisplayIsAliveWarriorOne(warriorTwo.Name, warriorOne.Name);
            }
            else
            {
                _displayView.DisplayDraw();  // Si ils ont tous les deux le même nombre de point de vie 
            }
            // Afficher le vainqueur
            if (!warriorOne.IsAlive)
            {
                // si le joueur un n'a plus de point de vie alors le joueur 2 gagne le combat 
                _displayView.DisplayIsAliveWarriorTwo(warriorTwo.Name, warriorOne.Name);
            }
            else
            {
                // si le joueur deux n'a plus de point de vie alors le joueur 1 gagne le combat
                _displayView.DisplayIsAliveWarriorOne(warriorTwo.Name, warriorOne.Name);
            }
            // rappel des fonctions reset() et ResetNumberOfAttack pour chaque joueur pour ne pas recommencer un nouveau combat avec des scores bas 
            warriorOne.Reset();
            warriorTwo.Reset();
            warriorOne.ResetNumberOfAttacks();
            warriorTwo.ResetNumberOfAttacks();

        }
    }
}
