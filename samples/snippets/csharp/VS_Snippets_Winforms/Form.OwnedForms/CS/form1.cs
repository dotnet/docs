using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace FormOwnedFormsEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
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
         this.button2 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(184, 32);
         this.button1.Name = "button1";
         this.button1.TabIndex = 0;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(200, 104);
         this.button2.Name = "button2";
         this.button2.TabIndex = 1;
         this.button2.Text = "button2";
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button2,
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
         AddMyOwnedForm();
      }

      //<Snippet1>
      private void AddMyOwnedForm()
      {
         // Create form to be owned.
         Form ownedForm = new Form();
         // Set the text of the owned form.
         ownedForm.Text = "Owned Form " + this.OwnedForms.Length;
         // Add the form to the array of owned forms.
         this.AddOwnedForm(ownedForm);
         // Show the owned form.
         ownedForm.Show();
      }

      private void ChangeOwnedFormText()
      {
         // Loop through all owned forms and change their text.
         for (int x = 0; x < this.OwnedForms.Length; x++)
         {
            this.OwnedForms[x].Text = "My Owned Form " + x.ToString();
         }
      }
      //</Snippet1>

      private void button2_Click(object sender, System.EventArgs e)
      {
         ChangeOwnedFormText();
      }


	}
}
