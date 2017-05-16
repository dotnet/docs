// Snippet for System.ServiceModel.Description.PolicyConversionContext
// Snippet 0
// Snippet 1 public class MyBindingElement : BindingElement,IPolicyExporter  
// Snippet 2 implement
// System.ServiceModel.Description.IPolicyExportExtension
// 001 06-27-2006 a-arhu using System.ServiceModel.Channels
// 002 07-11-2006 a-arhu put in snippet2

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
    class Program
    {
      string name1 = String.Empty;
      string ns1 = String.Empty;
// <snippet0>    
        public void ImportPolicy(MetadataImporter importer, 
            PolicyConversionContext context)
        {
            Console.WriteLine("The custom policy importer has been called.");
            foreach (XmlElement assertion in context.GetBindingAssertions())
            {
                Console.WriteLine(assertion.NamespaceURI + " : " + assertion.Name);
                // locate a particular assertion by Name and NamespaceURI
                XmlElement customAssertion = context.GetBindingAssertions().Find(name1, ns1);
                if (customAssertion != null)
                {
                  // Found assertion; remove from collection.
                  context.GetBindingAssertions().Remove(customAssertion);
                  Console.WriteLine(
                    "Removed our custom assertion from the imported "
                    + "assertions collection and inserting our custom binding element."
                  );
                    // Here if you find the custom policy assertion that you are looking for,
                    // add the custom binding element that handles the functionality that the policy indicates.
                    // Attach it to the PolicyConversionContext.BindingElements collection.
                    // For example, if the custom policy had a "speed" attribute value:
                    /*
                      string speed 
                        = customAssertion.GetAttribute(SpeedBindingElement.name2, SpeedBindingElement.ns2);
                      SpeedBindingElement e = new SpeedBindingElement(speed);
                      context.BindingElements.Add(e);
                    */
                }

                // write assertion name in red.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(assertion.NamespaceURI + " : " + assertion.Name);

                //write contents in gray.
                Console.WriteLine(assertion.OuterXml);
                Console.ForegroundColor = ConsoleColor.Gray; 
            }
        }
// </snippet0>
	
      static void Main2(string[] args)
      {
          // make endpoint address
          EndpointAddress mexAddress = new EndpointAddress("http://localhost:8080/ServiceMetadata/mex");
/*
          // Download all metadata. The policy importer runs automatically.
          ServiceEndpointCollection endpoints = 
              MetadataResolver.Resolve(
	         typeof(IStatefulService),
	          mexAddress);

          MetadataExchangeClient mexClient = 
              new MetadataExchangeClient(mexAddress);
          mexClient.ResolveMetadataReferences = true;

          MetadataSet metaDocs = mexClient.GetMetadata();

          WsdlImporter importer = new WsdlImporter(metaDocs);
          PolicyConversionContext myPolicyConversionContext = new PolicyConversionContext ();
          ImportPolicy(importer, myPolicyConversionContext);
*/	  
      }  

  }

namespace CS2
{
// <snippet1>
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
			return null;
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
				ContractDescription.GetContract(typeof(MyContract));
			ServiceEndpoint endpoint = 
				new ServiceEndpoint(contract, customBinding, address);
			MetadataExporter exporter = new WsdlExporter();
			exporter.ExportEndpoint(endpoint);
		}
	}
// </snippet1>
}
