

#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::IO;
using namespace System::Collections;
using namespace System::Runtime::Remoting;

namespace SampleNamespace
{
   public ref class SampleWellKnown: public MarshalByRefObject
   {
   public:
      int State;
      int Add( int a, int b )
      {
         Console::WriteLine( "Add method called" );
         return a + b;
      }
   };
}
