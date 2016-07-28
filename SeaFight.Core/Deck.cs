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

        public Deck(int x = 0, int y = 0)
        {
            //this.ship = ship;
            this.X = x;
            this.Y = y;
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
