using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;


namespace VbPowerPacksShapeContainerGetChildCS
{
    public partial class ShapeContainerGetChild : Form
    {
        public ShapeContainerGetChild()
        {
            InitializeComponent();
        }
        // <Snippet1>
        private void shapeContainer1_MouseDown(object sender, 
            System.Windows.Forms.MouseEventArgs e)
        {
            Shape sh;
            // Find the shape at the point where the mouse was clicked.
            sh = shapeContainer1.GetChildAtPoint(new Point(e.X, e.Y));
            MessageBox.Show(sh.Name);
        }
        // </Snippet1>
    }


}
