using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksSimpleShapeHeightCS
{
    public partial class SimpleShapeHeight : Form
    {
        public SimpleShapeHeight()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ovalShape1_Click(System.Object sender, System.EventArgs e)
        {
            // Set the height.
            ovalShape1.Height = ovalShape1.Height + 50;
            // Set the width the same as the height to make it a circle.
            ovalShape1.Width = ovalShape1.Height;
        }
        // </Snippet1>
    }
}
