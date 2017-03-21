    private void toggleColumnStylesBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
		TableLayoutColumnStyleCollection styles = 
			this.TableLayoutPanel1.ColumnStyles;

        foreach( ColumnStyle style in styles )
        {
            if( style.SizeType == SizeType.Absolute )
            {
                style.SizeType = SizeType.AutoSize;
            }
            else if( style.SizeType == SizeType.AutoSize )
            {
                style.SizeType = SizeType.Percent;

                // Set the column width to be a percentage
                // of the TableLayoutPanel control's width.
                style.Width = 33;
            }
            else
            {
                // Set the column width to 50 pixels.
                style.SizeType = SizeType.Absolute;
                style.Width = 50;
            }
        }
    }