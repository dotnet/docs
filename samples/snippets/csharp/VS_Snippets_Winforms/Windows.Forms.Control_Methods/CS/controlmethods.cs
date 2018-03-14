using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SetBoundsCore
{
	public class MyUserControl : System.Windows.Forms.UserControl
	{
		private System.ComponentModel.Container components = null;

		public MyUserControl()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         // 
         // MyUserControl
         // 
         this.BackColor = System.Drawing.SystemColors.Desktop;
         this.Name = "MyUserControl";
         this.Size = new System.Drawing.Size(224, 88);

      }
		#endregion



// <snippet1>
protected override void SetBoundsCore(int x, int y, 
   int width, int height, BoundsSpecified specified)
{
   // Set a fixed height and width for the control.
   base.SetBoundsCore(x, y, 150, 75, specified);
}
// </snippet1>


// <snippet2>
protected override void SetClientSizeCore(int x, int y)
{
   // Keep the client size square.
   if(x > y)
   {
      base.SetClientSizeCore(x, x);
   }
   else
   {
      base.SetClientSizeCore(y, y);
   }
}
// </snippet2>


// <snippet3>
protected override void ScaleCore(float dx, float dy)
{
   // Scale all child controls.
   this.SuspendLayout();

   Size myClientSize = this.ClientSize;
   myClientSize.Height = (int)(myClientSize.Height * dx);
   myClientSize.Width = (int)(myClientSize.Width * dy);
   
   /* Scale the child controls because
    * base.ScaleCore was not called. */
   foreach(Control childControl in this.Controls)
   {
      childControl.Scale(dx, dy);      
   }
   this.ResumeLayout();

   this.ClientSize = myClientSize;
}
// </snippet3>



	}
}
