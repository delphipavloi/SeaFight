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

        public void Rotate(Rotation rotation, int maxX, int maxY)
        {
            int deltaX;
            int deltaY;
            Deck deckHead = Decks.First();
            if (IsShipRotatable())
            {
                GetRotationDirection(out deltaY, out deltaX);
                switch (rotation)
                {
                    case Rotation.Left:
                        for (int i = 1; i < Decks.Count - 1; i++)
                        {
                            Decks.ElementAt(i).X = deckHead.X - deltaX * i;
                            Decks.ElementAt(i).Y = deckHead.Y - deltaY * i;
                        }
                        break;
                    case Rotation.Right:
                        for (int i = 1; i < Decks.Count - 1; i++)
                        {
                            Decks.ElementAt(i).X = deckHead.X + deltaX * i;
                            Decks.ElementAt(i).Y = deckHead.Y + deltaY * i;
                        }
                        break;
                }
            }
        }

        private bool IsDeckRotatable(Deck deck, Rotation rotation, int deltaX, int deltaY)
        {
            switch (rotation)
            {
                case Rotation.Left:
                    if (((deck.X - deltaX) < 0) || (deck.X - deltaX) > )
                        break;
                case Rotation.Right:

                    break;
            }
            return false;
        }

        private bool IsShipRotatable()
        {
            if (Decks.Count > 1)
            {
                return true;
            }
            return false;
        }

        private void GetRotationDirection(out int xAxis, out int yAxis)
        {
            xAxis = Decks.ElementAt(0).X - Decks.ElementAt(1).X;
            yAxis = Decks.ElementAt(0).X - Decks.ElementAt(1).X;
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