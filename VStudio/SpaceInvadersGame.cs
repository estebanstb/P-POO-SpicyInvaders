using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace esteban_SpicyInvaders
{
    internal class SpaceInvadersGame
    {
        private int playerX;
        private int playerY;
        private int playerLives;
        private int score;
        private List<int> invadersX;
        private List<int> invadersY;
        private List<bool> invadersAlive;
        private List<int> bulletsX;
        private List<int> bulletsY;
        private List<bool> bulletsAlive;
        private int screenWidth;
        private int screenHeight;
        private Random random;
        private string playerName;

        private MySqlConnection connection;
        public SpaceInvadersGame(int width, int height)
        {
            screenWidth = width;
            screenHeight = height;

            playerLives = 3;
            score = 0;

            invadersX = new List<int>();
            invadersY = new List<int>();
            invadersAlive = new List<bool>();
            bulletsX = new List<int>();
            bulletsY = new List<int>();
            bulletsAlive = new List<bool>();

            random = new Random();

            playerName = "";

            string connectionString = "User=root; Password=root; Server=localhost; Port=6033; Database=db_space_invaders;";
            connection = new MySqlConnection(connectionString);
        }

        public void Start()
        {
            Console.WindowHeight = screenHeight;
            Console.WindowWidth = screenWidth;
            Console.BufferHeight = screenHeight;
            Console.BufferWidth = screenWidth;
            Console.CursorVisible = false;

            Console.SetCursorPosition(screenWidth / 2 - 15, screenHeight / 2 - 3);
            Console.Write("Eliminez tous les envahisseurs !");
            Console.SetCursorPosition(screenWidth / 2 - 13, screenHeight / 2 - 1);
            Console.Write("[<-] + [->] pour se déplacer");
            Console.SetCursorPosition(screenWidth / 2 - 8, screenHeight / 2 + 1);
            Console.Write("ESPACE pour tirer");
            Console.SetCursorPosition(screenWidth / 2 - 17, screenHeight / 2 + 5);
            Console.Write("Appuyez sur ENTER pour lancer le jeu");
            Console.ReadLine();

            playerX = screenWidth / 2;
            playerY = screenHeight - 1;

            InitializeInvaders();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    MovePlayer(key);
                    if (key == ConsoleKey.Spacebar)
                    {
                        Shoot();
                    }
                }

                MoveBullets();
                CheckCollisions();
                MoveInvaders();
                DrawScreen();

                bool allInvadersDead = invadersAlive.All(invader => !invader);

                if (allInvadersDead)
                {
                    HandleGameEnd();
                    break;
                }

                Thread.Sleep(35);
            }
        }

        private void InitializeInvaders()
        {
            for (int i = 0; i < 10; i++)
            {
                invadersX.Add(random.Next(screenWidth));
                invadersY.Add(random.Next(3));
                invadersAlive.Add(true);
            }
        }

        private void DrawScreen()
        {
            Console.Clear();

            for (int i = 0; i < invadersX.Count; i++)
            {
                if (invadersAlive[i] && invadersY[i] < screenHeight)
                {
                    Console.SetCursorPosition(invadersX[i], invadersY[i]);
                    Console.Write("V");
                }
            }

            for (int i = 0; i < bulletsX.Count; i++)
            {
                if (bulletsAlive[i] && bulletsY[i] >= 0 && bulletsY[i] < screenHeight)
                {
                    Console.SetCursorPosition(bulletsX[i], bulletsY[i]);
                    Console.Write("|");
                }
            }

            if (playerY < screenHeight)
            {
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("A");
            }

            Console.SetCursorPosition(0, 0);
            Console.Write($"Vies : {playerLives}  Score : {score}");
        }

        private void MovePlayer(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow && playerX > 0)
            {
                playerX--;
            }
            else if (key == ConsoleKey.RightArrow && playerX < screenWidth - 1)
            {
                playerX++;
            }
        }

        private void MoveInvaders()
        {
            for (int i = 0; i < invadersX.Count; i++)
            {
                if (invadersAlive[i])
                {
                    invadersY[i]++;
                    if (invadersY[i] >= screenHeight)
                    {
                        invadersY[i] = 0;
                        invadersX[i] = random.Next(screenWidth);
                    }

                    if (invadersX[i] == playerX && invadersY[i] == playerY)
                    {
                        playerLives--;
                        if (playerLives == 0)
                        {
                            HandleGameEnd();
                            break;
                        }
                        invadersAlive[i] = false;
                    }
                }
            }
        }

        private void MoveBullets()
        {
            for (int i = 0; i < bulletsX.Count; i++)
            {
                if (bulletsAlive[i])
                {
                    bulletsY[i]--;
                    if (bulletsY[i] < 0)
                    {
                        bulletsAlive[i] = false;
                    }
                }
            }
        }

        private void Shoot()
        {
            bulletsX.Add(playerX);
            bulletsY.Add(playerY - 1);
            bulletsAlive.Add(true);
        }

        private void CheckCollisions()
        {
            for (int i = 0; i < bulletsX.Count; i++)
            {
                if (bulletsAlive[i])
                {
                    for (int j = 0; j < invadersX.Count; j++)
                    {
                        if (invadersAlive[j] && bulletsX[i] == invadersX[j] && bulletsY[i] == invadersY[j])
                        {
                            invadersAlive[j] = false;
                            bulletsAlive[i] = false;
                            score += 100;
                        }
                    }
                }
            }
        }

        private void HandleGameEnd()
        {
            Console.Clear();
            Console.SetCursorPosition(screenWidth / 2 - 16, screenHeight / 2 - 1);
            Console.Write("Game Over!");
            Console.SetCursorPosition(screenWidth / 2 - 8, screenHeight / 2 + 1);
            Console.Write("Entrez votre pseudo : ");
            playerName = Console.ReadLine();

            try
            {
                connection.Open();
                string query = "INSERT INTO t_joueur (jouPseudo, jouNombrePoints) VALUES(@playerName, @score);";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@playerName", playerName);
                command.Parameters.AddWithValue("@score", score);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                Console.ReadLine();
            }
            finally
            {
                connection.Close();
            }

            Environment.Exit(0);
        }
    }

}
