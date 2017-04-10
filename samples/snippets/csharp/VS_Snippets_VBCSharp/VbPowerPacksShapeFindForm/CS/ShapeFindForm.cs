using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeFindFormCS
{
    public partial class ShapeFindForm : Form
    {
        public ShapeFindForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetTheForm();
        }

        // <Snippet1>
        private void GetTheForm()
        {
            Form myForm = lineShape1.FindForm();
            // Set the text and color of the form that contains the LineShape.
            myForm.Text = "This form contains a line";
            myForm.BackColor = Color.Red;
        }
        // </Snippet1>
    }
}
