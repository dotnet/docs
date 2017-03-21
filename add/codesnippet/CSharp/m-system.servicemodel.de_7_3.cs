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