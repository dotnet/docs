    private void Button5_Click(System.Object sender, System.EventArgs e)
    {
        try
        {
            if (image1 != null)
            {
                image1.Save("c:\\myBitmap.bmp");
                Button5.Text = "Saved file.";
            }
        }
        catch(Exception)
        {
            MessageBox.Show("There was a problem saving the file." +
                "Check the file permissions.");
        }

    }