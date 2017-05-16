
//<snippet1>
using namespace System;
using namespace System::Reflection;

namespace ReflectionModule_Examples
{

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

}


//Define a module-level attribute.

[module:ReflectionModule_Examples::MySimpleAttribute("module-level")];
int main()
{
   array<System::Reflection::Module^>^moduleArray;
   moduleArray = ReflectionModule_Examples::MySimpleAttribute::typeid->Assembly->GetModules( false );
   
   //In a simple project with only one module, the module at index
   // 0 will be the module containing these classes.
   System::Reflection::Module^ myModule = moduleArray[ 0 ];
   Type^ myType;
   myType = myModule->GetType( "ReflectionModule_Examples.MySimpleAttribute" );
   Console::WriteLine( "IsDefined(MySimpleAttribute) = {0}", myModule->IsDefined( myType, false ) );
}

//</snippet1>
