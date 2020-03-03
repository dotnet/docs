using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MouseEventArgs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //<SNIPPET1>
        private void Form1_Load(object sender, EventArgs e)
        {
            // This line suppresses the default context menu for the TextBox control. 
            textBox1.ContextMenu = new ContextMenu();
            textBox1.MouseDown += new MouseEventHandler(textBox1_MouseDown);
        }

        void textBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                textBox1.Select(0, textBox1.Text.Length);
            }
        }
        //</SNIPPET1>

        //<SNIPPET2>
        Point firstPoint;
        Boolean haveFirstPoint;

        public void EnableDrawing()
        {
            this.MouseDown += new MouseEventHandler(Form1_MouseDownDrawing);
        }

        void Form1_MouseDownDrawing(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (haveFirstPoint)
            {
                Graphics g = this.CreateGraphics();
                g.DrawLine(Pens.Black, firstPoint, e.Location);
                haveFirstPoint = false;
            }
            else
            {
                firstPoint = e.Location;
                haveFirstPoint = true;
            }
        }
        //</SNIPPET2>

        private void enableDrawingButton_Click(object sender, EventArgs e)
        {
            EnableDrawing();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrackCoordinates();
        }

        //<SNIPPET3>
        ToolTip trackTip;

        private void TrackCoordinates()
        {
            trackTip = new ToolTip();
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
        }

        void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            String tipText = String.Format("({0}, {1})", e.X, e.Y);
            trackTip.Show(tipText, this, e.Location);
        }
        //</SNIPPET3>
    }
}