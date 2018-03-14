
// <Snippet1>
using namespace System;

// Declare MyTestClass as public.
public ref class TestClass{};

int main()
{
   TestClass^ testClassInstance = gcnew TestClass;
   
   // Get the type of myTestClassInstance.
   Type^ testType = testClassInstance->GetType();
   
   // Get the IsPublic property of the myTestClassInstance.
   bool isPublic = testType->IsPublic;
   Console::WriteLine( "Is {0} public? {1}", testType->FullName, isPublic);
}

// </Snippet1>
