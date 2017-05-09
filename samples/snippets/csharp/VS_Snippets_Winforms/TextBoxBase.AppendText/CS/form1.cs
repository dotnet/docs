using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TextBoxBaseAppendEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.TextBox textBox2;
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
         this.textBox2 = new System.Windows.Forms.TextBox();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(24, 24);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(144, 20);
         this.textBox1.TabIndex = 0;
         this.textBox1.Text = "textBox1";
         // 
         // textBox2
         // 
         this.textBox2.Location = new System.Drawing.Point(24, 56);
         this.textBox2.Name = "textBox2";
         this.textBox2.Size = new System.Drawing.Size(144, 20);
         this.textBox2.TabIndex = 1;
         this.textBox2.Text = "textBox2";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(208, 40);
         this.button1.Name = "button1";
         this.button1.TabIndex = 2;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1,
                                                                      this.textBox2,
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
         AppendTextBox1Text();
      }

      //<Snippet1>
      private void AppendTextBox1Text()
      {
         // Determine if text is selected in textBox1.
         if(textBox1.SelectionLength == 0)
            // No selection made, return.
            return;
         
         // Determine if the text being appended to textBox2 exceeds the MaxLength property.
         if((textBox1.SelectedText.Length + textBox2.TextLength) > textBox2.MaxLength)
            MessageBox.Show("The text to paste in is larger than the maximum number of characters allowed");
         else
            // Append the text from textBox1 into textBox2.
            textBox2.AppendText(textBox1.SelectedText);
      }
      //</Snippet1>
	}
}
