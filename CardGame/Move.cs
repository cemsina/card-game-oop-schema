using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Move
    {
        public DateTime MoveDateTime;
        public MoveEnum Type;
        public Dictionary<string, object> Arguments;
        public Move(MoveEnum type,Dictionary<string,object> args)
        {
            if(args == null) { throw new ArgumentException("Arguments cannot be null"); }
            this.Type = type;
            this.Arguments = args;
        }
        public enum MoveEnum
        {
            AddCardToDeck,
            RemoveCardFromDeck,
            MixDeck
        }
    }
}
