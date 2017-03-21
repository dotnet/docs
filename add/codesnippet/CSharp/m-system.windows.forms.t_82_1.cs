        // This utility method creates a ContextMenuStrip control
        // that has four ToolStripMenuItems showing the four 
        // possible combinations of image and check margins.
        internal ContextMenuStrip CreateCheckImageContextMenuStrip()
        {
            // Create a new ContextMenuStrip control.
            ContextMenuStrip checkImageContextMenuStrip = new ContextMenuStrip();

            // Create a ToolStripMenuItem with a
            // check margin and an image margin.
            ToolStripMenuItem yesCheckYesImage = 
                new ToolStripMenuItem("Check, Image");
            yesCheckYesImage.Checked = true;
            yesCheckYesImage.Image = CreateSampleBitmap();

            // Create a ToolStripMenuItem with no
            // check margin and with an image margin.
            ToolStripMenuItem noCheckYesImage = 
                new ToolStripMenuItem("No Check, Image");
            noCheckYesImage.Checked = false;
            noCheckYesImage.Image = CreateSampleBitmap();

            // Create a ToolStripMenuItem with a
            // check margin and without an image margin.
            ToolStripMenuItem yesCheckNoImage = 
                new ToolStripMenuItem("Check, No Image");
            yesCheckNoImage.Checked = true;

            // Create a ToolStripMenuItem with no
            // check margin and no image margin.
            ToolStripMenuItem noCheckNoImage = 
                new ToolStripMenuItem("No Check, No Image");
            noCheckNoImage.Checked = false;

            // Add the ToolStripMenuItems to the ContextMenuStrip control.
            checkImageContextMenuStrip.Items.Add(yesCheckYesImage);
            checkImageContextMenuStrip.Items.Add(noCheckYesImage);
            checkImageContextMenuStrip.Items.Add(yesCheckNoImage);
            checkImageContextMenuStrip.Items.Add(noCheckNoImage);

            return checkImageContextMenuStrip;
        }