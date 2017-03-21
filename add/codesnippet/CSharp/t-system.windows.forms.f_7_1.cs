    private void flowTopDownBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
    }

    private void flowBottomUpBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.FlowLayoutPanel1.FlowDirection = FlowDirection.BottomUp;
    }

    private void flowLeftToRight_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.FlowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
    }

    private void flowRightToLeftBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.FlowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
    }