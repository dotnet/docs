#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services;
using namespace System::Web::Services::Protocols;
using namespace System::IO;

ref class TraceExtension;

// Create a SoapExtensionAttribute for our SOAP Extension that can be
// applied to an XML Web service method.

[AttributeUsage(AttributeTargets::Method)]
public ref class TraceExtensionAttribute: public SoapExtensionAttribute
{
private:
   String^ filename;
   int priority;

public:
   TraceExtensionAttribute()
      : filename( "c:\\log.txt" )
   {}

   property Type^ ExtensionType 
   {
      virtual Type^ get() override
      {
         return TraceExtension::typeid;
      }
   }

   property int Priority 
   {
      virtual int get() override
      {
         return priority;
      }
      virtual void set( int value ) override
      {
         priority = value;
      }
   }

   property String^ Filename 
   {
      String^ get()
      {
         return filename;
      }
      void set( String^ value )
      {
         filename = value;
      }
   }
};

// Define a SOAP Extension that traces the SOAP request and SOAP response
// for the XML Web service method, the SOAP extension is applied to.
public ref class TraceExtension: public SoapExtension
{
private:
   Stream^ oldStream;
   Stream^ newStream;
   String^ filename;

public:
   // When the SOAP extension is accessed for the first time the XML Web service method it is applied
   // is accessed store the filename passed in using the corresponding SoapExtensionAttribute.    
   virtual Object^ GetInitializer( LogicalMethodInfo^ /*methodInfo*/, SoapExtensionAttribute^ attribute ) override
   {
      return (dynamic_cast<TraceExtensionAttribute^>(attribute))->Filename;
   }

   virtual Object^ GetInitializer( Type^ filename ) override
   {
      return dynamic_cast<Type^>(filename);
   }

   // <Snippet1>
   // Receive the file name stored by GetInitializer and store it in
   // a member variable for this specific instance.
public:
   virtual void Initialize( Object^ initializer ) override
   {
      filename = dynamic_cast<String^>(initializer);
   }
   // </Snippet1>

   //  If the SoapMessageStage is such that the SoapRequest or SoapResponse is still in the SOAP 
   //  format to be sent or received over the wire, save it out to filename passed in using the SoapExtensionAttribute
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
         default:
            throw gcnew Exception( "invalid stage" );
      }
   }

   // Save the Stream representing the SOAP request or SOAP response into a local memory buffer
   virtual Stream^ ChainStream( Stream^ stream ) override
   {
      oldStream = stream;
      newStream = gcnew MemoryStream;
      return newStream;
   }

   void WriteOutput( SoapMessage^ /*message*/ )
   {
      newStream->Position = 0;
      FileStream^ fs = gcnew FileStream( filename,FileMode::Append,FileAccess::Write );
      StreamWriter^ w = gcnew StreamWriter( fs );
      w->WriteLine( "---------------------------------- Response at {0}", DateTime::Now );
      w->Flush();
      Copy( newStream, fs );
      fs->Close();
      newStream->Position = 0;
      Copy( newStream, oldStream );
   }

   void WriteInput( SoapMessage^ /*message*/ )
   {
      Copy( oldStream, newStream );
      FileStream^ fs = gcnew FileStream( filename,FileMode::Append,FileAccess::Write );
      StreamWriter^ w = gcnew StreamWriter( fs );
      w->WriteLine( "================================== Request at {0}", DateTime::Now );
      w->Flush();
      newStream->Position = 0;
      Copy( newStream, fs );
      fs->Close();
      newStream->Position = 0;
   }

   void Copy( Stream^ from, Stream^ to )
   {
      TextReader^ reader = gcnew StreamReader( from );
      TextWriter^ writer = gcnew StreamWriter( to );
      writer->WriteLine( reader->ReadToEnd() );
      writer->Flush();
   }
};

int main(){}
