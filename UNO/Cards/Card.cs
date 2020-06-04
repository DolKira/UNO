using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNO
{
    public enum CardFunction
    {
        AddFour,
        ChangeColor
    }
    public enum CardColorFunction
    {
        Skip,
        Reverse,
        AddTwo
    }
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
    };

    abstract class Card
    {
        public virtual void Show()
        {
            Console.WriteLine(this);
        }
    }
}

