using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ProgressBarEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button1;
		private ProgressBar pBar1 = new ProgressBar();

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			pBar1.Bounds = new Rectangle(10,50,200,20);
			this.Controls.Add(pBar1);

			

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		private bool CopyFile(string filename)
		{
			System.Diagnostics.Debug.WriteLine("File Being Copied = " + filename);
			return true;
		}

		// <snippet1>
		private void CopyWithProgress(string[] filenames)
		{
			// Display the ProgressBar control.
			pBar1.Visible = true;
			// Set Minimum to 1 to represent the first file being copied.
			pBar1.Minimum = 1;
			// Set Maximum to the total number of files to copy.
			pBar1.Maximum = filenames.Length;
			// Set the initial value of the ProgressBar.
			pBar1.Value = 1;
			// Set the Step property to a value of 1 to represent each file being copied.
			pBar1.Step = 1;
			
			// Loop through all files to copy.
			for (int x = 1; x <= filenames.Length; x++)
			{
				// Copy the file and increment the ProgressBar if successful.
				if(CopyFile(filenames[x-1]) == true)
				{
					// Perform the increment on the ProgressBar.
					pBar1.PerformStep();
				}
			}
		}
		// </snippet1>

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
			this.button1.Location = new System.Drawing.Point(288, 72);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 16);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(472, 398);
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
			string[] tempFiles = new string [5];
			tempFiles[0] = "file1.txt";
			tempFiles[1] = "file2.txt";
			tempFiles[2] = "file3.txt";
			tempFiles[3] = "file4.txt";
			tempFiles[4] = "file5.txt";

			CopyWithProgress(tempFiles);
		}
	}
}
