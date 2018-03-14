
// <snippet1>
using namespace System;
using namespace System::Runtime::Remoting;

public ref class Remotable: public MarshalByRefObject
{
private:
   int callCount;

public:
   Remotable()
      : callCount( 0 )
   {}

   int GetCount()
   {
      callCount++;
      return (callCount);
   }
};
// </snippet1>
