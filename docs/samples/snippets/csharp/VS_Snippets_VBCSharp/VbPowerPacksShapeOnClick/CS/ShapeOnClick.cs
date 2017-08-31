using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeOnClickCS
{
    public partial class ShapeOnClick : Form
    {
        public ShapeOnClick()
        {
            InitializeComponent();
        }

        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            HighlightLine theLine = new HighlightLine();
            ShapeContainer canvas = new ShapeContainer();
            canvas.Parent = this;
            theLine.Parent = canvas;
            theLine.X1 = 0;
            theLine.X2 = 0;
            theLine.StartPoint = new System.Drawing.Point(0, 0);
            theLine.EndPoint = new System.Drawing.Point(640, 480);
        }
    }
    // <Snippet1>
    public class HighlightLine :
        LineShape
    {
        protected override void OnClick(EventArgs e)
        {
            // Change the color of the line when clicked.
            this.BorderColor = Color.Red;
            base.OnClick(e);
        }
        protected override void OnLostFocus(System.EventArgs e)
        {
            // Change the color of the line when focus is changed.
            this.BorderColor = Color.Black;
            base.OnLostFocus(e);
        }
    }
    // </Snippet1>

}
