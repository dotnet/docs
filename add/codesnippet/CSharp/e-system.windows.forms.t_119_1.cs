
	//Declare a new TrackBar object.
	internal System.Windows.Forms.TrackBar TrackBar1;

	// Initalize the TrackBar and add it to the form.
	private void InitializeTrackBar()
	{
		this.TrackBar1 = new System.Windows.Forms.TrackBar();
		TrackBar1.Location = new System.Drawing.Point(75, 30);

		// Set the TickStyle property so there are ticks on both sides
		// of the TrackBar.
		TrackBar1.TickStyle = TickStyle.Both;

		// Set the minimum and maximum number of ticks.
		TrackBar1.Minimum = 10;
		TrackBar1.Maximum = 100;

		// Set the tick frequency to one tick every ten units.
		TrackBar1.TickFrequency = 10;

		// Associate the event-handling method with the 
		// ValueChanged event.
		TrackBar1.ValueChanged += 
			new System.EventHandler(TrackBar1_ValueChanged);
		this.Controls.Add(this.TrackBar1);
	}
	

	// Handle the TrackBar.ValueChanged event by calculating a value for
	// TextBox1 based on the TrackBar value.  
	private void TrackBar1_ValueChanged(object sender, System.EventArgs e)
	{
		TextBox1.Text = (System.Math.Round(TrackBar1.Value/10.0)).ToString();
	}