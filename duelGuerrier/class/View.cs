using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using duelGuerrier.@class;
using static System.Net.Mime.MediaTypeNames;

namespace duelGuerrier.@class
{

    internal class View
    {
        public View() {}
        // ----------------------------------------------------Fonctions pour les messages d'affichages----------------------------------------
        // -------------------------------------------------------Message pour le Program-----------------------------------------------------
        // Message d'ouverture du jeu 
        public void DisplayStart()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("████──████─█──█───██─████─█──█────███─███────████─█─█─███─████─████─███─███─████\r\n█──██─█──█─██─█────█─█──█─██─█────█────█─────█────█─█─█───█──█─█──█──█──█───█──█\r\n█──██─█──█─█─██────█─█──█─█─██────███──█─────█─██─█─█─███─████─████──█──███─████\r\n█──██─█──█─█──█─█──█─█──█─█──█────█────█─────█──█─█─█─█───█─█──█─█───█──█───█─█─\r\n████──████─█──█─████─████─█──█────███──█─────████─███─███─█─█──█─█──███─███─█─█─\r\n");
            Console.WriteLine("       ^                ^               ^\r\n      / \\              / \\             / \\\r\n     |   |            |   |           |   |\r\n     |   |            |   |           |   |\r\n     | | |            | | |           | | |\r\n     | | |            | | |           | | |\r\n     | | |            | | |           | | |\r\n     | | |            | | |           | | |\r\n  ===========      ===========      =========\r\n    =======          =======          =====\r\n      | |              | |             | |\r\n      | |              | |             | |\r\n      | |              | |             | |\r\n       @                @               @");
            Console.ResetColor();
            Console.Write("Appuyer sur <Enter> pour commencer ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
        // Affichage du Menu principal 
        public void DisplayMenu()
        {
            Console.WriteLine("\n" + new string('\u2550', 50));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("---- Dongons et Guerrier ----- \n");
            Console.ResetColor();
            Console.WriteLine(" - 1 Créer votre challenger ! \n");
            Console.WriteLine(" - 2 Afficher les joueurs ! \n");
            Console.WriteLine(" - 3 Lancer un combat ! \n");           
            Console.WriteLine(" - 0 On Quitter le jeux ! \n");
            Console.WriteLine("Entrez le numéro correspondant à votre choix :");
            Console.WriteLine("\n" + new string('\u2550', 50));
        }
        // Affichage des choix de roles des personnages
        public void Role()
        {
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.WriteLine(" -1 Créer votre Challenger ! \n");
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.WriteLine("Veuillez choisir le rôle de votre personnage :\n");
            Console.WriteLine("1. Guerrier \n");
            Console.WriteLine("Le guerrier peut avoir une épée qui infilgera +2 dégats\n");
            Console.WriteLine("2. Nain \n");
            Console.WriteLine("Le nain peut avoir une armure qui réduira les dégats subit\n");
            Console.WriteLine("3. Elfe \n");
            Console.WriteLine("L'elfe infligera toujours au moins 1 de dégats");
            Console.ForegroundColor= ConsoleColor.DarkRed;
            Console.WriteLine("0. retour au menu principal\n");
            Console.ResetColor();
            Console.WriteLine("Entrez le numéro correspondant à votre choix :");
        }
        // ------------------------------------------------Message du controller--------------------------------------------------------- 
        // Affiche la liste des personnages crées 
        public void MessageShowPersonal()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.WriteLine(" - 2 Afficher les joueurs ! \n");
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.ResetColor();
            Console.WriteLine("Voici tout vos challengers \n");
        }
        // Message lors de la création d'un personnage pour demander à l'utilisateur de choisir un nom
        public void AskUserName()
        {
            Console.WriteLine("Veuillez entrer le nom de votre combattant :");
        }
        // Message lors de la création d'un personnage pour demander à l'utilisateur de choisir un nombre de point de vie limité à 30
        public void AskUserLifePoint()
        {
            Console.WriteLine("Veuillez entrer vos points de vie (entre 10 et 50) :");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Attention les point de vie supérieur à 30 seront limité");
            Console.ResetColor();
        }
        // Message lors de la création d'un personnage pour demander à l'utilisateur de choisir un nombre d'attaque 
        public void AskUserNumberOfAttack()
        {
            Console.WriteLine("Veuillez entrer votre nombre d'attaques (entre 10 et 30) :");
        }
        // Message pour lancer le combat 
        public void MessageFightPersonal()
        {
            Console.ForegroundColor=ConsoleColor.DarkYellow;
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.WriteLine(" -3 Lancer un combat ! \n");
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.ResetColor();
        }
        // Message pour l'affichage du jeu pierre, feuille, ciseaux
        public void MessageMiniGame()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.WriteLine("\nMini-jeu : Pierre-Feuille-Ciseaux !");
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.ResetColor();
            Console.WriteLine("Veuillez choisir entre Pierre, Feuille, Ciseaux :");
        }
        // Affichage qui permet de montrer les points de vies des joueurs et leurs nombres d'attaques et de rapeller la fonction seeInfos lors du combat
        public void LifePointMessage(string warriorOne, string warriorTwo)
        {
            Console.WriteLine($"{warriorOne}\n{warriorTwo}\n");
        }
        // Message qui permet d'indiquer que l'un des joueurs ne peut plus attaquer 
        public void DisplayNoMoreAttacks(string warriorName)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{warriorName} n'a plus d'attaques disponibles !");
            Console.ResetColor();
        }
        // Message si les deux personnages n'ont plus d'attaque disponible chancun
        public void DisplayBothOutOfAttacks()
        {
            Console.WriteLine("Les deux combattants sont à court d'attaques ! Le combat est terminé !");
        }
        // Message si les deux personnages n'ont plus d'attaques, ils seront départager par leurs points de vie restant si égalité de points de vie ce texte s'affiche.
        public void DisplayDraw()
        {
            Console.WriteLine("Match nul ! Les deux combattants ont le même nombre de points de vie !");
        }
        //------------------------------------------ Message Class Character------------------------------------------------------------------
        //Affiche les dégats infligés lors d'une attaque 
        public void MessageTackle(int damage,string name)
        {
            Console.WriteLine($"les dégats de {name} sont de {damage} ");
        }
        // Affiche les dégats subit lors d'une attaque 
        public void MessageUndergoDamage(string name, int newPointOfLife)
        {
            Console.WriteLine($"{name} vos points de vie sont de {newPointOfLife}");
        }
        // --------------------------------------------------message Class Dwarf-----------------------------------------------------------------
        // Message qui s'affichera si à la création le nain à une armure 
        public void MessageHeavyTrue(string nameWarrior)
        {
            Console.WriteLine($"{nameWarrior} a une armure lourde.");
        }
        // Message qui s'affichera si à la création le nain n'a pas d'armure 
        public void MessageHeavyFalse(string nameWarrior)
        {
            Console.WriteLine($"{nameWarrior} n'a pas d'armure lourde.");
        }
        // Message qui s'affichera lors d'un combat si le nain à une armure 
        public void MessageUndergoDamageHeavy(string name,int newPointOfLife)
        {
            Console.WriteLine($"{name} Grâce à votre armure lourde, vos points de vie sont de {newPointOfLife}.");
        }
        // ---------------------------------------------------message Class Warrior-----------------------------------------------------------
        // Message à la création d'un guerrier si il a une épée de lumière 
        public void MessageSwordOfLightTrue(string name)
        {
            Console.WriteLine($"{name} a une épée de lumière qui plus permet d'infligé +2 dégats.");
        }
        // Message à la création d'un guerrier si il n'a pas d'épée de lumière 
        public void MessageSwordOfLightFalse(string name)
        {
            Console.WriteLine($"{name} n'a pas d'épée de lumière.");
        }
        // Message lors d'un combat si le guerrier à l'épée de lumière montre les nouveaux dégats infilgé
        public void TackleSwordofLight(string name,int damage, int newDamage)
        {
            Console.WriteLine($"les dégats de {name} sont de {damage} mais grâce à votre épée de lumière les dégats sont {newDamage} ");
        }

        
      
        // ---------------------------------------------Fonctions Message D'alerte------------------------------------------------------------ 
       // ----------------------------------------------Alerte du controller----------------------------------------------------------
       // Message d'alerte s'il n'y a pas de personnage créer dans le menu d'affichage
        public void MessageAlertNoneCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Aucun personnage créé pour le moment.");
            Console.ResetColor();
        }
        // Message d'alerte si l'utilisateur lance un combat et qu'il n'y a pas plus de deux joueurs 
        public void AlertNumberCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Il faut au moins 2 personnages pour lancer un combat !");
            Console.ResetColor();
        }
        // Message d'alerte si le nombre de point de vie choisie par l'utilsateur  est supérieur à 30 
        public void DisplayNumberAttack(int numberOfAttack)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Le nombre d'attaques sera limité automatiquement.");
            Console.ResetColor();
            Console.WriteLine($"Votre nombre d'attaques sera de {numberOfAttack}");
        }
        // Message d'alerte pour indiquer l'utilisateur que son nombre de point de vie est élevé et demande confirmation de choix 
        public void AlertLifePoint()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vos points de vie sont élevés, le nombre d'attaques sera limité automatiquement!");
            Console.ResetColor();
            Console.WriteLine("Êtes-vous sûr de vouloir poursuivre avec ce nombre de points de vie (oui/non) ?");
        }
        // Alerte si l'utilisateur saisi autre chose que oui ou non 
        public void AlertYesNo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Entrée invalide, veuillez répondre par 'oui' ou 'non'.");
            Console.ResetColor();
        }
        // Alerte si l'utilisateur saisit un nombre de point de vie non compris entre 10 et 50
        public void AlertLifePointNotBetween()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Entrée invalide, veuillez entrer un nombre compris entre 10 et 50.");
            Console.ResetColor();
        }
        // Alerte si l'utilisateur saisit un nombre d'attaque non compris entre 10 et 30
        public void AlertNumberAttackNotBetween()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Entrée invalide, veuillez entrer un nombre compris entre 10 et 30.");
            Console.ResetColor();
        }
        // ---------------------------------------------Alerte du Programme-----------------------------------------------------------
       // Message d'alerte si la saisie n'est pas un nombre 
        public void AlertSeizurePlayerCharacterChoice()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Entrée invalide. Veuillez entrer un nombre.");
            Console.ResetColor();
        }
        // message d'alerte si la saisie n'est pas comprise entre 0 et 3
        public void AlertNumberPlayerCharacterChoice()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Entrée invalide. Veuillez entrer un nombre entre 0 et 3.");
            Console.ResetColor();
        }
        //--------------------------------------------------- Fonctions Message succès--------------------------------------------------------
        // Message indiquant lors de la création d'un personnage est un succès 
        public void ShowSuccessesCreationPersonal(string name)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Votre combattant {name} a été créé avec succès !");
            Console.ResetColor();
        }
         //------------------------------------------------- Fonctions Message de Résultat----------------------------------------------------
         // Message lors d'un combat pour indiquer les dégats infligés du joueur 1
        public void DisplayAttackWarriorOne(string warriorOne,string warriorTwo, int damage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{warriorOne} inflige {damage} dégâts à {warriorTwo} !");
            Console.ResetColor();
        }
        // Message lors d'un combat pour indiquer les dégats infligés du joueur 2
        public void DisplayAttackWarriorTwo(string warriorOne,string warriorTwo, int damage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{warriorTwo} inflige {damage} dégâts à {warriorOne} !");
            Console.ResetColor();
        }
        // Message pour indiquer les choix de chacun des joueurs du mini jeu pierre, feuille et ciseaux 
        public void DisplayWarriorMiniGame(string warriorOne,string warriorTwo, string choiceWarriorOne,string choiceWarriortwo)
        {
            Console.WriteLine($"{warriorOne} choisit : {choiceWarriorOne}");
            Console.WriteLine($"{warriorTwo} choisit : {choiceWarriortwo}");
        }
        // Message si égalité lors du mini jeu pierre, feuille et ciseaux 
        public void DisplayWarriorEqualityMiniGame(bool warriorOneStart)
        {
            Console.WriteLine("Égalité ! Le départ sera choisi aléatoirement.");
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            Console.WriteLine($"c'est à {warriorOneStart} de commencer");
            Console.ResetColor();
        }
        // Message du joueur 1 s'il gagne au  mini jeu pierre, feuille et ciseaux 
        public void DisplayWarriorOneMiniGame(string warriorOne)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{warriorOne} remporte le mini-jeu et commence !");
            Console.ResetColor();
        }
        // Message du joueur 2 s'il gagne au  mini jeu pierre, feuille et ciseaux 
        public void DisplayWarriorTwoMiniGame(string warriorTwo)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{warriorTwo} remporte le mini-jeu et commence !");
            Console.ResetColor();
        }
        // Message si le joueur 1 remporte le combat 
        public void DisplayIsAliveWarriorOne(string warriorTwo, string warriorOne)
        {
            Console.ForegroundColor =ConsoleColor.DarkGreen;
            Console.WriteLine($"{warriorTwo} est mort ! {warriorOne} remporte le combat !");
            Console.ResetColor();
        }
        // Message si le joueur 2 remporte le combat 
        public void DisplayIsAliveWarriorTwo (string warriorTwo, string warriorOne)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{warriorOne} est mort ! {warriorTwo} remporte le combat !");
            Console.ResetColor();
        }

    }
}
