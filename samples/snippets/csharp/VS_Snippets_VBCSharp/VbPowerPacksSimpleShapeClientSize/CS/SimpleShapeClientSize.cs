using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksSimpleShapeClientSizeCS
{
    public partial class SimpleShapeClientSize : Form
    {
        public SimpleShapeClientSize()
        {
            InitializeComponent();
        }

        // <Snippet1>
    private void ovalShape1_Click(System.Object sender, System.EventArgs e)
    {
        // Declare a Size 20 pixels wider and taller than the current Size.
        System.Drawing.Size sz = new System.Drawing.Size(ovalShape1.Width+20, 
            ovalShape1.Height+20);
        // Change the ClientSize.
        ovalShape1.ClientSize = sz;
    }
    // </Snippet1>
    }
}
