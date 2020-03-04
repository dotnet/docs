using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeContextMenuStripCS
{
    public partial class ShapeContextMenuStrip : Form
    {
        public ShapeContextMenuStrip()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ovalShape1_MouseUp(object sender, MouseEventArgs e)
        {
            // If the right mouse button is clicked and released,
            // display the shortcut menu assigned to the TreeView. 
            if (e.Button == MouseButtons.Right)
            {
                ovalShape1.ContextMenuStrip.Show(this, new Point(e.X, e.Y));
            }
        }

        // </Snippet1>
    }
}
