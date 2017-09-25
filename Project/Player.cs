using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string Name;
        public int Score { get; set; }
        public List<Item> Inventory { get; set; }

        public Player(string name, int score){
            Name = name;
            score = Score;
            Inventory = new List<Item>();            
        }
    }
}