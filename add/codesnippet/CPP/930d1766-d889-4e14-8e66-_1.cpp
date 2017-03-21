using namespace System;
using namespace System::Reflection;
using namespace System::ComponentModel;

// Assign some attributes to the module.
// Set the module's CLSCompliant attribute to false
// The CLSCompliant attribute is applicable for /target:module.
[module:Description("A sample description")];
[module:CLSCompliant(false)];
namespace CustAttrs2CS
{
   ref class DemoClass
   {
   public:
      static void Main()
      {
         Type^ clsType = DemoClass::typeid;

         // Get the Module type to access its metadata.
         Module^ module = clsType->Module;

         // Iterate through all the attributes for the module.
         System::Collections::IEnumerator^ myEnum1 = Attribute::GetCustomAttributes( module )->GetEnumerator();
         while ( myEnum1->MoveNext() )
         {
            Attribute^ attr = safe_cast<Attribute^>(myEnum1->Current);

            // Check for the Description attribute.
            if ( attr->GetType() == DescriptionAttribute::typeid )
                        Console::WriteLine( "Module {0} has the description \"{1}\".", module->Name, (dynamic_cast<DescriptionAttribute^>(attr))->Description );
            // Check for the CLSCompliant attribute.
            else

            // Check for the CLSCompliant attribute.
            if ( attr->GetType() == CLSCompliantAttribute::typeid )
                        Console::WriteLine( "Module {0} {1} CLSCompliant.", module->Name, (dynamic_cast<CLSCompliantAttribute^>(attr))->IsCompliant ? (String^)"is" : "is not" );
         }
      }
   };
}


/*
 * Output:
 * Module CustAttrs2CS.exe is not CLSCompliant.
 * Module CustAttrs2CS.exe has the description "A sample description".
 */