using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Game
    {
        public string Name;
        public List<Player> PlayerList;
        public List<List<Move>> MovesList;
        public Dictionary<string, object> KeyList;
        public Game()
        {
            this.KeyList = new Dictionary<string, object>();
        }
        public void Undo()
        {
            if(this.MovesList.Count() == 0) { return; }
            List<Move> moveList = this.MovesList[this.MovesList.Count() - 1];
            foreach(Move m in moveList)
            {
                MoveUndoHandler undoHandler = new MoveUndoHandler(m);
                undoHandler.Undo();
            }
        }
    }
}
