
// <Snippet1>
using namespace System;
using namespace System::Reflection;
ref class MyClass
{
public:
   void HelloWorld()
   {
      Console::WriteLine( "Hello World" );
   }

};

int main()
{
   try
   {
      Binder^ defaultBinder = Type::DefaultBinder;
      MyClass^ myClass = gcnew MyClass;
      
      // Invoke the HelloWorld method of MyClass.
      myClass->GetType()->InvokeMember( "HelloWorld", BindingFlags::InvokeMethod, defaultBinder, myClass, nullptr );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
   }

}

// </Snippet1>
