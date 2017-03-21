	// This method demonstrates retrieving line numbers that 
	// indicate the location of a particular word
	// contained in a RichTextBox. The line numbers are zero-based.

	private void Button1_Click(System.Object sender, System.EventArgs e)
	{

		// Reset the results box.
		TextBox1.Text = "";

		// Get the word to search from from TextBox2.
		string searchWord = TextBox2.Text;

		int index = 0;

		//Declare an ArrayList to store line numbers.
		System.Collections.ArrayList lineList = new System.Collections.ArrayList();
		do
		{
			// Find occurrences of the search word, incrementing  
			// the start index. 
			index = RichTextBox1.Find(searchWord, index+1, RichTextBoxFinds.MatchCase);
			if (index!=-1)

				// Find the word's line number and add the line 
				// number to the arrayList. 
			{
				lineList.Add(RichTextBox1.GetLineFromCharIndex(index));
			}
		}
		while((index!=-1));

		// Iterate through the list and display the line numbers in TextBox1.
		System.Collections.IEnumerator myEnumerator = lineList.GetEnumerator();
		if (lineList.Count<=0)
        {
            TextBox1.Text = searchWord+" was not found";
        }
        else
        {
            TextBox1.SelectedText = searchWord+" was found on line(s):";
            while (myEnumerator.MoveNext())
            {
                TextBox1.SelectedText = myEnumerator.Current+" ";
            }
        }
	}