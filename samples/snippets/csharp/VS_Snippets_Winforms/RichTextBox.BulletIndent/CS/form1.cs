using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace RichTextBoxSelectionEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.RichTextBox richTextBox1;
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
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // richTextBox1
         // 
         this.richTextBox1.Location = new System.Drawing.Point(8, 8);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.Size = new System.Drawing.Size(400, 168);
         this.richTextBox1.TabIndex = 0;
         this.richTextBox1.Text = "richTextBox1";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(312, 192);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(416, 382);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1,
                                                                      this.richTextBox1});
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
         WriteTextToRichTextBox();
      }

      //<Snippet1>
      private void WriteTextToRichTextBox()
      {
         // Clear all text from the RichTextBox;
         richTextBox1.Clear();
         // Indent bulleted text 30 pixels away from the bullet.
         richTextBox1.BulletIndent = 30;
         // Set the font for the opening text to a larger Arial font;
         richTextBox1.SelectionFont = new Font("Arial", 16);
         // Assign the introduction text to the RichTextBox control.
         richTextBox1.SelectedText = "The following is a list of bulleted items:\n";
         // Set the Font for the first item to a smaller size Arial font.
         richTextBox1.SelectionFont = new Font("Arial", 12);
         // Specify that the following items are to be added to a bulleted list.
         richTextBox1.SelectionBullet = true;
         // Set the color of the item text.
         richTextBox1.SelectionColor = Color.Red;
         // Assign the text to the bulleted item.
         richTextBox1.SelectedText = "Apples" + "\n";
         // Apply same font since font settings do not carry to next line.
         richTextBox1.SelectionFont = new Font("Arial", 12);
         richTextBox1.SelectionColor = Color.Orange;
         richTextBox1.SelectedText = "Oranges" + "\n";
         richTextBox1.SelectionFont = new Font("Arial", 12);
         richTextBox1.SelectionColor = Color.Purple;
         richTextBox1.SelectedText = "Grapes" + "\n";
         // End the bulleted list.
         richTextBox1.SelectionBullet = false;
         // Specify the font size and string for text displayed below bulleted list.
         richTextBox1.SelectionFont = new Font("Verdana", 10);
         richTextBox1.SelectedText = "The bulleted text is indented 30 pixels from the bullet symbol using the BulletIndent property.\n";
      }
      //</Snippet1>
	}
}
