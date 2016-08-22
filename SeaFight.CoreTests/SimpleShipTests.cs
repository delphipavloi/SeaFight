using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaFight.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SeaFight.Core.Tests
{
    [TestClass()]
    public class SimpleShipTests
    {

        [TestMethod()]

        public void RotateTest()
        {
            SimpleShip testShip = new SimpleShip(5);
            List<Deck> testDecks = new List<Deck>(5);
            
            int Y = 10;

            int y = Y;
            foreach (var deck in testShip.Decks)
            {
                deck.Y += y;
                deck.X = 10;
                y++;
            }

            testDecks.AddRange(testShip.Decks.Select(t => new Deck(t.X, t.Y)));
            
            testShip.Rotate(Rotation.Right);

            for (int i = 1; i < testShip.Decks.Count; i++)
            {
                if (testShip.Decks[i - 1].Y != Y || testShip.Decks[i].X != testDecks[i].X + i)
                    Assert.Fail();
            }

            testShip.Rotate(Rotation.Left);

            for (int i = 1; i < testShip.Decks.Count; i++)
            {
                if (testShip.Decks[i].Y != testDecks[i].Y 
                    || testShip.Decks[i].X != testDecks[i].X)
                    Assert.Fail();
            }
            
        }
    }
}
