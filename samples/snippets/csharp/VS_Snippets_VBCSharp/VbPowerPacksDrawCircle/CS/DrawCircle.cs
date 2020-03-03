using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksDrawCircleCS
{
    public partial class DrawCircle : Form
    {
        public DrawCircle()
        {
            InitializeComponent();
        }

        private void DrawCircle_Load(System.Object sender, System.EventArgs e)
        {
            DrawCircle1();
            DrawOval();
            DrawCircle2();
        }
        // <Snippet1>
        private void DrawCircle1()
        {
            Microsoft.VisualBasic.PowerPacks.ShapeContainer canvas = 
                new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            Microsoft.VisualBasic.PowerPacks.OvalShape oval1 = 
                new Microsoft.VisualBasic.PowerPacks.OvalShape();
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the OvalShape.
            oval1.Parent = canvas;
            // Set the location and size of the circle.
            oval1.Left = 10;
            oval1.Top = 10;
            oval1.Width = 100;
            oval1.Height = 100;
        }
        // </Snippet1>
        // <Snippet2>
        private void DrawOval()
        {
            // Declare an OvalShape and parent it to LineShape1's ShapeContainer.
            Microsoft.VisualBasic.PowerPacks.OvalShape oval1 = 
                new Microsoft.VisualBasic.PowerPacks.OvalShape(lineShape1.Parent);
            // Set the location and size of the oval.
            oval1.Left = 10;
            oval1.Top = 10;
            oval1.Width = 100;
            oval1.Height = 200;
        }
        // </Snippet2>
        // <Snippet3>
        private void DrawCircle2()
        {
            Microsoft.VisualBasic.PowerPacks.ShapeContainer canvas = 
                new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            // Declare an OvalShape and set the location and size.
            Microsoft.VisualBasic.PowerPacks.OvalShape oval1 = 
                new Microsoft.VisualBasic.PowerPacks.OvalShape(20, 20, 120, 120);
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the OvalShape.
            oval1.Parent = canvas;
        }
        // </Snippet3>
    }
}
