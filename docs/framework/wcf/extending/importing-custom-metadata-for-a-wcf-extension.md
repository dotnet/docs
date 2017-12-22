---
title: "Importing Custom Metadata for a WCF Extension"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 78beb28f-408a-4c75-9c3c-caefe9595b1a
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Importing Custom Metadata for a WCF Extension
In [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], metadata import is the process of generating an abstract representation of a service or its component parts from its metadata. For example, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can import <xref:System.ServiceModel.Description.ServiceEndpoint> instances, <xref:System.ServiceModel.Channels.Binding> instances or <xref:System.ServiceModel.Description.ContractDescription> instances from a WSDL document for a service. To import service metadata in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], use an implementation of the <xref:System.ServiceModel.Description.MetadataImporter?displayProperty=nameWithType> abstract class. Types that derive from the <xref:System.ServiceModel.Description.MetadataImporter> class implement support for importing metadata formats that take advantage of the WS-Policy import logic in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
 Custom metadata consists of XML elements that the system-provided metadata importers cannot import. Typically, this includes custom WSDL extensions and custom policy assertions.  
  
 This section describes how to import custom WSDL extensions and policy assertions. It does not focus on the importing process itself. For more information about how to use the types that export and import metadata regardless of whether the metadata is custom or system-supported, see [Exporting and Importing Metadata](../../../../docs/framework/wcf/feature-details/exporting-and-importing-metadata.md).  
  
## Overview  
 The <xref:System.ServiceModel.Description.WsdlImporter?displayProperty=nameWithType> type is the implementation of the <xref:System.ServiceModel.Description.MetadataImporter> abstract class included with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. The <xref:System.ServiceModel.Description.WsdlImporter> type imports WSDL metadata with attached policies that are bundled in a <xref:System.ServiceModel.Description.MetadataSet?displayProperty=nameWithType> object. Policy assertions and WSDL extensions that the default importers do not recognize are passed to any registered custom policy and WSDL importers for importing. Typically, importers are implemented to support user-defined binding elements or to modify the imported contract.  
  
 This section describes:  
  
1.  How to implement and use the <xref:System.ServiceModel.Description.IWsdlImportExtension?displayProperty=nameWithType> interface, which exposes the WSDL data to custom importers prior to the generation of descriptions and the generation of code. You can use this interface to examine or modify the description types and code compilation performed using a given set of metadata.  
  
2.  How to implement and use the <xref:System.ServiceModel.Description.IPolicyImportExtension?displayProperty=nameWithType> interface, which exposes policy assertions to importers prior to the generation of description objects. You can use this interface to examine or modify the binding or contract based on the downloaded policies.  
  
 For more information about exporting custom WSDL and policy assertions, see [Exporting Custom Metadata for a WCF Extension](../../../../docs/framework/wcf/extending/exporting-custom-metadata-for-a-wcf-extension.md).  
  
## Importing Custom WSDL Extensions  
 To add support for importing WSDL extensions, implement the <xref:System.ServiceModel.Description.IWsdlImportExtension> interface and then add your implementation to the <xref:System.ServiceModel.Description.WsdlImporter.WsdlImportExtensions%2A> property. The <xref:System.ServiceModel.Description.WsdlImporter> can also load implementations of the <xref:System.ServiceModel.Description.IWsdlImportExtension> interface registered in your application configuration file. Note that a number of WSDL importers are registered by default and the order of the registered WSDL importers is significant.  
  
 When the custom WSDL importer is loaded and used by the <xref:System.ServiceModel.Description.WsdlImporter>, first the <xref:System.ServiceModel.Description.IWsdlImportExtension.BeforeImport%2A> method is called to enable the modification of metadata prior to the import process. Next, the contracts are imported after which the <xref:System.ServiceModel.Description.IWsdlImportExtension.ImportContract%2A> method is called to enable the modification of the contracts imported from the metadata. Finally, the <xref:System.ServiceModel.Description.IWsdlImportExtension.ImportEndpoint%2A> method is called to enable the modification of the imported endpoints.  
  
 For more information, see [How to: Import Custom WSDL](../../../../docs/framework/wcf/extending/how-to-import-custom-wsdl.md).  
  
### Importing Custom Policy Assertions  
 The <xref:System.ServiceModel.Description.WsdlImporter> type and the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) automatically handle processing a variety of policy assertion types in policy expressions attached to WSDL documents. These tools collect, normalize, and merge policy expressions attached to WSDL bindings and WSDL ports.  
  
 To add support for importing custom policy assertions, implement the <xref:System.ServiceModel.Description.IPolicyImportExtension> interface and then add your implementation to the <xref:System.ServiceModel.Description.MetadataImporter.PolicyImportExtensions%2A> property. The <xref:System.ServiceModel.Description.MetadataImporter> can also load implementations of the <xref:System.ServiceModel.Description.IPolicyImportExtension> interface registered in your application configuration file. Note that a number of policy importers are registered by default and the order of the registered policy importers is significant.  
  
 The metadata system repeatedly calls the <xref:System.ServiceModel.Description.IPolicyImportExtension.ImportPolicy%2A?displayProperty=nameWithType> method on all registered policy import extensions for each combination of policy alternatives attached to the message, operation, and endpoint policy subjects. When importing a WSDL port, policies attached to the port and to the corresponding WSDL binding are merged before calling into the policy import extensions. The policy alternatives are made available through a <xref:System.ServiceModel.Description.PolicyConversionContext> as <xref:System.ServiceModel.Description.PolicyAssertionCollection> objects. Each <xref:System.ServiceModel.Description.PolicyAssertionCollection> is a collection of policy assertions represented by <xref:System.Xml.XmlElement> objects.  
  
 The <xref:System.ServiceModel.Description.PolicyConversionContext.Contract%2A> and <xref:System.ServiceModel.Description.PolicyConversionContext.BindingElements%2A> properties on the <xref:System.ServiceModel.Description.PolicyConversionContext> object expose the <xref:System.ServiceModel.Description.ContractDescription> and <xref:System.ServiceModel.Channels.BindingElement> objects that were imported from the WSDL. Policy import extensions process policy assertions by finding instances of a particular policy assertion type, making corresponding changes to the <xref:System.ServiceModel.Description.ContractDescription> or <xref:System.ServiceModel.Channels.BindingElement> objects and then removing the policy assertions from the corresponding <xref:System.ServiceModel.Description.PolicyAssertionCollection> instance.  
  
 The `wsp:Optional` attribute and nested policy expressions are not normalized, so policy import extensions must handle these policy constructs. Also, policy import extensions may be called multiple times with the same <xref:System.ServiceModel.Description.ContractDescription> and <xref:System.ServiceModel.Channels.BindingElement> objects, so policy import extensions should be robust to this behavior.  
  
> [!IMPORTANT]
>  Invalid or improper metadata can be passed to the importer. Ensure that custom importers are robust to all forms of XML.  
  
## See Also  
 [How to: Import Custom WSDL](../../../../docs/framework/wcf/extending/how-to-import-custom-wsdl.md)  
 [How to: Import Custom Policy Assertions](../../../../docs/framework/wcf/extending/how-to-import-custom-policy-assertions.md)  
 [How to: Write an Extension for the ServiceContractGenerator](../../../../docs/framework/wcf/extending/how-to-write-an-extension-for-the-servicecontractgenerator.md)
