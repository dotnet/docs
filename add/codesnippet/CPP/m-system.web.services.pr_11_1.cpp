[System::Web::Services::WebServiceBindingAttribute(Name="Service1Soap",
   Namespace="http://tempuri.org/")]
ref class TempConvertService: public System::Web::Services::Protocols::WebClientProtocol
{
public:
   TempConvertService() : WebClientProtocol()
   {
      // Rest of class initialization.
   }