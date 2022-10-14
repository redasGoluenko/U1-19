using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.GetEncoding(1257);
            Console.OutputEncoding = Encoding.UTF8;
            string Team1;
            string Team2;
            List<Player> AllPlayers = InOutUtils.ReadPlayers(@"Dalyviai.csv", out Team1, out Team2);
            Console.WriteLine("Aktyviausi „Jungle“ pozicijoje žaidžiantys žaidėjai: ");
            InOutUtils.PrintBestPlayers(AllPlayers, Position.Jungle);
            Console.WriteLine();
            Console.WriteLine("Geriausiai bendradarbiavusios komandos:");
            InOutUtils.PrintBestTeam(AllPlayers, Team1, Team2);          
            List<string> Champions = TaskUtils.FindChampions(AllPlayers);
            string fileName = "Čempionai.csv";
            InOutUtils.PrintChampions(Champions, fileName);
            InOutUtils.PrintAllToTXT(AllPlayers);
            Console.WriteLine();
           
        }
    }
}
