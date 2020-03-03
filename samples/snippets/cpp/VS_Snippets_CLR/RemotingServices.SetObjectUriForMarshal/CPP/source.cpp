
// <Snippet1>
using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Security::Permissions;

public ref class SetObjectUriForMarshalTest
{
public:
   ref class TestClass: public MarshalByRefObject{};

   [SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::RemotingConfiguration)]   
   static void Main()
   {
      TestClass^ obj = gcnew TestClass;
      RemotingServices::SetObjectUriForMarshal( obj,  "testUri" );
      RemotingServices::Marshal(obj);
      Console::WriteLine( RemotingServices::GetObjectUri( obj ) );
   }

};
// </Snippet1>

int main()
{
   SetObjectUriForMarshalTest::TestClass^ testerobject = gcnew SetObjectUriForMarshalTest::TestClass;
   SetObjectUriForMarshalTest::Main();
}
