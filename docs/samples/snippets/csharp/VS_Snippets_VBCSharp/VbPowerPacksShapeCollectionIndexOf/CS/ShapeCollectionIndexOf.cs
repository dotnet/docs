using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeCollectionIndexOfCS
{
    public partial class ShapeCollectionIndexOf : Form
    {
        public ShapeCollectionIndexOf()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ovalShape2_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            // Find the index for OvalShape1.
            i = ovalShape2.Parent.Shapes.IndexOf(ovalShape1);
            // If the shape is not in the collection, display a message.
            if (i == -1)
            {
                MessageBox.Show("ovalShape1 is not in this collection.");
            }
        }
        // </Snippet1>

        // <Snippet2>
        private void ovalShape1_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            // Find the index for OvalShape1.
            i = ovalShape1.Parent.Shapes.IndexOfKey("ovalShape2");
            // If the shape is not in the collection, display a message.
            if (i == -1)
            {
                MessageBox.Show("ovalShape2 is not in this collection.");
            }
        }
        // </Snippet2>
    }
}
