using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.Core
{
    public class SeaField : ISeaField
    {
        private List<ICell> cells;

        public SeaField()
        {
            cells = new List<ICell>();
        }

        public SeaField(List<ICell> cells) : this()
        {
            cells.AddRange(cells);
        }

        public void AddCells(List<ICell> cells)
        {
            cells.AddRange(cells);
        }

        public void DropTheBomb(IBomb bomb)
        {
            var cellToBomb = cells.Find(cell => cell.X == bomb.X && cell.Y == bomb.Y);
            cellToBomb.DropTheBomb(bomb);
        }

        public void PlaceShip(IShip ship)
        {
            throw new NotImplementedException();
        }
    }
}
