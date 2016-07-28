using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.Core
{
    public class SimpleShip : IShip
    {
        List<Deck> decks;

        public SimpleShip(int deckCount)
        {
            decks = new List<Deck>();

            for (int i = 0; i < deckCount; i++)
            {
                decks.Add(new Deck(0, i));
            }
            Decks = decks;
        }

        public List<Deck> Decks { set; get; }

        public void DropTheBomb(IBomb bomb)
        {
            
        }

        public void Rotate(Rotation rotation)
        {

        }
    }
}
