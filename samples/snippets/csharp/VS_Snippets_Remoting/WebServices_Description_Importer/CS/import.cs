// <snippet0>
using System;
using System.Web.Services.Description;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Security.Permissions;

public class Import {

    public static void Main() 
    {
        Run();
    }

    [PermissionSetAttribute(SecurityAction.Demand, Name = "Full Trust")]
    public static void Run()
    {
    // Get a WSDL file describing a service.
    ServiceDescription description = ServiceDescription.Read("service.wsdl");

// <snippet1>
    // Initialize a service description importer.
    ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
    importer.ProtocolName = "Soap12";  // Use SOAP 1.2.
    importer.AddServiceDescription(description,null,null);
// </snippet1>

// <snippet2>
    // Report on the service descriptions.
    Console.WriteLine("Importing {0} service descriptions with {1} associated schemas.",
                      importer.ServiceDescriptions.Count, importer.Schemas.Count);
// </snippet2>

// <snippet3>
    // Generate a proxy client.
    importer.Style = ServiceDescriptionImportStyle.Client;
// </snippet3>

// <snippet4>
    // Generate properties to represent primitive values.
    importer.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties;
// </snippet4>

    // Initialize a Code-DOM tree into which we will import the service.
    CodeNamespace nmspace = new CodeNamespace();
    CodeCompileUnit unit = new CodeCompileUnit();
    unit.Namespaces.Add(nmspace);

// <snippet5>
    // Import the service into the Code-DOM tree. This creates proxy code
    // that uses the service.
    ServiceDescriptionImportWarnings warning = importer.Import(nmspace,unit);

    if (warning == 0)
    {
        // Generate and print the proxy code in C#.
        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
        provider.GenerateCodeFromCompileUnit(unit, Console.Out, new CodeGeneratorOptions() );
    }
    else
    {
        // Print an error message.
        Console.WriteLine(warning); 
    }
// </snippet5>
}


}
// </snippet0>