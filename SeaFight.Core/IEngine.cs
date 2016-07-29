using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.Core
{
    public interface IEngine
    {
        void StartGame();
        void Initialize();
        void StopGame();
        void SetSession(ISession session);                     
    }
}
