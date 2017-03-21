    private void ComboBox1_SelectedIndexChanged(System.Object sender, 
        System.EventArgs e)
    {

        // Cast the sender object back to a ComboBox.
        ComboBox ComboBox1 = (ComboBox) sender;

        // Retrieve the selected item.
        string selectedString = (string) ComboBox1.SelectedItem;

        // Convert it to lowercase.
        selectedString = selectedString.ToLower();

        // Declare the current size.
        float currentSize;

        // Switch on the selected item. 
        switch(selectedString)
        {

                // If Bigger is selected, get the current size from the 
                // Size property and increase it. Reset the font to the
                //  new size, using the current unit.
            case "bigger":
                currentSize = Label1.Font.Size;
                currentSize += 2.0F;
                Label1.Font = new Font(Label1.Font.Name, currentSize, 
                    Label1.Font.Style, Label1.Font.Unit);

                // If Smaller is selected, get the current size, in points,
                // and decrease it by 1.  Reset the font with the new size
                // in points.
                break;
            case "smaller":
                currentSize = Label1.Font.SizeInPoints;
                currentSize -= 1;
                Label1.Font = new Font(Label1.Font.Name, currentSize, 
                    Label1.Font.Style);
                break;
        }
    }