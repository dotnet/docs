// <Snippet1>
using System;
using System.Resources;


public class WriteResources {
   public static void Main(string[] args) {
      
      // Creates a resource writer.
      IResourceWriter writer = new ResourceWriter("myResources.resources");
    
      // Adds resources to the resource writer.
      writer.AddResource("String 1", "First String");

      writer.AddResource("String 2", "Second String");

      writer.AddResource("String 3", "Third String");

      // Writes the resources to the file or stream, and closes it.
      writer.Close();
   }
}
// </Snippet1>

