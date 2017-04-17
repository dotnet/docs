// <Snippet2>
using System;
using System.IO;

public class Example
{
   public static void Main()
   {
      Type t = typeof(Stream);
      Type genericT = typeof(GenericWithConstraint<>);
      Type genericParam = genericT.GetGenericArguments()[0];
      Console.WriteLine(t.IsAssignableFrom(genericParam));  
      // Displays True.
   }
}

public class GenericWithConstraint<T> where T : Stream
{}
// </Snippet2>
