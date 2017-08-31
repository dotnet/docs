using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace ShapeCollectionContainsKeyCS
{
    public partial class ShapeCollectionContainsKey : Form
    {
        public ShapeCollectionContainsKey()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void Form1_Click(object sender, System.EventArgs e)
        {
            ShapeContainer canvas;
            // Get the ShapeContainer.
            canvas = ovalShape1.Parent;
            // If OvalShape2 is in the same collection, remove it.
            if (canvas.Shapes.ContainsKey("ovalShape2"))
            {
                canvas.Shapes.Remove(ovalShape2);
            }
        }
        // </Snippet1>
    }
}
