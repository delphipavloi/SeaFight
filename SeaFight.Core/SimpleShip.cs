using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.Core
{
    public class SimpleShip : IShip
    {
        public List<Deck> Decks { set; get; }

        public SimpleShip(int deckCount)
        {
            Decks = new List<Deck>();

            for (int i = 0; i < deckCount; i++)
            {
                Decks.Add(new Deck(this));
            }
            
        }

        public void DropTheBomb(IBomb bomb)
        {
            
        }

        public void Rotate(Rotation rotation)
        {

        }
    }
}
