using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace U1_19
{
    /// <summary>
    /// for doing calculations.
    /// </summary>
    static class TaskUtils
    {
        /// <summary>
        /// for calculating largest sum of kills and assists of specified position.
        /// </summary>
        /// <param name="Players"> list of players. </param> 
        /// <param name="Position"> specified position </param> 
        /// <returns> largest sum of kills assists </returns>
        public static int FindBiggestKA(List<Player> Players, Position Position)
        {
            int count = 0;
            foreach(Player player in Players)
            {
                if(player.Position.Equals(Position) && count < player.Kills + player.Assists)
                {           
                        count = player.Kills + player.Assists;
                }
            } 
            return count;
        }
      /// <summary>
      /// for calculating sum of assists of specified team.
      /// </summary>
      /// <param name="Players"> list of players </param>
      /// <param name="Team"> specified team </param>
      /// <returns> assists of specified team </returns>
        public static int FindTeamAssists(List<Player> Players, string Team)
        {
            int count = 0;
            foreach(Player player in Players)
            {
                if(player.Team.Equals(Team))
                {
                    count += player.Assists;
                }
            }
            return count;
        }
        /// <summary>
        /// fills up a list with names of champions participating.
        /// </summary>
        /// <param name="Players"> list of players </param>
        /// <returns> list of champions participating </returns>
       public static List<string> FindChampions(List<Player> Players)
        {
            List<string> Champions = new List<string>();
            foreach(Player player in Players)
            {
                string champion = player.Champion;
                if(!Champions.Contains(champion))
                {
                    Champions.Add(champion);
                }
            }
            return Champions;
        }
    }
}
