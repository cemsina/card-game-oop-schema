using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class MoveUndoHandler
    {
        private Move move;
        public MoveUndoHandler(Move m)
        {
            this.move = m;
        }
        public void Undo()
        {
            switch (this.move.Type)
            {
                case Move.MoveEnum.AddCardToDeck:
                    UndoHandler_AddCardToDeck();
                    break;
                case Move.MoveEnum.RemoveCardFromDeck:
                    UndoHandler_RemoveCardFromDeck();
                    break;
                case Move.MoveEnum.MixDeck:
                    UndoHandler_MixDeck();
                    break;
            }
        }
        private void UndoHandler_AddCardToDeck()
        {
            Deck d = (Deck)this.move.Arguments["Deck"];
            Card c = (Card)this.move.Arguments["Card"];
            d.CardList.Remove(c);
        }
        private void UndoHandler_RemoveCardFromDeck()
        {
            Deck d = (Deck)this.move.Arguments["Deck"];
            Card c = (Card)this.move.Arguments["Card"];
            d.CardList.Add(c);
        }
        private void UndoHandler_MixDeck()
        {
            Deck beforeMix = (Deck)this.move.Arguments["DeckBeforeMix"];
            Deck afterMix = (Deck)this.move.Arguments["DeckAfterMix"];
            afterMix = beforeMix;
        }
    }
}
