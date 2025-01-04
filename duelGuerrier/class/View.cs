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
        // ----------------------------------------------------Functions pour les messages d'affichages----------------------------------------
        public void DisplayStart()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("████──████─█──█───██─████─█──█────███─███────████─█─█─███─████─████─███─███─████\r\n█──██─█──█─██─█────█─█──█─██─█────█────█─────█────█─█─█───█──█─█──█──█──█───█──█\r\n█──██─█──█─█─██────█─█──█─█─██────███──█─────█─██─█─█─███─████─████──█──███─████\r\n█──██─█──█─█──█─█──█─█──█─█──█────█────█─────█──█─█─█─█───█─█──█─█───█──█───█─█─\r\n████──████─█──█─████─████─█──█────███──█─────████─███─███─█─█──█─█──███─███─█─█─\r\n");
            Console.WriteLine("       ^                ^               ^\r\n      / \\              / \\             / \\\r\n     |   |            |   |           |   |\r\n     |   |            |   |           |   |\r\n     | | |            | | |           | | |\r\n     | | |            | | |           | | |\r\n     | | |            | | |           | | |\r\n     | | |            | | |           | | |\r\n  ===========      ===========      =========\r\n    =======          =======          =====\r\n      | |              | |             | |\r\n      | |              | |             | |\r\n      | |              | |             | |\r\n       @                @               @");
            Console.ResetColor();
            Console.Write("Appuyer sur <Enter> pour commencer ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
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
        public void Role()
        {
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.WriteLine(" -1 Créer votre Challenger ! \n");
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.WriteLine("Veuillez choisir le rôle de votre personnage :\n");
            Console.WriteLine("1. Guerrier \n");
            Console.WriteLine("2. Nain \n");
            Console.WriteLine("3. Elfe \n");
            Console.ForegroundColor= ConsoleColor.DarkRed;
            Console.WriteLine("0. retour au menu principal\n");
            Console.ResetColor();
            Console.WriteLine("Entrez le numéro correspondant à votre choix :");
        }
        public void MessageFightPersonal()
        {
            Console.ForegroundColor=ConsoleColor.DarkYellow;
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.WriteLine(" -3 Lancer un combat ! \n");
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.ResetColor();
        }
        public void MessageShowPersonal()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.WriteLine(" - 2 Afficher les joueurs ! \n");
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.ResetColor();
            Console.WriteLine("Voici tout vos challengers \n");
        }
        public void MessageMiniGame()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.WriteLine("\nMini-jeu : Pierre-Feuille-Ciseaux !");
            Console.WriteLine("\n" + new string('\u2550', 35));
            Console.ResetColor();
            Console.WriteLine("Veuillez choisir entre Pierre, Feuille, Ciseaux :");
        }
        public void LifePointMessage(string warriorOne, string warriorTwo)
        {
            Console.WriteLine($"{warriorOne}\n{warriorTwo}\n");
        }

        public void DisplayNoMoreAttacks(string warriorName)
        {
            Console.WriteLine($"{warriorName} n'a plus d'attaques disponibles !");
        }

        public void DisplayBothOutOfAttacks()
        {
            Console.WriteLine("Les deux combattants sont à court d'attaques ! Le combat est terminé !");
        }

        public void DisplayDraw()
        {
            Console.WriteLine("Match nul ! Les deux combattants ont le même nombre de points de vie !");
        }

        

      
        // Message Class Character
        public void MessageTackle(int damage,string name)
        {
            Console.WriteLine($"les dégats de {name} sont de {damage} ");
        }
        public void MessageUndergoDamage(string name, int newPointOfLife)
        {
            Console.WriteLine($"{name} vos points de vie sont de {newPointOfLife}");
        }

      

        // message Class Dwarf
        public void MessageHeavyTrue(string nameWarrior)
        {
            Console.WriteLine($"{nameWarrior} a une armure lourde.");
        }
        public void MessageHeavyFalse(string nameWarrior)
        {
            Console.WriteLine($"{nameWarrior} n'a pas d'armure lourde.");
        }
        public void MessageUndergoDamageHeavy(string name,int newPointOfLife)
        {
            Console.WriteLine($"{name} Grâce à votre armure lourde, vos points de vie sont de {newPointOfLife}.");
        }
        // message Class Warrior
        public void MessageSwordOfLightTrue(string name)
        {
            Console.WriteLine($"{name} a une épée de lumière qui plus permet d'infligé +2 dégats.");
        }
        public void MessageSwordOfLightFalse(string name)
        {
            Console.WriteLine($"{name} n'a pas d'épée de lumière.");
        }
        public void TackleSwordofLight(string name,int damage, int newDamage)
        {
            Console.WriteLine($"les dégats de {name} sont de {damage} mais grâce à votre épée de lumière les dégats sont {newDamage} ");
        }

        // controller
        public void AskUserName()
        {
            Console.WriteLine("Veuillez entrer le nom de votre combattant :");
        }
        public void AskUserNumberOfAttack()
        {
            Console.WriteLine("Veuillez entrer votre nombre d'attaques (entre 10 et 30) :");
        }
        public void AskUserLifePoint()
        {
            Console.WriteLine("Veuillez entrer vos points de vie (entre 10 et 50) :");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Attention les point de vie supérieur à 30 seront limité");
            Console.ResetColor();
        }
        // ---------------------------------------------Functions Message D'alerte------------------------------------------------------------ 
       // ----------------------------------------------Alerte du controller----------------------------------------------------------
       // Message d'alerte si il n'y a pas de personnage créer dans le menu d'affichage
        public void MessageAlertNoneCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Aucun personnage créé pour le moment.");
            Console.ResetColor();
        }
        // Message d'alerte si le nombre de point de vie choisie par le joueur est supérieur à 30 
        public void DisplayNumberAttack(int numberOfAttack)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Le nombre d'attaques sera limité automatiquement.");
            Console.ResetColor();
            Console.WriteLine($"Votre nombre d'attaques sera de {numberOfAttack}");
        }
        // Message d'alerte si le joueur lance un combat est qu'il n'y a pas plus de deux joueurs 
        public void AlertNumberCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Il faut au moins 2 personnages pour lancer un combat !");
            Console.ResetColor();
        }
        public void AlertLifePoint()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vos points de vie sont élevés, le nombre d'attaques sera limité automatiquement!");
            Console.ResetColor();
            Console.WriteLine("Êtes-vous sûr de vouloir poursuivre avec ce nombre de points de vie (oui/non) ?");
        }
        public void AlertYesNo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Entrée invalide, veuillez répondre par 'oui' ou 'non'.");
            Console.ResetColor();
        }
        public void AlertLifePointNotBetween()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Entrée invalide, veuillez entrer un nombre compris entre 10 et 50.");
            Console.ResetColor();
        }
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

        //--------------------------------------------------- Functions Message succès--------------------------------------------------------
        public void ShowSuccessesCreationPersonal(string name)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Votre combattant {name} a été créé avec succès !");
            Console.ResetColor();
        }

       
         //------------------------------------------------- Functions Message de Résultat----------------------------------------------------
       public void DisplayAttackWarriorOne(string warriorOne,string warriorTwo, int damage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{warriorOne} inflige {damage} dégâts à {warriorTwo} !");
            Console.ResetColor();
        }
        public void DisplayAttackWarriorTwo(string warriorOne,string warriorTwo, int damage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{warriorTwo} inflige {damage} dégâts à {warriorOne} !");
            Console.ResetColor();
        }

        public void DisplayWarriorMiniGame(string warriorOne,string warriorTwo, string choiceWarriorOne,string choiceWarriortwo)
        {
            Console.WriteLine($"{warriorOne} choisit : {choiceWarriorOne}");
            Console.WriteLine($"{warriorTwo} choisit : {choiceWarriortwo}");
        }

        public void DisplayWarriorEqualityMiniGame(bool warriorOneStart)
        {
            Console.WriteLine("Égalité ! Le départ sera choisi aléatoirement.");
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            Console.WriteLine($"c'est à {warriorOneStart} de commencer");
            Console.ResetColor();
        }

        public void DisplayWarriorOneMiniGame(string warriorOne)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{warriorOne} remporte le mini-jeu et commence !");
            Console.ResetColor();
        }
        public void DisplayWarriorTwoMiniGame(string warriorTwo)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{warriorTwo} remporte le mini-jeu et commence !");
            Console.ResetColor();
        }

        public void DisplayIsAliveWarriorOne(string warriorTwo, string warriorOne)
        {
            Console.ForegroundColor =ConsoleColor.DarkGreen;
            Console.WriteLine($"{warriorTwo} est mort ! {warriorOne} remporte le combat !");
            Console.ResetColor();
        }
        public void DisplayIsAliveWarriorTwo (string warriorTwo, string warriorOne)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{warriorOne} est mort ! {warriorTwo} remporte le combat !");
            Console.ResetColor();
        }

        internal void MessageNoMoreAttacks(string name)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{name} n'a plus d'attaques disponibles !");
            Console.ResetColor();
        }
    }
}
