using System;
using System.Resources;

public class Example
{
   public static void Main()
   {
      // <Snippet2>
      ResourceManager rm = new ResourceManager(typeof(Resource1));
      // </Snippet2>
   }
}

internal class Resource1
{ }