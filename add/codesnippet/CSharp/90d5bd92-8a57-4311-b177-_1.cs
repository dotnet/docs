		public int FindMyText(string searchText, int searchStart, int searchEnd)
		{
			// Initialize the return value to false by default.
			int returnValue = -1;

			// Ensure that a search string and a valid starting point are specified.
			if (searchText.Length > 0 && searchStart >= 0) 
			{
				// Ensure that a valid ending value is provided.
				if (searchEnd > searchStart || searchEnd == -1)
				{	
					// Obtain the location of the search string in richTextBox1.
					int indexToText = richTextBox1.Find(searchText, searchStart, searchEnd, RichTextBoxFinds.MatchCase);
					// Determine whether the text was found in richTextBox1.
					if(indexToText >= 0)
					{
						// Return the index to the specified search text.
						returnValue = indexToText;
					}
				}
			}

			return returnValue;
		}