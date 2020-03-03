
//<Snippet1>
// To run this sample you must create a strong-name key named snkey.snk 
// using the Strong Name tool (sn.exe).  Both the library assembly and the 
// application assembly that calls it must be signed with that key.  
// To run successfully, the application assembly must be in the global 
// assembly cache.
// This console application can be created using the following code.

//#using <mscorlib.dll>
//#using <ClassLibrary1.dll>
//using namespace System;
//using namespace System::Security;
//using namespace System::Reflection;
//using namespace ClassLibrary1;
//[assembly: AssemblyVersion(S"1.0.555.0")]
//[assembly: AssemblyKeyFile(S"snKey.snk")];
//int main()
//{ 
//    try
//    {
//        Class1* myLib = new Class1();
//        myLib->DoNothing();
//
//        Console::WriteLine(S"Exiting the sample.");
//    }
//    catch (Exception* e)
//    {
//        Console::WriteLine(e->Message);
//    }
//}
using namespace System;
using namespace System::Security::Permissions;

namespace ClassLibrary1
{
   //<Snippet2>
   // Demand that the calling program be in the global assembly cache.
   [GacIdentityPermissionAttribute(SecurityAction::Demand)]
   public ref class Class1
   //</Snippet2>
   {
   public:
      void DoNothing()
      {
         Console::WriteLine( "Exiting the library program." );
      }
   };
}

//</Snippet1>
