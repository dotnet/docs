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