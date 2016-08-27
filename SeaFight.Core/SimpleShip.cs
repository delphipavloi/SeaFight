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

        private Rotation currentRotation = Rotation.Left;

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
            currentRotation = rotation;
        }

        public void MoveShipToPoint(int x, int y)
        {
            int deltaX, deltaY;
            Deck head = Decks.First();
            deltaX = x - head.X;
            deltaY = y - head.Y;

            foreach (Deck deck in Decks)
            {   
                //TODO: Add boundaries validation
                deck.X += deltaX;
                deck.Y += deltaY;
            }
        }

    }
}
