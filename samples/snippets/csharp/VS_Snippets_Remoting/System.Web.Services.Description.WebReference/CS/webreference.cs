/// Class: System.Web.Services.Description.WebReference
/// 11 #ctor(DocumentCollection,CodeNamespace,String,String,String)
/// 11 ProxyCode
/// 11 ValidationWarnings
/// 11 Warnings

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Discovery;
using System.Xml;
using System.Xml.Serialization;

public class Test
{
    public static void Main ()
    {
        //<snippet11>
        // Read in a WSDL service description.
        string url = "http://www.contoso.com/Example/WebService.asmx?WSDL";
        XmlTextReader reader = new XmlTextReader(url);
        ServiceDescription wsdl = ServiceDescription.Read(reader);

        // Create a WSDL collection.
        DiscoveryClientDocumentCollection wsdlCollection = 
            new DiscoveryClientDocumentCollection();
        wsdlCollection.Add(url, wsdl);

        // Create a namespace.
        CodeNamespace proxyNamespace = new CodeNamespace("ExampleNamespace");

        // Create a web reference using the WSDL collection.
        string baseUrl = "http://www.contoso.com";
        string urlKey = "ExampleUrlKey";
        string protocolName = "Soap12";
        WebReference reference = new WebReference(
            wsdlCollection, proxyNamespace, protocolName, urlKey, baseUrl);

        // Print some information about the web reference.
        Console.WriteLine("The WebReference object contains {0} document(s).", 
            reference.Documents.Count);
        Console.WriteLine("The protocol name is {0}.", reference.ProtocolName);
        Console.WriteLine("The base URL is {0}.", reference.AppSettingBaseUrl);
        Console.WriteLine("The URL key is {0}.", reference.AppSettingUrlKey);

        // Print some information about the proxy code namespace.
        Console.WriteLine("The proxy code namespace is {0}.", 
            reference.ProxyCode.Name);

        // Print some information about the validation warnings.
        Console.WriteLine("There are {0} validation warnings.",
            reference.ValidationWarnings.Count);

        // Print some information about the warnings.
        if (reference.Warnings == 0)
        {
            Console.WriteLine("There are no warnings.");
        }
        else
        {
            Console.WriteLine("Warnings: " + reference.Warnings);
        }
        //</snippet11>
    }
}
