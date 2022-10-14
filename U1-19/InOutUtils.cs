using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace U1_19
{
    /// <summary>
    /// for reading and writing data.
    /// </summary>
    static class InOutUtils
    {
        /// <summary>
        /// for reading data from file.
        /// </summary>
        /// <param name="fileName"> file name </param>
        /// <param name="Team1"> name of first team </param>
        /// <param name="Team2"> name of second team </param>
        /// <returns> list of players </returns>
        public static List<Player> ReadPlayers(string fileName, out string Team1, out string Team2)
        {
            List<Player> Players = new List<Player>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            Team1 = "";
            Team2 = "";
            foreach (string Line in Lines)
            {
                string[] Values = Line.Split(';');
                string name = Values[0];
                string lastName = Values[1];
                string team = Values[2];
                if (Team1 == "")
                {
                    Team1 = team;
                }
                else if (team != Team1 && Team2 == "")
                {
                    Team2 = team;

                }
                Position position;
                Enum.TryParse(Values[3], out position);

                string champion = Values[4];
                int kills = int.Parse(Values[5]);
                int assists = int.Parse(Values[6]);
                Player player = new Player(name, lastName, team, position, champion, kills, assists);
                Players.Add(player);
            }
            return Players;
        }
        /// <summary>
        /// prints out list of best players in position.
        /// </summary>
        /// <param name="Players"> list of players </param>
        /// <param name="Position"> position </param>
        public static void PrintBestPlayers(List<Player> Players, Position Position)
        {
            int count = TaskUtils.FindBiggestKA(Players, Position);
            Console.WriteLine(new string('-', 88));
            Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|{3,-10}|{4,-15}|{5,-5}|{6,-5}|", "Vardas", "Pavardė", "Komanda", "Pozicija", "Čempionas", "K", "A");
            Console.WriteLine(new string('-', 88));
            foreach (Player player in Players)
            {
                if (count == player.Kills + player.Assists && player.Position.Equals(Position))
                {
                    Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|{3,-10}|{4,-15}|{5,5}|{6,5}|", player.Name, player.LastName, player.Team, player.Position, player.Champion, player.Kills, player.Assists);
                }
            }
            Console.WriteLine(new string('-', 88));
        }
        /// <summary>
        /// prints out list of the best team(-s).
        /// </summary>
        /// <param name="Players"> list of players </param>
        /// <param name="Team1"> name of first team </param>
        /// <param name="Team2"> name of second team </param>
        public static void PrintBestTeam(List<Player> Players, string Team1, string Team2)
        {
            int team1 = TaskUtils.FindTeamAssists(Players, Team1);
            int team2 = TaskUtils.FindTeamAssists(Players, Team2);
            Console.WriteLine(new string('-', 24));
            Console.WriteLine("|{0,-15}|{1,-5}|", "Komanda", "A suma");
            Console.WriteLine(new string('-', 24));
            if (team1 > team2)
            {
                Console.WriteLine("|{0,-15}|{1,5} |", Team1, team1);
            }
            else if (team2 > team1)
            {
                Console.WriteLine("|{0,-15}|{1,5}|", Team2);
            }
            else
            {
                Console.WriteLine("|{0,-15}|{1,5}|", Team1, team1);
                Console.WriteLine("|{0,-15}|{1,5}|", Team2, team2);
            }
            Console.WriteLine(new string('-', 24));
        }
        /// <summary>
        /// prints out list of all the participating champions into .csv file.
        /// </summary>
        /// <param name="champions"> list of champions </param>
        /// <param name="fileName"> file name to print into </param>
        public static void PrintChampions(List<string> champions, string fileName)
        {
            string[] lines = new string[champions.Count];

            for (int i = 0; i < champions.Count; i++)
            {
                lines[i] = champions[i] + ';';
            }
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);

        }
        /// <summary>
        /// prints all information into .txt file.
        /// </summary>
        /// <param name="Players"> list of players </param>
        public static void PrintAllToTXT(List<Player> Players)
        {
            string[] Lines = new string[Players.Count + 2];
            Lines[0] = String.Format(new string('-', 87));
            for(int i =0; i < Players.Count; i++)
            {
                Lines[i + 1] = String.Format("|{0,-15}|{1,-15}|{2,-15}|{3,-10}|{4,-15}|{5,-5}|{6,-5}|", Players[i].Name, Players[i].LastName, Players[i].Team, Players[i].Position, Players[i].Champion, Players[i].Kills, Players[i].Assists);
            }
            Lines[Players.Count + 1] = String.Format(new string('-', 87));

            if (File.Exists("Žaidėjai.txt"))
            {
                File.Delete("Žaidėjai.txt");
            }
            File.WriteAllLines("Žaidėjai.txt", Lines);
        }
    }
}
