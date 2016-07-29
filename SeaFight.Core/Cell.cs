using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.Core
{
    public class Cell : ICell
    {
        public bool IsShoot { get; set; }

        public IGamingObject Content { set; get; }

        public bool IsOccupied { set; get; }

        public int X { set; get; }

        public int Y { set; get; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            IsOccupied = false;
        }

        public virtual void DropTheBomb(IBomb bomb)
        {
            IsShoot = true;

            if (Content != null)
            {
                Content.DropTheBomb(bomb);
            }
        }
    }
}