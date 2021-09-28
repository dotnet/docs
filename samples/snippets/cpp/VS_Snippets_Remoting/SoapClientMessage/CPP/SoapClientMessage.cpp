// System.Web.Services.Protocols.SoapClientMessage
// System.Web.Services.Protocols.SoapClientMessage.Action
// System.Web.Services.Protocols.SoapClientMessage.Client
// System.Web.Services.Protocols.SoapClientMessage.MethodInfo
// System.Web.Services.Protocols.SoapClientMessage.OneWay
// System.Web.Services.Protocols.SoapClientMessage.Url

/*
The following example demonstrates the 'Action', 'Client', 'MethodInfo', 
'OneWay' and 'Url' properties of the 'SoapClientMessage' class. 
It extends the 'SoapExtension' class to create a class that is used to 
log the SOAP messages transferred for a web service method invocation. 
To associate this 'SoapExtension' class with the web service method on 
the client proxy, a class that extends from 'SoapExtensionAttribute' is 
used. This 'SoapExtensionAttribute' is applied to a client proxy method 
which is associated with a web service method. Whenever this method is 
invoked on the client side all the SOAP message that get transfered both
from the client and the server(which is hosting the web service) are 
written into a log file. 
*/

#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Web::Services::Protocols;
using namespace System::Web::Services;

ref class MySoapExtension;
ref class MathSvc;

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
   MySoapExtensionAttribute()
      : SoapExtensionAttribute()
   {
      myFilename = "C:\\logClient.txt";
   }

   property Type^ ExtensionType 
   {
      // Return the type of MySoapExtension.
      Type^ get()
      {
         return typeid<MySoapExtension^>;
      }
   }

   property int Priority 
   {
      // User can set priority of the SoapExtension.
      int get()
      {
         return myPriority;
      }
      void set( int value )
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

public ref class MySoapExtension: public SoapExtension
{
private:
   Stream^ oldStream;
   Stream^ newStream;
   String^ filename;

public:
   // Return the filename that is to log the SOAP messages.
   Object^ GetInitializer( LogicalMethodInfo^ /*methodInfo*/, SoapExtensionAttribute^ attribute )
   {
      return (dynamic_cast<MySoapExtensionAttribute^>(attribute))->Filename;
   }

   // Return the filename that is to log the SOAP messages.
   Object^ GetInitializer( Type^ filename )
   {
      return dynamic_cast<Type^>(filename);
   }

   // Save the name of the log file that will save the SOAP messages.
   void Initialize( Object^ initializer )
   {
      filename = dynamic_cast<String^>(initializer);
   }

// <Snippet1>
   // Process the SOAP message received and write to a log file.
   void ProcessMessage( SoapMessage^ message )
   {
      switch ( message->Stage )
      {
         case SoapMessageStage::BeforeSerialize:
            break;
         case SoapMessageStage::AfterSerialize:
            WriteOutput( dynamic_cast<SoapClientMessage^>(message) );
            break;
         case SoapMessageStage::BeforeDeserialize:
            WriteInput( dynamic_cast<SoapClientMessage^>(message) );
            break;
         case SoapMessageStage::AfterDeserialize:
            break;
         default:
            throw gcnew Exception( "invalid stage" );
      }
   }

   // Write the contents of the outgoing SOAP message to the log file.
   void WriteOutput( SoapClientMessage^ message )
   {
// <Snippet2>
// <Snippet3>
// <Snippet4>
// <Snippet5>
// <Snippet6>
      newStream->Position = 0;
      FileStream^ myFileStream = gcnew FileStream( filename, FileMode::Append,
         FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->WriteLine(
         "================================== Request at {0}", DateTime::Now );
      
      // Print to the log file the request header field for SoapAction header.
      myStreamWriter->WriteLine( "The SoapAction Http request header field is: " );
      myStreamWriter->WriteLine( "\t{0}", message->Action );
      
      // Print to the log file the type of the client that invoked 
      // the XML Web service method.
      myStreamWriter->WriteLine( "The type of the client is: " );
      if ( (message->Client->GetType())->Equals( typeid<MathSvc^> ) )
      {
         myStreamWriter->WriteLine( "\tMathSvc" );
      }
      
      // Print to the log file the method invoked by the client.
      myStreamWriter->WriteLine(
         "The method that has been invoked by the client is:" );
      myStreamWriter->WriteLine( "\t{0}", message->MethodInfo->Name );
      
      // Print to the log file if the method invoked is OneWay.
      if ( message->OneWay )
      {
         myStreamWriter->WriteLine(
            "The client doesn't wait for the server to finish processing" );
      }
      else
      {
         myStreamWriter->WriteLine(
         "The client waits for the server to finish processing" );
      }
      
      // Print to the log file the URL of the site that provides 
      // implementation of the method.
      myStreamWriter->WriteLine(
         "The URL of the XML Web service method that has been requested is: " );
      myStreamWriter->WriteLine( "\t{0}", message->Url );
      myStreamWriter->WriteLine( "The contents of the SOAP envelope are: " );
      myStreamWriter->Flush();
      
      // Copy the contents of one stream to another. 
      Copy( newStream, myFileStream );
      myFileStream->Close();
      newStream->Position = 0;
      
      // Copy the contents of one stream to another. 
      Copy( newStream, oldStream );
// </Snippet6>
// </Snippet5>
// </Snippet4>
// </Snippet3>
// </Snippet2>
   }
// </Snippet1>

   // Write the contents of the incoming SOAP message to the log file.
   void WriteInput( SoapClientMessage^ /*message*/ )
   {
      Copy( oldStream, newStream );
      FileStream^ myFileStream = gcnew FileStream( filename, FileMode::Append,
         FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->WriteLine(
         "---------------------------------- Response at {0}", DateTime::Now );
      myStreamWriter->Flush();
      newStream->Position = 0;
      Copy( newStream, myFileStream );
      myFileStream->Close();
      newStream->Position = 0;
   }

   // Return a new MemoryStream for SOAP processing.
   Stream^ ChainStream( Stream^ stream )
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

[System::Web::Services::WebServiceBindingAttribute(Name="MathSvcSoap",
   Namespace="http://tempuri.org/")]
public ref class MathSvc: public System::Web::Services::Protocols::SoapHttpClientProtocol
{
public:

   [System::Diagnostics::DebuggerStepThroughAttribute]
   MathSvc()
   {
      this->Url = "http://localhost/MathSvc_SoapClientMessage.asmx";
   }

   [System::Web::Services::Protocols::SoapDocumentMethodAttribute(
      "http://tempuri.org/Add",
      Use=System::Web::Services::Description::SoapBindingUse::Literal,
      ParameterStyle=System::Web::Services::Protocols::SoapParameterStyle::Wrapped)]
   [MySoapExtensionAttribute]
   Single Add( Single xValue, Single yValue )
   {
      array<Object^>^temp2 = {xValue,yValue};
      array<Object^>^results = this->Invoke( "Add", temp2 );
      return safe_cast<Single>(results[ 0 ]);
   }

   System::IAsyncResult^ BeginAdd( Single xValue, Single yValue, System::AsyncCallback^ callback, Object^ asyncState )
   {
      array<Object^>^ temp3 = { xValue, yValue };
      return this->BeginInvoke( "Add", temp3, callback, asyncState );
   }

   Single EndAdd( System::IAsyncResult^ asyncResult )
   {
      array<Object^>^results = this->EndInvoke( asyncResult );
      return ( (Single)( results[ 0 ] ) );
   }
};
