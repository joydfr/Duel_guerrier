using System;

namespace duelGuerrier.@class
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'une variable displayScreen afin de rappeler les fonction dans la vue 
            View displayScreen = new View();
            // Création d'une variable controller afin de rappeler les fonction dans le controller qui dépende de la vue 
            Controller controller = new Controller(displayScreen);
            // Initialisation d'une varibale int playerChoice pour la réaffecter 
            int playerChoice;
            // Affichage du message d'ouverture du jeu 
            displayScreen.DisplayStart();
            // clean du message d'ouverture du jeu 
            Console.Clear();
            // Utilisation du boucle While pour que l'utilisateur reste dans le programme 
            while (true)
            {
                // utilisation d'un try catch pour contraindre l'utilisateur à saisir un nombre et éviter l'arrêt du programme 
                try
                {
                    // Affichage du menu de sélection
                    displayScreen.DisplayMenu();
                    // réaffectation de playerChoice en int.parse pour la saisie de nombre 
                    playerChoice = int.Parse(Console.ReadLine());
                    
                    // clean de la console 
                    Console.Clear();
                    // utilisation d'un switch pour le menu de sélection à choix multiple par rapport au choix utilisateur 
                    switch (playerChoice)
                    {
                        case 0:
                            // permet de quitter la console 
                            Environment.Exit(0);
                            break;

                        case 1:
                            // permet la création d'un personage 

                            // déclaration d'une variable en bool pour gérer le retour au menu principal
                            bool goBackToMenu = false; 
 
                            //Utilisation d'une boucle While tant qu'elle est différente de goBackToMenu, l'utilisateur reste dans la boucle de création 
                            while (!goBackToMenu)
                            {
                                // Affichage du message pour les différents role possible 
                                displayScreen.Role();
                                // contrainte utilisateur géré avec un if pour que si l'utilisateur saisi autre chose qu'un nombre, le message d'erreur s'affiche 
                                if (!int.TryParse(Console.ReadLine(), out int playerCharacterChoice))
                                {
                                    displayScreen.AlertSeizurePlayerCharacterChoice();
                                    continue;
                                }
                                // utilisation d'un nouveau d'un nouveau swtich pour la confirmation de saisi d'un personnage ou le retour au menu principal
                                // connecter au controleur 
                                switch (playerCharacterChoice)
                                {
                                    case 0:
                                        Console.WriteLine("Retour au menu principal.");
                                        // remise de la variable à true pour sortir et retourner au menu principal 
                                        goBackToMenu = true;
                                        break;
                                    case 1:
                                        Console.WriteLine("Vous avez choisi : Guerrier.");
                                        controller.CreationPersonnal("guerrier");
                                        break;
                                    case 2:
                                        Console.WriteLine("Vous avez choisi : Nain.");
                                        controller.CreationPersonnal("nain");
                                        break;
                                    case 3:
                                        Console.WriteLine("Vous avez choisi : Elfe.");
                                        controller.CreationPersonnal("elfe");
                                        break;
                                    // Contrainte utilisateur si il choissit un nombre non compris dans le menu 
                                    default:
                                        displayScreen.AlertNumberPlayerCharacterChoice();
                                        break;
                                }
                            }
                            break;
                            // Permet l'affichage des joueurs créer 
                        case 2:
                            controller.DisplayPersonal();
                            break;
                          // Permet de lancer un combat   
                        case 3:
                            controller.ChooseFight();
                            break;
                        // Permet la contrainte utilisateur si il saisi autres choses que des nombres 
                        default:
                            displayScreen.AlertSeizurePlayerCharacterChoice();
                            break;
                    }
                }
                // Permet la contrainte utilisateur si il saisi autres choses que des nombres dans le menu 
                catch
                {
                    displayScreen.AlertSeizurePlayerCharacterChoice();
                }
            }
        }
    }
}
