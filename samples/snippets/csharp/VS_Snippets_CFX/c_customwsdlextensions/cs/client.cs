using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Runtime.Serialization;

namespace Microsoft.WCF.Documentation
{
	class Client
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Press Any Key to Start");
			Console.ReadLine();

			// Create Client
      ChannelFactory<IFibonacci> channelFactory = new ChannelFactory<IFibonacci>("");
			IFibonacci fibonacci = channelFactory.CreateChannel();

			GenerateCSCodeForService(
        new EndpointAddress("http://localhost:8000/Fibonacci/mex/"), 
        System.Environment.CurrentDirectory + "\\..\\..\\GeneratedContract.cs"
      );

      GenerateVBCodeForService(
        new EndpointAddress("http://localhost:8000/Fibonacci/mex/"),
        System.Environment.CurrentDirectory + "\\..\\..\\GeneratedContract.vb"
      );

      // Input Loop
			int input;
			Console.Write("Fibonacci Number: ");
			while (int.TryParse(Console.ReadLine(), out input))
      {
				Console.WriteLine(fibonacci.Compute(input));
				Console.Write("Fibonacci Number: ");
			}

			// Cleanup
      channelFactory.Close();
		}
    //<snippet8>
		static void GenerateCSCodeForService(EndpointAddress metadataAddress, string outputFile)
		{
      //<snippet10>
      MetadataExchangeClient mexClient = new MetadataExchangeClient(metadataAddress);
      mexClient.ResolveMetadataReferences = true;
      MetadataSet metaDocs = mexClient.GetMetadata();
 
			WsdlImporter importer = new WsdlImporter(metaDocs);
      ServiceContractGenerator generator = new ServiceContractGenerator();
      //</snippet10>

      // Add our custom DCAnnotationSurrogate 
      // to write XSD annotations into the comments.
      object dataContractImporter;
      XsdDataContractImporter xsdDCImporter;
      if (!importer.State.TryGetValue(typeof(XsdDataContractImporter), out dataContractImporter))
      {
        Console.WriteLine("Couldn't find the XsdDataContractImporter! Adding custom importer.");
        xsdDCImporter = new XsdDataContractImporter();
        xsdDCImporter.Options = new ImportOptions();
        importer.State.Add(typeof(XsdDataContractImporter), xsdDCImporter);
      }
      else
      {
        xsdDCImporter = (XsdDataContractImporter)dataContractImporter;
        if (xsdDCImporter.Options == null)
        {
          Console.WriteLine("There were no ImportOptions on the importer.");
          xsdDCImporter.Options = new ImportOptions();
        }
      }
      xsdDCImporter.Options.DataContractSurrogate = new DCAnnotationSurrogate();

      // Uncomment the following code if you are going to do your work programmatically rather than add 
      // the WsdlDocumentationImporters through a configuration file. 
      /*
      // <snippet11>
      // The following code inserts a custom WsdlImporter without removing the other 
      // importers already in the collection.
      System.Collections.Generic.IEnumerable<IWsdlImportExtension> exts = importer.WsdlImportExtensions;
      System.Collections.Generic.List<IWsdlImportExtension> newExts 
        = new System.Collections.Generic.List<IWsdlImportExtension>();
      foreach (IWsdlImportExtension ext in exts)
      {
        Console.WriteLine("Default WSDL import extensions: {0}", ext.GetType().Name);
        newExts.Add(ext);
      }
      newExts.Add(new WsdlDocumentationImporter());
      System.Collections.Generic.IEnumerable<IPolicyImportExtension> polExts = importer.PolicyImportExtensions;
      importer = new WsdlImporter(metaDocs, polExts, newExts);
      // </snippet11>
      */

      System.Collections.ObjectModel.Collection<ContractDescription> contracts 
        = importer.ImportAllContracts();
      importer.ImportAllEndpoints();
			foreach (ContractDescription contract in contracts)
			{
				generator.GenerateServiceContractType(contract);
			}
      if (generator.Errors.Count != 0)
        throw new Exception("There were errors during code compilation.");

      // Write the code dom
      System.CodeDom.Compiler.CodeGeneratorOptions options 
        = new System.CodeDom.Compiler.CodeGeneratorOptions();
			options.BracingStyle = "C";
			System.CodeDom.Compiler.CodeDomProvider codeDomProvider 
        = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("C#");
			System.CodeDom.Compiler.IndentedTextWriter textWriter 
        = new System.CodeDom.Compiler.IndentedTextWriter(new System.IO.StreamWriter(outputFile));
			codeDomProvider.GenerateCodeFromCompileUnit(
        generator.TargetCompileUnit, textWriter, options
      );
			textWriter.Close();
		}
    //</snippet8>

    static void GenerateVBCodeForService(EndpointAddress metadataAddress, string outputFile)
    {
      MetadataExchangeClient mexClient = new MetadataExchangeClient(metadataAddress);
      mexClient.ResolveMetadataReferences = true;
      MetadataSet metaDocs = mexClient.GetMetadata();

      WsdlImporter importer = new WsdlImporter(metaDocs);
      ServiceContractGenerator generator = new ServiceContractGenerator();

      // Add our custom DCAnnotationSurrogate 
      // to write XSD annotations into the comments.
      object dataContractImporter;
      XsdDataContractImporter xsdDCImporter;
      if (!importer.State.TryGetValue(typeof(XsdDataContractImporter), out dataContractImporter))
      {
        Console.WriteLine("Couldn't find the XsdDataContractImporter! Adding custom importer.");
        xsdDCImporter = new XsdDataContractImporter();
        xsdDCImporter.Options = new ImportOptions();
        importer.State.Add(typeof(XsdDataContractImporter), xsdDCImporter);
      }
      else
      {
        xsdDCImporter = (XsdDataContractImporter)dataContractImporter;
        if (xsdDCImporter.Options == null)
        {
          Console.WriteLine("There were no ImportOptions on the importer.");
          xsdDCImporter.Options = new ImportOptions();
        }
      }
      xsdDCImporter.Options.DataContractSurrogate = new DCAnnotationSurrogate();

      // Uncomment the following code if you are going to do your work programmatically rather than add 
      // the WsdlDocumentationImporters through a configuration file. 
      /*
      // The following code inserts the custom WSDL programmatically 
      // adding the custom WsdlImporter without removing the other 
      // importers already in the collection.
      System.Collections.Generic.IEnumerable<IWsdlImportExtension> exts = importer.WsdlImportExtensions;
      System.Collections.Generic.List<IWsdlImportExtension> newExts 
        = new System.Collections.Generic.List<IWsdlImportExtension>();
      foreach (IWsdlImportExtension ext in exts)
      {
        Console.WriteLine("Default WSDL import extensions: {0}", ext.GetType().Name);
        newExts.Add(ext);
      }
      newExts.Add(new WsdlDocumentationImporter());
      System.Collections.Generic.IEnumerable<IPolicyImportExtension> polExts = importer.PolicyImportExtensions;
      importer = new WsdlImporter(metaDocs, polExts, newExts);
      */

      System.Collections.ObjectModel.Collection<ContractDescription> contracts = importer.ImportAllContracts();
      foreach (ContractDescription contract in contracts)
      {
        generator.GenerateServiceContractType(contract);
      }
      if (generator.Errors.Count != 0)
        throw new Exception("There were errors during code compilation.");
 
      // Write the code dom.
      System.CodeDom.Compiler.CodeGeneratorOptions options = new System.CodeDom.Compiler.CodeGeneratorOptions();
      options.BracingStyle = "C";
      System.CodeDom.Compiler.CodeDomProvider codeDomProvider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("VB");
      System.CodeDom.Compiler.IndentedTextWriter textWriter = new System.CodeDom.Compiler.IndentedTextWriter(new System.IO.StreamWriter(outputFile));
      codeDomProvider.GenerateCodeFromCompileUnit(generator.TargetCompileUnit, textWriter, options);
      textWriter.Close();
    }
  }
}
