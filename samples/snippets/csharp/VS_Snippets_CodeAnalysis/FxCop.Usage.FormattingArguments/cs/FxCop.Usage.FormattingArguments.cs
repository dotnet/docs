//<Snippet1>
using System;

namespace UsageLibrary
{
   class CallsStringFormat
   {
      void CallFormat()
      {
         string file = "file name";
         int errors = 13;

         // Violates the rule.
         Console.WriteLine(string.Format("{0}", file, errors));

         Console.WriteLine(string.Format("{0}: {1}", file, errors));

         // Violates the rule and generates a FormatException at runtime.
         Console.WriteLine(string.Format("{0}: {1}, {2}", file, errors));
      }
   }
}
//</Snippet1>
