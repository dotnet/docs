using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ResizeEvent
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();
		}

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
		private void InitializeComponent()
		{
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Resize += new System.EventHandler(this.Form1_Resize);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

//<snippet1>
private void Form1_Resize(object sender, System.EventArgs e)
{
   Control control = (Control)sender;
		
   // Ensure the Form remains square (Height = Width).
   if(control.Size.Height != control.Size.Width)
   {
      control.Size = new Size(control.Size.Width, control.Size.Width);
   }
}
//</snippet1>

	}
}
