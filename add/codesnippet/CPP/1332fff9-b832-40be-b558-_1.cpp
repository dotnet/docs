using namespace System;
using namespace System::Reflection;

// Add an AssemblyDescription attribute
[assembly:AssemblyDescription("A sample description")];
namespace IsDef1CS
{
   ref class DemoClass
   {
   public:
      static void Main()
      {
         
         // Get the class type to access its metadata.
         Type^ clsType = DemoClass::typeid;
         
         // Get the assembly object.
         Assembly^ assy = clsType->Assembly;
         
         // Store the assembly's name.
         String^ assyName = assy->GetName()->Name;
         
         //Type assyType = assy.GetType();
         // See if the Assembly Description is defined.
         bool isdef = Attribute::IsDefined( assy, AssemblyDescriptionAttribute::typeid );
         if ( isdef )
         {
            
            // Affirm that the attribute is defined.
            Console::WriteLine( "The AssemblyDescription attribute "
            "is defined for assembly {0}.", assyName );
            
            // Get the description attribute itself.
            AssemblyDescriptionAttribute^ adAttr = dynamic_cast<AssemblyDescriptionAttribute^>(Attribute::GetCustomAttribute( assy, AssemblyDescriptionAttribute::typeid ));
            
            // Display the description.
            if ( adAttr != nullptr )
                        Console::WriteLine( "The description is \"{0}\".", adAttr->Description );
            else
                        Console::WriteLine( "The description could not "
            "be retrieved." );
         }
         else
                  Console::WriteLine( "The AssemblyDescription attribute is not "
         "defined for assembly {0}.", assyName );
      }

   };

}


/*
 * Output:
 * The AssemblyDescription attributeis defined for assembly IsDef1CS.
 * The description is "A sample description".
 */