
using namespace System;
using namespace System::Runtime::Remoting;

// Remote object.
public ref class RemoteObject: public MarshalByRefObject
{
private:
   int callCount;

public:
   RemoteObject()
      : callCount( 0 )
   {}

   int GetCount()
   {
      callCount++;
      return (callCount);
   }

};


