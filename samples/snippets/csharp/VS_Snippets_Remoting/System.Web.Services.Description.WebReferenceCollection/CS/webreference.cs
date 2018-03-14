/// Class: System.Web.Services.Description.WebReferenceCollection
/// 10 Item[Int32]
/// 10 Contains(WebReference)
/// 10 CopyTo(WebReference[],Int32)
/// 10 IndexOf(WebReference)
/// 10 Insert(Int32,WebReference)
/// 10 Remove(WebReference)

/// Temporary URL for testing:
/// string url = "http://a-assim-jalis/Example/S4_WebService.asmx?WSDL";
/// string url = "http://www.contoso.com/Example/WebService.asmx?WSDL";

//<snippet10>
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
        // Read in a WSDL service description.
        string url = "http://www.contoso.com/Example/WebService.asmx?WSDL";
        XmlTextReader reader = new XmlTextReader(url);
        ServiceDescription wsdl = ServiceDescription.Read(reader);

        // Create a WSDL collection.
        DiscoveryClientDocumentCollection wsdlCollection = 
            new DiscoveryClientDocumentCollection();
        wsdlCollection.Add(url, wsdl);

        // Define the parameters needed to create web references.
        CodeNamespace proxyNamespace = new CodeNamespace("ExampleNamespace");
        string baseUrl = "http://www.contoso.com";
        string protocolName = "Soap12";

        // Create some web references.
        WebReference reference1 = new WebReference(
            wsdlCollection, proxyNamespace, protocolName, 
            "UrlKey1", baseUrl);
        WebReference reference2 = new WebReference(
            wsdlCollection, proxyNamespace, protocolName, 
            "UrlKey2", baseUrl);
        WebReference reference3 = new WebReference(
            wsdlCollection, proxyNamespace, protocolName, 
            "UrlKey3", baseUrl);

        // Create a web reference collection.
        WebReferenceCollection references = new WebReferenceCollection();
        references.Add(reference1);
        references.Add(reference2);

        // Confirm that the references were inserted.
        Console.WriteLine("The collection contains {0} references.", 
            references.Count);

        // Insert another reference into the collection.
        references.Insert(2, reference3);

        // Print the index of the inserted reference.
        int index = references.IndexOf(reference3);
        Console.WriteLine("The index of reference3 is {0}.", index);

        // Remove the inserted reference from the collection.
        references.Remove(reference3);

        // Determine if the collection contains reference3.
        if (references.Contains(reference3))
        {
            Console.WriteLine("The collection contains reference3.");
        }
        else 
        {
            Console.WriteLine("The collection does not contain reference3.");
        }

        // Print the URL key of the first reference in the collection.
        Console.WriteLine(
            "The URL key of the first reference in the collection is {0}.",
            references[0].AppSettingUrlKey);

        // Copy the collection to an array leaving the first array slot empty.
        WebReference[] referenceArray = new WebReference[3];
        references.CopyTo(referenceArray, 1);
        Console.WriteLine(
            "The URL key of the first reference in the array is {0}.",
            referenceArray[1].AppSettingUrlKey);
    }
}
//</snippet10>
