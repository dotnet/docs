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