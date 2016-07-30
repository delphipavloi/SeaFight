using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                Decks.Add(new Deck(this, 0, i));
            }
        }       

        public void DropTheBomb(IBomb bomb)
        {

        }

        public bool Rotate(Rotation rotation)
        {
            int deltaX, deltaY;
            Deck head = Decks.First();
            if (IsShipRotatable())
            {
                GetRotationDirection(out deltaY, out deltaX);
                for (int i = 1; i < Decks.Count; i++)
                {
                    int newX = 0, newY = 0;
                    switch (rotation)
                    {
                        case Rotation.Left:
                            newX = head.X - deltaX * i;
                            newY = head.Y - deltaY * i;
                            break;
                        case Rotation.Right:
                            newX = head.X + deltaX * i;
                            newY = head.Y + deltaY * i;
                            break;
                    }
                    if (AreCoordinatesNotNegative(newX, newY))
                    {
                        Decks.ElementAt(i).X = newX;
                        Decks.ElementAt(i).Y = newY;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool AreCoordinatesNotNegative(int x, int y)
        {
            if ((x >= 0) && (y >= 0))
            {
                return true;
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
            xAxis = Decks.ElementAt(1).X - Decks.ElementAt(0).X;
            yAxis = Decks.ElementAt(1).Y - Decks.ElementAt(0).Y;
        }

        public bool MoveShipToPoint(int x, int y)
        {
            int deltaX, deltaY;
            Deck head = Decks.First();
            deltaX = x - head.X;
            deltaY = y - head.Y;

            foreach (Deck deck in Decks)
            {
                if (AreCoordinatesNotNegative(deck.X + deltaX, deck.Y + deltaY))
                {
                    deck.X += deltaX;
                    deck.Y += deltaY;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

    }
}