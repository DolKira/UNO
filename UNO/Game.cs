using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNO.Cards;

namespace UNO
{
    class Game
    {
        public CardSet Table { get; }
        public List<Player> Players { get; }
        public CardSet Deck { get; }
        public bool Reverse { get; set; }

        public CardFunction currentFunction { get; set; }
        public CardColor currentColor { get; set; }
        public CardFigure currentFigure { get; set; }
        public Player ActivePlayer { get; set; }
        public bool IsSkip { get;set; }

        public Player NextMover
        {
            get
            {
                if (IsSkip)
                {
                    IsSkip = false;
                    return Reverse ? GetPreviousPlayer(GetPreviousPlayer(ActivePlayer)) :
                        GetNextPlayer(GetNextPlayer(ActivePlayer));
                }
                else
                    return Reverse ? GetPreviousPlayer(ActivePlayer) : GetNextPlayer(ActivePlayer);
            }
        }

        private int _currentPlayerIndex = -1;
        private int _turnDirection = 1;

        public Action<Player> MarkActivePlayer;
        public Action<string> ShowMessage;
        public Func<CardColor> ColorRequest;
        //public Func<CardFunction> FunctionRequest;
        //public Func<CardFigure> FigureRequest;
        //private int cardsToDraw = 0;
        public Game(CardSet table, CardSet deck, params Player[] players)
        {
            Table = table;
            Players = new List<Player>(players);
            Deck = deck;
            ActivePlayer = players[0];
            Reverse = false;
            IsSkip = false;
        }
        public string Move(Player mover, Card card)
        {
            if (mover != ActivePlayer) return "Move is incorrect";

            if (mover.PlayerCards.Cards.IndexOf(card) == -1) return "Move is incorrect";

            if (Table != null)
            {
                if (CurrentCard is ValueCard)
                {
                    ValueCard currentCard = (ValueCard)card;
                    if (card is IColor && ((IColor)card).Color != currentColor) return "Move is incorrect";
                    if (card is ValueCard && ((ValueCard)card).Figure != currentCard.Figure) return "Move is incorrect";
                }
                if (CurrentCard is IFunctional && CurrentCard is IColor)
                {
                    if (card is IColor && ((IColor)card).Color != currentColor) return "Move is incorrect";
                    if (card is IFunctional && card is IColor &&
                        ((IFunctional)CurrentCard).Function != ((IFunctional)card).Function) return "Move is incorrect";
                }
            }


            Deck.Add(mover.PlayerCards.Pull(card));

            if (card is IColor)
                currentColor = ((IColor)card).Color;

            if (card is IFunctional)
                ((IFunctional)card).DoFunction(this);


            
            ActivePlayer = NextMover;            
            MarkActivePlayer(ActivePlayer);
            CheckWinner();
            Refresh();
            return "Ok";
        }

        private void CheckWinner()//проверка выигрыша
        {
            foreach (var item in Players)
            {
                if (item.PlayerCards.Cards.Count != 0)
                    ShowMessage(item.Name + "loose");
            }
        }

        public void NoCurrentCard()
        {
            ActivePlayer.PlayerCards.Add(Deck.Pull());
            ActivePlayer = NextMover;
        }
        //Method игрок не хочет ходить

        public Card CurrentCard
        {
            get { return Table.Cards.Last(); }
        }

        public void Refresh()
        {
            foreach (var card in Players)
            {
                card.PlayerCards.Show();
            }  
            Table.Show();
        }

        public Player GetNextPlayer(Player player)
        {
            if (player == Players[Players.Count - 1]) return Players[0];

            return Players[Players.IndexOf(player) + 1];
        }

        private Player GetPreviousPlayer(Player player)
        {
            if (player == Players[0]) return Players[Players.Count - 1];

            return Players[Players.IndexOf(player) - 1];
        }

        public void Deal()
        {
            Deck.Shuffle();
            foreach (var item in Players)
            {
                item.PlayerCards.Add(Deck.Deal(7));
            }
            Refresh();
        }
        public void GameOver()
        {
            foreach (var item in Players)
            {
                if (item.PlayerCards.Cards.Count != 0)
                    ShowMessage(item.Name + "loose");
            }
        }

        public void HangUp()
        {
            Table.Cards.Clear();
            Refresh();
        }

        public int NumberOfPlayers
        {
            get { return Players.Count; }
        }
        public Hashtable PlayersCards
        {
            get { return PlayersCards; }
        }

        private int CurrentPlayerIndex
        {
            get { return _currentPlayerIndex; }
            set { _currentPlayerIndex = value; }
        }
        public void GoToNextPlayer()
        {
            CurrentPlayerIndex += _turnDirection;

            if (CurrentPlayerIndex < 0)
                CurrentPlayerIndex = Players.Count() - 1;

            if (CurrentPlayerIndex > Players.Count() - 1)
                CurrentPlayerIndex = 0;
        }
        public void ReverseTurnDirection()
        {
            _turnDirection *= -1;
        }
    }
}
