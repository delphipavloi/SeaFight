using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaFight.Core;

namespace SeaFight.CoreTests
{
    [TestClass()]
    public class SimpleShipTests
    {

        [TestMethod()]

        public void RotateTest()
        {
            var testShip = new SimpleShip(5);
            var testDecks = new List<Deck>(5);
            
            int Y = 10;

            var y = Y;
            foreach (var deck in testShip.Decks)
            {
                deck.Y += y;
                deck.X = 10;
                y++;
            }

            testDecks.AddRange(testShip.Decks.Select(t => new Deck(t.X, t.Y)));
            
            testShip.Rotate(Rotation.Right);
            testShip.Rotate(Rotation.Left);

            CheckResult(testShip, testDecks);

            testShip.Rotate(Rotation.Right);
            testShip.Rotate(Rotation.Right);
            testShip.Rotate(Rotation.Left);
            testShip.Rotate(Rotation.Left);

            CheckResult(testShip, testDecks);
            
        }

        private void CheckResult(IShip testShip, IReadOnlyList<Deck> testDecks)
        {
            for (int i = 1; i < testShip.Decks.Count; i++)
            {
                if (testShip.Decks[i].Y != testDecks[i].Y
                    || testShip.Decks[i].X != testDecks[i].X)
                    Assert.Fail();
            }
        }
    }
}
