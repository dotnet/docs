
// <Snippet1>
using namespace System;

// Declare MyTestClass as sealed.
ref class TestClass sealed{};

int main()
{
      TestClass^ testClassInstance = gcnew TestClass;
      
      // Get the type of testClassInstance.
      Type^ type = testClassInstance->GetType();
      
      // Get the IsSealed property of the myTestClassInstance.
      bool sealed = type->IsSealed;
      Console::WriteLine("{0} is sealed: {1}.", type->FullName, sealed);
}
// The example displays the following output:
//        TestClass is sealed: True.
// </Snippet1>
