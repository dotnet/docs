//<snippet1>
using System;
using System.Resources;
using System.Collections;

class EnumerateResources 
{
    public static void Main() 
    {
        // Create a ResourceReader for the file items.resources.
        ResourceReader rr = new ResourceReader("items.resources"); 

        
        // Create an IDictionaryEnumerator to iterate through the resources.
        IDictionaryEnumerator id = rr.GetEnumerator(); 

        // Iterate through the resources and display the contents to the console. 
        while(id.MoveNext())
          Console.WriteLine("\n[{0}] \t{1}", id.Key, id.Value); 

        rr.Close();     
 
    }
}
//</snippet1>