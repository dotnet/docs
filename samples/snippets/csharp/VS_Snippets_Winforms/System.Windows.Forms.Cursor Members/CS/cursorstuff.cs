using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CursorStuff
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Cursor = System.Windows.Forms.Cursors.Default;
			this.button1.Location = new System.Drawing.Point(40, 184);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Cursor = System.Windows.Forms.Cursors.Default;
			this.button2.Location = new System.Drawing.Point(56, 232);
			this.button2.Name = "button2";
			this.button2.TabIndex = 3;
			this.button2.Text = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																							 this.button2,
																							 this.button1});
			this.Cursor = System.Windows.Forms.Cursors.Hand;
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


		private void button1_Click(object sender, System.EventArgs e)
		{
			this.MoveCursor();
		}

//<snippet1>
private void MoveCursor()
{
   // Set the Current cursor, move the cursor's Position,
   // and set its clipping rectangle to the form. 

   this.Cursor = new Cursor(Cursor.Current.Handle);
   Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
   Cursor.Clip = new Rectangle(this.Location, this.Size);
}
//</snippet1>

//<snippet2>
private void DrawCursorsOnForm(Cursor cursor)
{
   // If the form's cursor is not the Hand cursor and the 
   // Current cursor is the Default, Draw the specified 
   // cursor on the form in normal size and twice normal size.
   if(this.Cursor != Cursors.Hand & 
     Cursor.Current == Cursors.Default)
   {
      // Draw the cursor stretched.
      Graphics graphics = this.CreateGraphics();
      Rectangle rectangle = new Rectangle(
        new Point(10,10), new Size(cursor.Size.Width * 2, 
        cursor.Size.Height * 2));
      cursor.DrawStretched(graphics, rectangle);
		
      // Draw the cursor in normal size.
      rectangle.Location = new Point(
      rectangle.Width + rectangle.Location.X, 
        rectangle.Height + rectangle.Location.Y);
      rectangle.Size = cursor.Size;
      cursor.Draw(graphics, rectangle);

      // Dispose of the cursor.
      cursor.Dispose();
   }
}
//</snippet2>

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.DrawCursorsOnForm(new Cursor("c:\\MyCursor.cur"));
		}


	}
}
