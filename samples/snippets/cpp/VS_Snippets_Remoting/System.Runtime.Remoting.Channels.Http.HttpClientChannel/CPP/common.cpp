//<snippet30>
#using <System.dll>
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
      Console::WriteLine( L"GetCount was called." );
      callCount++;
      return (callCount);
   }

};

//</snippet30>
