using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksSimpleShapeLocationCS
{
    public partial class SimpleShapeLocation : Form
    {
        public SimpleShapeLocation()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ovalShape1_Click(System.Object sender, System.EventArgs e)
        {
            // Move the shape incrementally until it reaches the bottom 
            // of the form.
            if (ovalShape1.Bottom < this.ClientSize.Height - 50)
            // Move down 50 pixels.
            {
                ovalShape1.Location = new Point(ovalShape1.Left, ovalShape1.Top + 50);
            }
            else
            {
                // Move back to the top.
                ovalShape1.Location = new Point(ovalShape1.Left, 0);
            }
        }
        // </Snippet1>
    }
}
