using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Controls
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.Button addRangeButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button removeAtButton;
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

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.addRangeButton = new System.Windows.Forms.Button();
			this.removeAtButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.removeButton = new System.Windows.Forms.Button();
			this.clearButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(168, 112);
			this.panel1.TabIndex = 5;
			// 
			// addRangeButton
			// 
			this.addRangeButton.Location = new System.Drawing.Point(8, 168);
			this.addRangeButton.Name = "addRangeButton";
			this.addRangeButton.TabIndex = 4;
			this.addRangeButton.Text = "AddRange";
			this.addRangeButton.Click += new System.EventHandler(this.addRangeButton_Click);
			// 
			// removeAtButton
			// 
			this.removeAtButton.Location = new System.Drawing.Point(96, 168);
			this.removeAtButton.Name = "removeAtButton";
			this.removeAtButton.TabIndex = 6;
			this.removeAtButton.Text = "RemoveAt";
			this.removeAtButton.Click += new System.EventHandler(this.removeAtButton_Click);
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(8, 136);
			this.addButton.Name = "addButton";
			this.addButton.TabIndex = 0;
			this.addButton.Text = "Add";
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// removeButton
			// 
			this.removeButton.Location = new System.Drawing.Point(96, 136);
			this.removeButton.Name = "removeButton";
			this.removeButton.TabIndex = 2;
			this.removeButton.Text = "Remove";
			this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
			// 
			// clearButton
			// 
			this.clearButton.Location = new System.Drawing.Point(96, 200);
			this.clearButton.Name = "clearButton";
			this.clearButton.TabIndex = 3;
			this.clearButton.Text = "Clear";
			this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(184, 229);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.removeAtButton,
																		  this.panel1,
																		  this.addRangeButton,
																		  this.clearButton,
																		  this.removeButton,
																		  this.addButton});
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	
	
//<snippet3>		
// Create two RadioButtons to add to the Panel.
private RadioButton radioAddButton = new RadioButton();
private RadioButton radioRemoveButton = new RadioButton();

// Add controls to the Panel using the AddRange method.
private void addRangeButton_Click(object sender, System.EventArgs e)
{
   // Set the Text the RadioButtons will display.
   radioAddButton.Text = "radioAddButton";
   radioRemoveButton.Text = "radioRemoveButton";
			
   // Set the appropriate location of radioRemoveButton.
   radioRemoveButton.Location = new System.Drawing.Point(
     radioAddButton.Location.X, 
     radioAddButton.Location.Y + radioAddButton.Height);
			
   //Add the controls to the Panel.
   panel1.Controls.AddRange(new Control[]{radioAddButton, radioRemoveButton});
}
//</snippet3>

//<snippet2>
// Create a TextBox to add to the Panel.
private TextBox textBox1 = new TextBox();

// Add controls to the Panel using the Add method.
private void addButton_Click(object sender, System.EventArgs e)
{
   panel1.Controls.Add(textBox1);
}
//</snippet2>

//<snippet1>
// Clear all the controls in the Panel.
private void clearButton_Click(object sender, System.EventArgs e)
{
   panel1.Controls.Clear();
}
//</snippet1>

//<snippet5>
// Remove the first control in the collection.
private void removeAtButton_Click(object sender, System.EventArgs e)
{
   if (panel1.Controls.Count > 0)
   {
      panel1.Controls.RemoveAt(0);
   }
}
//</snippet5>

//<snippet4>	
// Remove the RadioButton control if it exists.
private void removeButton_Click(object sender, System.EventArgs e)
{
   if(panel1.Controls.Contains(removeButton))
   {
      panel1.Controls.Remove(removeButton);
   }
}
//</snippet4>

	}
}
