//<Snippet1>
using namespace System;

namespace DesignLibrary
{
   public enum class TraceLevel
   {
      Off     = 0,
      Error   = 1,
      Warning = 2,
      Info    = 3,
      Verbose = 4
   };

   [Flags]
   public enum class TraceOptions
   {
      None         =    0,
      CallStack    = 0x01,
      LogicalStack = 0x02,
      DateTime     = 0x04,
      Timestamp    = 0x08
   };

   [Flags]
   public enum class BadTraceOptions
   {
      CallStack    =    0,
      LogicalStack = 0x01,
      DateTime     = 0x02,
      Timestamp    = 0x04
   };
}

using namespace DesignLibrary;

void main()
{
   // Set the flags.
   BadTraceOptions badOptions = safe_cast<BadTraceOptions> 
      (BadTraceOptions::LogicalStack | BadTraceOptions::Timestamp);

   // Check whether CallStack is set.
   if((badOptions & BadTraceOptions::CallStack) == 
         BadTraceOptions::CallStack)
   {
      // This 'if' statement is always true.
   }
}
//</Snippet1>