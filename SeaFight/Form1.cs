using SeaFight.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaFight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            ShipFactory shipFactory = new ShipFactory();
            IShip ship = shipFactory.GetTriple();
            ship.Rotate(Rotation.Right);
        }
    }
}
