using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace FormAutoScrollEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
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
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(200, 56);
         this.button1.Name = "button1";
         this.button1.TabIndex = 0;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(336, 294);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1});
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
        DisplayMyScrollableForm();
      }

      //<Snippet1>
      private void DisplayMyScrollableForm()
      {
         // Create a new form.
         Form form2 = new Form();
         // Create a button to add to the new form.
         Button button1 = new Button();
         // Set text for the button.
         button1.Text = "Scrolled Button";
         // Set the size of the button.
         button1.Size = new Size(100,30);
         // Set the location of the button to be outside the form's client area.
         button1.Location = new Point(form2.Size.Width + 200, form2.Size.Height + 200);

         // Add the button control to the new form.
         form2.Controls.Add(button1);
         // Set the AutoScroll property to true to provide scrollbars.
         form2.AutoScroll = true;

         // Display the new form as a dialog box.
         form2.ShowDialog();
      }
      //</Snippet1>

	}
}
