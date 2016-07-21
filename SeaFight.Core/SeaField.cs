using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.Core
{
    public class SeaField : ISeaField
    {
        private ICell[,] cells;
        private int width, height;

        public SeaField(int width, int height)
        {
            cells = new Cell[width, height];
            this.height = height;
            this.width = width;
        }
       
        public void AddCells(List<ICell> cells)
        {
            cells.AddRange(cells);
        }

        public void DropTheBomb(IBomb bomb)
        {            
            var cellToBomb = cells[bomb.X, bomb.Y];
            cellToBomb.DropTheBomb(bomb);
        }

        public bool PlaceShip(IShip ship)
        {
            List<ICell> cellsToPlace = new List<ICell>();
            ship.Decks.ForEach(deck => cellsToPlace.Add(cells[deck.X, deck.Y]));
            
            if (cellsToPlace.Any(cell => cell.IsOccupied))
            {
                return false;
            }

            for (int i = 0; i < cellsToPlace.Count; i++)
            {
                ICell current = cellsToPlace[i];
                current.IsOccupied = true;
                current.Content = ship.Decks[i];

            }

            return true;
        }

        private void OccupyAround(ICell cell)
        {
            bool isOnRightEdge, isOnLeftEdge, isOnTopEdge, isOnBottomEdge;
            if (cell.X < width - 1)
            {
                cells[cell.X + 1, cell.Y].IsOccupied = true;
            }
            else
            {
                isOnRightEdge = true;
            }

            if (cell.X > 0)
            {
                cells[cell.X - 1, cell.Y].IsOccupied = true;
            }
            else
            {
                isOnLeftEdge = true;
            }

            if (cell.Y < height - 1)
            {
                cells[cell.X, cell.Y + 1].IsOccupied = true;
            }
            else
            {
                isOnBottomEdge = true;
            }

            if (cell.Y > 0)
            {
                cells[cell.X, cell.Y - 1].IsOccupied = true;
            }
            else
            {
                isOnTopEdge = true;
            }
        }


    }
}
