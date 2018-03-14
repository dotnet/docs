using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WindowsApplication1
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
         this.button1.Location = new System.Drawing.Point(144, 72);
         this.button1.Name = "button1";
         this.button1.TabIndex = 0;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(292, 273);
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
      private void button1_Click(object sender, System.EventArgs e)
      {
//<snippet1>
         System.Windows.Forms.ColorDialog MyDialog = new ColorDialog();
         // Allows the user to select or edit a custom color.
         MyDialog.AllowFullOpen = true ;
         // Assigns an array of custom colors to the CustomColors property
         MyDialog.CustomColors = new int[]{6916092, 15195440, 16107657, 1836924,
            3758726, 12566463, 7526079, 7405793, 6945974, 241502, 2296476, 5130294,
            3102017, 7324121, 14993507, 11730944,};

         // Allows the user to get help. (The default is false.)
         MyDialog.ShowHelp = true ;
         // Sets the initial color select to the current text color,
         // so that if the user cancels out, the original color is restored.
         MyDialog.Color = this.BackColor;
         MyDialog.ShowDialog();
         this.BackColor =  MyDialog.Color;
//</snippet1>
         // Print the custom colors if the user has changed them.
         PrintCustomColors(MyDialog.CustomColors);
      }

      private void PrintCustomColors(int[] clrs)
      {
         TextWriter writer = new StreamWriter("colors.txt");
      {foreach(int i in clrs) writer.WriteLine(i);}
         writer.Close();
      }
//      private int[] AddCustomColors()
//      {
//         return new int[]{6916092, 
//                            15195440,
//                            16107657,
//                            1836924,
//                            3758726,
//                            12566463,
//                            7526079,
//                            7405793,
//                            6945974,
//                            241502,
//                            2296476,
//                            5130294,
//                            3102017,
//                            7324121,
//                            14993507,
//                            11730944,
//         };
//      }
      [STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

	}
}
