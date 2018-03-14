using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ListBoxFindStringEx2
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
         this.listBox1.Items.AddRange(new object[] {
                                                      "Alpha",
                                                      "Bravo",
                                                      "Charlie",
                                                      "Delta",
                                                      "Echo"});
         this.listBox1.Location = new System.Drawing.Point(24, 32);
         this.listBox1.Name = "listBox1";
         this.listBox1.Size = new System.Drawing.Size(224, 108);
         this.listBox1.TabIndex = 0;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(264, 32);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(104, 24);
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(504, 422);
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
         FindMyString("Charlie");
      }

      //<Snippet1>
      private void FindMyString(string searchString)
      {
         // Ensure we have a proper string to search for.
         if (searchString != string.Empty)
         {
            // Find the item in the list and store the index to the item.
            int index = listBox1.FindString(searchString);
            // Determine if a valid index is returned. Select the item if it is valid.
            if (index != -1)
               listBox1.SetSelected(index,true);
            else
               MessageBox.Show("The search string did not match any items in the ListBox");
         }
      }
      //</Snippet1>
	}
}
