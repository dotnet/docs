using namespace System;
using namespace System::Diagnostics;

// Add the Debuggable attribute to the module.
[module:Debuggable(true,false)];
namespace IsDef2CS
{
   ref class DemoClass
   {
   public:
      static void Main()
      {
         
         // Get the class type to access its metadata.
         Type^ clsType = DemoClass::typeid;
         
         // See if the Debuggable attribute is defined for this module.
         bool isDef = Attribute::IsDefined( clsType->Module, DebuggableAttribute::typeid );
         
         // Display the result.
         Console::WriteLine( "The Debuggable attribute {0} "
         "defined for Module {1}.", isDef ? (String^)"is" : "is not", clsType->Module->Name );
         
         // If the attribute is defined, display the JIT settings.
         if ( isDef )
         {
            
            // Retrieve the attribute itself.
            DebuggableAttribute^ dbgAttr = dynamic_cast<DebuggableAttribute^>(Attribute::GetCustomAttribute( clsType->Module, DebuggableAttribute::typeid ));
            if ( dbgAttr != nullptr )
            {
               Console::WriteLine( "JITTrackingEnabled is {0}.", dbgAttr->IsJITTrackingEnabled );
               Console::WriteLine( "JITOptimizerDisabled is {0}.", dbgAttr->IsJITOptimizerDisabled );
            }
            else
                        Console::WriteLine( "The Debuggable attribute "
            "could not be retrieved." );
         }
      }

   };

}


/*
 * Output:
 * The Debuggable attribute is defined for Module IsDef2CS.exe.
 * JITTrackingEnabled is True.
 * JITOptimizerDisabled is False.
 */