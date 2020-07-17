//<snippet40>
using namespace System;
using namespace System::Runtime::Remoting;

// Remote object.
public ref class RemoteObject: public MarshalByRefObject
{
private:
   static int callCount = 0;

public:
   int GetCount()
   {
      callCount++;
      return (callCount);
   }

};
//</snippet40>
