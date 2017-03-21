      [SoapMethod(
         ResponseXmlElementName="ExampleResponseElement",
         ResponseXmlNamespace=
         "http://example.org/MethodResponseXmlNamespace",
         ReturnXmlElementName="HelloMessage",
         SoapAction="http://example.org/ExampleSoapAction#GetHello",
         XmlNamespace="http://example.org/MethodCallXmlNamespace")]
      String^ GetHello( String^ name )
      {
         return String::Format( L"Hello, {0}", name );
      }