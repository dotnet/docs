		internal ToolStripButton imageButton;

		private void InitializeImageButtonWithToolTip()
		{

			// Construct the button and set the image-related properties.
			imageButton = new ToolStripButton();
			imageButton.Image = new Bitmap(typeof(Timer), "Timer.bmp");
			imageButton.ImageScaling = ToolStripItemImageScaling.SizeToFit;

			// Set the background color of the image to be transparent.
			imageButton.ImageTransparentColor = Color.FromArgb(0, 255, 0);

			// Show ToolTip text, set custom ToolTip text, and turn
			// off the automatic ToolTips.
			toolStrip1.ShowItemToolTips = true;
			imageButton.ToolTipText = "Click for the current time";
			imageButton.AutoToolTip = false;

			// Add the button to the ToolStrip.
			toolStrip1.Items.Add(imageButton);

		}