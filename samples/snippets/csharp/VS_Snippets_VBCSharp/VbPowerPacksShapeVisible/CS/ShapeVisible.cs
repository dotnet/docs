using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeVisibleCS
{
    public partial class ShapeVisible : Form
    {
        public ShapeVisible()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ShapeVisible_Load(System.Object sender, System.EventArgs e)
        {
            // Hide the oval.
            ovalShape1.Visible = false;
        }

        private void Shapes_Click(System.Object sender, System.EventArgs e)
        {
            if (ovalShape1.Visible == true)
            // Hide the oval.
            {
                ovalShape1.Visible = false;
                // Show the rectangle.
                rectangleShape1.Visible = true;
            }
            else
            {
                // Hide the rectangle.
                rectangleShape1.Visible = false;
                // Show the oval.
                ovalShape1.Visible = true;
            }
        }
        // </Snippet1>
    }
}
