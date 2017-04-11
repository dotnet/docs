using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeCollectionRemoveCS
{
    public partial class ShapeCollectionRemove : Form
    {
        public ShapeCollectionRemove()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void form1_Click(object sender, System.EventArgs e)
        {
            ShapeContainer canvas;
            // Get the ShapeContainer.
            canvas = ovalShape1.Parent;
            // If OvalShape2 is in the same collection, remove it.
            if (canvas.Shapes.Contains(ovalShape2))
            {
                canvas.Shapes.Remove(ovalShape2);
            }
        }
        // </Snippet1>
        // <Snippet2>
        private void ovalShape2_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            // Find the index for OvalShape1.
            i = ovalShape2.Parent.Shapes.GetChildIndex(ovalShape1, false);
            // If the shape is not in the collection, display a message.
            if (i == -1)
            {
                MessageBox.Show("ovalShape1 is not in this collection.");
            }
            else
            {
                // Remove the shape.
                ovalShape2.Parent.Shapes.RemoveAt(i);
            }
        }
        // </Snippet2>
    }
}
