using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esteban_SpicyInvaders
{
    class Program
    {
        
        static int selectedOption = 0;

        static void Main()
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool quit = false;

            while (!quit)
            {
                Console.Clear();

                // Affiche le titre;   
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine
            (@"
        ░██████╗██████╗░██╗░█████╗░██╗░░░██╗  ██╗███╗░░██╗██╗░░░██╗░█████╗░██████╗░███████╗██████╗░░██████╗
        ██╔════╝██╔══██╗██║██╔══██╗╚██╗░██╔╝  ██║████╗░██║██║░░░██║██╔══██╗██╔══██╗██╔════╝██╔══██╗██╔════╝
        ╚█████╗░██████╔╝██║██║░░╚═╝░╚████╔╝░  ██║██╔██╗██║╚██╗░██╔╝███████║██║░░██║█████╗░░██████╔╝╚█████╗░
        ░╚═══██╗██╔═══╝░██║██║░░██╗░░╚██╔╝░░  ██║██║╚████║░╚████╔╝░██╔══██║██║░░██║██╔══╝░░██╔══██╗░╚═══██╗
        ██████╔╝██║░░░░░██║╚█████╔╝░░░██║░░░  ██║██║░╚███║░░╚██╔╝░░██║░░██║██████╔╝███████╗██║░░██║██████╔╝
        ╚═════╝░╚═╝░░░░░╚═╝░╚════╝░░░░╚═╝░░░  ╚═╝╚═╝░░╚══╝░░░╚═╝░░░╚═╝░░╚═╝╚═════╝░╚══════╝╚═╝░░╚═╝╚═════╝░"); Console.Write("\n");


                // Position le menu de navigation au centre de l'image
                Console.SetCursorPosition(50, 10);
                string[] options = { "\u25A0 JOUER", "\u25A0 CLASSEMENT" ,"\u25A0 QUITTER" };

                // Affiche le menu avec les options sélectionnables
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.SetCursorPosition(50, 10 + i); // Positionnez le curseur pour afficher le menu au milieu de la fenêtre
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }

                ConsoleKey key = Console.ReadKey().Key;

                // Système pour pouvoir utiliser le menu avec les flèches et Enter
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedOption > 0)
                            selectedOption--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (selectedOption < options.Length - 1)
                            selectedOption++;
                        break;

                    case ConsoleKey.Enter:
                        ExecuteSelectedOption(selectedOption);
                        break;
                }
            }
        }

        static void ExecuteSelectedOption(int optionIndex)
        {
            Console.Clear();

            switch (optionIndex)
            {
                // JOUER
                case 0:
                    // Code pour démarrer le jeu
                    SpaceInvadersGame game = new SpaceInvadersGame(50, 20);
                    game.Start();
                    ReturnToMainMenuPrompt();
                    break;

                // CLASSEMENT
                case 1:
                    // Code pour afficher le classement
                    new Highscore();
                    ReturnToMainMenuPrompt();
                    break;

                // QUITTER
                case 2:
                    Environment.Exit(0);
                    break;

            }
        }

        static void ReturnToMainMenuPrompt()
        {
            Console.WriteLine("\n\n\nTouche ESC pour revenir au menu principal...");

            // Attendre la pression de la touche ESC
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape)
                    return; // Quitte la boucle lorsque la touche ESC est enfoncée
            }
        }
    }
}