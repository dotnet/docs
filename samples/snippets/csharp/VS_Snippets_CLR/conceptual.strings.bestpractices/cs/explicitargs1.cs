using System;

public class Example
{
   public static void Main()
   {
      CompareWithDefaults();
      CompareExplicit();
   }
   
   private static void CompareWithDefaults()
   {
      Uri url = new Uri("http://msdn.microsoft.com");
      // <Snippet1> 
      string protocol = GetProtocol(url);       
      if (String.Equals(protocol, "http")) {
         // ...Code to handle HTTP protocol.
      }
      else {
         throw new InvalidOperationException();
      }
      // </Snippet1>
   }

   private static void CompareExplicit()
   {
      Uri url = new Uri("http://msdn.microsoft.com");
      // <Snippet2> 
      string protocol = GetProtocol(url);       
      if (String.Equals(protocol, "http", StringComparison.OrdinalIgnoreCase)) {
         // ...Code to handle HTTP protocol.
      }
      else {
         throw new InvalidOperationException();
      }
      // </Snippet2>
   }

   private static string GetProtocol(Uri url)
   {
      return url.Scheme;
   }
}
