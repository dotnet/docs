    private void swapControlsBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        Control c1 = this.TableLayoutPanel1.GetControlFromPosition(0, 0);
        Control c2 = this.TableLayoutPanel1.GetControlFromPosition(0, 1);

        if( c1 != null && c2 != null )
        {
            this.TableLayoutPanel1.SetColumn(c2, 0);
            this.TableLayoutPanel1.SetColumn(c1, 1);
        }
    }