using MySql.Data.MySqlClient;

namespace testCSHARPIntoSQL
{
    internal class connDb
    {
        public connDb()
        {
            /*// Referencer et donner les identifiants pour se connecter à la DB
            string mysqlCon = "server=localhost; user=root; password=root; database=db_space_invaders;";

            MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);


            // COMMANDE POUR SE CONNECTER A LA DB
            try
            {
                mySqlConnection.Open();

                // Message si la connexion est reussie
                Console.WriteLine("Connexion reussie");
            }
            catch (Exception ex)
            {
                // Afficher le code d'erreur si il y a une erreur
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Couper la connection
                mySqlConnection.Close();
            }*/

            string connectionString = "Server=localhost;Database=db_space_invaders;User=root;Password=root;";



            MySqlConnection connection = new MySqlConnection(connectionString);
            Console.Clear();



            try
            {
                int x = 0;
                int y = 40;
                int w = 0;
                int z = 20;
                connection.Open();
                //Console.WriteLine("Connexion réussie !");



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
