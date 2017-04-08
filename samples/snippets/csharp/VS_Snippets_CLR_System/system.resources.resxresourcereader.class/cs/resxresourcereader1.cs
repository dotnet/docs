// <Snippet1>
using System;
using System.Collections;
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
      IDictionaryEnumerator dict = rr.GetEnumerator();
      while (dict.MoveNext())
         Console.WriteLine("{0}: {1}", dict.Key, dict.Value);   
   }

   private static void CreateResourceFile()
   {
      ResXResourceWriter rw = new ResXResourceWriter(resxFilename);
      string[] resNames = {"Country", "Population", "Area", 
                           "Capital", "LCity" };
      string[] columnHeaders = { "Country Name", "Population (2010}", 
                                 "Area", "Capital", "Largest City" };
      string[] comments = { "The localized country name", "", 
                            "The area in square miles", "", 
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
//       Title: Country Information
//       nColumns: 5
//       Country: Country Name
//       Population: Population (2010}
//       Area: Area
//       Capital: Capital
//       LCity: Largest City
// </Snippet1>

