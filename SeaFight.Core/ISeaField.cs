using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.Core
{
    public interface ISeaField : IBombable
    {
        void PlaceShip(IShip ship);
        void AddCells(List<ICell> cells);

    }
}
