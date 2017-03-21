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