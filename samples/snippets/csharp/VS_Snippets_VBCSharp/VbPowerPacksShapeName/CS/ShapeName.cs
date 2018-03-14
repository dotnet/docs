using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeNameCs
{
    public partial class ShapeName : Form
    {
        public ShapeName()
        {
            InitializeComponent();
        }

        private void ShapeName_Load(object sender, EventArgs e)
        {
            // <Snippet1>
            OvalShape os = new OvalShape();
            ShapeContainer sc = new ShapeContainer();
            sc.Parent = this;
            os.Parent = sc;
            // Assign a value to the Name property.
            os.Name = "NewOval1";
            // </Snippet1>
            MessageBox.Show(os.Name);
        }
    }
}
