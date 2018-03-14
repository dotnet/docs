//<Snippet1>
using System;

namespace DesignLibrary
{
   public class History
   {
      public void AddToHistory(string uriString)
      {
          Uri newUri = new Uri(uriString);
          AddToHistory(newUri);
      }

      public void AddToHistory(Uri uriType) { }
   }
}
//</Snippet1>
