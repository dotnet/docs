using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RichTextBoxAllowDropEx
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



   //
   // Required for Windows Form Designer supports
   //
   //<Snippet1>
   public Form1()
   {
      InitializeComponent();
      // Sets the control to allow drops, and then adds the necessary event handlers.
      this.richTextBox1.AllowDrop = true;
   }
	
   private void listBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
   {
      // Determines which item was selected.
      ListBox lb =( (ListBox)sender);
      Point pt = new Point(e.X,e.Y);
      //Retrieve the item at the specified location within the ListBox.
      int index = lb.IndexFromPoint(pt);

      // Starts a drag-and-drop operation.
      if(index>=0) 
      {
         // Retrieve the selected item text to drag into the RichTextBox.
         lb.DoDragDrop(lb.Items[index].ToString(), DragDropEffects.Copy);
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
      // Paste the text into the RichTextBox where at selection location.
      richTextBox1.SelectedText =  e.Data.GetData("System.String", true).ToString();
   }

   //</Snippet1>



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
      this.listBox1.Items.AddRange(new object[] {
                                                   "Alpha",
                                                   "Bravo",
                                                   "Charlie",
                                                   "Delta",
                                                   "Echo",
                                                   "Foxtrot"});
      this.listBox1.Location = new System.Drawing.Point(16, 16);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(208, 238);
      this.listBox1.TabIndex = 0;
      this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
      // 
      // richTextBox1
      // 
      this.richTextBox1.Location = new System.Drawing.Point(240, 16);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(208, 240);
      this.richTextBox1.TabIndex = 1;
      this.richTextBox1.Text = "";
      this.richTextBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.richTextBox1_DragDrop);
      this.richTextBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.richTextBox1_DragEnter);
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
