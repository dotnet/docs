
//<snippet30>
using namespace System;

// Remote object.
public ref class RemoteObject: public MarshalByRefObject
{
private:
   static int callCount = 0;

public:
   int GetCount()
   {
      Console::WriteLine( L"GetCount has been called." );
      callCount++;
      return (callCount);
   }

};

//</snippet30>
