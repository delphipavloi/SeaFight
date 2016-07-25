using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.Core
{
    public class ShipFactory
    {
        public IShip GetSingle()
        {
            SimpleShip ship = new SimpleShip(1);
            return ship;
        }

        public IShip GetDouble()
        {
            SimpleShip ship = new SimpleShip(2);
            return ship;
        }

        public IShip GetTriple()
        {
            SimpleShip ship = new SimpleShip(3);
            return ship;
        }
    }
}
