using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RichText_DD_cs
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;



public Form1()
{
   //
   // Required for Windows Form Designer supports
   //
   InitializeComponent();

		
   // Sets the control to allow drops, and then adds the necessary event handlers.
   this.richTextBox1.AllowDrop = true;
   this.richTextBox1.DragEnter += new DragEventHandler(this.richTextBox1_DragEnter);
   this.richTextBox1.DragDrop += new DragEventHandler(this.richTextBox1_DragDrop);
   this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
   this.Load += new System.EventHandler(this.Form1_Load);

   // Add code here to populate the ListBox1 with paths to text files.

}


//<snippet1>
private void Form1_Load(object sender, EventArgs e) 
{
   // Sets the AllowDrop property so that data can be dragged onto the control.
   richTextBox1.AllowDrop = true;

   // Add code here to populate the ListBox1 with paths to text files.

}

private void listBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
{
   // Determines which item was selected.
   ListBox lb =( (ListBox)sender);
   Point pt = new Point(e.X,e.Y);
   int index = lb.IndexFromPoint(pt);

   // Starts a drag-and-drop operation with that item.
   if(index>=0) 
   {
      lb.DoDragDrop(lb.Items[index].ToString(), DragDropEffects.Link);
   }
}

private void richTextBox1_DragEnter(object sender, DragEventArgs e) 
{
   // If the data is text, copy the data to the RichTextBox control.
   if(e.Data.GetDataPresent("Text"))
      e.Effect = DragDropEffects.Copy;
}

private void richTextBox1_DragDrop(object sender, DragEventArgs e) 
{
   // Loads the file into the control. 
   richTextBox1.LoadFile((String)e.Data.GetData("Text"), System.Windows.Forms.RichTextBoxStreamType.RichText);
}

//</snippet1>



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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(256, 48);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(120, 95);
			this.listBox1.TabIndex = 0;
			
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(64, 40);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "richTextBox1";
		
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(464, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.richTextBox1,
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


	}
}
