	static int x = 200;
	static int y = 200;

	private void Button1_Click(System.Object sender, 
		System.EventArgs e)
	{
		// Create a new Form1 and set its Visible property to true.
		Form1 form2 = new Form1();
		form2.Visible = true;

		// Set the new form's desktop location so it  
		// appears below and to the right of the current form.
		form2.SetDesktopLocation(x, y);
		x += 30;
		y += 30;

		// Keep the current form active by calling the Activate
		// method.
		this.Activate();
		this.Button1.Enabled = false;
	}
	


	// Updates the label text to reflect the current values of x 
	// and y, which was were incremented in the Button1 control's 
	// click event.
	private void Form1_Activated(object sender, System.EventArgs e)
	{
		Label1.Text = "x: "+x+" y: "+y;
		Label2.Text = "Number of forms currently open: "+count;
	}

	static int count = 0;

	private void Form1_Closed(object sender, System.EventArgs e)
	{
		count -= 1;
	}

	private void Form1_Load(object sender, System.EventArgs e)
	{
		count += 1;
	}