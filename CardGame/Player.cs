using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player : CardGameObject
    {
        public string Name;
        public Deck Deck;
        public int Score;
        public bool isDead;
        public Player(String Name)
        {
            this.KeyList = new Dictionary<string, object>();
            Deck = new Deck();
            Score = 0;
            isDead = false;
        }
    }
}
