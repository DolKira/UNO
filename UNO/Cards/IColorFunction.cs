using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO
{
    interface IColorFunction
    {
        CardColorFunction ColorFunction { get; set; }
        void DoFunction(Game game);
    }
}
