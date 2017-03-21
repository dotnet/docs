	private StatusBar StatusBar1;

	private void InitializeStatusBarPanels()
	{
		StatusBar1 = new StatusBar();

		// Create two StatusBarPanel objects.
		StatusBarPanel panel1 = new StatusBarPanel();
		StatusBarPanel panel2 = new StatusBarPanel();

		// Set the style of the panels.  
		// panel1 will be owner-drawn.
		panel1.Style = StatusBarPanelStyle.OwnerDraw;

		// The panel2 object will be drawn by the operating system.
		panel2.Style = StatusBarPanelStyle.Text;

		// Set the text of both panels to the same date string.
		panel1.Text = System.DateTime.Today.ToShortDateString();
		panel2.Text = System.DateTime.Today.ToShortDateString();

		// Add both panels to the StatusBar.
		StatusBar1.Panels.Add(panel1);
		StatusBar1.Panels.Add(panel2);

		// Make panels visible by setting the ShowPanels 
		// property to True.
		StatusBar1.ShowPanels = true;

		// Associate the event-handling method with the DrawItem event 
		// for the owner-drawn panel.
		StatusBar1.DrawItem += 
			new StatusBarDrawItemEventHandler(DrawCustomStatusBarPanel);
            
		this.Controls.Add(StatusBar1);
	}

	// Draw the panel.
	private void DrawCustomStatusBarPanel(object sender, 
		StatusBarDrawItemEventArgs e)
	{

		// Draw a blue background in the owner-drawn panel.
		e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);

		// Create a StringFormat object to align text in the panel.
		StringFormat textFormat = new StringFormat();

		// Center the text in the middle of the line.
		textFormat.LineAlignment = StringAlignment.Center;

		// Align the text to the left.
		textFormat.Alignment = StringAlignment.Far;

		// Draw the panel's text in dark blue using the Panel 
		// and Bounds properties of the StatusBarEventArgs object 
		// and the StringFormat object.
		e.Graphics.DrawString(e.Panel.Text, StatusBar1.Font, 
			Brushes.DarkBlue, new RectangleF(e.Bounds.X, 
			e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), textFormat);

	}