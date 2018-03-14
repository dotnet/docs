
//<Snippet1>
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
//</Snippet1>
//<Snippet2>
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
//</Snippet2>
//<Snippet3>
using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::InteropServices;

namespace IsDef3CS
{

   // Assign a Guid attribute to a class.

   [Guid("BF235B41-52D1-46cc-9C55-046793DB363F")]
   public ref class TestClass{};

   ref class DemoClass
   {
   public:
      static void Main()
      {
         
         // Get the class type to access its metadata.
         Type^ clsType = TestClass::typeid;
         
         // See if the Guid attribute is defined for the class.
         bool isDef = Attribute::IsDefined( clsType, GuidAttribute::typeid );
         
         // Display the result.
         Console::WriteLine( "The Guid attribute {0} defined for class {1}.", isDef ? (String^)"is" : "is not", clsType->Name );
         
         // If it's defined, display the GUID.
         if ( isDef )
         {
            GuidAttribute^ guidAttr = dynamic_cast<GuidAttribute^>(Attribute::GetCustomAttribute( clsType, GuidAttribute::typeid ));
            if ( guidAttr != nullptr )
                        Console::WriteLine( "GUID: {{0}}.", guidAttr->Value );
            else
                        Console::WriteLine( "The Guid attribute could "
            "not be retrieved." );
         }
      }

   };

}


/*
 * Output:
 * The Guid attribute is defined for class TestClass.
 * GUID: {BF235B41-52D1-46cc-9C55-046793DB363F}.
 */
// </Snippet3>
// <Snippet4>
using namespace System;
using namespace System::Reflection;

namespace IsDef4CS
{
   public ref class TestClass
   {
   public:

      // Assign the Obsolete attribute to a method.

      [Obsolete("This method is obsolete. Use Method2 instead.")]
      void Method1(){}

      void Method2(){}

   };

   ref class DemoClass
   {
   public:
      static void Main()
      {
         
         // Get the class type to access its metadata.
         Type^ clsType = TestClass::typeid;
         
         // Get the MethodInfo object for Method1.
         MethodInfo^ mInfo = clsType->GetMethod( "Method1" );
         
         // See if the Obsolete attribute is defined for this method.
         bool isDef = Attribute::IsDefined( mInfo, ObsoleteAttribute::typeid );
         
         // Display the result.
         Console::WriteLine( "The Obsolete Attribute {0} defined for {1} of class {2}.", isDef ? (String^)"is" : "is not", mInfo->Name, clsType->Name );
         
         // If it's defined, display the attribute's message.
         if ( isDef )
         {
            ObsoleteAttribute^ obsAttr = dynamic_cast<ObsoleteAttribute^>(Attribute::GetCustomAttribute( mInfo, ObsoleteAttribute::typeid ));
            if ( obsAttr != nullptr )
                        Console::WriteLine( "The message is: \"{0}\".", obsAttr->Message );
            else
                        Console::WriteLine( "The message could not be retrieved." );
         }
      }

   };

}


/*
 * Output:
 * The Obsolete Attribute is defined for Method1 of class TestClass.
 * The message is: "This method is obsolete. Use Method2 instead.".
 */
//</Snippet4>
//<Snippet5>
using namespace System;
using namespace System::Reflection;

namespace IsDef5CS
{
   public ref class TestClass
   {
   public:

      // Assign a ParamArray attribute to the parameter using the keyword.
      void Method1(... array<String^>^args ){}

   };

   ref class DemoClass
   {
   public:
      static void Main()
      {
         
         // Get the class type to access its metadata.
         Type^ clsType = TestClass::typeid;
         
         // Get the MethodInfo object for Method1.
         MethodInfo^ mInfo = clsType->GetMethod( "Method1" );
         
         // Get the ParameterInfo array for the method parameters.
         array<ParameterInfo^>^pInfo = mInfo->GetParameters();
         if ( pInfo != nullptr )
         {
            
            // See if the ParamArray attribute is defined.
            bool isDef = Attribute::IsDefined( pInfo[ 0 ], ParamArrayAttribute::typeid );
            
            // Display the result.
            Console::WriteLine( "The ParamArray attribute {0} defined for "
            "parameter {1} of method {2}.", isDef ? (String^)"is" : "is not", pInfo[ 0 ]->Name, mInfo->Name );
         }
         else
                  Console::WriteLine( "The parameters information could "
         "not be retrieved for method {0}.", mInfo->Name );
      }

   };

}

/*
 * Output:
 * The ParamArray attribute is defined for parameter args of method Method1.
 */
//</Snippet5>
