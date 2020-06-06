using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNO.Cards;
using UNO.Properties;

namespace UNO
{
    public partial class Form1 : Form
    {
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
            game = new Game(new GraphicCardSet(pnlTable, CardSetType.Empty), new GraphicCardSet(pnlDeck, CardSetType.Uno),
                new Player("Sam", new GraphicCardSet(pnlPlayer1, CardSetType.Empty)), new Player("Dan", new GraphicCardSet(pnlPlayer2, CardSetType.Empty)));
            
            foreach (var card in game.Deck.Cards)
            {
                if (card is GraphicValueCard)
                {
                    IGraphics graphics = (GraphicValueCard)card;
                    graphics.Pb.DoubleClick += CardPictureBox_DoubleClick;
                    graphics.Pb.Click += CardPictureBox_Click;
                }
                else if (card is GraphicFunctionCard)
                {
                    IGraphics graphics = (GraphicFunctionCard)card;
                    graphics.Pb.DoubleClick += CardPictureBox_DoubleClick;
                    graphics.Pb.Click += CardPictureBox_Click;
                }
                else if (card is GraphicColorFunctionCard)
                {
                    IGraphics graphics = (GraphicColorFunctionCard)card;
                    graphics.Pb.MouseDoubleClick += CardPictureBox_DoubleClick;
                    graphics.Pb.Click += CardPictureBox_Click;
                }
            }
            game.ShowMessage = ShowMessage;
            game.MarkActivePlayer = MarkPlayer;

            game.Deal();
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
                        GraphicFunctionCard graphicCard = (GraphicFunctionCard)card;
                        graphicCard.Opened = true;
                    }
                else
                    foreach (var card in player.PlayerCards.Cards)
                    {
                        GraphicFunctionCard graphicCard = (GraphicFunctionCard)card;
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
                    if (((GraphicFunctionCard)card).Pb is PictureBox && ((GraphicColorFunctionCard)card).Pb is PictureBox && ((GraphicValueCard)card).Pb is PictureBox)
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
        }

        private void pnlTable_Click(object sender, EventArgs e)
        {
            if (activeCard != null && mover != null)
                game.Move(mover, activeCard);
        }

        private void pnlDeck_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
