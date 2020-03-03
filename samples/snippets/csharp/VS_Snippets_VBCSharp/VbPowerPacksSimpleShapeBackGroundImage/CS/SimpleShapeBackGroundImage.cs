using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleShapeBackGroundImageCS
{
    public partial class SimpleShapeBackGroundImage : Form
    {
        public SimpleShapeBackGroundImage()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void form1_Load(System.Object sender, System.EventArgs e)
        {
            // Assign an image resource.
            ovalShape1.BackgroundImage = SimpleShapeBackGroundImageCS.Properties.Resources.Image1;
            // Resize the image to fit the oval.
            ovalShape1.BackgroundImageLayout = ImageLayout.Stretch;
        }
        // </Snippet1>
    }
}
