    private void growStyleNoneBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.tlpGrowStyle = TableLayoutPanelGrowStyle.FixedSize;
    }

    private void growStyleAddRowBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.tlpGrowStyle = TableLayoutPanelGrowStyle.AddRows;
    }

    private void growStyleAddColumnBtn_CheckedChanged(
		System.Object sender, 
		System.EventArgs e)
    {
        this.tlpGrowStyle = TableLayoutPanelGrowStyle.AddColumns;
    }

    private void testGrowStyleBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        this.TableLayoutPanel1.GrowStyle = this.tlpGrowStyle;

        try
        {
            this.TableLayoutPanel1.Controls.Add(new Button());
        }
        catch(ArgumentException ex)
        {
            Trace.WriteLine(ex.Message);
        }
    }