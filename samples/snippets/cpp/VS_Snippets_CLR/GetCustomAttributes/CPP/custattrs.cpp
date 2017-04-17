

// <Snippet2>
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
// </Snippet2>
// <Snippet3>
using namespace System;
using namespace System::Runtime::InteropServices;

namespace CustAttrs3CS
{
   // Set a GUID and ProgId attribute for this class.

   [Guid("BF235B41-52D1-46CC-9C55-046793DB363F")]
   [ProgId("CustAttrs3CS.ClassWithGuidAndProgId")]
   public ref class ClassWithGuidAndProgId{};

   ref class DemoClass
   {
   public:
      static void Main()
      {
         // Get the Class type to access its metadata.
         Type^ clsType = ClassWithGuidAndProgId::typeid;

         // Iterate through all the attributes for the class.
         System::Collections::IEnumerator^ myEnum2 = Attribute::GetCustomAttributes( clsType )->GetEnumerator();
         while ( myEnum2->MoveNext() )
         {
            Attribute^ attr = safe_cast<Attribute^>(myEnum2->Current);

            // Check for the Guid attribute.
            if ( attr->GetType() == GuidAttribute::typeid )
            {
               // Display the GUID.
               Console::WriteLine( "Class {0} has a GUID.", clsType->Name );
               Console::WriteLine( "GUID: {{0}}.", (dynamic_cast<GuidAttribute^>(attr))->Value );
            }
            // Check for the ProgId attribute.
            else

            // Check for the ProgId attribute.
            if ( attr->GetType() == ProgIdAttribute::typeid )
            {
               // Display the ProgId.
               Console::WriteLine( "Class {0} has a ProgId.", clsType->Name );
               Console::WriteLine( "ProgId: \"{0}\".", (dynamic_cast<ProgIdAttribute^>(attr))->Value );
            }
         }
      }
   };
}


/*
 * Output:
 * Class ClassWithGuidAndProgId has a GUID.
 * GUID: {BF235B41-52D1-46CC-9C55-046793DB363F}.
 * Class ClassWithGuidAndProgId has a ProgId.
 * ProgId: "CustAttrs3CS.ClassWithGuidAndProgId".
 */
// </Snippet3>
// <Snippet4>
using namespace System;
using namespace System::Reflection;
using namespace System::Security;
using namespace System::Runtime::InteropServices;

namespace CustAttrs4CS
{
   // Create a class for Win32 imported unmanaged functions.
   public ref class Win32
   {
   public:

      [DllImport("user32.dll", CharSet = CharSet::Unicode)]
      static int MessageBox( int hWnd, String^ text, String^ caption, UInt32 type );
   };

   public ref class AClass
   {
   public:

      // Add some attributes to the Win32CallMethod.

      [Obsolete("This method is obsolete. Use managed MsgBox instead.")]
      void Win32CallMethod()
      {
         Win32::MessageBox( 0, "This is an unmanaged call.", "Be Careful!", 0 );
      }

   };

   ref class DemoClass
   {
   public:
      static void Main()
      {
         // Get the Class type to access its metadata.
         Type^ clsType = AClass::typeid;

         // Get the type information for the Win32CallMethod.
         MethodInfo^ mInfo = clsType->GetMethod( "Win32CallMethod" );
         if ( mInfo != nullptr )
         {
            // Iterate through all the attributes for the method.
            System::Collections::IEnumerator^ myEnum3 = Attribute::GetCustomAttributes( mInfo )->GetEnumerator();
            while ( myEnum3->MoveNext() )
            {
               Attribute^ attr = safe_cast<Attribute^>(myEnum3->Current);

               // Check for the Obsolete attribute.
               if ( attr->GetType() == ObsoleteAttribute::typeid )
               {
                  Console::WriteLine( "Method {0} is obsolete. "
                  "The message is:", mInfo->Name );
                  Console::WriteLine( (dynamic_cast<ObsoleteAttribute^>(attr))->Message );
               }
               // Check for the SuppressUnmanagedCodeSecurity attribute.
               else

               // Check for the SuppressUnmanagedCodeSecurity attribute.
               if ( attr->GetType() == SuppressUnmanagedCodeSecurityAttribute::typeid )
               {
                  Console::WriteLine( "This method calls unmanaged code "
                  "with no security check." );
                  Console::WriteLine( "Please do not use unless absolutely necessary." );
                  AClass^ myCls = gcnew AClass;
                  myCls->Win32CallMethod();
               }
            }
         }
      }
   };
}


/*
 * Output:
 * Method Win32CallMethod is obsolete. The message is:
 * This method is obsolete. Use managed MsgBox instead.
 * This method calls unmanaged code with no security check.
 * Please do not use unless absolutely necessary.
 */
// </Snippet4>
// <Snippet5>
using namespace System;
using namespace System::Reflection;
using namespace System::ComponentModel;

namespace CustAttrs5CS
{
   public ref class AClass
   {
   public:
      void ParamArrayAndDesc(
         // Add ParamArray and Description attributes.
         [Description("This argument is a ParamArray")]
         array<Int32>^args )
      {}
   };

   ref class DemoClass
   {
   public:
      static void Main()
      {
         // Get the Class type to access its metadata.
         Type^ clsType = AClass::typeid;

         // Get the type information for the method.
         MethodInfo^ mInfo = clsType->GetMethod( "ParamArrayAndDesc" );
         if ( mInfo != nullptr )
         {
            // Get the parameter information.
            array<ParameterInfo^>^pInfo = mInfo->GetParameters();
            if ( pInfo != nullptr )
            {
               // Iterate through all the attributes for the parameter.
               System::Collections::IEnumerator^ myEnum4 = Attribute::GetCustomAttributes( pInfo[ 0 ] )->GetEnumerator();
               while ( myEnum4->MoveNext() )
               {
                  Attribute^ attr = safe_cast<Attribute^>(myEnum4->Current);

                  // Check for the ParamArray attribute.
                  if ( attr->GetType() == ParamArrayAttribute::typeid )
                                    Console::WriteLine( "Parameter {0} for method {1} "
                  "has the ParamArray attribute.", pInfo[ 0 ]->Name, mInfo->Name );
                  // Check for the Description attribute.
                  else

                  // Check for the Description attribute.
                  if ( attr->GetType() == DescriptionAttribute::typeid )
                  {
                     Console::WriteLine( "Parameter {0} for method {1} "
                     "has a description attribute.", pInfo[ 0 ]->Name, mInfo->Name );
                     Console::WriteLine( "The description is: \"{0}\"", (dynamic_cast<DescriptionAttribute^>(attr))->Description );
                  }
               }
            }
         }
      }
   };
}

/*
 * Output:
 * Parameter args for method ParamArrayAndDesc has a description attribute.
 * The description is: "This argument is a ParamArray"
 * Parameter args for method ParamArrayAndDesc has the ParamArray attribute.
 */
// </Snippet5>
