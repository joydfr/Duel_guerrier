using System;

namespace duelGuerrier.@class
{
    class Program
    {
        static void Main(string[] args)
        {
            View displayScreen = new View();
            Controller controller = new Controller(displayScreen);
            int playerChoice;
            displayScreen.DisplayStart();
            Console.Clear();
            while (true)
            {
                try
                {
                    displayScreen.DisplayMenu();
                    playerChoice = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (playerChoice)
                    {
                        case 0:
                            Environment.Exit(0);
                            break;

                        case 1:
                            bool goBackToMenu = false; // Variable pour gérer le retour au menu principal
                            while (!goBackToMenu)
                            {
                                displayScreen.Role();

                                if (!int.TryParse(Console.ReadLine(), out int playerCharacterChoice))
                                {
                                    displayScreen.AlertSeizurePlayerCharacterChoice();
                                    continue;
                                }

                                switch (playerCharacterChoice)
                                {
                                    case 0:
                                        Console.WriteLine("Retour au menu principal.");
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

                                    default:
                                        displayScreen.AlertNumberPlayerCharacterChoice();
                                        break;
                                }
                            }
                            break;

                        case 2:
                            controller.DisplayPersonal();
                            break;

                        case 3:
                            controller.ChooseFight();
                            break;
                        default:
                            displayScreen.AlertSeizurePlayerCharacterChoice();
                            break;
                    }
                }
                catch
                {
                    displayScreen.AlertSeizurePlayerCharacterChoice();
                }
            }
        }
    }
}
