using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ImageListCollectionEx
{
    public class Form1 : Form
    {
        private Button button1;
        private ImageList imageList1;
        private IContainer components;
    
        public Form1()
        {
            InitializeComponent();
            
            button1.Click += new EventHandler(button1_Click);

            InitializeRadioButtons();
        }
        void button1_Click(object sender, EventArgs e)
        {
                AddStripToCollection();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        //<snippet6>
        private NumericUpDown numericUpDown1;
        private void InitializeAcceleratedUpDown()
        {
            numericUpDown1 = new NumericUpDown();
            numericUpDown1.Location = new Point(40, 40);
            numericUpDown1.Maximum = 40000;
            numericUpDown1.Minimum = -40000;

            // Add some accelerations to the control.
            numericUpDown1.Accelerations.Add(new NumericUpDownAcceleration(2,100));
            numericUpDown1.Accelerations.Add(new NumericUpDownAcceleration(5, 1000));
            numericUpDown1.Accelerations.Add(new NumericUpDownAcceleration(8, 5000));
            Controls.Add(numericUpDown1);
       
        }
        //</snippet6>

//<snippet2>
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RadioButton selectedrb;
        private Button getSelectedRB;

        public void InitializeRadioButtons()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.getSelectedRB = new System.Windows.Forms.Button();

            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.getSelectedRB);
            this.groupBox1.Location = new System.Drawing.Point(30, 100);
            this.groupBox1.Size = new System.Drawing.Size(220, 125);
            this.groupBox1.Text = "Radio Buttons";

            this.radioButton2.Location = new System.Drawing.Point(31, 53);
            this.radioButton2.Size = new System.Drawing.Size(67, 17);
            this.radioButton2.Text = "Choice 2";
            this.radioButton2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);

            this.radioButton1.Location = new System.Drawing.Point(31, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 17);
            this.radioButton1.Text = "Choice 1";
            this.radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChanged);

            this.getSelectedRB.Location = new System.Drawing.Point(10, 75);
            this.getSelectedRB.Size = new System.Drawing.Size(200, 25);
            this.getSelectedRB.Text = "Get selected RadioButton";
            this.getSelectedRB.Click += new EventHandler(getSelectedRB_Click);

            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.groupBox1);
        }

        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            // Ensure that the RadioButton.Checked property
            // changed to true.
            if (rb.Checked)
            {
                // Keep track of the selected RadioButton by saving a reference
                // to it.
                selectedrb = rb;
            }
        }

        // Show the text of the selected RadioButton.
        void getSelectedRB_Click(object sender, EventArgs e)
        {
            MessageBox.Show(selectedrb.Text);
        }
        
        //</snippet2>
        private System.Drawing.Printing.PrintDocument printDocument1;
  //<snippet3>
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (e.PageSettings.Color && !printDocument1.PrinterSettings.SupportsColor)
                MessageBox.Show("Color printing not supported on selected printer.", "Printer Warning", MessageBoxButtons.OKCancel);
        }
        //</snippet3>

      

        //Per VSWhidbey 370432 Demonstrates the ImageListCollection.AddStrip method.
//<snippet1>
        public void AddStripToCollection()
        {
            // Add the image strip.
            Bitmap bitmaps = new Bitmap(typeof(PrintPreviewDialog), "PrintPreviewStrip.bmp");
            imageList1.Images.AddStrip(bitmaps);
            
            // Iterate through the images and display them on the form.
            for (int i = 0; i < imageList1.Images.Count; i++) {
            
                imageList1.Draw(this.CreateGraphics(), new Point(10,10), i);
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                
            }
            

        }
//</snippet1>

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 25);
            this.button1.Name = "button1";
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.button1);
            this.Name = "Form1";

         
            this.ResumeLayout(false);
            
        }

        
    }
}