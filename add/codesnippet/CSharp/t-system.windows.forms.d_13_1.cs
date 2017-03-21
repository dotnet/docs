	// Declare the MainMenu control.
	internal System.Windows.Forms.MainMenu MainMenu1;

	// Declare MenuItem2 as With-Events because it will be user drawn.
	internal System.Windows.Forms.MenuItem MenuItem2;


	private void InitializeMenu()
	{

		// Create MenuItem1, which will be drawn by the operating system.
		MenuItem MenuItem1 = new MenuItem("Regular Menu Item");

		// Create MenuItem2.
		MenuItem2 = new MenuItem("Custom Menu Item");

		// Set OwnerDraw property to true. This requires handling the
		// DrawItem event for this menu item.
		MenuItem2.OwnerDraw = true;

		//Add the event-handler delegate to handle the DrawItem event.
        MenuItem2.DrawItem += new DrawItemEventHandler(DrawCustomMenuItem);
		
      // Add the items to the menu.
		MainMenu1 = new MainMenu(new MenuItem[]{MenuItem1, MenuItem2});																													  

		// Add the menu to the form.
		this.Menu = this.MainMenu1;
	}

	// Draw the custom menu item.
	private void DrawCustomMenuItem(object sender, 
		DrawItemEventArgs e)
	{

		// Cast the sender to MenuItem so you can access text property.
		MenuItem customItem = (MenuItem) sender;

		// Create a Brush and a Font to draw the MenuItem.
		System.Drawing.Brush aBrush = System.Drawing.Brushes.DarkMagenta;
		Font aFont = new Font("Garamond", 10, 
			FontStyle.Italic, GraphicsUnit.Point);

		// Get the size of the text to use later to draw an ellipse
		// around the item.
		SizeF stringSize = e.Graphics.MeasureString(
			customItem.Text, aFont);

		// Draw the item and then draw the ellipse.
		e.Graphics.DrawString(customItem.Text, aFont, 
			aBrush, e.Bounds.X, e.Bounds.Y);
		e.Graphics.DrawEllipse(new Pen(System.Drawing.Color.Black, 2),
			new Rectangle(e.Bounds.X, e.Bounds.Y, 
			(System.Int32)stringSize.Width,
			(System.Int32)stringSize.Height));
	}