#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace Current
{
	class Form1 : Form
	{
		private BindingSource BindingSource1;

		private Button button1;


		public Form1()
		{
			this.Load += new EventHandler(Form1_Load);
			this.Paint += new PaintEventHandler(Form1_Paint);
			this.BindingSource1 = new BindingSource();
			this.button1 = new Button();
			button1.Text = "Move Next";
			this.button1.Location = new System.Drawing.Point(147, 129);
			this.button1.Click += new System.EventHandler(this.button1_Click);

			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.button1);

		}
		// The following snippet demonstrates the BindingSource.MoveNext, BindingSource.Current,
		// BindingSource.CurrentItem, BindingSource.Position and the BindingSourceItem.Value members.

		// To run this example paste the code into a form that contains a BindingSource
		// named BindingSource1 and a button named button1.  Associate the
		// Form1_Load and the Form1_Paint method with the load and paint events for the form,
		// and the button1_click method with the click event for button1.

		//<snippet1>
		void Form1_Load(object sender, EventArgs e)
		{
			// Set the data source to the Brush type and populate
			// BindingSource1 with some brushes.
			BindingSource1.DataSource = typeof(System.Drawing.Brush);
			BindingSource1.Add(
				new TextureBrush(new Bitmap(typeof(Button), "Button.bmp")));
			BindingSource1.Add(new HatchBrush(HatchStyle.Cross, Color.Red));
			BindingSource1.Add(new SolidBrush(Color.Blue));
		}


		private void button1_Click(object sender, EventArgs e)
		{
			// If you are not at the end of the list, move to the next item
			// in the BindingSource.
			if (BindingSource1.Position + 1 < BindingSource1.Count)
				BindingSource1.MoveNext();

			// Otherwise, move back to the first item.
			else
				BindingSource1.MoveFirst();

			// Force the form to repaint.
			this.Invalidate();
		}

		void Form1_Paint(object sender, PaintEventArgs e)
		{
			// Get the current item in the BindingSource.
			Brush item = (Brush)BindingSource1.Current;

			// If the current type is a TextureBrush, fill an ellipse.
			if (item.GetType() == typeof(TextureBrush))
				e.Graphics.FillEllipse(item,
				   e.ClipRectangle);

			// If the current type is a HatchBrush, fill a triangle.
			else if (item.GetType() == typeof(HatchBrush))
				e.Graphics.FillPolygon(item,
					new Point[] { new Point(0, 0), new Point(0, 200),
                    new Point(200, 0)});

			// Otherwise, fill a rectangle.
			else
				e.Graphics.FillRectangle(
					(Brush)BindingSource1.Current, e.ClipRectangle);
		}
		//</snippet1>

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new Form1());
		}

	}




}
