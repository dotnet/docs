		private void button1_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(FindMyText(new char[]{'B','r','a','v','o'}, 5).ToString());
		}

		public int FindMyText(char[] text, int start)
		{
			// Initialize the return value to false by default.
			int returnValue = -1;

			// Ensure that a valid char array has been specified and a valid start point.
			if (text.Length > 0 && start >= 0) 
			{
				// Obtain the location of the first character found in the control
				// that matches any of the characters in the char array.
				int indexToText = richTextBox1.Find(text, start);
				// Determine whether any of the chars are found in richTextBox1.
				if(indexToText >= 0)
				{
					// Return the location of the character.
					returnValue = indexToText;
				}
			}

			return returnValue;
		}