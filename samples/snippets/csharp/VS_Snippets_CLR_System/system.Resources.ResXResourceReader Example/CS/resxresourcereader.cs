//<Snippet1>
using System;
using System.Resources;
using System.Collections;

class ReadResXResources
{
   public static void Main()
   {

      // Create a ResXResourceReader for the file items.resx.
      ResXResourceReader rsxr = new ResXResourceReader("items.resx");

      // Iterate through the resources and display the contents to the console.
      foreach (DictionaryEntry d in rsxr)
      {
    Console.WriteLine(d.Key.ToString() + ":\t" + d.Value.ToString());
      }

     //Close the reader.
     rsxr.Close();
   }
}
//</Snippet1>