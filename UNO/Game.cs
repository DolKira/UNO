using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO
{
    class Game
    {
        public CardSet Table { get; }
        public List<Player> Players { get; }
        public CardSet Deck { get; }

        public bool Reverse { get; set; }

        public CardColor currentColor { get; set; }
        public Player ActivePlayer { get; set; }

        public Action<Player> MarkActivePlayer;
        public Action<string> ShowMessage;
        public Func<CardColor> ColorRequest;

        public Game(CardSet table, CardSet deck, params Player[] players)
        {
            Table = table;
            Players = new List<Player>(players);
            Deck = deck;
            ActivePlayer = players[0];
        }
        public void Move(Player mover, Card card)
        {
            if (mover != ActivePlayer) return;

            if (mover.PlayerCards.Cards.IndexOf(card) == -1) return;

            /*проверить стол. Если пустой, то ок. Если нет, то проверить последнюю карту
             если она обычная. проверить звет и значение,
             если функциональная, проверить цвет,
             если черная, то ок*/

            Table.Add(mover.PlayerCards.Pull(card));

            if (card is FunctionCard)
            {
                ((FunctionCard)card).DoFunction(this);
            }
            else
            {
                currentColor = ((ValueCard)card).Color;
                ActivePlayer = NextPlayer(ActivePlayer);
            }
            
            MarkActivePlayer(ActivePlayer);
            Refresh();
        }

        public void Refresh()
        {
            foreach (var item in Players)
            {
                item.PlayerCards.Show();
            }
            Table.Show();
        }

        public Player NextPlayer(Player player)
        {
            if (Reverse) return PreviousPlayer(player);

            if (player == Players[Players.Count - 1]) return Players[0];

            return Players[Players.IndexOf(player) + 1];
        }

        private Player PreviousPlayer(Player player)
        {
            if (player == Players[0]) return Players[Players.Count - 1];

            return Players[Players.IndexOf(player) - 1];
        }

        public void Deal()
        {
            Deck.Mix();
            foreach (var item in Players)
            {
                item.PlayerCards.Add(Deck.Deal(6));
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
    }
}
