// <Snippet0>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SingleVersusDoubleClick
{
    class Form1 : Form
    {
        private Rectangle hitTestRectangle = new Rectangle();
        private Rectangle doubleClickRectangle = new Rectangle();
        private TextBox textBox1 = new TextBox();
        private Timer doubleClickTimer = new Timer();
        private ProgressBar doubleClickBar = new ProgressBar();
        private Label label1 = new Label();
        private Label label2 = new Label();
        private bool isFirstClick = true;
        private bool isDoubleClick = false;
        private int milliseconds = 0;

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        public Form1()
        {
            label1.Location = new Point(30, 5);
            label1.Size = new Size(100, 15);
            label1.Text = "Hit test rectangle:";

            label2.Location = new Point(30, 70);
            label2.Size = new Size(100, 15);
            label2.Text = "Double click timer:";

            hitTestRectangle.Location = new Point(30, 20);
            hitTestRectangle.Size = new Size(100, 40);

            doubleClickTimer.Interval = 100;
            doubleClickTimer.Tick +=
                new EventHandler(doubleClickTimer_Tick);

            doubleClickBar.Location = new Point(30, 85);
            doubleClickBar.Minimum = 0;
            doubleClickBar.Maximum = SystemInformation.DoubleClickTime;

            textBox1.Location = new Point(30, 120);
            textBox1.Size = new Size(200, 100);
            textBox1.AutoSize = false;
            textBox1.Multiline = true;

            this.Paint += new PaintEventHandler(Form1_Paint);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.Controls.AddRange(new Control[] { doubleClickBar, textBox1, 
                label1, label2 });
        }

        // <Snippet10>
        // Detect a valid single click or double click.
        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // Verify that the mouse click is in the main hit
            // test rectangle.
            if (!hitTestRectangle.Contains(e.Location))
            {
                return;
            }

            // This is the first mouse click.
            if (isFirstClick)
            {
                isFirstClick = false;

                // Determine the location and size of the double click 
                // rectangle area to draw around the cursor point.
                doubleClickRectangle = new Rectangle(
                    e.X - (SystemInformation.DoubleClickSize.Width / 2),
                    e.Y - (SystemInformation.DoubleClickSize.Height / 2),
                    SystemInformation.DoubleClickSize.Width,
                    SystemInformation.DoubleClickSize.Height);
                Invalidate();

                // Start the double click timer.
                doubleClickTimer.Start();
            }

            // This is the second mouse click.
            else
            {
                // Verify that the mouse click is within the double click
                // rectangle and is within the system-defined double 
                // click period.
                if (doubleClickRectangle.Contains(e.Location) &&
                    milliseconds < SystemInformation.DoubleClickTime)
                {
                    isDoubleClick = true;
                }
            }
        }
        // </Snippet10>

        void doubleClickTimer_Tick(object sender, EventArgs e)
        {
            milliseconds += 100;
            doubleClickBar.Increment(100);

            // The timer has reached the double click time limit.
            if (milliseconds >= SystemInformation.DoubleClickTime)
            {
                doubleClickTimer.Stop();

                if (isDoubleClick)
                {
                    textBox1.AppendText("Perform double click action");
                    textBox1.AppendText(Environment.NewLine);
                }
                else
                {
                    textBox1.AppendText("Perform single click action");
                    textBox1.AppendText(Environment.NewLine);
                }

                // Allow the MouseDown event handler to process clicks again.
                isFirstClick = true;
                isDoubleClick = false;
                milliseconds = 0;
                doubleClickBar.Value = 0;
            }
        }

        // Paint the hit test and double click rectangles.
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the border of the main hit test rectangle.
            e.Graphics.DrawRectangle(Pens.Black, hitTestRectangle);

            // Fill in the double click rectangle.
            e.Graphics.FillRectangle(Brushes.Blue, doubleClickRectangle);
        }
    }
}
// </Snippet0>