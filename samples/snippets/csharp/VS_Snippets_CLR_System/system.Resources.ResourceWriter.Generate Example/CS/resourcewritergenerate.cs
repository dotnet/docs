// <snippet1>
using System;
using System.Resources;
using System.IO;
public class WriteResources 
{
   public static void Main(string[] args) 
   {  
       // Create a file stream to encapsulate items.resources.
       FileStream fs = new FileStream("items.resources", 
          FileMode.OpenOrCreate,FileAccess.Write);

       // Open a resource writer to write from the stream.
       IResourceWriter writer = new ResourceWriter(fs);
    
       // Add resources to the resource writer.
       writer.AddResource("String 1", "First String");
       writer.AddResource("String 2", "Second String");
       writer.AddResource("String 3", "Third String");

       // Generate the resources, and close the writer.
       writer.Generate();
       writer.Close();
    }
}
// </snippet1>