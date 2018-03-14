// System.Windows.Forms.DataFormats.GetFormat(Int32)

/*
The following example demonstrates the 'GetFormat(int)' method of 'DataFormats'
class. It creates a 'DataFormats' object using a integer into the 'GetFormat' method.
By using the 'DatFormats' object it displays the format name with respective the id.
*/
// <Snippet1>
using System;
using System.Windows.Forms;

   public class DataFormat_GetFormat
   {
      static void Main()
      {

         // Create a DataFormats.Format for the Unicode data format.
         DataFormats.Format myFormat = DataFormats.GetFormat(13);

         // Display the contents of myFormat.
         Console.WriteLine("The Format Name corresponding to the ID "+myFormat.Id+" is :");
         Console.WriteLine(myFormat.Name);

         

      }
   }
// </Snippet1>