using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO
{
    public enum TurnResult
    {
        GameStart, 
        PlayedCard, 
        Skip, 
        AddTwo,
        Attacked,
        ForceDraw,
        ForceDrawPlay,
        BlackCard,
        AddFour,
        Reversed
    }
    class PlayerTurn
    {
        public Card card { get; set; }
        public CardColor DeclaredColor { get; set; }
        public TurnResult Result { get; set; }
    }

    private PlayerTurn ProcessAttack(Card currentDiscard, CardDesk drawPile)
    {
        PlayerTurn turn = new PlayerTurn();
        turn.Result = TurnResult.Attacked;

        turn.card = currentDiscard;
        turn.DeclaredColor = currentDiscard.Color;

        if(currentDiscard.Figure == CardFigure.Skip)
        {

        }
        else if(currentDiscard.Figure == CardFigure.AddTwo)
        {
            PlayerCards.AddRange(drawPile.Pull(2));
        }
        else if(currentDiscard.Black == CardBlack.AddFour)
        {
            PlayerCards.AddRange(drawPile.Pull(4));
        }
        return turn;
    }
}
