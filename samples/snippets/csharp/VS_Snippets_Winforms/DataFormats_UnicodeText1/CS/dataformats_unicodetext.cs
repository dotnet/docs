// System.Windows.Forms.DataFormats.UnicodeText;System.Windows.Forms.Text;

/*
 *  The following example demonstrates the 'UnicodeText' and 'Text' field of 'DataFormats' class. 
 *  It stores a String object in Clipboard using the Clipboard's 'SetDataObject' method.
 *  It retrieves the String object stored in the Clipboard by using the GetDataObject method
 *  which returns the 'IDataObject'.  It checks whether the Unicodetext data is present 
 *  or not by using the 'GetDataPresent' method of 'IDataObject'. If data is there then it
 *  displays the data to the console. It also checks 'Text' format data is present or not. If
 *  the data is there it displays the data to the console.
 *    
 */

using System;
using System.Drawing.Imaging;
using System.Windows.Forms;

public class DataFormats_UnicodeText
{
   public static void Main(string[] args)
   {
// <Snippet1>
// <Snippet2>
		try
		{

			String myString = "This is a String from the ClipBoard";
      
			// Sets the data into the Clipboard.
			Clipboard.SetDataObject(myString);
			IDataObject myDataObject = Clipboard.GetDataObject();
			// Checks whether the format of the data is 'UnicodeText' or not.
			if(myDataObject.GetDataPresent(DataFormats.UnicodeText)) 
			{
				Console.WriteLine("Data in 'UnicodeText' format:"+myDataObject.GetData(DataFormats.UnicodeText));
			} 
			else 
			{
				Console.WriteLine("No String information was contained in the clipboard.");
			}

			// Checks whether the format of the data is 'Text' or not.
			if(myDataObject.GetDataPresent(DataFormats.Text)) 
			{
				String clipString = (String)myDataObject.GetData(DataFormats.StringFormat);
				Console.WriteLine("Data in 'Text' format:"+clipString);
			}
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}

      
// </Snippet2>
// </Snippet1>
   }    
}
