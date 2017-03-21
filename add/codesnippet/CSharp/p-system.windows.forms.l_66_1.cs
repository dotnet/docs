		private void CreateTabStopList()
		{
			ListBox listBox1 = new ListBox();
			listBox1.SetBounds(20,20,100,100);

			for(int x = 1; x < 20;x++)
			{
				listBox1.Items.Add("Item\t" + x.ToString());
			}
			// Make the ListBox display tabs within each item.
			listBox1.UseTabStops = true;
			this.Controls.Add(listBox1);
		}