		// The event handler on Form2.
		private void button1_Click(object sender, System.EventArgs e)
		{
			// Get the Name property of the Parent.
			string s = ParentForm.Name;
			// Display the name in a message box.
			MessageBox.Show("My Parent is " + s + ".");
		}