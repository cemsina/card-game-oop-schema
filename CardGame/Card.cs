using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card : CardGameObject
    {
        public CardTypeEnum Type;
        public int No;
        public Deck ParentDeck;
        public Card(CardTypeEnum type,int no)
        {
            if(no > 13 || no < 1) throw new ArgumentException("Card No cannot be less than 1 or more than 13");
            this.Type = type;
            this.No = no;
            this.KeyList = new Dictionary<string, object>();
            ParentDeck = null;
        }
        public Card Clone()
        {
            Card newCard = new Card(this.Type, this.No);
            newCard.KeyList = new Dictionary<string, object>();
            newCard.KeyList = this.CloneKeyList();
            newCard.ParentDeck = this.ParentDeck;
            return newCard;
        }
        public enum CardTypeEnum
        {
            Club, Diamond, Heart, Spade
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Card);
        }
        public bool Equals(Card obj)
        {
            return this.Type == obj.Type || this.No == obj.No ? true : false;
        }
        public static bool operator ==(Card card1,Card card2)
        {
            return card1.Equals(card2) ? true : false;
        }
        public static bool operator !=(Card card1, Card card2)
        {
            return card1.Equals(card2) ? false : true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return this.Type.ToString() +" " + this.No.ToString();
        }
    }
}
