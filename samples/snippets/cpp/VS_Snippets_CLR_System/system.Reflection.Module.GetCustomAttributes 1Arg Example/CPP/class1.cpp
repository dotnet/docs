
// <snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Collections;

namespace ReflectionModule_Examples
{

   //Define a module-level attribute.
   //A very simple custom attribute.

   [AttributeUsage(AttributeTargets::Class|AttributeTargets::Module)]
   public ref class MySimpleAttribute: public Attribute
   {
   private:
      String^ name;

   public:
      MySimpleAttribute( String^ newName )
      {
         name = newName;
      }

   };


   [module:MySimpleAttribute("module-level")];
   ref class MyMainClass{};

}

int main()
{
   array<System::Reflection::Module^>^moduleArray;
   moduleArray = ReflectionModule_Examples::MySimpleAttribute::typeid->Assembly->GetModules( false );
   
   // In a simple project with only one module, the module at index
   // 0 will be the module containing these classes.
   System::Reflection::Module^ myModule = moduleArray[ 0 ];
   array<Object^>^attributes;
   attributes = myModule->GetCustomAttributes( true );
   IEnumerator^ myEnum = attributes->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ o = safe_cast<Object^>(myEnum->Current);
      Console::WriteLine( "Found this attribute on myModule: {0}.", o );
   }
}

// </snippet1>
