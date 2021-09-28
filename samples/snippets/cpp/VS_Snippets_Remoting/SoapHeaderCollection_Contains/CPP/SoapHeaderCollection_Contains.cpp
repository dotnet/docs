// System.Web.Services.Protocols.SoapHeaderCollection.Contains(SoapHeader); System.Web.Services.Protocols.SoapHeaderCollection.IndexOf(); System.Web.Services.Protocols.SoapHeaderCollection.Item; System.Web.Services.Protocols.SoapHeaderCollection.Remove(SoapHeader)

/*
The following example demonstrates the methods 'Contains','IndexOf' and
'Remove' and the property 'Item' of the 'SoapHeaderCollection' class. The
program extends the 'SoapExtension' class to create a class that is
used to log the SOAP messages transferred for a web service method
invocation. Whenever this method is invoked on the client side
all the SOAP message that get transfered both from the client
and the server are written into a log file.
*/

#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Web::Services::Protocols;
using namespace System::Web::Services;
using namespace System::Xml;

ref class MySoapExtension;

// A 'SoapExtensionAttribute' that can be associated with web service method.

[AttributeUsage(AttributeTargets::Method)]
public ref class MySoapExtensionAttribute: public SoapExtensionAttribute
{
private:
   String^ myFilename;
   int myPriority;

public:

   // Set the name of the log file were SOAP messages will be stored.
   MySoapExtensionAttribute()
      : SoapExtensionAttribute()
   {
      myFilename = "C:\\logClient.txt";
   }

   property Type^ ExtensionType 
   {
      // Return the type of 'MySoapExtension' class.
      virtual Type^ get() override
      {
         return MySoapExtension::typeid;
      }
   }

   property int Priority 
   {
      // User can set priority of the 'SoapExtension'.
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
   String^ Text;
};

[System::Web::Services::WebServiceBindingAttribute(Name="MathSvcSoap",Namespace="http://tempuri.org/")]
public ref class MathService: public System::Web::Services::Protocols::SoapHttpClientProtocol
{
public:
   array<SoapHeader^>^mySoapHeaders;

   [SoapHeaderAttribute("mySoapHeaders",Direction=SoapHeaderDirection::In,Required=false)]
   [System::Web::Services::Protocols::SoapDocumentMethodAttribute("http://tempuri.org/Add",
   Use=System::Web::Services::Description::SoapBindingUse::Literal,
   ParameterStyle=System::Web::Services::Protocols::SoapParameterStyle::Wrapped)]
   [MySoapExtensionAttribute]
   Single Add( Single xValue, Single yValue )
   {
      SoapHeaderCollection^ mySoapHeaderCollection = gcnew SoapHeaderCollection;
      MySoapHeader^ myFirstSoapHeader;
      myFirstSoapHeader = gcnew MySoapHeader;
      myFirstSoapHeader->Text = "This is the first soap header";
      mySoapHeaderCollection->Add( myFirstSoapHeader );
      MySoapHeader^ mySecondSoapHeader = gcnew MySoapHeader;
      mySecondSoapHeader->Text = "This is the second soap header";
      mySoapHeaderCollection->Add( mySecondSoapHeader );

      // <Snippet1>
      // Check to see whether the collection contains mySecondSoapHeader.
      if ( mySoapHeaderCollection->Contains( mySecondSoapHeader ) )
      {
         // Get the index of mySecondSoapHeader from the collection.
         Console::WriteLine( "Index of mySecondSoapHeader: {0}", mySoapHeaderCollection->IndexOf( mySecondSoapHeader ) );

         // Get the SoapHeader from the collection.
         MySoapHeader^ mySoapHeader1 = dynamic_cast<MySoapHeader^>(mySoapHeaderCollection[ mySoapHeaderCollection->IndexOf( mySecondSoapHeader ) ]);
         Console::WriteLine( "SoapHeader retrieved from the collection: {0}", mySoapHeader1 );

         // Remove a SoapHeader from the collection.
         mySoapHeaderCollection->Remove( mySoapHeader1 );
         Console::WriteLine( "Number of items after removal: {0}", mySoapHeaderCollection->Count );
      }
      else
            Console::WriteLine( "mySoapHeaderCollection does not contain mySecondSoapHeader." );
      // </Snippet1>

      mySoapHeaders = gcnew array<MySoapHeader^>(mySoapHeaderCollection->Count);
      mySoapHeaderCollection->CopyTo( mySoapHeaders, 0 );
      array<Object^>^temp0 = {xValue,yValue};
      array<Object^>^results = this->Invoke( "Add", temp0 );
      return safe_cast<Single>(results[ 0 ]);
   }

   [System::Diagnostics::DebuggerStepThroughAttribute]
   MathService()
   {
      this->Url = "http://localhost/MathService_SoapHeaderCollection.cs.asmx";
   }

   System::IAsyncResult^ BeginAdd( Single xValue, Single yValue, System::AsyncCallback^ callback, Object^ asyncState )
   {
      array<Object^>^temp1 = {xValue,yValue};
      return this->BeginInvoke( "Add", temp1, callback, asyncState );
   }

   Single EndAdd( System::IAsyncResult^ asyncResult )
   {
      array<Object^>^results = this->EndInvoke( asyncResult );
      return safe_cast<Single>(results[ 0 ]);
   }

};

public ref class MySoapExtension: public SoapExtension
{
private:
   Stream^ oldStream;
   Stream^ newStream;
   String^ myFilename;

public:

   // Return the filename that is to log the SOAP messages.
   virtual Object^ GetInitializer( LogicalMethodInfo^ /*methodInfo*/, SoapExtensionAttribute^ myAttribute ) override
   {
      return (dynamic_cast<MySoapExtensionAttribute^>(myAttribute))->Filename;
   }

   // Return the filename that is to log the SOAP messages.
   virtual Object^ GetInitializer( Type^ myFilename ) override
   {
      return dynamic_cast<Type^>(myFilename);
   }

   // Save the name of the log file that shall save the SOAP messages.
   virtual void Initialize( Object^ initializer ) override
   {
      myFilename = dynamic_cast<String^>(initializer);
   }

   // Process the SOAP message received and write to log file.
   virtual void ProcessMessage( SoapMessage^ message ) override
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
   void WriteOutput( SoapClientMessage^ /*message*/ )
   {
      newStream->Position = 0;
      FileStream^ myFileStream = gcnew FileStream( myFilename,FileMode::Append,FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->WriteLine( "================================== Request at {0}", DateTime::Now );
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
      FileStream^ myFileStream = gcnew FileStream( myFilename,FileMode::Append,FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myStreamWriter->WriteLine( "---------------------------------- Response at {0}", DateTime::Now );
      myStreamWriter->Flush();
      newStream->Position = 0;
      Copy( newStream, myFileStream );
      myStreamWriter->Close();
      myFileStream->Close();
      newStream->Position = 0;
   }

   // Return a new 'MemoryStream' instance for SOAP processing.
   virtual Stream^ ChainStream( Stream^ myStream ) override
   {
      oldStream = myStream;
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
