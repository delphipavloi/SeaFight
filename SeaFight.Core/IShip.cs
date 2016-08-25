using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.Core
{
    public interface IShip : IBombable
    {
        List<Deck> Decks { set; get; }

        void Rotate(Rotation rotation, int fileldSize);   
    }
}
