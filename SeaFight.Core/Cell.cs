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

        public int X { set; get; }
       
        public int Y { set; get; }



        public virtual void DropTheBomb(IBomb bomb)
        {
            IsShoot = true;
        }
    }
}
