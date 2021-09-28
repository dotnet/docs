// System.Web.Services.Protocols.SoapHeaderCollection
// System.Web.Services.Protocols.SoapHeaderCollection.SoapHeaderCollection()
// System.Web.Services.Protocols.SoapHeaderCollection.Add(SoapHeader)
// System.Web.Services.Protocols.SoapHeaderCollection.Insert(int, SoapHeader)
// System.Web.Services.Protocols.SoapHeaderCollection.CopyTo(SoapHeader[], int)
// System.Web.Services.Protocols.SoapHeaderDirection.In

/*
   The following example demonstrates various members of the
   SoapHeaderCollection class and the In member of the SoapHeaderDirection
   enumeration. The program extends the SoapExtension class to create a
   class that is used to log the SOAP messages transferred for an XML Web
   service method invocation. Whenever this method is invoked on the client
   side, all the SOAP message that are transfered both from the client and
   the server are written to a log file.
*/

#using <System.Web.Services.dll>
#using <System.dll>
#using <System.Xml.dll>

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
   MySoapExtensionAttribute()
      : SoapExtensionAttribute()
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

// <Snippet1>
[System::Web::Services::WebServiceBindingAttribute(Name="MathSvcSoap",
   Namespace="http://tempuri.org/")]
public ref class MathSvc: public System::Web::Services::Protocols::SoapHttpClientProtocol
{
   // <Snippet6>
public:
   array<SoapHeader^>^ mySoapHeaders;

   [SoapHeaderAttribute("mySoapHeaders",
      Direction=SoapHeaderDirection::In)]
   [System::Web::Services::Protocols::SoapDocumentMethodAttribute(
      "http://tempuri.org/Add",
      Use=System::Web::Services::Description::SoapBindingUse::Literal,
      ParameterStyle=System::Web::Services::Protocols::SoapParameterStyle::Wrapped)]
   [MySoapExtensionAttribute]
   Single Add( Single xValue, Single yValue )
   {
      // <Snippet2>
      SoapHeaderCollection^ mySoapHeaderCollection = gcnew SoapHeaderCollection;
      MySoapHeader^ mySoapHeader;
      mySoapHeader = gcnew MySoapHeader;
      mySoapHeader->text = "This is the first SOAP header";
      mySoapHeaderCollection->Add( mySoapHeader );
      // </Snippet2>

      // <Snippet3>
      mySoapHeader = gcnew MySoapHeader;
      mySoapHeader->text = "This is the second SOAP header";
      mySoapHeaderCollection->Add( mySoapHeader );
      // </Snippet3>

      // <Snippet4>
      mySoapHeader = gcnew MySoapHeader;
      mySoapHeader->text = "This header is inserted before the first header";
      mySoapHeaderCollection->Insert( 0, mySoapHeader );
      // </Snippet4>

      // <Snippet5>
      mySoapHeaders = gcnew array<MySoapHeader^>(mySoapHeaderCollection->Count);
      mySoapHeaderCollection->CopyTo( mySoapHeaders, 0 );
      // </Snippet5>

      array<Object^>^ temp0 = {xValue,yValue};
      array<Object^>^ results = this->Invoke( "Add", temp0 );
      return ( (Single)( results[ 0 ] ) );
   }
   // </Snippet6>

   [System::Diagnostics::DebuggerStepThroughAttribute]
   MathSvc()
   {
      this->Url = "http://localhost/MathSvc_SoapHeaderCollection.cs.asmx";
   }

   System::IAsyncResult^ BeginAdd( Single xValue,
      Single yValue, System::AsyncCallback^ callback, Object^ asyncState )
   {
      array<Object^>^ temp1 = {xValue,yValue};
      return this->BeginInvoke( "Add", temp1, callback, asyncState );
   }

   Single EndAdd( System::IAsyncResult^ asyncResult )
   {
      array<Object^>^ results = this->EndInvoke( asyncResult );
      return ( (Single)( results[ 0 ] ) );
   }
};
// </Snippet1>

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
      return ( (MySoapExtensionAttribute^)( attribute ) )->Filename;
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

   // Process the SOAP message received and write it to the log file.
   virtual void ProcessMessage( SoapMessage^ message ) override
   {
      switch ( message->Stage )
      {
         case SoapMessageStage::BeforeSerialize:
            break;
         case SoapMessageStage::AfterSerialize:
            WriteOutput( (SoapClientMessage^)( message ) );
            break;
         case SoapMessageStage::BeforeDeserialize:
            WriteInput( (SoapClientMessage^)( message ) );
            break;
         case SoapMessageStage::AfterDeserialize:
            break;
         default:
            throw gcnew Exception( "invalid stage" );
      }
   }

   // Write the contents of the outgoing SOAP message to the log file.
   void WriteOutput( SoapClientMessage^ /*message*/ )
   {
      newStream->Position = 0;
      FileStream^ myFileStream =
         gcnew FileStream( filename, FileMode::Append, FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->WriteLine( "================================== Request at {0}",
         DateTime::Now );
      myStreamWriter->Flush();
      Copy( newStream, myFileStream );
      myStreamWriter->Close();
      myFileStream->Close();
      newStream->Position = 0;
      Copy( newStream, oldStream );
   }

   // Write the contents of the incoming SOAP message to the log file.
   void WriteInput( SoapClientMessage^ /*message*/ )
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
