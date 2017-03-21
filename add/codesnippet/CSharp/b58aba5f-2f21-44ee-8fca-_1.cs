    private void getcontrolFromPosBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        int i = 0;
        int j = 0;
        Trace.WriteLine(this.TableLayoutPanel1.ColumnCount);
        Trace.WriteLine(this.TableLayoutPanel1.RowCount);

        for(i=0; i<=this.TableLayoutPanel1.ColumnCount; i++)
        {
            for(j=0; j<=this.TableLayoutPanel1.RowCount; j++)
            {
                Control c = this.TableLayoutPanel1.GetControlFromPosition(i, j);

                if( c != null )
                {
                    Trace.WriteLine(c.ToString());
                }
            }
        }
    }