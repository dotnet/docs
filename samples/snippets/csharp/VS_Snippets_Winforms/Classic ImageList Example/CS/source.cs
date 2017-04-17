//<snippet1>
namespace myImageRotator
{
	using System;
	using System.Drawing;
	using System.ComponentModel;
	using System.Windows.Forms;
 
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		protected Graphics myGraphics;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label5;
		private int currentImage = 0;
 
		public Form1()
		{
			InitializeComponent();
			imageList1 = new ImageList () ;

			// The default image size is 16 x 16, which sets up a larger
			// image size. 
			imageList1.ImageSize = new Size(255,255);
			imageList1.TransparentColor = Color.White;

			// Assigns the graphics object to use in the draw options.
			myGraphics = Graphics.FromHwnd(panel1.Handle);
		}
 
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.listBox1.Location = new System.Drawing.Point(16, 16);
            this.listBox1.Size = new System.Drawing.Size(400, 95);
            this.listBox1.TabIndex = 0;

            this.label3.Location = new System.Drawing.Point(24, 168);
            this.label3.Text = "label3";

            this.button1.Location = new System.Drawing.Point(96, 128);
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.Text = "Show Next Image";
            this.button1.Click += new System.EventHandler(this.button1_Click);

            this.button2.Location = new System.Drawing.Point(208, 128);
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.Text = "Remove Image";
            this.button2.Click += new System.EventHandler(this.button2_Click);

            this.button3.Location = new System.Drawing.Point(320, 128);
            this.button3.Text = "Clear List";
            this.button3.Click += new System.EventHandler(this.button3_Click);

            this.button4.Location = new System.Drawing.Point(16, 128);
            this.button4.Text = "Open Image";
            this.button4.Click += new System.EventHandler(this.button4_Click);

            this.pictureBox1.Location = new System.Drawing.Point(328, 232);
            this.pictureBox1.Size = new System.Drawing.Size(336, 192);

            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;

            this.panel1.Location = new System.Drawing.Point(8, 240);
            this.panel1.Size = new System.Drawing.Size(296, 184);

            this.label5.Location = new System.Drawing.Point(168, 168);
            this.label5.Size = new System.Drawing.Size(312, 40);
            this.label5.Text = "label5";

            this.ClientSize = new System.Drawing.Size(672, 461);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.ResumeLayout(false);
        }

        // Display the image.
        private void button1_Click (object sender, System.EventArgs e)
		{
			if(imageList1.Images.Empty != true)
			{
				if(imageList1.Images.Count-1 > currentImage)
				{
					currentImage++;
				}
				else
				{
					currentImage=0;
				}
				panel1.Refresh();
                
                // Draw the image in the panel.
				imageList1.Draw(myGraphics,10,10,currentImage);

                // Show the image in the PictureBox.
				pictureBox1.Image = imageList1.Images[currentImage];
				label3.Text = "Current image is " + currentImage ;
				listBox1.SelectedIndex = currentImage;
				label5.Text = "Image is " + listBox1.Text ;
            }
		}
 
        // Remove the image.
		private void button2_Click (object sender, System.EventArgs e)
		{
			imageList1.Images.RemoveAt(listBox1.SelectedIndex);
			listBox1.Items.Remove(listBox1.SelectedItem);
		}
 
        // Clear all images.
		private void button3_Click (object sender, System.EventArgs e)
		{
			imageList1.Images.Clear();
			listBox1.Items.Clear();
		}
 
        // Find an image.
		private void button4_Click (object sender, System.EventArgs e)
		{
			openFileDialog1.Multiselect = true ;
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				if (openFileDialog1.FileNames != null)
				{
					for(int i =0 ; i < openFileDialog1.FileNames.Length ; i++ )
					{
						addImage(openFileDialog1.FileNames[i]);
					}
				}
				else
					addImage(openFileDialog1.FileName);
			}
            
		}
 
		private void addImage(string imageToLoad)
		{
			if (imageToLoad != "")
			{
				imageList1.Images.Add(Image.FromFile(imageToLoad));
				listBox1.BeginUpdate();
				listBox1.Items.Add(imageToLoad);
				listBox1.EndUpdate();
			}
		}
        [STAThread]
        public static void Main(string[] args) 
		{
			Application.Run(new Form1());
		}
	}
}
//</snippet1>
