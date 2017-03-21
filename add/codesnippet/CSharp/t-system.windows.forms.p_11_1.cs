using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ProgressBarRendererSample
{
    public class Form1 : Form
    {
        private VerticalProgressBar bar1 = new VerticalProgressBar();
        private Button button1 = new Button();

        public Form1()
            : base()
        {
            this.Size = new Size(500, 500);
            bar1.NumberChunks = 30;
            button1.Location = new Point(150, 10);
            button1.Size = new Size(150, 30);
            button1.Text = "Start VerticalProgressBar";
            button1.Click += new EventHandler(button1_Click);
            Controls.AddRange(new Control[] { button1, bar1 });
        }

        [STAThread]
        public static void Main()
        {
            // The call to EnableVisualStyles below does not affect
            // whether ProgressBarRenderer.IsSupported is true; as 
            // long as visual styles are enabled by the operating system, 
            // IsSupported is true.
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        // Start the VerticalProgressBar.
        private void button1_Click(object sender, EventArgs e)
        {
            bar1.Start();
        }
    }

    public class VerticalProgressBar : Control
    {
        private int numberChunksValue;
        private int ticks;
        private Timer progressTimer = new Timer();
        private Rectangle[] progressBarRectangles;

        public VerticalProgressBar()
            : base()
        {
            this.Location = new Point(10, 10);
            this.Width = 50;

            // The progress bar will update every second.
            progressTimer.Interval = 1000;
            progressTimer.Tick += new EventHandler(progressTimer_Tick);

            // This property also calls SetupProgressBar to initialize 
            // the progress bar rectangles if styles are enabled.
            NumberChunks = 20;

            // Set the default height if visual styles are not enabled.
            if (!ProgressBarRenderer.IsSupported)
            {
                this.Height = 100;
            }
        }

        // Specify the number of progress bar chunks to base the height on.
        public int NumberChunks
        {
            get
            {
                return numberChunksValue;
            }

            set
            {
                if (value <= 50 && value > 0)
                {
                    numberChunksValue = value;
                }
                else
                {
                    MessageBox.Show("Number of chunks must be between " +
                        "0 and 50; defaulting to 10");
                    numberChunksValue = 10;
                }

                // Recalculate the progress bar size, if visual styles 
                // are active.
                if (ProgressBarRenderer.IsSupported)
                {
                    SetupProgressBar();
                }
            }
        }

        // Draw the progress bar in its normal state.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (ProgressBarRenderer.IsSupported)
            {
                ProgressBarRenderer.DrawVerticalBar(e.Graphics,
                    ClientRectangle);
                this.Parent.Text = "VerticalProgressBar Enabled";
            }
            else
            {
                this.Parent.Text = "VerticalProgressBar Disabled";
            }
        }

        // Initialize the rectangles used to paint the states of the 
        // progress bar.
        private void SetupProgressBar()
        {
            if (!ProgressBarRenderer.IsSupported)
            {
                return;
            }

            // Determine the size of the progress bar frame.
            this.Size = new Size(ClientRectangle.Width,
                (NumberChunks) * (ProgressBarRenderer.ChunkThickness +
                (2 * ProgressBarRenderer.ChunkSpaceThickness)) + 6);

            // Initialize the rectangles to draw each step of the 
            // progress bar.
            progressBarRectangles = new Rectangle[NumberChunks];

            for (int i = 0; i < NumberChunks; i++)
            {
                // Use the thickness defined by the current visual style 
                // to calculate the height of each rectangle. The size 
                // adjustments ensure that the chunks do not paint over 
                // the frame.

                int filledRectangleHeight =
                    ((i + 1) * (ProgressBarRenderer.ChunkThickness +
                    (2 * ProgressBarRenderer.ChunkSpaceThickness)));

                progressBarRectangles[i] = new Rectangle(
                    ClientRectangle.X + 3,
                    ClientRectangle.Y + ClientRectangle.Height - 3
                    - filledRectangleHeight,
                    ClientRectangle.Width - 6,
                    filledRectangleHeight);
            }
        }

        // Handle the timer tick; draw each progressively larger rectangle.
        private void progressTimer_Tick(Object myObject, EventArgs e)
        {
            if (ticks < NumberChunks)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    ProgressBarRenderer.DrawVerticalChunks(g,
                        progressBarRectangles[ticks]);
                    ticks++;
                }
            }
            else
            {
                progressTimer.Enabled = false;
            }
        }

        // Start the progress bar.
        public void Start()
        {
            if (ProgressBarRenderer.IsSupported)
            {
                progressTimer.Start();
            }
            else
            {
                MessageBox.Show("VerticalScrollBar requires visual styles");
            }
        }
    }
}