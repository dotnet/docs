    private void swapRowsBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {

        Control c1 = this.TableLayoutPanel1.GetControlFromPosition(0, 0);
        Control c2 = this.TableLayoutPanel1.GetControlFromPosition(1, 0);

        if ( c1 !=null && c2 != null )
        {
            this.TableLayoutPanel1.SetRow(c2, 0);
            this.TableLayoutPanel1.SetRow(c1, 1);
        }
    }