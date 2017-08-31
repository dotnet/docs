using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeDefaultBorderCS
{
    public partial class ShapeDefaultBorder : Form
    {
        public ShapeDefaultBorder()
        {
            InitializeComponent();
        }

        private void ShapeDefaultBorder_Load(object sender, EventArgs e)
        {
            // <Snippet1>
            foreach (Microsoft.VisualBasic.PowerPacks.Shape s in this.shapeContainer1.Shapes)
            {
                if (s.BorderColor != Microsoft.VisualBasic.PowerPacks.SimpleShape.DefaultBorderColor)
                {
                    s.BorderColor = Color.Black;
                }
            }
            // </Snippet1>
        }

        
    }
}
