
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml;
using System.Runtime.Serialization;


namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            string outputFile = "c:\\temp\\test";
            

            //<Snippet0>
            EndpointAddress mexAddress = new EndpointAddress("http://localhost:8000/ServiceModelSamples/service/mex");
            //</Snippet0>

            //<Snippet1>
            MetadataExchangeClient mexClient = new MetadataExchangeClient(mexAddress);
            mexClient.ResolveMetadataReferences = true;
            MetadataSet metaSet = mexClient.GetMetadata();
            //</Snippet1>

            //<Snippet2>
            WsdlImporter importer = new WsdlImporter(metaSet);
            System.Collections.ObjectModel.Collection<ContractDescription> contracts = importer.ImportAllContracts();
            //</Snippet2>

            //<Snippet3>
            ServiceContractGenerator generator = new ServiceContractGenerator();
			foreach (ContractDescription contract in contracts)
			{
				generator.GenerateServiceContractType(contract);
			}

            if (generator.Errors.Count != 0)
                throw new Exception("There were errors during code compilation.");
            //</Snippet3>


            // Write the code dom
            //<Snippet4>
            System.CodeDom.Compiler.CodeGeneratorOptions options = new System.CodeDom.Compiler.CodeGeneratorOptions();
			options.BracingStyle = "C";
			System.CodeDom.Compiler.CodeDomProvider codeDomProvider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("C#");
			System.CodeDom.Compiler.IndentedTextWriter textWriter = new System.CodeDom.Compiler.IndentedTextWriter(new System.IO.StreamWriter(outputFile));
			codeDomProvider.GenerateCodeFromCompileUnit(generator.TargetCompileUnit, textWriter, options);
			textWriter.Close();
            //</Snippet4>


            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
