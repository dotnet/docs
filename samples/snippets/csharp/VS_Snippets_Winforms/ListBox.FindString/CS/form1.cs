using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ListBoxFindStringEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.TextBox textBox1;
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
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.listBox1 = new System.Windows.Forms.ListBox();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(208, 216);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(152, 20);
         this.textBox1.TabIndex = 0;
         this.textBox1.Text = "";
         // 
         // listBox1
         // 
         this.listBox1.Items.AddRange(new object[] {
                                                      "Alpha",
                                                      "Bravo",
                                                      "Charlie",
                                                      "Delta",
                                                      "Echo",
                                                      "Foxtrot",
                                                      "Alpha2",
                                                      "Alpha3",
                                                      "Bravo2",
                                                      "Charlie2",
                                                      "Delta3",
                                                      "Echo2",
                                                      "Delta2",
                                                      "Foxtrot2"});
         this.listBox1.Location = new System.Drawing.Point(192, 32);
         this.listBox1.Name = "listBox1";
         this.listBox1.Size = new System.Drawing.Size(208, 147);
         this.listBox1.TabIndex = 1;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(368, 216);
         this.button1.Name = "button1";
         this.button1.TabIndex = 2;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(496, 350);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1,
                                                                      this.listBox1,
                                                                      this.textBox1});
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
         FindAllOfMyString(textBox1.Text);
      }

      //<Snippet1>
      private void FindAllOfMyString(string searchString)
      {
         // Set the SelectionMode property of the ListBox to select multiple items.
         listBox1.SelectionMode = SelectionMode.MultiExtended;
         
         // Set our intial index variable to -1.
         int x =-1;
         // If the search string is empty exit.
         if (searchString.Length != 0)
         {
            // Loop through and find each item that matches the search string.
            do
            {
               // Retrieve the item based on the previous index found. Starts with -1 which searches start.
               x = listBox1.FindString(searchString, x);
               // If no item is found that matches exit.
               if (x != -1)
               {
                  // Since the FindString loops infinitely, determine if we found first item again and exit.
                  if (listBox1.SelectedIndices.Count > 0)
                  {
                     if(x == listBox1.SelectedIndices[0])
                        return;
                  }
                  // Select the item in the ListBox once it is found.
                  listBox1.SetSelected(x,true);
               }
   
            }while(x != -1);
         }
      }
      //</Snippet1>
   }
}

