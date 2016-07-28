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
            for (int i = 0; i < width - 1; i++)
                for (int j = 0; j < height - 1; j++)
                {
                    cells[i, j] = new Cell(i,j);
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
                current.IsOccupied = true;
                current.Content = ship.Decks[i];
                OccupyAround(current);
            }            

            return true;
        }

        private void GetDirectionShift(Direction where, out int xShift, out int yShift)
        {
            xShift = 0;
            yShift = 0;
            switch (where)
            {
                case Direction.BootomLeft:
                    xShift = -1;
                    yShift = 1;
                    break;
                case Direction.Bottom:
                    xShift = 0;
                    yShift = 1;
                    break;
                case Direction.BottomRight:
                    xShift = 1;
                    yShift = 1;
                    break;
                case Direction.Left:
                    xShift = -1;
                    yShift = 0;
                    break;
                case Direction.Right:
                    xShift = 1;
                    yShift = 0;
                    break;
                case Direction.Top:
                    xShift = 0;
                    yShift = -1;
                    break;
                case Direction.TopLeft:
                    xShift = -1;
                    yShift = -1;
                    break;
                case Direction.TopRight:
                    xShift = 1;
                    yShift = -1;
                    break;
            }
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
            int xShift = 0;
            int yShift = 0;
            foreach(Direction direction in Enum.GetValues(typeof(Direction)))
            {
                GetDirectionShift(direction, out xShift, out yShift);
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
