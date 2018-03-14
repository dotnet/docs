// <Snippet1>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Scrollbar
{
    public class Form1 : Form
    {
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox1;
        private VScrollBar vScrollBar1;
        private HScrollBar hScrollBar1;

        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.openFileDialog1 = new OpenFileDialog();
            this.pictureBox1 = new PictureBox();
            this.vScrollBar1 = new VScrollBar();
            this.hScrollBar1 = new HScrollBar();
            this.pictureBox1.SuspendLayout();
            this.SuspendLayout();

            this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox1.Controls.AddRange(new Control[] { this.vScrollBar1, this.hScrollBar1 });
            this.pictureBox1.Dock = DockStyle.Fill;
            this.pictureBox1.Size = new System.Drawing.Size(440, 349);
            this.pictureBox1.DoubleClick += new EventHandler(this.pictureBox1_DoubleClick);

            this.vScrollBar1.Dock = DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(422, 0);
            this.vScrollBar1.Size = new System.Drawing.Size(16, 331);
            this.vScrollBar1.Visible = false;
            this.vScrollBar1.Scroll += new ScrollEventHandler(this.HandleScroll);

            this.hScrollBar1.Dock = DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 331);
            this.hScrollBar1.Size = new System.Drawing.Size(438, 16);
            this.hScrollBar1.Visible = false;
            this.hScrollBar1.Scroll += new ScrollEventHandler(this.HandleScroll);

            this.Text = "Form1";
            this.ClientSize = new System.Drawing.Size(440, 349);
            this.Controls.AddRange(new Control[] { this.pictureBox1 });
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.pictureBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // <Snippet3>
        private void HandleScroll(Object sender, ScrollEventArgs e)
        {
            //Create a graphics object and draw a portion of the image in the PictureBox.
            Graphics g = pictureBox1.CreateGraphics();

            int xWidth = pictureBox1.Width;
            int yHeight = pictureBox1.Height;

            int x;
            int y;

            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                x = e.NewValue;
                y = vScrollBar1.Value;
            }
            else //e.ScrollOrientation == ScrollOrientation.VerticalScroll
            {
                y = e.NewValue;
                x = hScrollBar1.Value;
            }

            g.DrawImage(pictureBox1.Image,
              new Rectangle(0, 0, xWidth, yHeight),  //where to draw the image
              new Rectangle(x, y, xWidth, yHeight),  //the portion of the image to draw
              GraphicsUnit.Pixel);

            pictureBox1.Update();
        }
        // </Snippet3>

        private void pictureBox1_DoubleClick(Object sender, EventArgs e)
        {
            //Ask the uesr to select a new image to display.
            //If the user does not select an image...
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;  //...do nothing.
            }

            //Otherwise display the image in the picture box.
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

            //And see if the image needs scrollbars and refresh the image. 
            this.DisplayScrollBars();
            this.SetScrollBarValues();
            this.Refresh();
        }

        private void Form1_Resize(Object sender, EventArgs e)
        {
            //If the picture box does not contain an image...
            if (pictureBox1.Image == null)
            {
                return;  //...do nothing.
            }

            //Otherwise see if the image needs scrollbars and refresh the image. 
            this.DisplayScrollBars();
            this.SetScrollBarValues();
            this.Refresh();
        }

        public void DisplayScrollBars()
        {
            //Very Important: Reset any previous scrollbar values to 0.
            hScrollBar1.Value = 0;
            vScrollBar1.Value = 0;

            //If the image is wider than the picture box, show a horizontal scrollbar.
            if (pictureBox1.Image.Width > pictureBox1.Width)
            {
                hScrollBar1.Visible = true;
            }
            else
            {
                hScrollBar1.Visible = false;
            }

            //If the image is taller than the picture box, show a vertical scrollbar.
            if (pictureBox1.Image.Height > pictureBox1.Height)
            {
                vScrollBar1.Visible = true;
            }
            else
            {
                vScrollBar1.Visible = false;
            }
        }

        // <Snippet2>
        public void SetScrollBarValues()
        {
            //Set the following scrollbar properties:

            //Minimum: Set to 0

            //SmallChange and LargeChange: Per UI guidelines, these must be set
            //    relative to the size of the view that the user sees, not to
            //    the total size including the unseen part.  In this example,
            //    these must be set relative to the picture box, not to the image.

            //Maximum: Calculate in steps:
            //Step 1: The maximum to scroll is the size of the unseen part.
            //Step 2: Add the size of visible scrollbars if necessary.
            //Step 3: Add an adjustment factor of ScrollBar.LargeChange.


            //Configure the horizontal scrollbar
            //---------------------------------------------
            if (this.hScrollBar1.Visible)
            {
                this.hScrollBar1.Minimum = 0;
                this.hScrollBar1.SmallChange = this.pictureBox1.Width / 20;
                this.hScrollBar1.LargeChange = this.pictureBox1.Width / 10;

                this.hScrollBar1.Maximum = this.pictureBox1.Image.Size.Width - pictureBox1.ClientSize.Width;  //step 1

                if (this.vScrollBar1.Visible) //step 2
                {
                    this.hScrollBar1.Maximum += this.vScrollBar1.Width;
                }

                this.hScrollBar1.Maximum += this.hScrollBar1.LargeChange; //step 3
            }

            //Configure the vertical scrollbar
            //---------------------------------------------
            if (this.vScrollBar1.Visible)
            {
                this.vScrollBar1.Minimum = 0;
                this.vScrollBar1.SmallChange = this.pictureBox1.Height / 20;
                this.vScrollBar1.LargeChange = this.pictureBox1.Height / 10;

                this.vScrollBar1.Maximum = this.pictureBox1.Image.Size.Height - pictureBox1.ClientSize.Height; //step 1

                if (this.hScrollBar1.Visible) //step 2
                {
                    this.vScrollBar1.Maximum += this.hScrollBar1.Height;
                }

                this.vScrollBar1.Maximum += this.vScrollBar1.LargeChange; //step 3
            }
        }
        // </Snippet2>
    }
}
// </Snippet1>
