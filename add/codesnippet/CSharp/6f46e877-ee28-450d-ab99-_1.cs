    private void toggleSpanBtn_Click(
		System.Object sender, 
		System.EventArgs e)
    {
        Control c = this.TableLayoutPanel1.GetControlFromPosition(0, 0);

        if ( c != null )
        {
            int xSpan = this.TableLayoutPanel1.GetColumnSpan(c);
            int ySpan = this.TableLayoutPanel1.GetRowSpan(c);

            if (xSpan>1)
            {
                xSpan = 1;
                ySpan = 1;
            }
            else
            {
                xSpan = 2;
                ySpan = 2;
            }

            this.TableLayoutPanel1.SetColumnSpan(c, xSpan);
            this.TableLayoutPanel1.SetRowSpan(c, ySpan);
        }
    }