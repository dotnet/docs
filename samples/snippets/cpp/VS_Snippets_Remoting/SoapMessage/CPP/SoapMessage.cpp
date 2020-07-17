// System.Web.Services.Protocols.SoapMessage
// System.Web.Services.Protocols.SoapMessage.Action
// System.Web.Services.Protocols.SoapMessage.ContentType
// System.Web.Services.Protocols.SoapMessage.OneWay
// System.Web.Services.Protocols.SoapMessage.Url
// System.Web.Services.Protocols.SoapMessage.GetInParameterValue(int)
// System.Web.Services.Protocols.SoapMessage.MethodInfo
// System.Web.Services.Protocols.SoapMessage.GetOutParameterValue(int)
// System.Web.Services.Protocols.SoapMessage.GetReturnValue()

/*
The following example demonstrates various members of the SoapMessage
class. The program extends the SoapExtension class to create a class
that is used to log the SOAP messages transferred for an XML Web service
method invocation. Whenever this method is invoked on the client side,
all the SOAP messages that get transfered both from the client and the
server are written into a log file.
*/

#using <System.Web.Services.dll>
#using <System.dll>

using namespace System::Runtime::InteropServices;
using namespace System;
using namespace System::IO;
using namespace System::Web::Services::Protocols;
using namespace System::Web::Services;

ref class MySoapExtension;

// A SoapExtensionAttribute that can be associated with an XML
// Web service method.
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
   String^ text;
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
   Single Add( Single xValue, Single yValue,
      [System::Runtime::InteropServices::Out]interior_ptr<Single> returnValue )
   {
      mySoapHeader = gcnew MySoapHeader;
      mySoapHeader->text = "This is the first SOAP header";
      array<Object^>^ temp0 = { xValue, yValue };
      array<Object^>^ results = this->Invoke( "Add", temp0 );
      *returnValue = (Single)( results[ 1 ] );
      return (Single)( results[ 0 ] );
   }

   [System::Diagnostics::DebuggerStepThroughAttribute]
   MathSvc()
   {
      this->Url = "http://localhost/MathSvc_SoapMessage.cs.asmx";
   }

   System::IAsyncResult^ BeginAdd( Single xValue,
      Single yValue, System::AsyncCallback^ callback,
      Object^ asyncState )
   {
      array<Object^>^ temp1 = { xValue, yValue };
      return this->BeginInvoke( "Add",
         temp1, callback, asyncState );
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
   Stream^ oldStream;
   Stream^ newStream;
   String^ filename;

public:

   // Return the file name that is to log the SOAP messages.
   virtual Object^ GetInitializer( LogicalMethodInfo^ /*methodInfo*/,
      SoapExtensionAttribute^ attribute ) override
   {
      return ( (MySoapExtensionAttribute^)( attribute ))->Filename;
   }

   // Return the file name that is to log the SOAP messages.
   virtual Object^ GetInitializer( Type^ filename ) override
   {
      return (Type^)( filename );
   }

   // Save the name of the log file that will save the SOAP messages.
   virtual void Initialize( Object^ initializer ) override
   {
      filename = (String^)( initializer );
   }

// <Snippet1>
   // Process the SOAP message received and write to log file.
   virtual void ProcessMessage( SoapMessage^ message ) override
   {
      switch ( message->Stage )
      {
         case SoapMessageStage::BeforeSerialize:
            WriteOutputBeforeSerialize( message );
            break;
         case SoapMessageStage::AfterSerialize:
            WriteOutputAfterSerialize( message );
            break;
         case SoapMessageStage::BeforeDeserialize:
            WriteInputBeforeDeserialize( message );
            break;
         case SoapMessageStage::AfterDeserialize:
            WriteInputAfterDeserialize( message );
            break;
         default:
            throw gcnew Exception( "invalid stage" );
      }
   }

   // Write the contents of the outgoing SOAP message to the log file.
   void WriteOutputBeforeSerialize( SoapMessage^ message )
   {
      FileStream^ myFileStream =
         gcnew FileStream( filename, FileMode::Append, FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->WriteLine( "================================== Request at {0}",
         DateTime::Now );
      
      // <Snippet7>
      myStreamWriter->WriteLine(
         "The method that has been invoked is: " );
      myStreamWriter->WriteLine( "\t{0}", message->MethodInfo );
      // </Snippet7>

      // <Snippet2>
      myStreamWriter->WriteLine( "The contents of the SOAPAction HTTP header is:" );
      myStreamWriter->WriteLine( "\t{0}", message->Action );
      // </Snippet2>

      // <Snippet3>
      myStreamWriter->WriteLine( "The contents of HTTP Content-type header is:" );
      myStreamWriter->WriteLine( "\t{0}", message->ContentType );
      // </Snippet3>

      // <Snippet4>
      if ( message->OneWay )
      {
         myStreamWriter->WriteLine(
            "The method invoked on the client shall not wait"
            + " till the server finishes" );
      }
      else
      {
         myStreamWriter->WriteLine(
            "The method invoked on the client shall wait"
            + " till the server finishes" );
      }
      // </Snippet4>

      // <Snippet5>
      myStreamWriter->WriteLine(
         "The site where the XML Web service is available is:" );
      myStreamWriter->WriteLine( "\t{0}", message->Url );
      // </Snippet5>

      // <Snippet6>
      myStreamWriter->WriteLine( "The values of the in parameters are:" );
      myStreamWriter->WriteLine(
         "Value of first in parameter: {0}", message->GetInParameterValue( 0 ) );
      myStreamWriter->WriteLine(
         "Value of second in parameter: {0}", message->GetInParameterValue( 1 ) );
      // </Snippet6>

      myStreamWriter->WriteLine();
      myStreamWriter->Flush();
      myStreamWriter->Close();
      myFileStream->Close();
   }

   // Write the contents of the incoming SOAP message to the log file.
   void WriteInputAfterDeserialize( SoapMessage^ message )
   {
      FileStream^ myFileStream =
         gcnew FileStream( filename, FileMode::Append, FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->WriteLine();
      
      // <Snippet8>
      myStreamWriter->WriteLine( "The values of the out parameter are:" );
      myStreamWriter->WriteLine(
         "The value of the out parameter is: {0}", message->GetOutParameterValue( 0 ) );
      // </Snippet8>

      // <Snippet9>
      myStreamWriter->WriteLine( "The values of the return parameter are:" );
      myStreamWriter->WriteLine(
         "The value of the return parameter is: {0}", message->GetReturnValue() );
      // </Snippet9>

      myStreamWriter->Flush();
      myStreamWriter->Close();
      myFileStream->Close();
   }
   // </Snippet1>

   // Write the contents of the outgoing SOAP message to the log file.
   void WriteOutputAfterSerialize( SoapMessage^ /*message*/ )
   {
      newStream->Position = 0;
      FileStream^ myFileStream =
         gcnew FileStream( filename, FileMode::Append, FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->Flush();
      Copy( newStream, myFileStream );
      myStreamWriter->Close();
      myFileStream->Close();
      newStream->Position = 0;
      Copy( newStream, oldStream );
   }


   // Write the contents of the incoming SOAP message to the log file.
   void WriteInputBeforeDeserialize( SoapMessage^ /*message*/ )
   {
      Copy( oldStream, newStream );
      FileStream^ myFileStream =
         gcnew FileStream( filename, FileMode::Append, FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->WriteLine( "---------------------------------- Response at {0}",
         DateTime::Now );
      myStreamWriter->Flush();
      newStream->Position = 0;
      Copy( newStream, myFileStream );
      myStreamWriter->Close();
      myFileStream->Close();
      newStream->Position = 0;
   }

   // Return a new MemoryStream for SOAP processing.
   virtual Stream^ ChainStream( Stream^ stream ) override
   {
      oldStream = stream;
      newStream = gcnew MemoryStream;
      return newStream;
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
