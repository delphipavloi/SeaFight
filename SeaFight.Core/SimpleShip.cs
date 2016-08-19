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
            if (rotation == Rotation.Right && Decks[0].X == Decks[1].X && Decks[0].Y < Decks[1].Y)
            {
                //================ 25 - for debug. FiledSize verification required =============
                    if (Decks.Count <= 25 - Decks[0].X)
                    {
                        for (int i = 1; i < Decks.Count; i++)
                        {
                            Decks[i].X += i;
                            Decks[i].Y = Decks[0].Y;
                        }   
                    }
                    else
                    {
                        Decks[0].X = 25 - Decks.Count;
                        for (int i = 1; i < Decks.Count; i++)
                        {
                            Decks[i].X = Decks[0].X + i;
                            Decks[i].Y = Decks[0].Y;
                        }
                    }
            }
            else if (rotation == Rotation.Right && Decks[0].Y == Decks[1].Y && Decks[0].X > Decks[1].X)
            {
                if (Decks.Count <= 25 - Decks[0].Y)
                {
                    for (int i = 1; i < Decks.Count; i++)
                    {
                        Decks[i].X = Decks[0].X;
                        Decks[i].Y += i;
                    }
                }
                else
                {
                    Decks[0].Y = 25 - Decks.Count;
                    for (int i = 1; i < Decks.Count; i++)
                    {
                        Decks[i].Y = Decks[0].Y + i;
                        Decks[i].X = Decks[0].X;
                    }
                }
            }

            if (rotation == Rotation.Left && Decks[0].X == Decks[1].X)
            {
                if (Decks.Count <= 25 - Decks[0].X)
                {
                    for (int i = 1; i < Decks.Count; i++)
                    {
                        Decks[i].X -= i;
                        Decks[i].Y = Decks[0].Y;
                    }
                }
                else
                {
                    Decks[0].X = 25 - Decks.Count;
                    for (int i = 1; i < Decks.Count; i++)
                    {
                        Decks[i].X = Decks[0].X - i;
                        Decks[i].Y = Decks[0].Y;
                    }
                }
            }
            else if (rotation == Rotation.Left && Decks[0].Y == Decks[1].Y)
            {
            if (Decks[0].Y - Decks.Count >= 0)
             {
                 for (int i = 1; i < Decks.Count; i++)
                 {
                     Decks[i].Y -= i;
                     Decks[i].X = Decks[0].X;
                 }
             }
           
            else
            {
                Decks[0].Y = Decks.Count - 1;
                for (int i = 1; i < Decks.Count; i++)
                {
                    Decks[i].Y = Decks[0].Y - i;
                    Decks[i].X = Decks[0].X;
                }
            }
           
         }

            //TODO: Create rotation logic (+ 4 loops)
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
