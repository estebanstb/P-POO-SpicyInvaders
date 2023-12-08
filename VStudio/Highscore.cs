using System;
using MySql.Data.MySqlClient;

namespace esteban_SpicyInvaders
{
    internal class Highscore
    {
        public Highscore()
        {
                Console.WriteLine
                (@"
                ░█████╗░██╗░░░░░░█████╗░░██████╗░██████╗███████╗███╗░░░███╗███████╗███╗░░██╗████████╗
                ██╔══██╗██║░░░░░██╔══██╗██╔════╝██╔════╝██╔════╝████╗░████║██╔════╝████╗░██║╚══██╔══╝
                ██║░░╚═╝██║░░░░░███████║╚█████╗░╚█████╗░█████╗░░██╔████╔██║█████╗░░██╔██╗██║░░░██║░░░
                ██║░░██╗██║░░░░░██╔══██║░╚═══██╗░╚═══██╗██╔══╝░░██║╚██╔╝██║██╔══╝░░██║╚████║░░░██║░░░
                ╚█████╔╝███████╗██║░░██║██████╔╝██████╔╝███████╗██║░╚═╝░██║███████╗██║░╚███║░░░██║░░░
                ░╚════╝░╚══════╝╚═╝░░╚═╝╚═════╝░╚═════╝░╚══════╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░"); 
                Console.Write("\n");

            // Suite d'identifiants pour se connecter a la DB
            string connectionString = "User=root; Password=root; Server=localhost; Port=6033; Database=db_space_invaders;";

            // Connexion à la DB
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                // Permet de pouvoir bouger et place le classement ou on veut sur la console
                int x = 75;
                int y = 10;
                int w = 35;
                int z = 10;
                connection.Open();

                // Vous pouvez maintenant exécuter des requêtes SQL ici
                string query = "SELECT * FROM t_joueur order by jouNombrePoints desc limit 5;";
                MySqlCommand command = new MySqlCommand(query, connection);



                using (MySqlDataReader reader = command.ExecuteReader())
                { 
                    while (reader.Read())
                    {
                        Console.SetCursorPosition(w, z);
                        Console.WriteLine(reader["jouPseudo"].ToString());
                        z++;
                    }
                }
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine(reader["jouNombrePoints"].ToString());
                        y++;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            Console.ReadKey(true);
        }   

    }
    
}