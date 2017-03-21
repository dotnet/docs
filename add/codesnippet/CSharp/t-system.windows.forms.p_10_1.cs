
		private Rectangle RcDraw;
		private float PenWidth = 5;

		private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{

			// Determine the initial rectangle coordinates...

			RcDraw.X = e.X;
			RcDraw.Y = e.Y;
		
		}

		private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{

			// Determine the width and height of the rectangle...

			if(e.X < RcDraw.X)
			{
				RcDraw.Width = RcDraw.X - e.X;
				RcDraw.X = e.X;
			}
			else
			{
				RcDraw.Width = e.X - RcDraw.X;
			}

			if(e.Y < RcDraw.Y)
			{
				RcDraw.Height = RcDraw.Y - e.Y;
				RcDraw.Y = e.Y;
			}
			else
			{
				RcDraw.Height = e.Y - RcDraw.Y;
			}

			// Force a repaint of the region occupied by the rectangle...

			this.Invalidate(RcDraw);
		
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{

			// Draw the rectangle...

			e.Graphics.DrawRectangle(new Pen(Color.Blue, PenWidth), RcDraw);
			
		}
