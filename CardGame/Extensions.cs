using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public static class Extensions
    {
        public static List<Deck> ToDeckList(this List<Player> playerList)
        {
            List<Deck> deckList = new List<Deck>();
            foreach (Player p in playerList)
            {
                deckList.Add(p.Deck);
            }
            return deckList;
        }
    }
}
