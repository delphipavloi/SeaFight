using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.Core
{
    public class Deck : Cell
    {
        IShip ship;

        public Deck(IShip ship)
        {
            this.ship = ship;
        }

        public override void DropTheBomb(IBomb bomb)
        {
            base.DropTheBomb(bomb);

            if (ship != null)
            {
                ship.DropTheBomb(bomb);
            }
        }
    }
}
