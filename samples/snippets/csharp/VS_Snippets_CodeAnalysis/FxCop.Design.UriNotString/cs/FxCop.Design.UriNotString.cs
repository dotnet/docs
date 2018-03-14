//<Snippet1>
using System;

namespace DesignLibrary
{
   public class ErrorProne
   {
      string someUri;

      // Violates rule UriPropertiesShouldNotBeStrings.
      public string SomeUri
      {
         get { return someUri; }
         set { someUri = value; }
      }

      // Violates rule UriParametersShouldNotBeStrings.
      public void AddToHistory(string uriString) { }

      // Violates rule UriReturnValuesShouldNotBeStrings.
      public string GetRefererUri(string httpHeader)
      {
         return "http://www.adventure-works.com";
      }
   }

   public class SaferWay
   {
      Uri someUri;

      // To retrieve a string, call SomeUri.ToString().
      // To set using a string, call SomeUri = new Uri(string).
      public Uri SomeUri
      {
         get { return someUri; }
         set { someUri = value; }
      }

      public void AddToHistory(string uriString)
      {
         // Check for UriFormatException.
         AddToHistory(new Uri(uriString));
      }

      public void AddToHistory(Uri uriType) { }

      public Uri GetRefererUri(string httpHeader)
      {
         return new Uri("http://www.adventure-works.com");
      }
   }
}
//</Snippet1>
