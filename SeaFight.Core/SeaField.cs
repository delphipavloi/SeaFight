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

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    cells[i, j] = new Cell(i, j);
                }

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
                current.Content = ship.Decks[i];
                OccupyAround(current);
            }            

            return true;
        }

        private bool IsCellCoordinateOnBorder(int coord, int axisMax)
        {
            if ((coord == axisMax) || (coord < 0))
                return true;
            else
                return false;
        }

        private List<ICell> GetNeighbours(ICell cell)
        {
            List<ICell> neighbours = new List<ICell>();
            for (int xShift = -1; xShift <= 1; xShift++)
                for (int yShift = -1; yShift <= 1; yShift++)
                {
                    if (!IsCellCoordinateOnBorder(cell.X + xShift, width) && !IsCellCoordinateOnBorder(cell.Y + yShift, height))
                    {
                        neighbours.Add(cells[cell.X + xShift, cell.Y + yShift]);
                    }
                }
            return neighbours;
        }

        private void OccupyAround(ICell cell)
        {
            GetNeighbours(cell).ForEach(c => c.IsOccupied = true);
        }

    }
}
