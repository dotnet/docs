// Snippet for System.ServiceModel.Description.PolicyConversionContext
// Snippet 0
// Snippet 1 public class MyBindingElement : BindingElement, IPolicyExporter
// 001 06-27-2006 a-arhu using System.ServiceModel.Channels
 

using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml;
using System.IdentityModel;
using System.Text;
using System.ServiceModel.Channels;


// MetadataImporter is abstract class
// wsdlImporter is concrete class derived from MetadataImporter
// 
//
namespace CS
{


    class Program
    {
// <Snippet0>    
        public void ImportPolicy(MetadataImporter importer, 
            PolicyConversionContext context)
        {
            Console.WriteLine("The custom policy importer has been called.");
            foreach (XmlElement assertion in context.GetBindingAssertions())
            {
                // locate a particular assertion by Name and NamespaceURI
                if ((assertion.Name == "name") && 
                    assertion.NamespaceURI == "http://localhost/name/uri")
                {
                    // write assertion name in red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(assertion.NamespaceURI + " : " + assertion.Name);

                    //write contents in gray.
                    Console.WriteLine(assertion.OuterXml);
                    Console.ForegroundColor = ConsoleColor.Gray; 

                    // Here if you find the custom policy assertion that you are looking for,
                    // add the custom binding element that handles the functionality that the policy indicates
                    // Attach it to the PolicyConversionContext.BindingElements collection.
                    // For example, if the custom policy had a "speed" attribute value:
                    /*
                      string speed = assertion.GetAttribute(SpeedBindingElement.name2, SpeedBindingElement.ns2);
                      SpeedBindingElement e = new SpeedBindingElement(speed);
                      context.BindingElements.Add(e);
                      // remove your custom assertion from the assertions collection.
                      context.GetBindingAssertions()Remove(assertion);
                    */
                    continue;
                }
            Console.WriteLine(assertion.NamespaceURI + " : " + assertion.Name);
        }
      }
// </Snippet0>
	
      static void CallFromMain(string[] args)
      {
	//<snippet10>
          // make endpoint address
          EndpointAddress mexAddress = new EndpointAddress("http://localhost:8080/ServiceMetadata/mex");

          // Download all metadata. The policy importer runs automatically.p
          ServiceEndpointCollection endpoints
            = MetadataResolver.Resolve(
              typeof(IStatefulService),
              new EndpointAddress("http://localhost:8080/StatefulService/mex")
            );
          //</snippet10>

          MetadataExchangeClient mexClient = 
              new MetadataExchangeClient(mexAddress);
          mexClient.ResolveMetadataReferences = true;

          MetadataSet metaDocs = mexClient.GetMetadata();

          WsdlImporter importer = new WsdlImporter(metaDocs);
          // This is not neccesary for this snippet.
          // PolicyConversionContext myPolicyConversionContext = new PolicyConversionContext ();
          //ImportPolicy(importer, myPolicyConversionContext);
	  
      }  

  }

}    

namespace CS2
{
// <Snippet1>
	public class MyBindingElement : BindingElement, IPolicyExportExtension
	{
	// BindingElement implementation . . .

		public void ExportPolicy(
		 MetadataExporter exporter, PolicyConversionContext context)
		{
			XmlDocument xmlDoc = new XmlDocument();
			XmlElement xmlElement = 
			       xmlDoc.CreateElement("MyPolicyAssertion");
			context.GetBindingAssertions().Add(xmlElement);
		}


		// Note: All custom binding elements must return a deep clone 
		// to enable the run time to support multiple bindings using the 
		// same custom binding.
		public override BindingElement Clone()
		{
			// this is just a placeholder
			return this;
		}


		// Call the inner property.
		public override T GetProperty<T>(BindingContext context)
		{
			return context.GetInnerProperty<T>();
		}

	}

	public class Program {
		public static void Main(string[] args) {
			EndpointAddress address = 
				new EndpointAddress("http://localhost/metadata");
			CustomBinding customBinding = 
				new CustomBinding(new BasicHttpBinding());
			customBinding.Elements.Add(new MyBindingElement());
			ContractDescription contract =
                ContractDescription.GetContract(
                    typeof(StatefulServiceClient));
			ServiceEndpoint endpoint =
                new ServiceEndpoint(contract, new WSHttpBinding(), address);

			MetadataExporter exporter = new WsdlExporter();
			exporter.ExportEndpoint(endpoint);
		}
	}
// </Snippet1>


}
