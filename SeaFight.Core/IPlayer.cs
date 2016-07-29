using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.Core
{
    public delegate void GamingEventHandler(object sender, GamingEvent eventDetails);

    public interface IPlayer
    {
        string NickName { set; get; }
        ISeaField SeaField { get; }
        int Score { set; get; }        
        void LoadSeaField(ISeaField seaField);


        event GamingEventHandler GamingEvent;
    }
}
