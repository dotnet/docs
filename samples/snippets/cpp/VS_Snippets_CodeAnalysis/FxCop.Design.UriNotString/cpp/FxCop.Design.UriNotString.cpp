//<Snippet1>
#using <system.dll>
using namespace System;

namespace DesignLibrary
{
   public ref class ErrorProne
   {
   public:
      // Violates rule UriPropertiesShouldNotBeStrings.
      property String^ SomeUri;

      // Violates rule UriParametersShouldNotBeStrings.
      void AddToHistory(String^ uriString) { }

      // Violates rule UriReturnValuesShouldNotBeStrings.
      String^ GetRefererUri(String^ httpHeader)
      {
         return "http://www.adventure-works.com";
      }
   };

   public ref class SaferWay
   {
   public:
      // To retrieve a string, call SomeUri()->ToString().
      // To set using a string, call SomeUri(gcnew Uri(string)).
      property Uri^ SomeUri;

      void AddToHistory(String^ uriString)
      {
         // Check for UriFormatException.
         AddToHistory(gcnew Uri(uriString));
      }

      void AddToHistory(Uri^ uriType) { }

      Uri^ GetRefererUri(String^ httpHeader)
      {
         return gcnew Uri("http://www.adventure-works.com");
      }
   };
}
//</Snippet1>
