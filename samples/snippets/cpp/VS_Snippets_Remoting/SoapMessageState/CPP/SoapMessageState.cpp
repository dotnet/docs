// System.Web.Services.Protocols.SoapMessageState
// System.Web.Services.Protocols.SoapMessageState.AfterDeserialize
// System.Web.Services.Protocols.SoapMessageState.AfterSerialize
// System.Web.Services.Protocols.SoapMessageState.BeforeDeserialize
// System.Web.Services.Protocols.SoapMessageState.BeforeSerialize

/*
   The following example demonstrates the 'AfterDeserialize',
   'AfterSerialize', 'BeforeDeserialize' and 'BeforeSerialize' enum
   members of the 'SoapMessageState' class. The program extends the
   'SoapExtension' class to create a class that is used to log the
   SOAP messages transferred for a web service method invocation.
   To associate this 'SoapExtension' class with the web service
   method on the client proxy a class that extends from
   'SoapExtensionAttribute' is used. This 'SoapExtensionAttribute' is
   applied to a client proxy method which is associated with a web
   service method. Whenever this method is invoked on the client
   side all the SOAP message that get transfered both from the client
   and the server(which is hosting the web service) are written into
   a log file.
*/

#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Web::Services::Protocols;
using namespace System::Web::Services;

ref class MySoapExtension;

// A 'SoapExtensionAttribute' that can be associated with web service method.
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
      // Return the type of 'MySoapExtension' class.
      Type^ get()
      {
         return typeid<MySoapExtension^>;
      }
   }

   property int Priority 
   {
      // User can set priority of the 'SoapExtension'.
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

[System::Web::Services::WebServiceBindingAttribute(Name="MathSvcSoap",Namespace="http://tempuri.org/")]
public ref class MathSvc: public System::Web::Services::Protocols::SoapHttpClientProtocol
{
public:

   [System::Diagnostics::DebuggerStepThroughAttribute]
   MathSvc()
   {
      this->Url = "http://localhost/MathSvc_SoapMessageState.asmx";
   }

   [System::Web::Services::Protocols::SoapDocumentMethodAttribute("http://tempuri.org/Add",Use=System::Web::Services::Description::SoapBindingUse::Literal,ParameterStyle=System::Web::Services::Protocols::SoapParameterStyle::Wrapped)]
   [MySoapExtensionAttribute]
   Single Add( Single xValue, Single yValue )
   {
      array<Object^>^ temp0 = {xValue,yValue};
      array<Object^>^ results = this->Invoke( "Add", temp0 );
      return (Single)( results[ 0 ] );
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
   // Return the filename that is to log the SOAP messages.
   Object^ GetInitializer( LogicalMethodInfo^ /*methodInfo*/, SoapExtensionAttribute^ attribute )
   {
      return ( (MySoapExtensionAttribute^)( attribute ))->Filename;
   }

   // Return the filename that is to log the SOAP messages.
   Object^ GetInitializer( Type^ filename )
   {
      return (Type^)( filename );
   }

   // Save the name of the log file that shall save the SOAP messages.
   void Initialize( Object^ initializer )
   {
      filename = (String^)( initializer );
   }

// <Snippet1>
   // Process the SOAP message received and write to log file.
   void ProcessMessage( SoapMessage^ message )
   {
// <Snippet2>
// <Snippet3>
// <Snippet4>
// <Snippet5>
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
// </Snippet5>
// </Snippet4>
// </Snippet3>
// </Snippet2>
   }
// </Snippet1>

   // Return a new 'MemoryStream' instance for SOAP processing.
   Stream^ ChainStream( Stream^ stream )
   {
      oldStream = stream;
      newStream = gcnew MemoryStream;
      return newStream;
   }


   // Write the contents of the outgoing SOAP message to the log file.
   void WriteOutput( SoapMessage^ /*message*/ )
   {
      newStream->Position = 0;
      FileStream^ myFileStream =
         gcnew FileStream( filename, FileMode::Append, FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->WriteLine( "================================== Request at {0}",
         DateTime::Now );
      myStreamWriter->Flush();
      Copy( newStream, myFileStream );
      myFileStream->Close();
      newStream->Position = 0;
      Copy( newStream, oldStream );
   }

   // Write the contents of the incoming SOAP message to the log file.
   void WriteInput( SoapMessage^ /*message*/ )
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
      myFileStream->Close();
      newStream->Position = 0;
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
