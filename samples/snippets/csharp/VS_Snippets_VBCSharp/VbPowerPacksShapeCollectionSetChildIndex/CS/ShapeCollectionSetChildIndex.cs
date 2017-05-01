using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace ShapeCollectionSetChildIndexCS
{
    public partial class ShapeCollectionSetChildIndex : Form
    {
        public ShapeCollectionSetChildIndex()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ovalShape1_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            // Find the index for OvalShape2.
            i = ovalShape1.Parent.Shapes.GetChildIndex(ovalShape2, false);
            // If the shape is not in the collection, display a message.
            if (i == -1)
            {
                MessageBox.Show("ovalShape2 is not in this collection.");
            }
            else
            {
                // Change the index to 0.
                ovalShape1.Parent.Shapes.SetChildIndex(ovalShape2, 0);
            }
        }
        // </Snippet1>
    }
}
