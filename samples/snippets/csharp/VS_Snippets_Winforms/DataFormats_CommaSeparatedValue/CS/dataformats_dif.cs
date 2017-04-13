// System.Windows.Forms.DataFormats.Dif

/*
 The following example demonstrates the 'Dif' field of 'DataFormats' class. 
 It  creates a 'FileStream' object of the Temp.dif file.
 It stores the object in the form of the 'Dif'
 format in the 'DataObject'. Then it checks whether the data 
 stored in 'Dif' format is present or not.
 */

using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

public class DataFormats_Dif
{
   public static void Main()
   {
      try
      {
// <Snippet1>
            FileStream myFileStream = File.Open("Temp.dif",FileMode.Open);
            // Store the data into Dif format.
            DataObject myDataObject = new DataObject();
            myDataObject.SetData(DataFormats.Dif,myFileStream);

           // Check whether the data is stored or not in the specified format.
           bool formatPresent = myDataObject.GetDataPresent(DataFormats.Dif);
            if(formatPresent) 
            {
               Console.WriteLine("The data has been stored in the Dif format is:'"+formatPresent+"'");
            } 
            else 
            {
               Console.WriteLine("The data has not been stored in the specified format");
            }
// </Snippet1>
      }
      catch(Exception e)
      {
         Console.WriteLine("The Exception is:"+e.Message);
      }
   }
}