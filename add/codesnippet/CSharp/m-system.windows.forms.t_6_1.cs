    private void getColumnBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        foreach ( Control c in this.TableLayoutPanel1.Controls )
        {
            Trace.WriteLine(this.TableLayoutPanel1.GetColumn(c));
        }
    }