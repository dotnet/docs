using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MessageBox_CS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox serverName;
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
			this.serverName = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// serverName
			// 
			this.serverName.Location = new System.Drawing.Point(32, 40);
			this.serverName.Name = "serverName";
			this.serverName.TabIndex = 0;
			this.serverName.Text = "textBox1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(40, 96);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.serverName});
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
			validateUserEntry();
			validateUserEntry2();
			validateUserEntry3();
			validateUserEntry4();
			validateUserEntry5();
		
		}

		//<snippet1>

	private void validateUserEntry()
	{

		// Checks the value of the text.

		if(serverName.Text.Length == 0)
		{

			// Initializes the variables to pass to the MessageBox.Show method.

			string message = "You did not enter a server name. Cancel this operation?";
                        string caption = "Error Detected in Input";
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;

			// Displays the MessageBox.

			result = MessageBox.Show(message, caption, buttons);

			if (result == System.Windows.Forms.DialogResult.Yes)
			{

				// Closes the parent form.

				this.Close();

			}

		}

	}

	//</snippet1>

	//<snippet2>

	private void validateUserEntry2()
	{

		// Checks the value of the text.

		if(serverName.Text.Length == 0)
		{

			// Initializes the variables to pass to the MessageBox.Show method.

			string message = "You did not enter a server name. Cancel this operation?";
			string caption = "No Server Name Specified";
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;

			// Displays the MessageBox.

			result = MessageBox.Show(this, message, caption, buttons,
				MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
				MessageBoxOptions.RightAlign);

			if(result == DialogResult.Yes)
			{

				// Closes the parent form.

				this.Close();

			}

		}

	}

	//</snippet2>

	//<snippet3>
	private void validateUserEntry3()
	{

		// Checks the value of the text.

		if(serverName.Text.Length == 0)
		{

			// Initializes the variables to pass to the MessageBox.Show method.

			string message = "You did not enter a server name. Cancel this operation?";
			string caption = "No Server Name Specified";
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;

			// Displays the MessageBox.

			result = MessageBox.Show(this, message, caption, buttons,
			MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

			if(result == DialogResult.Yes)
			{

				// Closes the parent form.

				this.Close();

			}

		}

	}

	//</snippet3>

	//<snippet4>
	private void validateUserEntry4()
	{

		// Checks the value of the text.

		if(serverName.Text.Length == 0)
		{

			// Initializes the variables to pass to the MessageBox.Show method.

			string message = "You did not enter a server name. Cancel this operation?";
			string caption = "No Server Name Specified";
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;

			// Displays the MessageBox.

			result = MessageBox.Show(this, message, caption, buttons,
				MessageBoxIcon.Question);

			if(result == DialogResult.Yes)
			{

				// Closes the parent form.

				this.Close();

			}

		}

	}
	//</snippet4>

	//<snippet5>
	private void validateUserEntry5()
	{

		// Checks the value of the text.

		if(serverName.Text.Length == 0)
		{

			// Initializes the variables to pass to the MessageBox.Show method.

			string message = "You did not enter a server name. Cancel this operation?";
			string caption = "No Server Name Specified";
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;

			// Displays the MessageBox.

			result = MessageBox.Show(this, message, caption, buttons);

			if(result == DialogResult.Yes)
			{

				// Closes the parent form.

				this.Close();

			}

		}

	}
	//</snippet5>


        //<snippet6>
        private void DisplayMessageBoxText()
        {
                 MessageBox.Show("Hello, world.");
        }

        //</snippet6>


	}
}
