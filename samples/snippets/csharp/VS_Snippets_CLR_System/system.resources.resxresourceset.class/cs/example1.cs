// <Snippet1>
using System;
using System.Collections;
using System.Drawing;
using System.Resources;

public class Example
{
   public static void Main()
   {
      CreateResXFile();
      
      ResXResourceSet resSet = new ResXResourceSet(@".\StoreResources.resx");
      IDictionaryEnumerator dict = resSet.GetEnumerator();
      while (dict.MoveNext()) {
         string key = (string) dict.Key;
         // Retrieve resource by name.
         if (dict.Value is string)
            Console.WriteLine("{0}: {1}", key, resSet.GetString(key));
         else
            Console.WriteLine("{0}: {1}", key, resSet.GetObject(key));   
      }
   }

   private static void CreateResXFile()
   {
      Bitmap logo = new Bitmap(@".\Logo.bmp");
      ResXDataNode node;
      
      ResXResourceWriter rw = new ResXResourceWriter(@".\StoreResources.resx");
      node = new ResXDataNode("Logo", logo);
      node.Comment = "The corporate logo.";
      rw.AddResource(node); 
      rw.AddResource("AppTitle", "Store Locations");
      node = new ResXDataNode("nColumns", 5);
      node.Comment = "The number of columns in the Store Location table";
      rw.AddResource(node);
      rw.AddResource("City", "City");
      rw.AddResource("State", "State");
      rw.AddResource("Code", "Zip Code");
      rw.AddResource("Telephone", "Phone");
      rw.Generate();
      rw.Close();
   }
}
// The example displays the following output:
//       Telephone: Phone
//       Code: Zip Code
//       State: State
//       City: City
//       nColumns: 5
//       AppTitle: Store Locations
//       Logo: System.Drawing.Bitmap
// </Snippet1>