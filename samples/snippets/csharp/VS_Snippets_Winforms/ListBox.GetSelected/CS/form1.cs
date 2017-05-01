using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ListBoxGetSelectedEx
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
                                                      "Echo",
                                                      "Foxtro",
                                                      "Golf",
                                                      "Hotel",
                                                      "Igloo",
                                                      "Java",
                                                      "Koala",
                                                      "Lima",
                                                      "Mama"});
         this.listBox1.Location = new System.Drawing.Point(56, 40);
         this.listBox1.Name = "listBox1";
         this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
         this.listBox1.Size = new System.Drawing.Size(200, 82);
         this.listBox1.TabIndex = 0;
         this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(264, 72);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(376, 254);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1,
                                                                      this.listBox1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
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
      private void InitializeMyListBox()
      {
         // Add items to the ListBox.
         listBox1.Items.Add("A");
         listBox1.Items.Add("C");
         listBox1.Items.Add("E");
         listBox1.Items.Add("F");
         listBox1.Items.Add("G");
         listBox1.Items.Add("D");
         listBox1.Items.Add("B");

         // Sort all items added previously.
         listBox1.Sorted = true;

         // Set the SelectionMode to select multiple items.
         listBox1.SelectionMode = SelectionMode.MultiExtended;

         // Select three initial items from the list.
         listBox1.SetSelected(0,true);
         listBox1.SetSelected(2,true);
         listBox1.SetSelected(4,true);

         // Force the ListBox to scroll back to the top of the list.
         listBox1.TopIndex=0;
      }

      private void InvertMySelection()
      {
         // Loop through all items the ListBox.
         for (int x = 0; x < listBox1.Items.Count; x++)
         {
            // Determine if the item is selected.
            if(listBox1.GetSelected(x) == true)
               // Deselect all items that are selected.
               listBox1.SetSelected(x,false);      
            else
               // Select all items that are not selected.
               listBox1.SetSelected(x,true);
         }
         // Force the ListBox to scroll back to the top of the list.
         listBox1.TopIndex=0;
      }
      //</Snippet1>

      private void button1_Click(object sender, System.EventArgs e)
      {
         InvertMySelection();
      }

      private void listBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         
      }

      private void Form1_Load(object sender, System.EventArgs e)
      {
         listBox1.Items.Clear();
         this.InitializeMyListBox();
      }
	}
}
