// <snippet0>
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Security.Permissions;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Discovery;
using System.Xml;
using System.Xml.Serialization;

class Test
{

    [SecurityPermissionAttribute(SecurityAction.Demand, Unrestricted=true)]
    static void Run(){

   // Get a WSDL file describing a service.
        ServiceDescription description = ServiceDescription.Read("DataTypes_CS.wsdl");

    // Initialize a service description importer.
    ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
    importer.ProtocolName = "Soap12";  // Use SOAP 1.2.
    importer.AddServiceDescription(description,null,null);

    // Report on the service descriptions.
    Console.WriteLine("Importing {0} service descriptions with {1} associated schemas.",
                      importer.ServiceDescriptions.Count, importer.Schemas.Count);

    // Generate a proxy client.
    importer.Style = ServiceDescriptionImportStyle.Client;

    // Generate properties to represent primitive values.
    importer.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties;

    // Initialize a Code-DOM tree into which we will import the service.
    CodeNamespace nmspace = new CodeNamespace();
    CodeCompileUnit unit1 = new CodeCompileUnit();
    unit1.Namespaces.Add(nmspace);

    // Import the service into the Code-DOM tree. This creates proxy code
    // that uses the service.
    ServiceDescriptionImportWarnings warning = importer.Import(nmspace, unit1);

    if (warning == 0)
    {
        // Generate and print the proxy code in C#.
        CodeDomProvider provider1 = CodeDomProvider.CreateProvider("CSharp");
        provider1.GenerateCodeFromCompileUnit(unit1, Console.Out, new CodeGeneratorOptions());
    }
    else
    {
        // Print an error message.
        Console.WriteLine("Warning: " + warning); 
    }


        string url = "AddNumbers.wsdl";

// <snippet1>
        // Read in a WSDL service description.
        XmlTextReader reader = new XmlTextReader(url);
        ServiceDescription wsdl = ServiceDescription.Read(reader);
// </snippet1>

// <snippet2>
        // Create a WSDL collection.
        DiscoveryClientDocumentCollection wsdlCollection = new DiscoveryClientDocumentCollection();
        wsdlCollection.Add(url, wsdl);
// </snippet2>

// <snippet3>
        // Create a namespace and a unit for compilation.
        CodeNamespace space = new CodeNamespace();
        CodeCompileUnit unit = new CodeCompileUnit();
        unit.Namespaces.Add(space);
// </snippet3>

// <snippet4>
        // Create a web referernce using the WSDL collection.
        WebReference reference = new WebReference(wsdlCollection, space);
        reference.ProtocolName = "Soap12";
// </snippet4>

// <snippet5>
        // Print some information about the web reference.
        Console.WriteLine("Base Url = {0}", reference.AppSettingBaseUrl);
        Console.WriteLine("Url Key = {0}", reference.AppSettingUrlKey);
        Console.WriteLine("Documents = {0}", reference.Documents.Count);
// </snippet5>

// <snippet6>
        // Create a web reference collection.
        WebReferenceCollection references = new WebReferenceCollection();
        references.Add(reference);
// </snippet6>

// <snippet7>
        // Compile a proxy client and print out the code. 
        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
        WebReferenceOptions options = new WebReferenceOptions();
        options.Style = ServiceDescriptionImportStyle.Client;
        options.CodeGenerationOptions = CodeGenerationOptions.GenerateNewAsync;
        ServiceDescriptionImporter.GenerateWebReferences(
            references,
            provider,
            unit,
            options        
        );
        provider.GenerateCodeFromCompileUnit(unit, Console.Out, new CodeGeneratorOptions() );          
// </snippet7>
    
    }

    static void Main ()
    {

        Test.Run();
 

    }
}
// </snippet0>
