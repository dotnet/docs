	internal System.Windows.Forms.ImageList ImageList1;

	// Create an ImageList Object, populate it, and display
	// the images it contains.
	private void Button1_Click(System.Object sender, 
		System.EventArgs e)
	{

		// Construct the ImageList.
		ImageList1 = new ImageList();

		// Set the ImageSize property to a larger size 
		// (the default is 16 x 16).
		ImageList1.ImageSize = new Size(112, 112);

		// Add two images to the list.
		ImageList1.Images.Add(
			Image.FromFile("c:\\windows\\FeatherTexture.bmp"));
		ImageList1.Images.Add(
			Image.FromFile("C:\\windows\\Gone Fishing.bmp"));

		// Get a Graphics object from the form's handle.
		Graphics theGraphics = Graphics.FromHwnd(this.Handle);

		// Loop through the images in the list, drawing each image.
		for(int count = 0; count < ImageList1.Images.Count; count++)
		{
			ImageList1.Draw(theGraphics, new Point(85, 85), count);

			// Call Application.DoEvents to force a repaint of the form.
			Application.DoEvents();

			// Call the Sleep method to allow the user to see the image.
			System.Threading.Thread.Sleep(1000);
		}
	}
