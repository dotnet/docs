using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksSimpleShapeBottomCS
{
    public partial class SimpleShapeBottom : Form
    {
        public SimpleShapeBottom()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void rectangleShape1_Click(System.Object sender, System.EventArgs e)
        {
            // Set the upper-left corner of Rectangle2 
            // to the lower-right corner of Rectangle1.
            rectangleShape2.Left = rectangleShape1.Right;
            rectangleShape2.Top = rectangleShape1.Bottom;
        }
        // </Snippet1>
    }
}
