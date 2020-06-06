using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNO
{
    enum CardSetType
    {
        Empty,
        Uno
    }

    class CardSet
    {
        public List<Card> Cards { get; set; }
        protected int Count
        {
            get { return Cards.Count; }
        }

        public CardSet(List<Card> cards)
        {
            this.Cards = cards;
        }
        public CardSet() : this(new List<Card>())
        { }

        public CardSet(CardSetType cardSetType) : this()
        {
            if (cardSetType == CardSetType.Empty) return;
            else
            {
                foreach (var figure in Enum.GetValues(typeof(CardFigure)))
                {
                    foreach (var color in Enum.GetValues(typeof(CardColor)))
                    {
                        if ((CardFigure)figure == CardFigure.Zero)
                        {
                            Cards.Add(new ValueCard((CardColor)color, CardFigure.Zero));
                        }
                        else if ((CardFigure)figure != CardFigure.Zero)
                        {
                            for (int i = 1; i <= 2; i++)
                            {
                                Cards.Add(new ValueCard((CardColor)color, (CardFigure)figure));
                            }
                        }
                    }
                }
                foreach (var colorFunction in Enum.GetValues(typeof(CardColorFunction)))
                {
                    foreach (var color in Enum.GetValues(typeof(CardColor)))
                    {
                        for (int i = 1; i <= 2; i++)
                        {
                            Cards.Add(new ColorFunctionCard((CardColor)color, (CardColorFunction)colorFunction));
                        }
                    }
                }
                foreach (var function in Enum.GetValues(typeof(CardFunction)))
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        Cards.Add(new FunctionCard((CardFunction)function));
                    }
                }
            }
        }

        public void Mix()
        { 
            //Random r = new Random();
            //List<Card> newCards = Cards;
            //for (int i = Cards.Count - 1; i > 0; --i)
            //{
            //    int n = r.Next(i + 1);
            //    Card t = Cards[i];
            //    Cards[i] = Cards[n];
            //    Cards[n] = t;
            //}
        }
        public void Add(params Card[] card)
        {
            foreach (var item in card)
            {
                Cards.Add(item);
            }
        }

        public void Add(CardSet cards)
        {
            Add(cards.Cards.ToArray());
        }
        public Card Pull()
        {
            return Pull(0);
        }
        public Card Pull(int number)
        {
            if (number > Count - 1) return null;

            Card a = Cards[number];
            Cards.RemoveAt(number);
            return a;
        }
        public Card Pull(Card card)
        {
            int ind = Cards.IndexOf(card);
            if (ind == -1) throw new Exception("Card's not find from cardset");
            return Pull(ind);
        }
        public virtual void Show()
        {
            foreach (var card in Cards)
            {
                card.Show();
            }
        }

        //public virtual void Sort()
        //{
        //    Cards.Sort((card1, card2) =>
        //    card1.Figure.CompareTo(card2.Figure) == 0 ?
        //    card1.Suit.CompareTo(card2.Suit) :
        //    card1.Figure.CompareTo(card2.Figure)
        //        );
        //}

        public void Shuffle()
        {
            Random r = new Random();
            List<Card> cards = Cards;
            for (int n = cards.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                Card temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }
        }
        public CardSet Deal(int amount)
        {
            CardSet c = new CardSet();
            if (amount > Cards.Count) amount = Cards.Count;

            for (int i = 0; i < amount; i++)
            {
                c.Add(Cards[0]);
                Cards.RemoveAt(0);
            }
            return c;
        }

        public List<Card> Draw(int count)
        {
            var drawnCards = Cards.Take(count).ToList();
            Cards.RemoveAll(x => drawnCards.Contains(x));
            return drawnCards;
        }
    }
}
