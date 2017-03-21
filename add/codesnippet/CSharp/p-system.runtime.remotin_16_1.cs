        [SoapMethod(
             ResponseXmlElementName="ExampleResponseElement",
             ResponseXmlNamespace=
                "http://example.org/MethodResponseXmlNamespace",
             ReturnXmlElementName="HelloMessage",
             SoapAction="http://example.org/ExampleSoapAction#GetHello",
             XmlNamespace="http://example.org/MethodCallXmlNamespace")]
        public string GetHello(string name)
        {
            return "Hello, " + name;
        }