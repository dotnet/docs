using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;


namespace VbPowerPacksShapeIsKeyLockedCS
{
    public partial class ShapeIsKeyLocked : Form
    {
        public ShapeIsKeyLocked()
        {
            InitializeComponent();
        }

        private void ovalShape1_Click(System.Object sender, System.EventArgs e)
        {
            GetCapsLocked(ovalShape1);
        }
        // <Snippet1>
        private void GetCapsLocked(Shape shape)
        {
            // You can test for the CAPS LOCK, NUM LOCK, OR SCROLL LOCK key
            // by changing the value of Keys.
            if (Shape.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("The Caps Lock key is ON.");
            }
            else
            {
                MessageBox.Show("The Caps Lock key is OFF.");
            }
        }
        // </Snippet1>
    }
}
