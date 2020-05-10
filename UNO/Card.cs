using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNO
{
    public enum CardColor
    {
        Yellow,
        Red,
        Green,
        Blue,
    };
    public enum CardFigure
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine, 
        Skip,
        Reverse,
        AddTwo,
    };

    public enum CardBlack
    {
        AddFour,
        ChangeColor,
    };

    class Card
    {
        public CardFigure Figure { get; set; }
        public CardColor Color { get; set; }
        public CardBlack Black { get; set; }
        public Card(CardColor color, CardFigure figure)
        {
            Color = color;
            Figure = figure;
        }
        public override string ToString()
        {
            return String.Format("{0}_{1}", Color, Figure);
        }

        public virtual void Show()
        {
            Console.WriteLine(this);
        }
    }
    
    //class Numerical:Card
    //{
    //   public CardFigure Figure{ get; set; }
    //    public CardColor Color { get; set; }
    //    Numerical(CardColor color, CardFigure figure)
    //    {
    //        Color = color;
    //        Figure = figure;
    //    }
    //    public override string ToString()
    //    {
    //        return String.Format("{0}_{1}", Color, Figure);
    //    }
    //}
    //class Actional : Card
    //{
    //    public CardBlack Black { get; set; }
    //    public Actional(CardBlack black)
    //    {
    //        Black = black;
    //    }
    //    public override string ToString()
    //    {
    //        return String.Format("{0}", Black);
    //    }
    //}
}

