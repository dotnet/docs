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