//<Snippet1>
#using <system.dll>
using namespace System;

namespace DesignLibrary
{
   ref class History
   {
   public:
      void AddToHistory(String^ uriString) {}
      void AddToHistory(Uri^ uriType) {}
   };

   public ref class Browser
   {
      History^ uriHistory;

   public:
      Browser()
      {
         uriHistory = gcnew History();
      }
      
      void ErrorProne()
      {
         uriHistory->AddToHistory("http://www.adventure-works.com");
      }

      void SaferWay()
      {
         try
         {
            Uri^ newUri = gcnew Uri("http://www.adventure-works.com");
            uriHistory->AddToHistory(newUri);
         }
         catch(UriFormatException^ uriException) {}
      }
   };
}
//</Snippet1>
