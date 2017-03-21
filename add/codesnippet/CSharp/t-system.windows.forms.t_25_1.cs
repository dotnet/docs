    private void borderStyleOutsetRadioBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.TableLayoutPanel1.CellBorderStyle = 
			TableLayoutPanelCellBorderStyle.Outset;
    }

    private void borderStyleNoneRadioBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.TableLayoutPanel1.CellBorderStyle = 
			TableLayoutPanelCellBorderStyle.None;
    }

    private void borderStyleInsetRadioBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.TableLayoutPanel1.CellBorderStyle = 
			TableLayoutPanelCellBorderStyle.Inset;
    }