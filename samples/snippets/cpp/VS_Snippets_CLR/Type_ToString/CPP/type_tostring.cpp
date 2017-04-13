
// <Snippet1>
using namespace System;

namespace MyNamespace
{
   ref class MyClass
   {
   };
}

void main()
{
      Type^ myType = MyNamespace::MyClass::typeid;
      Console::WriteLine("Displaying information about {0}:", myType );
      
      // Get the namespace of the class MyClass.
      Console::WriteLine("   Namespace: {0}", myType->Namespace );
      
      // Get the name of the module.
      Console::WriteLine("   Module: {0}", myType->Module );
      
      // Get the fully qualified common language runtime namespace.
      Console::WriteLine("   Fully qualified type: {0}", myType );
}
// The example displays the following output:
//    Displaying information about MyNamespace.MyClass:
//       Namespace: MyNamespace
//       Module: type_tostring.exe
//       Fully qualified name: MyNamespace.MyClass
// </Snippet1>
