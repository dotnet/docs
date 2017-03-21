	// Uses the SelectedIndices property to retrieve and tally the  
	// price of the selected menu items.
	private void ListView1_SelectedIndexChanged_UsingIndices(
		object sender, System.EventArgs e)
	{

		ListView.SelectedIndexCollection indexes = 
			this.ListView1.SelectedIndices;
		
		double price = 0.0;
		foreach ( int index in indexes )
		{
			price += Double.Parse(
				this.ListView1.Items[index].SubItems[1].Text);
		}

		// Output the price to TextBox1.
		TextBox1.Text =  price.ToString();
	}