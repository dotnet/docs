// System.Web.Services.Protocols.SoapMessage.Headers
// System.Web.Services.Protocols.SoapMessage.Stream

/*
   The following example demonstrates the 'Headers' and 'Stream' properties
   of the 'SoapMessage' class. The program extends the
   'SoapExtension' class to create a class that is used to log the
   SOAP messages transferred for a web service method invocation.
   Whenever this method is invoked on the client side all the SOAP
   message that get transfered both from the client and the server
   are written into a log file.
*/

#using <System.Web.Services.dll>
#using <System.dll>
#using <System.Xml.dll>

using namespace System::Runtime::InteropServices;
using namespace System;
using namespace System::IO;
using namespace System::Web::Services::Protocols;
using namespace System::Web::Services;

ref class MySoapExtension;

// A SoapExtensionAttribute that can be associated with an
// XML Web service method.
[AttributeUsage(AttributeTargets::Method)]
public ref class MySoapExtensionAttribute: public SoapExtensionAttribute
{
private:
   String^ myFilename;
   int myPriority;

public:
   // Set the name of the log file where SOAP messages will be stored.
   MySoapExtensionAttribute() : SoapExtensionAttribute()
   {
      myFilename = "C:\\logClient.txt";
   }

   property Type^ ExtensionType 
   {
      // Return the type of MySoapExtension.
      virtual Type^ get() override
      {
         return MySoapExtension::typeid;
      }
   }

   property int Priority 
   {
      // User can set priority of the SoapExtension.
      virtual int get() override
      {
         return myPriority;
      }
      virtual void set( int value ) override
      {
         myPriority = value;
      }
   }

   property String^ Filename 
   {
      String^ get()
      {
         return myFilename;
      }
      void set( String^ value )
      {
         myFilename = value;
      }
   }
};

public ref class MySoapHeader: public SoapHeader
{
public:
   String^ myText;
};

[System::Web::Services::WebServiceBindingAttribute(Name="MathSvcSoap",
   Namespace="http://tempuri.org/")]
public ref class MathSvc: public System::Web::Services::Protocols::SoapHttpClientProtocol
{
public:
   MySoapHeader^ mySoapHeader;

   [SoapHeaderAttribute("mySoapHeader",Direction=SoapHeaderDirection::In)]
   [System::Web::Services::Protocols::SoapDocumentMethodAttribute(
      "http://tempuri.org/Add",
      Use=System::Web::Services::Description::SoapBindingUse::Literal,
      ParameterStyle=System::Web::Services::Protocols::SoapParameterStyle::Wrapped)]
   [MySoapExtensionAttribute]
   Single Add( Single xValue,
      Single yValue,
      [System::Runtime::InteropServices::Out]interior_ptr<Single> returnValue )
   {
      mySoapHeader = gcnew MySoapHeader;
      mySoapHeader->myText = "This is the first SOAP header";
      array<Object^>^ temp0 = {xValue,yValue};
      array<Object^>^ results = this->Invoke( "Add", temp0 );
      *returnValue = (Single)( results[ 1 ] );
      return (Single)( results[ 0 ] );
   }

   [System::Diagnostics::DebuggerStepThroughAttribute]
   MathSvc()
   {
      this->Url = "http://localhost/SoapMessage_Headers.cs.asmx";
   }

   System::IAsyncResult^ BeginAdd( Single xValue, Single yValue,
      System::AsyncCallback^ callback, Object^ asyncState )
   {
      array<Object^>^ temp1 = { xValue, yValue };
      return this->BeginInvoke( "Add", temp1, callback, asyncState );
   }

   Single EndAdd( System::IAsyncResult^ asyncResult,
         [System::Runtime::InteropServices::Out]interior_ptr<Single> returnValue )
   {
      array<Object^>^ results = this->EndInvoke( asyncResult );
      *returnValue = (Single)( results[ 1 ] );
      return (Single)( results[ 0 ] );
   }
};

public ref class MySoapExtension: public SoapExtension
{
private:
   Stream^ myOldStream;
   Stream^ myNewStream;
   String^ myFileName;

public:
   // Return the filename that is to log the SOAP messages.
   virtual Object^ GetInitializer( LogicalMethodInfo^ /*myMethodInfo*/,
      SoapExtensionAttribute^ mySoapExtensionAttributeObject ) override
   {
      return ( (MySoapExtensionAttribute^)( mySoapExtensionAttributeObject ) )->Filename;
   }

   // Return the filename that is to log the SOAP messages.
   virtual Object^ GetInitializer( Type^ myFileName ) override
   {
      return (Type^)( myFileName );
   }

   // Save the name of the log file that shall save the SOAP messages.
   virtual void Initialize( Object^ myInitializer ) override
   {
      myFileName = (String^)( myInitializer );
   }

   // Process the SOAP message received and write to log file.
   virtual void ProcessMessage( SoapMessage^ myMessage ) override
   {
      switch ( myMessage->Stage )
      {
         case SoapMessageStage::BeforeSerialize:
            WriteOutputBeforeSerialize( myMessage );
            break;
         case SoapMessageStage::AfterSerialize:
            WriteOutputAfterSerialize( myMessage );
            break;
         case SoapMessageStage::BeforeDeserialize:
            WriteInputBeforeDeserialize( myMessage );
            break;
         case SoapMessageStage::AfterDeserialize:
            WriteInputAfterDeserialize( myMessage );
            break;
         default:
            throw gcnew Exception( "invalid stage" );
      }
   }

   // <Snippet1>
   // Write the contents of the outgoing SOAP message to the log file.
public:
   void WriteOutputBeforeSerialize( SoapMessage^ myMessage )
   {
      FileStream^ myFileStream = gcnew FileStream(
         myFileName, FileMode::Append, FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->WriteLine(
         "================================== Request at {0}", DateTime::Now );

      myStreamWriter->WriteLine( "The values of the in parameters are:" );
      myStreamWriter->WriteLine( "Value of first in parameter: {0}",
         myMessage->GetInParameterValue( 0 ) );
      myStreamWriter->WriteLine( "Value of second in parameter: {0}",
         myMessage->GetInParameterValue( 1 ) );

      myStreamWriter->Write( "Number of headers for the current request: " );
      myStreamWriter->WriteLine( myMessage->Headers->Count );

      myStreamWriter->WriteLine();
      myStreamWriter->Flush();
      myStreamWriter->Close();
      myFileStream->Close();
   }
   // </Snippet1>

   // Write the contents of the incoming SOAP message to the log file.
   void WriteInputAfterDeserialize( SoapMessage^ myMessage )
   {
      FileStream^ myFileStream = gcnew FileStream(
         myFileName, FileMode::Append, FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->WriteLine();

      myStreamWriter->WriteLine( "The values of the out parameter are:" );
      myStreamWriter->WriteLine( "The value of the out parameter is: {0}",
         myMessage->GetOutParameterValue( 0 ) );

      myStreamWriter->WriteLine( "The values of the return parameter are:" );
      myStreamWriter->WriteLine( "The value of the return parameter is: {0}",
         myMessage->GetReturnValue() );

      myStreamWriter->Flush();
      myStreamWriter->Close();
      myFileStream->Close();
   }

   // Write the contents of the outgoing SOAP message to the log file.
   void WriteOutputAfterSerialize( SoapMessage^ /*myMessage*/ )
   {
      myNewStream->Position = 0;
      FileStream^ myFileStream = gcnew FileStream(
         myFileName, FileMode::Append, FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->Flush();
      Copy( myNewStream, myFileStream );
      myStreamWriter->Close();
      myFileStream->Close();
      myNewStream->Position = 0;
      Copy( myNewStream, myOldStream );
   }

   // <Snippet2>
   // Write the contents of the incoming SOAP message to the log file.
public:
   void WriteInputBeforeDeserialize( SoapMessage^ myMessage )
   {
      Copy( myOldStream, myNewStream );
      FileStream^ myFileStream =
         gcnew FileStream( myFileName, FileMode::Append, FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->WriteLine(
         "---------------------------------- Response at {0}", DateTime::Now );
      Stream^ myStream = myMessage->Stream;
      myStreamWriter->Write( "Length of data in the current response: " );
      myStreamWriter->WriteLine( myStream->Length );
      myStreamWriter->Flush();
      myNewStream->Position = 0;
      Copy( myNewStream, myFileStream );
      myStreamWriter->Close();
      myFileStream->Close();
      myNewStream->Position = 0;
   }
   // </Snippet2>

   // Return a new MemoryStream for SOAP processing.
   virtual Stream^ ChainStream( Stream^ myStream ) override
   {
      myOldStream = myStream;
      myNewStream = gcnew MemoryStream;
      return myNewStream;
   }

   // Utility method to copy the contents of one stream to another.
   void Copy( Stream^ fromStream, Stream^ toStream )
   {
      TextReader^ myTextReader = gcnew StreamReader( fromStream );
      TextWriter^ myTextWriter = gcnew StreamWriter( toStream );
      myTextWriter->WriteLine( myTextReader->ReadToEnd() );
      myTextWriter->Flush();
   }
};
