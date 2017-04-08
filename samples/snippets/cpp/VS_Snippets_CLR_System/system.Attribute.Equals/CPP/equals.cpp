
//<Snippet1>
// Example for the Attribute.Equals( Object* ) method.
using namespace System;
using namespace System::Reflection;

namespace NDP_UE_CPP
{
   // Define a custom parameter attribute that takes a single message argument.

   [AttributeUsage(AttributeTargets::Parameter)]
   public ref class ArgumentUsageAttribute: public Attribute
   {
   protected:

      // usageMsg is storage for the attribute message.
      String^ usageMsg;

   public:

      // This is the attribute constructor.
      ArgumentUsageAttribute( String^ UsageMsg )
      {
         this->usageMsg = UsageMsg;
      }


      // Override ToString() to append the message to what the base generates.
      virtual String^ ToString() override
      {
         return String::Concat( Attribute::ToString(), ":", usageMsg );
      }

   };


   // Define a custom parameter attribute that generates a GUID for each instance.

   [AttributeUsage(AttributeTargets::Parameter)]
   public ref class ArgumentIDAttribute: public Attribute
   {
   protected:

      // instanceGUID is storage for the generated GUID.
      Guid instanceGUID;

   public:

      // This is the attribute constructor, which generates the GUID.
      ArgumentIDAttribute()
      {
         this->instanceGUID = Guid::NewGuid();
      }

      // Override ToString() to append the GUID to what the base generates.
      virtual String^ ToString() override
      {
         return String::Concat( Attribute::ToString(), ".", instanceGUID.ToString() );
      }
   };

   public ref class TestClass
   {
   public:

      // Assign an ArgumentID attribute to each parameter.
      // Assign an ArgumentUsage attribute to each parameter.
      void TestMethod( [ArgumentID][ArgumentUsage("Must pass an array here.")]array<String^>^strArray, 
                       [ArgumentID][ArgumentUsage("Can pass param list or array here.")]array<String^>^strList ){}

   };


   // Create Attribute objects and compare them.
   void CompareAttributes()
   {
      // Get the class type, and then get the MethodInfo object 
      // for TestMethod to access its metadata.
      Type^ clsType = TestClass::typeid;
      MethodInfo^ mInfo = clsType->GetMethod( "TestMethod" );

      // There will be two elements in pInfoArray, one for each parameter.
      array<ParameterInfo^>^pInfoArray = mInfo->GetParameters();
      if ( pInfoArray != nullptr )
      {
         // Create an instance of the argument usage attribute on strArray.
         ArgumentUsageAttribute^ arrayUsageAttr1 = static_cast<ArgumentUsageAttribute^>(Attribute::GetCustomAttribute( pInfoArray[ 0 ], ArgumentUsageAttribute::typeid ));

         // Create another instance of the argument usage attribute 
         // on strArray.
         ArgumentUsageAttribute^ arrayUsageAttr2 = static_cast<ArgumentUsageAttribute^>(Attribute::GetCustomAttribute( pInfoArray[ 0 ], ArgumentUsageAttribute::typeid ));

         // Create an instance of the argument usage attribute on strList.
         ArgumentUsageAttribute^ listUsageAttr = static_cast<ArgumentUsageAttribute^>(Attribute::GetCustomAttribute( pInfoArray[ 1 ], ArgumentUsageAttribute::typeid ));

         // Create an instance of the argument ID attribute on strArray.
         ArgumentIDAttribute^ arrayIDAttr1 = static_cast<ArgumentIDAttribute^>(Attribute::GetCustomAttribute( pInfoArray[ 0 ], ArgumentIDAttribute::typeid ));

         // Create another instance of the argument ID attribute on strArray.
         ArgumentIDAttribute^ arrayIDAttr2 = static_cast<ArgumentIDAttribute^>(Attribute::GetCustomAttribute( pInfoArray[ 0 ], ArgumentIDAttribute::typeid ));

         // Create an instance of the argument ID attribute on strList.
         ArgumentIDAttribute^ listIDAttr = static_cast<ArgumentIDAttribute^>(Attribute::GetCustomAttribute( pInfoArray[ 1 ], ArgumentIDAttribute::typeid ));

         // Compare various pairs of attributes for equality.
         Console::WriteLine( "\nCompare a usage attribute instance to "
         "another instance of the same attribute:" );
         Console::WriteLine( "   \"{0}\" == \n   \"{1}\" ? {2}", arrayUsageAttr1->ToString(), arrayUsageAttr2->ToString(), arrayUsageAttr1->Equals( arrayUsageAttr2 ) );
         Console::WriteLine( "\nCompare a usage attribute to another usage attribute:" );
         Console::WriteLine( "   \"{0}\" == \n   \"{1}\" ? {2}", arrayUsageAttr1->ToString(), listUsageAttr->ToString(), arrayUsageAttr1->Equals( listUsageAttr ) );
         Console::WriteLine( "\nCompare an ID attribute instance to "
         "another instance of the same attribute:" );
         Console::WriteLine( "   \"{0}\" == \n   \"{1}\" ? {2}", arrayIDAttr1->ToString(), arrayIDAttr2->ToString(), arrayIDAttr1->Equals( arrayIDAttr2 ) );
         Console::WriteLine( "\nCompare an ID attribute to another ID attribute:" );
         Console::WriteLine( "   \"{0}\" == \n   \"{1}\" ? {2}", arrayIDAttr1->ToString(), listIDAttr->ToString(), arrayIDAttr1->Equals( listIDAttr ) );
      }
      else
            Console::WriteLine( "The parameters information could "
      "not be retrieved for method {0}.", mInfo->Name );
   }
}

int main()
{
   Console::WriteLine( "This example of Attribute::Equals( Object* ) "
   "generates the following output." );
   NDP_UE_CPP::CompareAttributes();
}

/*
This example of Attribute::Equals( Object* ) generates the following output.

Compare a usage attribute instance to another instance of the same attribute:
   "NDP_UE_CPP.ArgumentUsageAttribute:Must pass an array here." ==
   "NDP_UE_CPP.ArgumentUsageAttribute:Must pass an array here." ? True

Compare a usage attribute to another usage attribute:
   "NDP_UE_CPP.ArgumentUsageAttribute:Must pass an array here." ==
   "NDP_UE_CPP.ArgumentUsageAttribute:Can pass param list or array here." ? False

Compare an ID attribute instance to another instance of the same attribute:
   "NDP_UE_CPP.ArgumentIDAttribute.28db2434-1031-469a-9a13-babeb9be9e2c" ==
   "NDP_UE_CPP.ArgumentIDAttribute.1140dcb9-7341-4ba0-b2de-e9d8f0955216" ? False

Compare an ID attribute to another ID attribute:
   "NDP_UE_CPP.ArgumentIDAttribute.28db2434-1031-469a-9a13-babeb9be9e2c" ==
   "NDP_UE_CPP.ArgumentIDAttribute.7f983425-5ea9-4c90-b536-bd6229fdfe63" ? False
*/
//</Snippet1>
