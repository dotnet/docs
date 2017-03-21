    private void toggleRowStylesBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
		TableLayoutRowStyleCollection styles = 
			this.TableLayoutPanel1.RowStyles;

        foreach( RowStyle style in styles )
        {
            if (style.SizeType==SizeType.Absolute)
            {
                style.SizeType = SizeType.AutoSize;
            }
            else if(style.SizeType==SizeType.AutoSize)
            {
                style.SizeType = SizeType.Percent;

                // Set the row height to be a percentage
                // of the TableLayoutPanel control's height.
                style.Height = 33;
            }
            else
            {

                // Set the row height to 50 pixels.
                style.SizeType = SizeType.Absolute;
                style.Height = 50;
            }
        }
    }