using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeHideCS
{
    public partial class ShapeHide : Form
    {
        public ShapeHide()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            // Hide the oval.
            ovalShape1.Hide();
        }

        private void Shapes_Click(System.Object sender, System.EventArgs e)
        {
            if (ovalShape1.Visible == true)
            // Hide the oval.
            {
                ovalShape1.Hide();
                // Show the rectangle.
                rectangleShape1.Show();
            }
            else
            {
                // Hide the rectangle.
                rectangleShape1.Hide();
                // Show the oval.
                ovalShape1.Show();
            }
        }
        // </Snippet1>
    }


}
