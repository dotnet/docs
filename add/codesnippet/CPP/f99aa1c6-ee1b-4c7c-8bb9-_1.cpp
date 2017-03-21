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