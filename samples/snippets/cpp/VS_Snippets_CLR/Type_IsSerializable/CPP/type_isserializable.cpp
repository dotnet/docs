
// <Snippet1>
using namespace System;
public ref class MyClass
{
public:

   // Declare a public class with the [Serializable] attribute.

   [Serializable]
   ref class MyTestClass{};


};

int main()
{
   try
   {
      bool myBool = false;
      MyClass::MyTestClass^ myTestClassInstance = gcnew MyClass::MyTestClass;
      
      // Get the type of myTestClassInstance.
      Type^ myType = myTestClassInstance->GetType();
      
      // Get the IsSerializable property of myTestClassInstance.
      myBool = myType->IsSerializable;
      Console::WriteLine( "\nIs {0} serializable? {1}.", myType->FullName, myBool );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nAn exception occurred: {0}", e->Message );
   }

}

// </Snippet1>
