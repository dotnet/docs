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