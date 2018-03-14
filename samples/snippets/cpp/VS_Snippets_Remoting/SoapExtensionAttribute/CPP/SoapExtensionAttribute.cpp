// System.Web.Services.Protocols.SoapExtensionAttribute
// System.Web.Services.Protocols.SoapExtensionAttribute.ExtensionType
// System.Web.Services.Protocols.SoapExtensionAttribute.Priority

/*
The following example demonstrates the 'ExtensionType'
and 'Priority' attribute of the 'SoapExtensionAttribute' class.
The program extends the 'SoapExtension' class to create a class
that is used to log the SOAP messages transferred for a web service
method invocation. To associate this 'SoapExtension' class with the
web service method on the client proxy, a class that extends from
'SoapExtensionAttribute' is used. This 'SoapExtensionAttribute'
is applied to a client proxy method which is associated with a
web service method. Whenever this method is invoked on the client
side all the SOAP message that get transffered both from the client
and the server(which is hosting the web service) are written into
a log file.
*/

#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Web::Services::Protocols;
using namespace System::Web::Services;

ref class TraceExtension;

// <Snippet1>
// A SoapExtensionAttribute that can be associated with an
// XML Web service method.
[AttributeUsage(AttributeTargets::Method)]
public ref class TraceExtensionAttribute: public SoapExtensionAttribute
{
private:
   String^ myFilename;
   int myPriority;

public:
   // Set the name of the log file where SOAP messages will be stored.
   TraceExtensionAttribute() : SoapExtensionAttribute()
   {
      myFilename = "C:\\logClient.txt";
   }

   // <Snippet2>
   // Return the type of TraceExtension.
   property Type^ ExtensionType 
   {
      Type^ get()
      {
         return typeid<TraceExtension^>;
      }
   }
   // </Snippet2>

   // <Snippet3>
   // User can set priority of the SoapExtension.
   property int Priority 
   {
      int get()
      {
         return myPriority;
      }
      void set( int value )
      {
         myPriority = value;
      }

   }
   // </Snippet3>

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
// </Snippet1>

[System::Web::Services::WebServiceBindingAttribute(Name="MathSvcSoap",Namespace="http://tempuri.org/")]
public ref class MathSvc: public System::Web::Services::Protocols::SoapHttpClientProtocol
{
public:

   [System::Diagnostics::DebuggerStepThroughAttribute]
   MathSvc()
   {
      this->Url = "http://localhost/MathSvc_SoapExtensionAttribute.asmx";
   }

   [System::Web::Services::Protocols::SoapDocumentMethodAttribute("http://tempuri.org/Add", Use=System::Web::Services::Description::SoapBindingUse::Literal, ParameterStyle=System::Web::Services::Protocols::SoapParameterStyle::Wrapped)]
   [TraceExtension]
   Single Add( Single xValue, Single yValue )
   {
      array<Object^>^ temp0 = { xValue, yValue };
      array<Object^>^ results = this->Invoke( "Add", temp0 );
      return ( (Single)( results[ 0 ] ) );
   }

   System::IAsyncResult^ BeginAdd( Single xValue,
      Single yValue,
      System::AsyncCallback^ callback,
      Object^ asyncState )
   {
      array<Object^>^ temp1 = { xValue, yValue };
      return this->BeginInvoke( "Add", temp1, callback, asyncState );
   }

   Single EndAdd( System::IAsyncResult^ asyncResult )
   {
      array<Object^>^ results = this->EndInvoke( asyncResult );
      return ( (Single)( results[ 0 ] ) );
   }
};

// Define a SOAP Extension that traces the SOAP request and SOAP
// response for the XML Web service method the SOAP extension is
// applied to.
public ref class TraceExtension: public SoapExtension
{
private:
   Stream^ oldStream;
   Stream^ newStream;
   String^ filename;

public:
   // Save the Stream representing the SOAP request or SOAP response into
   // a local memory buffer.
   Stream^ ChainStream( Stream^ stream )
   {
      oldStream = stream;
      newStream = gcnew MemoryStream;
      return newStream;
   }

   // When the SOAP extension is accessed for the first time, the XML Web
   // service method it is applied to is accessed to store the file
   // name passed in, using the corresponding SoapExtensionAttribute.
   Object^ GetInitializer( LogicalMethodInfo^ /*methodInfo*/, SoapExtensionAttribute^ attribute )
   {
      return ( (TraceExtensionAttribute^)( attribute ) )->Filename;
   }

   // The SOAP extension was configured to run using a configuration file
   // instead of an attribute applied to a specific XML Web service
   // method.
   Object^ GetInitializer( Type^ WebServiceType )
   {
      // Return a file name to log the trace information to, based on the
      // type.
      return String::Format( "C:\\{0}.log", WebServiceType->FullName );
   }

   // Receive the file name stored by GetInitializer and store it in a
   // member variable for this specific instance.
   void Initialize( Object^ initializer )
   {
      filename = (String^)( initializer );
   }

   //  If the SoapMessageStage is such that the SoapRequest or
   //  SoapResponse is still in the SOAP format to be sent or received,
   //  save it out to a file.
   void ProcessMessage( SoapMessage^ message )
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

   void WriteOutput( SoapMessage^ message )
   {
      newStream->Position = 0;
      FileStream^ fs = gcnew FileStream( filename, FileMode::Append,
         FileAccess::Write );
      StreamWriter^ w = gcnew StreamWriter( fs );

      String^ soapString = ( (SoapServerMessage^)( message ) ) ? (String^)"SoapResponse" : "SoapRequest";
      w->WriteLine( "-----{0} at {1}", soapString, DateTime::Now );
      w->Flush();
      Copy( newStream, fs );
      w->Close();
      newStream->Position = 0;
      Copy( newStream, oldStream );
   }

   void WriteInput( SoapMessage^ message )
   {
      Copy( oldStream, newStream );
      FileStream^ fs = gcnew FileStream( filename, FileMode::Append,
         FileAccess::Write );
      StreamWriter^ w = gcnew StreamWriter( fs );
      String^ soapString = ( (SoapServerMessage^)( message ) ) ?
         (String^)"SoapRequest" : "SoapResponse";
      w->WriteLine( "-----{0} at {1}", soapString, DateTime::Now );
      w->Flush();
      newStream->Position = 0;
      Copy( newStream, fs );
      w->Close();
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
