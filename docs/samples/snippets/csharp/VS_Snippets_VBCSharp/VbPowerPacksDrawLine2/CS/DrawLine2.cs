using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDrawLine2CS
{
    public partial class DrawLine2 : Form
    {
        public DrawLine2()
        {
            InitializeComponent();
        }

        private void DrawLine2_Load(object sender, EventArgs e)
        {
            // <Snippet1>
            Microsoft.VisualBasic.PowerPacks.ShapeContainer canvas = 
                new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            Microsoft.VisualBasic.PowerPacks.LineShape line1 = 
                new Microsoft.VisualBasic.PowerPacks.LineShape(0, 0, 1000, 1000);
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the LineShape.
            line1.Parent = canvas;
            // </Snippet1>
        }
    }
}
