using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeContextMenuCS
{
    public partial class ShapeContextMenu : Form
    {
        public ShapeContextMenu()
        {
            InitializeComponent();
        }

        private void ShapeContextMenu_Load(object sender, EventArgs e)
        {
            ovalShape1.ContextMenu = contextMenu1;
        }

        // <Snippet1>
        private void ovalShape1_MouseUp(object sender, MouseEventArgs e)
        {
            // If the right mouse button is clicked and released,
            // display the shortcut menu assigned to the OvalShape. 
            if (e.Button == MouseButtons.Right)
            {
                ovalShape1.ContextMenu.Show(this, new Point(e.X, e.Y));
            }
        }
        // </Snippet1>
    }
}
