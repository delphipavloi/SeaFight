using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.Core
{
    public interface IBomb : IGamingObject
    {
        int X { set; get; }
        int Y { set; get; }        
    }
}
