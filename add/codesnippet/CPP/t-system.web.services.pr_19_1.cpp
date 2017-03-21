[System::Web::Services::WebServiceBindingAttribute(Name="MathSvcSoap",
   Namespace="http://tempuri.org/")]
public ref class MathSvc: public System::Web::Services::Protocols::SoapHttpClientProtocol
{
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
      SoapHeaderCollection^ mySoapHeaderCollection = gcnew SoapHeaderCollection;
      MySoapHeader^ mySoapHeader;
      mySoapHeader = gcnew MySoapHeader;
      mySoapHeader->text = "This is the first SOAP header";
      mySoapHeaderCollection->Add( mySoapHeader );

      mySoapHeader = gcnew MySoapHeader;
      mySoapHeader->text = "This is the second SOAP header";
      mySoapHeaderCollection->Add( mySoapHeader );

      mySoapHeader = gcnew MySoapHeader;
      mySoapHeader->text = "This header is inserted before the first header";
      mySoapHeaderCollection->Insert( 0, mySoapHeader );

      mySoapHeaders = gcnew array<MySoapHeader^>(mySoapHeaderCollection->Count);
      mySoapHeaderCollection->CopyTo( mySoapHeaders, 0 );

      array<Object^>^ temp0 = {xValue,yValue};
      array<Object^>^ results = this->Invoke( "Add", temp0 );
      return ( (Single)( results[ 0 ] ) );
   }

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