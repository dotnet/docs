#using <System.Web.Services.dll>
#using <System.Web.dll>

using namespace System;
using namespace System::Web;
using namespace System::Web::Services;
using namespace System::Web::Services::Protocols;

public ref class Sample: public SoapExtension
{
   // <Snippet1>
public:
   virtual void ProcessMessage( SoapMessage^ message ) override
   {
      switch ( message->Stage )
      {
         case SoapMessageStage::BeforeSerialize:
            break;

         case SoapMessageStage::AfterSerialize:
            WriteOutput( message );
            break;

         case SoapMessageStage::BeforeDeserialize:
            WriteInput( message );
            break;

         case SoapMessageStage::AfterDeserialize:
            break;


      }
   }
   // </Snippet1>

   virtual Object^ GetInitializer( LogicalMethodInfo^ /*lmi*/, SoapExtensionAttribute^ /*sea*/ ) override
   {
      // method added so sample will compile
      Object^ myobject = gcnew Object;
      return myobject;
   }

   virtual void Initialize( Object^ /*o*/ ) override
   {
      
      // method added so sample will compile
   }

   void WriteOutput( SoapMessage^ /*message*/ )
   {
      
      // method added so sample will compile
   }

   void WriteInput( SoapMessage^ /*message*/ )
   {
      
      // method added so sample will compile
   }

   virtual Object^ GetInitializer( Type^ filename ) override
   {
      return dynamic_cast<Type^>(filename);
   }

};

int main(){}
