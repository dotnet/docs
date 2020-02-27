
// <snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Collections;

namespace ReflectionModule_Examples
{

   // Define a very simple custom attribute

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

}


//Define a module-level attribute.

[module:ReflectionModule_Examples::MySimpleAttribute("module-level")];
int main()
{
   array<System::Reflection::Module^>^moduleArray;
   moduleArray = ReflectionModule_Examples::MySimpleAttribute::typeid->Assembly->GetModules( false );
   
   // In a simple project with only one module, the module at index
   // 0 will be the module containing these classes.
   System::Reflection::Module^ myModule = moduleArray[ 0 ];
   array<Object^>^attributes;
   
   //Get only MySimpleAttribute attributes for this module.
   attributes = myModule->GetCustomAttributes( myModule->GetType( "ReflectionModule_Examples.MySimpleAttribute", false, false ), true );
   IEnumerator^ myEnum = attributes->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ o = safe_cast<Object^>(myEnum->Current);
      Console::WriteLine( "Found this attribute on myModule: {0}", o );
   }
}

// </snippet1>
