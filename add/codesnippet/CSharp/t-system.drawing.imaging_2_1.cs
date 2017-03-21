    private void ExtractMetaData(PaintEventArgs e)
    {
        try
        {
            // Create an Image object. 
            Image theImage = new Bitmap("c:\\fakePhoto.jpg");

            // Get the PropertyItems property from image.
            PropertyItem[] propItems = theImage.PropertyItems;

            // Set up the display.
            Font font1 = new Font("Arial", 10);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            int X = 0;
            int Y = 0;

            // For each PropertyItem in the array, display the id, 
            // type, and length.
            int count = 0;
            foreach ( PropertyItem propItem in propItems )
            {
                e.Graphics.DrawString("Property Item " + 
                    count.ToString(), font1, blackBrush, X, Y);
                Y += font1.Height;

                e.Graphics.DrawString("   ID: 0x" + 
                    propItem.Id.ToString("x"), font1, blackBrush, X, Y);
                Y += font1.Height;

                e.Graphics.DrawString("   type: " +
                    propItem.Type.ToString(), font1, blackBrush, X, Y);
                Y += font1.Height;

                e.Graphics.DrawString("   length: " + 
                    propItem.Len.ToString() + 
                    " bytes", font1, blackBrush, X, Y);
                Y += font1.Height;
                count += 1;
            }
            font1.Dispose();
        }
        catch(Exception)
        {
            MessageBox.Show("There was an error." + 
                "Make sure the path to the image file is valid.");
        }

    }