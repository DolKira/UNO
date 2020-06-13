using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UNO
{
    public partial class Form1 : Form
    {
        public string SelectedColor;
        Card activeCard;
        Game game;
        Player mover;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, PaintEventArgs e)
        {
             
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            game = new Game(new GraphicCardSet(pnlTable, CardSetType.Empty),
                new GraphicCardSet(pnlDeck, CardSetType.Uno),
                new Player("Sam", new GraphicCardSet(pnlPlayer1, CardSetType.Empty)),
                new Player("Dan", new GraphicCardSet(pnlPlayer2, CardSetType.Empty)),
                new Player("Kate", new GraphicCardSet(pnlPlayer3, CardSetType.Empty)));
            
            foreach (var card in game.Deck.Cards)
            {
                if (card is IGraphics)
                {
                    IGraphics graphics = (IGraphics)card;
                    graphics.Pb.Click += Pb_Click;
                }
            }
            game.ShowMessage = ShowMessage;
            game.MarkActivePlayer = MarkPlayer;
            game.ColorRequest = ColorRequest;

            game.Deal();
            foreach (var card in game.Table.Cards)
            {
                if (card is IGraphics)
                    ((IGraphics)card).Opened = true;
            }

            game.Refresh();
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            SetActiveCard(pictureBox);
            if (activeCard != null)
            {
                lblMessage.Text = game.Move(mover, activeCard);
            }
        }

        public CardColor ColorRequest()
        {
            Form2 fr2 = new Form2();
            fr2.ShowDialog();
            
            return fr2.Color;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CardPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void CardPictureBox_DoubleClick(object sender, EventArgs e)
        {

        }

        private void ShowMessage(string message)
        {
            lblMessage.Text = message;
        }

        private void MarkPlayer(Player activePlayer)
        {
            foreach (var player in game.Players)
            {
                if (player == activePlayer)
                    foreach (var card in player.PlayerCards.Cards)
                    {
                        IGraphics graphicCard = (IGraphics)card;
                        graphicCard.Opened = true;
                    }
                else
                    foreach (var card in player.PlayerCards.Cards)
                    {
                        IGraphics graphicCard = (IGraphics)card;
                        graphicCard.Opened = false;
                    }
            }
            game.Refresh();

        }
        private void SetActiveCard(PictureBox pictureBox)
        {
            foreach (var player in game.Players)
            {
                foreach (var card in player.PlayerCards.Cards)
                {
                    if (((IGraphics)card).Pb ==pictureBox)
                    {

                            activeCard = card;
                            mover = player;
                        return;
                    }
                }
            }
            game.Refresh();
        }

        private void pnlTable_Click(object sender, EventArgs e)
        {
            if (activeCard != null && mover != null)
                game.Move(mover, activeCard);
        }

        private void pnlDeck_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NoCurrentCardButton_Click(object sender, EventArgs e)
        {
            game.NoCurrentCard();
        }
    }
}
