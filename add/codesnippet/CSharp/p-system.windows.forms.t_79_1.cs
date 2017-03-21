	//Declare a textbox called TextBox1.
	internal System.Windows.Forms.TextBox TextBox1;

	//Initialize TextBox1.
	private void InitializeTextBox()
	{
		this.TextBox1 = new TextBox();
		this.TextBox1.Location = new System.Drawing.Point(32, 24);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.Size = new System.Drawing.Size(136, 20);
		this.TextBox1.TabIndex = 1;
		this.TextBox1.Text = "Type and hit enter here...";

		//Keep the selection highlighted, even after textbox loses focus.
		TextBox1.HideSelection = false;
		this.Controls.Add(TextBox1);
	}