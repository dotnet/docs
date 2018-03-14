using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShapeCollectionGetChildIndexCS
{
    public partial class ShapeCollectionGetChildIndex : Form
    {
        public ShapeCollectionGetChildIndex()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ovalShape2_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            String index;
            // Find the index for OvalShape1.
            i = ovalShape2.Parent.Shapes.GetChildIndex(ovalShape1);
            index = i.ToString();
            MessageBox.Show("The index for OvalShape1 is " + index);
        }

        // </Snippet1>

         // <Snippet2>
    private void ovalShape1_Click(System.Object sender, System.EventArgs e)
    {
        int i;
        // Find the index for OvalShape1.
        i = ovalShape1.Parent.Shapes.GetChildIndex(ovalShape2, false);
        // If the shape is not in the collection, display a message.
        if (i==-1)
        {
            MessageBox.Show("ovalShape2 is not in this collection.");
        }
        else
        {
            String index;
            index = i.ToString();
            MessageBox.Show("The index for ovalShape2 is " + index);
        }
    }
    // </Snippet2>
}














    
}
