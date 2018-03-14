using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeCollectionCountCS
{
    public partial class ShapeCollectionCount : Form
    {
        public ShapeCollectionCount()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void Shapes_Click(System.Object sender, System.EventArgs e)
        {
            int i = shapeContainer1.Shapes.Count;
            Console.WriteLine("There are {0} shapes in the collection.", i);
        }
        // </Snippet1>
    }
}
