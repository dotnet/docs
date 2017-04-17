using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ListBoxIndexChangeEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.ListBox listBox1;
      private System.Windows.Forms.ListBox listBox2;
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
         this.listBox2 = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // listBox1
         // 
         this.listBox1.Items.AddRange(new object[] {
                                                      "A",
                                                      "B",
                                                      "C",
                                                      "D",
                                                      "E",
                                                      "F",
                                                      "G",
                                                      "H",
                                                      "I",
                                                      "J",
                                                      "K"});
         this.listBox1.Location = new System.Drawing.Point(40, 32);
         this.listBox1.Name = "listBox1";
         this.listBox1.Size = new System.Drawing.Size(136, 95);
         this.listBox1.TabIndex = 0;
         this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
         // 
         // listBox2
         // 
         this.listBox2.Items.AddRange(new object[] {
                                                      "D",
                                                      "A",
                                                      "B",
                                                      "E",
                                                      "C",
                                                      "F",
                                                      "H",
                                                      "G",
                                                      "K",
                                                      "I",
                                                      "J"});
         this.listBox2.Location = new System.Drawing.Point(200, 32);
         this.listBox2.Name = "listBox2";
         this.listBox2.Size = new System.Drawing.Size(136, 95);
         this.listBox2.TabIndex = 2;
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(424, 266);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.listBox2,
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

      //<Snippet1>
      private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         // Get the currently selected item in the ListBox.
         string curItem = listBox1.SelectedItem.ToString();

         // Find the string in ListBox2.
         int index = listBox2.FindString(curItem);
         // If the item was not found in ListBox 2 display a message box, otherwise select it in ListBox2.
         if(index == -1)
            MessageBox.Show("Item is not available in ListBox2");
         else
            listBox2.SetSelected(index,true);
      }
      //</Snippet1>
	}
}
