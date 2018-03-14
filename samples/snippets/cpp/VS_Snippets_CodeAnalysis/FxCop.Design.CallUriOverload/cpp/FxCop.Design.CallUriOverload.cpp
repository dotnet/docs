//<Snippet1>
#using <system.dll>
using namespace System;

namespace DesignLibrary
{
   public ref class History
   {
   public:
      void AddToHistory(String^ uriString)
      {
          Uri^ newUri = gcnew Uri(uriString);
          AddToHistory(newUri);
      }

      void AddToHistory(Uri^ uriType) { }
   };
}
//</Snippet1>
