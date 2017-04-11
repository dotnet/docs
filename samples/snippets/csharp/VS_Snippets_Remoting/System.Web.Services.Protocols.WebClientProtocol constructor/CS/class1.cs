using System;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Web.Services.Protocols;
using System.Web.Services;

namespace WebClientProtocol_Constructor {
    // This class derives from System.Web.Services.Protocols.WebClientProtocol
    // as if the user is implemented his own protocol.
    // It demonstrates the use of WebClientProtocol's constructor.
    // <Snippet1>
    [System.Web.Services.WebServiceBindingAttribute(Name="Service1Soap",
         Namespace="http://tempuri.org/")]
    class TempConvertService: System.Web.Services.Protocols.WebClientProtocol 
    {
        public TempConvertService(): base() 
        {
            // Rest of class initialization.
        }    

        // </Snippet1>
        public static void Main() 
        {

        }
    }
}
