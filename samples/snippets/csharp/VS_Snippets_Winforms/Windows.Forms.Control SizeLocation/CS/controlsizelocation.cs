using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace ControlMembers
{
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Button button1;
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
		/// <summary>
		/// Required method for Designer support; do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
         this.button1.Location = new System.Drawing.Point(104, 104);
         this.button1.Name = "button1";
         this.button1.TabIndex = 0;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button_Click);
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

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

// <snippet1>
// Create three buttons and place them on a form using 
// several size and location related properties. 
private void AddOKCancelButtons()
{
   // Set the button size and location using 
   // the Size and Location properties.
   Button buttonOK = new Button();
   buttonOK.Location = new Point(136,248);
   buttonOK.Size = new Size(75,25);
   // Set the Text property and make the 
   // button the form's default button. 
   buttonOK.Text = "&OK";
   this.AcceptButton = buttonOK;

   // Set the button size and location using the Top, 
   // Left, Width, and Height properties.
   Button buttonCancel = new Button();
   buttonCancel.Top = buttonOK.Top;
   buttonCancel.Left = buttonOK.Right + 5;
   buttonCancel.Width = buttonOK.Width;
   buttonCancel.Height = buttonOK.Height;
   // Set the Text property and make the 
   // button the form's cancel button.
   buttonCancel.Text = "&Cancel";
   this.CancelButton = buttonCancel;

   // Set the button size and location using 
   // the Bounds property.
   Button buttonHelp = new Button();
   buttonHelp.Bounds = new Rectangle(10,10, 75, 25);
   // Set the Text property of the button.
   buttonHelp.Text = "&Help";

   // Add the buttons to the form.
   this.Controls.AddRange(new Control[] {buttonOK, buttonCancel, buttonHelp} );
}
// </snippet1>

      private void button_Click(object sender, System.EventArgs e)
      {
         Control ctrl = (Control)sender;
         MessageBox.Show("Top: " + ctrl.Top.ToString() + "\n" +
                         "Bottom: " + ctrl.Bottom.ToString() + "\n" +
                         "Left: " + ctrl.Left.ToString() + "\n" +
                         "Right: " + ctrl.Right.ToString() + "\n" +
                         "Width: " + ctrl.Width.ToString() + "\n" +
                         "Height: " + ctrl.Height.ToString() + "\n" +
                         "Size: " + ctrl.Size.ToString() + "\n" +
                         "Location: " + ctrl.Location.ToString(),"button1 Position",MessageBoxButtons.OKCancel );
         this.AddOKCancelButtons();
      }


	}
}
