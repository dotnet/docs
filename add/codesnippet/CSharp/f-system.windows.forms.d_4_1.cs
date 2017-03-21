		try
		{
			String myString = "This is a String from the ClipBoard";
			// Sets the data to the Clipboard.   
			Clipboard.SetDataObject(myString);
			IDataObject myDataObject = Clipboard.GetDataObject();

			// Checks whether the data is present or not in the Clipboard.
			if(myDataObject.GetDataPresent(DataFormats.StringFormat)) 
			{
				String clipString = (String)myDataObject.GetData(DataFormats.StringFormat);
				Console.WriteLine(clipString);
			} 
			else 
			{
				Console.WriteLine("No String information was contained in the clipboard.");
			}
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
