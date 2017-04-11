using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ListBoxHorizExtentEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.ListBox listBox1;
      private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.listBox1 = new System.Windows.Forms.ListBox();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // listBox1
         // 
         this.listBox1.Location = new System.Drawing.Point(56, 48);
         this.listBox1.Name = "listBox1";
         this.listBox1.Size = new System.Drawing.Size(160, 69);
         this.listBox1.TabIndex = 0;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(272, 56);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(464, 334);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1,
                                                                      this.listBox1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

      private void button1_Click(object sender, System.EventArgs e)
      {
         DisplayHScroll();
      }

      //<Snippet1>
      private void DisplayHScroll()
      {
         // Make sure no items are displayed partially.
         listBox1.IntegralHeight = true;

         // Add items that are wide to the ListBox.
         for (int x = 0; x < 10; x++)
         {
            listBox1.Items.Add("Item  " + x.ToString() + " is a very large value that requires scroll bars");
         }

         // Display a horizontal scroll bar.
         listBox1.HorizontalScrollbar = true;

         // Create a Graphics object to use when determining the size of the largest item in the ListBox.
         Graphics g = listBox1.CreateGraphics();

         // Determine the size for HorizontalExtent using the MeasureString method using the last item in the list.
         int hzSize = (int) g.MeasureString(listBox1.Items[listBox1.Items.Count -1].ToString(),listBox1.Font).Width;
         // Set the HorizontalExtent property.
         listBox1.HorizontalExtent = hzSize;
      }
      //</Snippet1>
	}
}
