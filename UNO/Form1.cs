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
                    graphics.Pb.DoubleClick += CardPictureBox_DoubleClick;
                    graphics.Pb.Click += CardPictureBox_Click;
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

        public CardColor ColorRequest()
        {
            Form2 fr2 = new Form2();
            fr2.Show();
            Hide();
            return game.currentColor;
            //if (game.CurrentCard is FunctionCard)
            //{
            //     comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            //    game.currentColor is SelectedColor;
            //}
            //return ;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CardPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            SetActiveCard(pictureBox);
        }

        private void CardPictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (activeCard != null)
            {
                lblMessage.Text = game.Move(mover, activeCard);
            }
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
                        if (card == activeCard)
                        {
                            activeCard = null;
                            pictureBox.Top -= 10;
                            mover = null;
                        }
                        else
                        {
                            activeCard = card;
                            pictureBox.Top += 10;
                            mover = player;
                        }
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
            game.ActivePlayer = game.NextMover;
        }
    }
}
