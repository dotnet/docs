		private void Form1_Load(object sender, System.EventArgs e)
		{
			// Add a text string to the TextBox.
			textBox1.Text = "Hello World!";
			
			// Set the size of the TextBox.
			textBox1.AutoSize = false;
			textBox1.Size = new Size(Width, Height/3);
			
			// Align the text in the center of the control element. 
			textBox1.TextAlign = HorizontalAlignment.Center;							
		}