	private void Button2_Click(System.Object sender, System.EventArgs e)
	{
		
		for(int i = 0; i <= 20; i++)
		{
			// With each loop through the code, the form's 
			// desktop location is adjusted right and down
			//  by 10 pixels and its height and width are each
			// decreased by 10 pixels. 
			this.SetDesktopBounds(this.Location.X+10, 
				this.Location.Y+10, this.Width-10, this.Height-10);

			// Call Sleep to show the form gradually shrinking.
			System.Threading.Thread.Sleep(50);
		}
	}