// System.Windows.Forms.DataFormats.StringFormat

/*
 *  The following example demonstrates the 'StringFormat' field of 'DataFormats' class. 
 *  It stores a String object in Clipboard using the Clipboard's 'SetDataObject' method.
 *  It retrieves the String object stored in the Clipboard by using the GetDataObject method
 *  which returns the 'IDataObject'. It checks the string data is available or not 
 *  by using the 'GetDataPresent' method of 'IDataObject'. If data is there then it
 *  displays the data to the console.   
 */

using System;
using System.Drawing.Imaging;
using System.Windows.Forms;

public class DataFormats_StringFormat
{
   public static void Main(string[] args)
   {
// <Snippet1>
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

// </Snippet1>
   }    
}
