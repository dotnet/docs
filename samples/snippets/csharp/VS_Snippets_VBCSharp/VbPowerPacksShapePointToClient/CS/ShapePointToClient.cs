using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapePointToClientCS
{
    public partial class ShapePointToClient : Form
    {
        public ShapePointToClient()
        {
            InitializeComponent();
        }

        // <Snippet1>
    private void Form1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
    {
        // Determine whether the drop is within the rectangle.
        if (rectangleShape1.HitTest(e.X, e.Y)==true)
            // Handle file data.
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
            {
                string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
                try
                {
                    // Assign the first image to the BackGroundImage
                    // property.
                    rectangleShape1.BackgroundImage = Image.FromFile(files[0]);
                    // Set the rectangle location relative to the form.
                    rectangleShape1.Location = 
                        rectangleShape1.PointToClient(new Point(e.X, e.Y));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
    }
    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
        // If the data is a file, display the copy cursor.
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.Copy;
        }
        else
        {
            e.Effect = DragDropEffects.None;
        }
    }
    // </Snippet1>
    }
}
