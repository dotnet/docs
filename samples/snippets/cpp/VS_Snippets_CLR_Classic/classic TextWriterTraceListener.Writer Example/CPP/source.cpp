#using <System.dll>
using namespace System;
using namespace System::Diagnostics;

public ref class Sample
{
protected:
   void Method()
   {
      // <Snippet1>
      #if defined(TRACE)
      TextWriterTraceListener^ myWriter = gcnew TextWriterTraceListener;
      myWriter->Writer = System::Console::Out;
      Trace::Listeners->Add( myWriter );
      #endif
      // </Snippet1>
   }
};
