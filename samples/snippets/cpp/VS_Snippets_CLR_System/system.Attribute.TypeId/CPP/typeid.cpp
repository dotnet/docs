
//<Snippet1>
// Example for the Attribute::TypeId property.
using namespace System;
using namespace System::Reflection;

namespace NDP_UE_CPP
{

   // Define a custom parameter attribute that takes a single message argument.

   [AttributeUsage(AttributeTargets::Parameter)]
   public ref class ArgumentUsageAttribute: public Attribute
   {
   protected:

      // This is storage for the attribute message and unique ID.
      String^ usageMsg;
      Guid instanceGUID;

   public:

      // The constructor saves the message and creates a unique identifier.
      ArgumentUsageAttribute( String^ UsageMsg )
      {
         this->usageMsg = UsageMsg;
         this->instanceGUID = Guid::NewGuid();
      }

      property String^ Message 
      {
         // This is the Message property for the attribute.
         String^ get()
         {
            return usageMsg;
         }

         void set( String^ value )
         {
            this->usageMsg = value;
         }
      }

      property Object^ TypeId 
      {
         // Override TypeId to provide a unique identifier for the instance.
         virtual Object^ get() override
         {
            return instanceGUID;
         }
      }

      // Override ToString() to append the message to 
      // what the base generates.
      virtual String^ ToString() override
      {
         return String::Concat( Attribute::ToString(), ":", usageMsg );
      }
   };

   public ref class TestClass
   {
   public:

      // Assign an ArgumentUsage attribute to each parameter.
      // Assign a ParamArray attribute to strList.
      void TestMethod( [ArgumentUsage("Must pass an array here.")]array<String^>^strArray,
                       [ArgumentUsage("Can pass a param list or array here.")]array<String^>^strList ){}
   };

   static void ShowAttributeTypeIds()
   {
      // Get the class type, and then get the MethodInfo object 
      // for TestMethod to access its metadata.
      Type^ clsType = TestClass::typeid;
      MethodInfo^ mInfo = clsType->GetMethod( "TestMethod" );

      // There will be two elements in pInfoArray, one for each parameter.
      array<ParameterInfo^>^pInfoArray = mInfo->GetParameters();
      if ( pInfoArray != nullptr )
      {
         // Create an instance of the param array attribute on strList.
         ParamArrayAttribute^ listArrayAttr = static_cast<ParamArrayAttribute^>(Attribute::GetCustomAttribute( pInfoArray[ 1 ], ParamArrayAttribute::typeid ));

         // Create an instance of the argument usage attribute on strArray.
         ArgumentUsageAttribute^ arrayUsageAttr1 = static_cast<ArgumentUsageAttribute^>(Attribute::GetCustomAttribute( pInfoArray[ 0 ], ArgumentUsageAttribute::typeid ));

         // Create another instance of the argument usage attribute 
         // on strArray.
         ArgumentUsageAttribute^ arrayUsageAttr2 = static_cast<ArgumentUsageAttribute^>(Attribute::GetCustomAttribute( pInfoArray[ 0 ], ArgumentUsageAttribute::typeid ));

         // Create an instance of the argument usage attribute on strList.
         ArgumentUsageAttribute^ listUsageAttr = static_cast<ArgumentUsageAttribute^>(Attribute::GetCustomAttribute( pInfoArray[ 1 ], ArgumentUsageAttribute::typeid ));

         // Display the attributes and corresponding TypeId values.
         Console::WriteLine( "\n\"{0}\" \nTypeId: {1}", listArrayAttr->ToString(), listArrayAttr->TypeId );
         Console::WriteLine( "\n\"{0}\" \nTypeId: {1}", arrayUsageAttr1->ToString(), arrayUsageAttr1->TypeId );
         Console::WriteLine( "\n\"{0}\" \nTypeId: {1}", arrayUsageAttr2->ToString(), arrayUsageAttr2->TypeId );
         Console::WriteLine( "\n\"{0}\" \nTypeId: {1}", listUsageAttr->ToString(), listUsageAttr->TypeId );
      }
      else
            Console::WriteLine( "The parameters information could "
      "not be retrieved for method {0}.", mInfo->Name );
   }
}

int main()
{
   Console::WriteLine( "This example of the Attribute::TypeId property\n"
   "generates the following output." );
   Console::WriteLine( "\nCreate instances from a derived Attribute "
   "class that implements TypeId, \nand then "
   "display the attributes and corresponding TypeId values:" );
   NDP_UE_CPP::ShowAttributeTypeIds();
}

/*
This example of the Attribute::TypeId property
generates the following output.

Create instances from a derived Attribute class that implements TypeId,
and then display the attributes and corresponding TypeId values:

"System.ParamArrayAttribute"
TypeId: System.ParamArrayAttribute

"NDP_UE_CPP.ArgumentUsageAttribute:Must pass an array here."
TypeId: 9316015d-1219-4ce1-b317-e71efb23d42e

"NDP_UE_CPP.ArgumentUsageAttribute:Must pass an array here."
TypeId: ebc1ba23-2573-4c1f-aea6-90515e733796

"NDP_UE_CPP.ArgumentUsageAttribute:Can pass a param list or array here."
TypeId: 624af10b-9bba-4403-a97e-46927e7385fb
*/
//</Snippet1>
