using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.Core
{
    public interface ISession
    {
        int Id { set; get; }
        void AddPlayer(IPlayer player);
        void RemovePlayer(IPlayer player);
    }
}
