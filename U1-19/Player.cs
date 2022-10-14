namespace U1_19
{
    /// <summary>
    /// for storing information of the player.
    /// </summary>
    class Player
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Team { get; set; }
        public Position Position { get; set; }
        public string Champion { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }
        /// <summary>
        /// constructor for player class.
        /// </summary>
        /// <param name="name"> name of player </param>
        /// <param name="lastName"> surname of player </param>
        /// <param name="team"> team of player </param>
        /// <param name="position"> position of player </param>
        /// <param name="champion"> name of players champion </param>
        /// <param name="kills"> kills of player </param>
        /// <param name="assists"> assists of player </param>
        public Player(string name, string lastName, string team, Position position, string champion, int kills, int assists)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Team = team;
            this.Position = position;
            this.Champion = champion;
            this.Kills = kills;
            this.Assists = assists;
        }
    }
}
