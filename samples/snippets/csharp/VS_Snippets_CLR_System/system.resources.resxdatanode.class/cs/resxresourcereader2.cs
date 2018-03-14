// <Snippet1>
using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Resources;

public class Example
{
   private const string resxFilename = @".\CountryHeaders.resx";
    
   public static void Main()
   {
      // Create a resource file to read.
      CreateResourceFile();
      
      // Enumerate the resources in the file.
      ResXResourceReader rr = new ResXResourceReader(resxFilename);
      rr.UseResXDataNodes = true;
      IDictionaryEnumerator dict = rr.GetEnumerator();
      while (dict.MoveNext()) {
         ResXDataNode node = (ResXDataNode) dict.Value;
         Console.WriteLine("{0,-20} {1,-20} {2}", 
                           node.Name + ":", 
                           node.GetValue((ITypeResolutionService) null), 
                           ! String.IsNullOrEmpty(node.Comment) ? "// " + node.Comment : "");
      }
   }

   private static void CreateResourceFile()
   {
      ResXResourceWriter rw = new ResXResourceWriter(resxFilename);
      string[] resNames = {"Country", "Population", "Area", 
                           "Capital", "LCity" };
      string[] columnHeaders = { "Country Name", "Population (2010}", 
                                 "Area", "Capital", "Largest City" };
      string[] comments = { "The localized country name", "Estimated population, 2010", 
                            "The area in square miles", "Capital city or chief administrative center", 
                            "The largest city based on 2010 data" };
      rw.AddResource("Title", "Country Information");
      rw.AddResource("nColumns", resNames.Length);
      for (int ctr = 0; ctr < resNames.Length; ctr++) {
         ResXDataNode node = new ResXDataNode(resNames[ctr], columnHeaders[ctr]);
         node.Comment = comments[ctr];
         rw.AddResource(node);
      }
      rw.Generate();
      rw.Close();
   }
}
// The example displays the following output:
//    Title:               Country Information
//    nColumns:            5
//    Country:             Country Name         // The localized country name
//    Population:          Population (2010}    // Estimated population, 2010
//    Area:                Area                 // The area in square miles
//    Capital:             Capital              // Capital city or chief administrative center
//    LCity:               Largest City         // The largest city based on 2010 data
// </Snippet1>

