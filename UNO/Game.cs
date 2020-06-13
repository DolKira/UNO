using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNO
{
    class Game
    {
        public CardSet Table { get; }
        public List<Player> Players { get; }
        public CardSet Deck { get; }
        public bool Reverse { get; set; } = false;

        public CardFunction currentFunction { get; set; }
        public CardColor currentColor { get; set; }
        public CardFigure currentFigure { get; set; }
        public Player ActivePlayer { get; set; }
        public bool IsSkip { get; set; } = false;

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
        public Action<Player> Win;

        //public Func<CardFunction> FunctionRequest;
        //public Func<CardFigure> FigureRequest;
        //private int cardsToDraw = 0;
        public Game(CardSet table, CardSet deck, params Player[] players)
        {
            Table = table;
            Players = players.ToList();
            Deck = deck;

        }
        public string Move(Player mover, Card card)
        {
            if (mover != ActivePlayer) return "Move is incorrect";

            if (mover.PlayerCards.Cards.IndexOf(card) == -1) return "Move is incorrect";

            if (Table != null)
            {
                
                if (CurrentCard is ValueCard)
                {
                    if(card is ValueCard)
                    {
                        if ((card is ValueCard && ((IFigure)card).Figure != currentFigure)
                        && (card is ValueCard && ((IColor)card).Color != currentColor)) return "Move is incorrect";
                    }
                    if (card is ColorFunctionCard &&((IColor)card).Color != currentColor) return "Move is incorrect";
                  
                }
                if (CurrentCard is ColorFunctionCard)
                {
                    if (card is ColorFunctionCard &&
                        ((IColorFunction)CurrentCard) != ((IColorFunction)card)
                        && (card is ColorFunctionCard && ((IColor)card).Color != currentColor)) return "Move is incorrect";
                    if(card is ValueCard && ((IColor)card).Color != currentColor) return "Move is incorrect";
                }
                
            }


            Table.Add(mover.PlayerCards.Pull(card));

            currentColor = card.GetColor(this);

            if (card is IFunctional)
                ((IFunctional)card).DoFunction(this);
            if (card is IColorFunction)
                ((IColorFunction)card).DoColorFunction(this);
            if (card is IFigure)
                currentFigure = ((IFigure)card).Figure;


            
            ActivePlayer = NextMover;            
            MarkActivePlayer(ActivePlayer);
            
            Refresh();
            return "Ok";
        }

        private void CheckWinner()//проверка выигрыша
        {
            foreach (var item in Players)
            {
                if (item.PlayerCards.Cards.Count == 0)
                    Win(item);
            }
        }

        public void NoCurrentCard()
        {
            ActivePlayer.PlayerCards.Add(Deck.Pull());
            ActivePlayer = NextMover;
            MarkActivePlayer(ActivePlayer);
            Refresh();
        }
        //Method игрок не хочет ходить

        public Card CurrentCard
        {
            get { return Table.Cards.Last(); }
        }

        public void Refresh()
        {
            foreach (var player in Players)
            {
                player.PlayerCards.Show();
            }
            Table.Show();
            Deck.Show();
            CheckWinner();
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

            Table.Add(Deck.Pull());
            currentColor = Table.Cards[0].GetColor(this);

            ActivePlayer = Players[0];
            MarkActivePlayer(ActivePlayer);
            Reverse = false;
            IsSkip = false;
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
