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
                OccupyAround(current);
            }            

            return true;
        }

        private void OccupyAround(ICell cell)
        {
            GetNeighbours(cell).ForEach(c => c.IsOccupied = true);
        }

        private List<ICell> GetNeighbours(ICell cell)
        {
            bool isOnRightEdge = false, isOnLeftEdge = false, isOnTopEdge = false, isOnBottomEdge = false;
            List<ICell> neighbours = new List<ICell>();

            if (cell.X < width - 1)
            {
                neighbours.Add(cells[cell.X + 1, cell.Y]);
            }
            else
            {
                isOnRightEdge = true;
            }

            if (cell.X > 0)
            {
                neighbours.Add(cells[cell.X - 1, cell.Y]);
            }
            else
            {
                isOnLeftEdge = true;
            }

            if (cell.Y < height - 1)
            {
                neighbours.Add(cells[cell.X, cell.Y + 1]);
            }
            else
            {
                isOnBottomEdge = true;
            }

            if (cell.Y > 0)
            {
                neighbours.Add(cells[cell.X, cell.Y - 1]);
            }
            else
            {
                isOnTopEdge = true;
            }

            //i had really tried
           // TODO: Refactor
            if (isOnTopEdge)
            {
                if (isOnLeftEdge)
                {
                    neighbours.Add(cells[cell.X + 1, cell.Y + 1]);
                }
                else if (isOnRightEdge)
                {
                    neighbours.Add(cells[cell.X - 1, cell.Y + 1]);
                }
                else
                {
                    neighbours.Add(cells[cell.X + 1, cell.Y + 1]);
                    neighbours.Add(cells[cell.X - 1, cell.Y + 1]);
                }
            }
            else if (isOnBottomEdge)
            {
                if (isOnLeftEdge)
                {
                    neighbours.Add(cells[cell.X + 1, cell.Y - 1]);
                }
                else if (isOnRightEdge)
                {
                    neighbours.Add(cells[cell.X - 1, cell.Y - 1]);
                }
                else
                {
                    neighbours.Add(cells[cell.X + 1, cell.Y - 1]);
                    neighbours.Add(cells[cell.X - 1, cell.Y - 1]);
                }
            }
            else
            {
                neighbours.Add(cells[cell.X + 1, cell.Y + 1]);
                neighbours.Add(cells[cell.X - 1, cell.Y + 1]);
                neighbours.Add(cells[cell.X + 1, cell.Y - 1]);
                neighbours.Add(cells[cell.X - 1, cell.Y - 1]);
            }


            return neighbours;
        }

    }
}
