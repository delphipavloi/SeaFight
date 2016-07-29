using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.Core
{
    public class Deck : IGamingObject
    {

        public int X { set; get; }

        public int Y { set; get; }

        IShip ship;

        public Deck(IShip ship) : this(ship, 0, 0)
        { 
            
        }

        public Deck(IShip ship, int x, int y)
        {
            this.ship = ship;
            X = x;
            Y = y;
        }

        public void DropTheBomb(IBomb bomb)
        {
            if (ship != null)
            {
                ship.DropTheBomb(bomb);
            }
        }
    }
}
