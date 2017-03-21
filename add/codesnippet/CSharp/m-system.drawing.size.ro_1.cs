    private void TruncateAndRoundSizes()
    {

        // Create a SizeF.
        SizeF theSize = new SizeF(75.9F, 75.9F);

        // Round the Size.
        Size roundedSize = Size.Round(theSize);

        // Truncate the Size.
        Size truncatedSize = Size.Truncate(theSize);

        //Print out the values on two labels.
        Label1.Text = "Rounded size = "+roundedSize.ToString();
        Label2.Text = "Truncated size = "+truncatedSize.ToString();

    }