    private void enumerateChildrenBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        foreach ( Control c in this.TableLayoutPanel1.Controls )
        {
            Trace.WriteLine(c.ToString());
        }
    }