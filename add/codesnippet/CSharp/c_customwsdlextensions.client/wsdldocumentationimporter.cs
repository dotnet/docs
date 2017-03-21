using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Web.Services.Description;
using System.Xml;
using System.Xml.Schema;

namespace Microsoft.WCF.Documentation
{
	public class WsdlDocumentationImporter : 
    IContractBehavior,
    IOperationBehavior,
    IWsdlImportExtension, 
    IServiceContractGenerationExtension, 
    IOperationContractGenerationExtension
	{
    private string commentText;

		#region WSDL Import
    public WsdlDocumentationImporter()
    { 
    
    }
    
    public WsdlDocumentationImporter(string text)
    {
      this.commentText = text;
      Console.WriteLine("WsdlDocumentationImporter created.");
    }
    // <snippet4>
		public void ImportContract(WsdlImporter importer, WsdlContractConversionContext context)
		{
      Console.Write("ImportContract");
			// Contract Documentation
			if (context.WsdlPortType.Documentation != null)
			{
        context.Contract.Behaviors.Add(new WsdlDocumentationImporter(context.WsdlPortType.Documentation));
			}
			// Operation Documentation
			foreach (Operation operation in context.WsdlPortType.Operations)
			{
				if (operation.Documentation != null)
				{
					OperationDescription operationDescription = context.Contract.Operations.Find(operation.Name);
					if (operationDescription != null)
					{
            operationDescription.Behaviors.Add(new WsdlDocumentationImporter(operation.Documentation));
					}
				}
			}
		}
    // </snippet4>

		public void BeforeImport(ServiceDescriptionCollection wsdlDocuments, XmlSchemaSet xmlSchemas, ICollection<XmlElement> policy) 
    {
      Console.WriteLine("BeforeImport called.");
    }
		public void ImportEndpoint(WsdlImporter importer, WsdlEndpointConversionContext context) 
    {
      Console.WriteLine("ImportEndpoint called.");
    }

		#endregion 
	
    #region IServiceContractGenerationExtension Members
    // <snippet12>
    public void GenerateContract(ServiceContractGenerationContext context)
    {
      Console.WriteLine("In generate contract.");
      context.ContractType.Comments.AddRange(Formatter.FormatComments(commentText));
    }
    // </snippet12>

    #endregion

    #region IOperationContractGenerationExtension Members
    // <snippet14>
    public void GenerateOperation(OperationContractGenerationContext context)
    {
      context.SyncMethod.Comments.AddRange(Formatter.FormatComments(commentText));
      Console.WriteLine("In generate operation.");
    }
    // </snippet14>

    #endregion

    #region IContractBehavior Members

    public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
    {
      return;
    }

    public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
    {
      return;
    }

    public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatchRuntime)
    {
      return;
    }

    public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
    {
      return;
    }

    #endregion

    #region IOperationBehavior Members

    public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
    {
      return;
    }

    public void ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
    {
      return;
    }

    public void ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
    {
      return;
    }

    public void Validate(OperationDescription operationDescription)
    {
      return;
    }

    #endregion
  }
}
