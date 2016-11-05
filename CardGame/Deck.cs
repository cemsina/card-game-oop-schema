using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Deck : CardGameObject
    {
        private List<Card> p_CardList;
        public List<Card> CardList
        {
            get { return p_CardList; }
            set{ value.ForEach(c => c.ParentDeck = this); p_CardList = value; }
        }
        public Deck()
        {
            CardList = new List<Card>();
            this.KeyList = new Dictionary<string, object>();
        }
        public Deck Clone()
        {
            Deck newDeck = new Deck();
            newDeck.KeyList = this.CloneKeyList();
            newDeck.CardList = new List<Card>();
            this.CardList.ForEach(c => newDeck.CardList.Add(c.Clone()));
            return newDeck;
        }
        public void MixCards()
        {
            Random rnd = new Random();
            List<Card> newList = new List<Card>();
            while(this.CardList.Count() > 0)
            {
                int selected = rnd.Next(0, this.CardList.Count());
                newList.Add(this.CardList[selected]);
                this.CardList.RemoveAt(selected);
            }
            this.CardList = newList;
        }
        public Card GetRandomCard()
        {
            Random rnd = new Random();
            return this.CardList[rnd.Next(0, this.CardList.Count())];
        }
        public void GetCardFromOtherDeck(Card c)
        {
            Deck OtherDeck = c.ParentDeck;
            OtherDeck.CardList.Remove(c);
            this.CardList.Add(c);
        }
        public void GetRandomCardFromOtherDeck(Deck OtherDeck)
        {
            Card c = OtherDeck.GetRandomCard();
            OtherDeck.CardList.Remove(c);
            this.CardList.Add(c);
        }
        public void DistributeCards(List<Deck> deckList)
        {
            int remaining = this.CardList.Count() % deckList.Count();
            while(this.CardList.Count() - remaining > 0)
            {
                foreach(Deck d in deckList)
                {
                    d.GetRandomCardFromOtherDeck(this);
                }
            }
        }
        public List<Card> GetCardsByType(Card.CardTypeEnum type)
        {
            List<Card> rtrn = new List<Card>();
            foreach(Card c in this.CardList)
            {
                if(c.Type == type) rtrn.Add(c);
            }
            return rtrn;
        }
        public void RemoveCardsByType(Card.CardTypeEnum type)
        {
            List<Card> removeList = this.GetCardsByType(type);
            removeList.ForEach(c => this.CardList.Remove(c));
        }
    }
}
