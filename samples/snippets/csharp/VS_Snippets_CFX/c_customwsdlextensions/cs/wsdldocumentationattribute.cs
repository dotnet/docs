using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web.Services.Description;
using System.Xml;
using System.Xml.Schema;

namespace Microsoft.WCF.Documentation
{
  [AttributeUsage(WsdlDocTargets.ContractOrOpTargets, AllowMultiple = false)]
	public class WsdlDocumentationAttribute : 
    Attribute, 
    IContractBehavior, 
		IWsdlExportExtension
	{
		ContractDescription contractDescription;
		OperationDescription operationDescription;
		string text;
    XmlElement customWsdlDocElement = null;

		public WsdlDocumentationAttribute(string text)
		{
			this.text = text;
		}

    /// <summary>
    /// This constructor takes an XmlElement if the sample 
    /// were to be modified to import the documentation element
    /// as XML. This sample does not use this constructor.
    /// </summary>
    /// <param name="wsdlDocElement"></param>
    public WsdlDocumentationAttribute(XmlElement wsdlDocElement)
    {
      this.customWsdlDocElement = wsdlDocElement;
    }

    public XmlElement WsdlDocElement
    {
      get { return this.customWsdlDocElement; }
      set { this.customWsdlDocElement = value; }
    }

		public string Text
		{
			get { return this.text; }
			set { this.text = value; }
		}

		#region WSDL Export
    //<snippet1>
    // <snippet6>
    public void ExportContract(WsdlExporter exporter, WsdlContractConversionContext context)
		{
      // </snippet6>
      // <snippet5>
      // Add a custom DCAnnotationSurrogate to write data contract comments into the XSD.
      object dataContractExporter;
      XsdDataContractExporter xsdDCExporter;
      if (!exporter.State.TryGetValue(typeof(XsdDataContractExporter), out dataContractExporter))
      {
        xsdDCExporter = new XsdDataContractExporter(exporter.GeneratedXmlSchemas);
        exporter.State.Add(typeof(XsdDataContractExporter), xsdDCExporter);
      }
      else
        xsdDCExporter = (XsdDataContractExporter)dataContractExporter;
      if (xsdDCExporter.Options == null)
        xsdDCExporter.Options = new ExportOptions();
      xsdDCExporter.Options.DataContractSurrogate = new DCAnnotationSurrogate();
      // </snippet5>
      // <snippet7>
      Console.WriteLine("Inside ExportContract");
			if (context.Contract != null)
			{
        // Inside this block it is the contract-level comment attribute.
        // This.Text returns the string for the contract attribute.
        // Set the doc element; if this isn't done first, there is no XmlElement in the 
        // DocumentElement property.
        context.WsdlPortType.Documentation = string.Empty; 
        // Contract comments.
        XmlDocument owner = context.WsdlPortType.DocumentationElement.OwnerDocument;
        XmlElement summaryElement = Formatter.CreateSummaryElement(owner, this.Text); 
        context.WsdlPortType.DocumentationElement.AppendChild(summaryElement);

        foreach (OperationDescription op in context.Contract.Operations)
        {
          Operation operation = context.GetOperation(op);
          object[] opAttrs = op.SyncMethod.GetCustomAttributes(typeof(WsdlDocumentationAttribute), false);
          if (opAttrs.Length == 1)
          {
            string opComment = ((WsdlDocumentationAttribute)opAttrs[0]).Text;

            // This.Text returns the string for the operation-level attributes.
            // Set the doc element; if this isn't done first, there is no XmlElement in the 
            // DocumentElement property.
            operation.Documentation = String.Empty;

            // Operation C# triple comments.
            XmlDocument opOwner = operation.DocumentationElement.OwnerDocument;
            XmlElement newSummaryElement = Formatter.CreateSummaryElement(opOwner, opComment);
            operation.DocumentationElement.AppendChild(newSummaryElement);

            // Get returns information
            ParameterInfo returnValue = op.SyncMethod.ReturnParameter;
            object[] returnAttrs = returnValue.GetCustomAttributes(typeof(WsdlParameterDocumentationAttribute), false);
            if (returnAttrs.Length == 1)
            {
              // <returns>text.</returns>
              XmlElement returnsElement = 
                Formatter.CreateReturnsElement(
                  opOwner,
                  ((WsdlParameterDocumentationAttribute)returnAttrs[0]).ParamComment
                );
              operation.DocumentationElement.AppendChild(returnsElement);
            }
            
            // Get parameter information.
            ParameterInfo[] args = op.SyncMethod.GetParameters();
            for (int i = 0; i < args.Length; i++)
            {
              object[] docAttrs 
                = args[i].GetCustomAttributes(typeof(WsdlParameterDocumentationAttribute), false);
              if (docAttrs.Length != 0)
              {
                // <param name="Int1">Text.</param>
                XmlElement newParamElement = opOwner.CreateElement("param");
                XmlAttribute paramName = opOwner.CreateAttribute("name");
                paramName.Value = args[i].Name;
                newParamElement.InnerText 
                  = ((WsdlParameterDocumentationAttribute)docAttrs[0]).ParamComment;
                newParamElement.Attributes.Append(paramName);
                operation.DocumentationElement.AppendChild(newParamElement);
              }
            }
          }
        }
      }
      // </snippet7>
    }
    //</snippet1>


		public void ExportEndpoint(WsdlExporter exporter, WsdlEndpointConversionContext context) 
    {
      Console.WriteLine("ExportEndpoint called.");
    }

		#endregion

    #region IContractBehavior Members

    public void AddBindingParameters(ContractDescription description, ServiceEndpoint endpoint, BindingParameterCollection parameters)
    { return; }

    public void ApplyClientBehavior(ContractDescription description, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    { return; }

    public void ApplyDispatchBehavior(ContractDescription description, ServiceEndpoint endpoint, DispatchRuntime dispatch)
    { return; }

    public void Validate(ContractDescription description, ServiceEndpoint endpoint)
    { return; }

    #endregion

  }

  public static class Targets
  {
    public const AttributeTargets ParamReturnTargets 
      = AttributeTargets.ReturnValue 
      | AttributeTargets.Parameter 
      | AttributeTargets.GenericParameter;
  }

  public static class WsdlDocTargets
  {
    public const AttributeTargets ContractOrOpTargets
      = AttributeTargets.Method
      | AttributeTargets.Interface;
  }

  [AttributeUsage(Targets.ParamReturnTargets)]
  public class WsdlParameterDocumentationAttribute : Attribute
  {
    public WsdlParameterDocumentationAttribute(string docComment)
    {
      this.docValue = docComment;
    }

    string docValue;

    public string ParamComment
    {
      get { return docValue; }
      set { docValue = value; }
    }
  }
}