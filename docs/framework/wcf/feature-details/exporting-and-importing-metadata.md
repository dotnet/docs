---
title: "Exporting and Importing Metadata"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "metadata [WCF], exporting and importing"
ms.assetid: 614a75bb-e0b0-4c95-b6d8-02cb5e5ddb38
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Exporting and Importing Metadata
In [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], exporting metadata is the process of describing service endpoints and projecting them into a parallel, standardized representation that clients can use to understand how to use the service. Importing service metadata is the process of generating <xref:System.ServiceModel.Description.ServiceEndpoint> instances or parts from service metadata.  
  
## Exporting Metadata  
 To export metadata from <xref:System.ServiceModel.Description.ServiceEndpoint?displayProperty=nameWithType> instances, use an implementation of the <xref:System.ServiceModel.Description.MetadataExporter> abstract class. The <xref:System.ServiceModel.Description.WsdlExporter> type is the implementation of the <xref:System.ServiceModel.Description.MetadataExporter> abstract class included with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
 The <xref:System.ServiceModel.Description.WsdlExporter?displayProperty=nameWithType> type generates Web Services Description Language (WSDL) metadata with attached policy expressions encapsulated in a <xref:System.ServiceModel.Description.MetadataSet> instance. You can use a <xref:System.ServiceModel.Description.WsdlExporter?displayProperty=nameWithType> instance to iteratively export metadata for <xref:System.ServiceModel.Description.ContractDescription> objects and <xref:System.ServiceModel.Description.ServiceEndpoint> objects. You can also export a collection of <xref:System.ServiceModel.Description.ServiceEndpoint> objects and associate them with a specific service name.  
  
> [!NOTE]
>  You can only use the `WsdlExporter` to export metadata from `ContractDescription` instances that contain common language runtime (CLR) type information, such as a `ContractDescription` instance created using the `ContractDescription.GetContract` method or created as part of the `ServiceDescription` for a `ServiceHost` instance. You cannot use the `WsdlExporter` to export metadata from `ContractDescription` instances imported from service metadata or constructed without type information.  
  
## Importing Metadata  
  
### Importing WSDL Documents  
 To import service metadata in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], use an implementation of the <xref:System.ServiceModel.Description.MetadataImporter> abstract class. The <xref:System.ServiceModel.Description.WsdlImporter?displayProperty=nameWithType> type is the implementation of the <xref:System.ServiceModel.Description.MetadataImporter> abstract class included with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. The <xref:System.ServiceModel.Description.WsdlImporter> type imports WSDL metadata with attached policies bundled in a <xref:System.ServiceModel.Description.MetadataSet> object.  
  
 The <xref:System.ServiceModel.Description.WsdlImporter> type gives you control over how to import the metadata. You can import all of the endpoints, all of the bindings, or all of the contracts. You can import all of the endpoints associated with a specific WSDL service, binding, or port type. You can also import the endpoint for a specific WSDL port, the binding for a specific WSDL binding or the contract for a specific WSDL port type.  
  
 The <xref:System.ServiceModel.Description.WsdlImporter> also exposes a <xref:System.ServiceModel.Description.MetadataImporter.KnownContracts%2A> property that allows you to specify a set of contracts that do not need to be imported. The <xref:System.ServiceModel.Description.WsdlImporter> uses the contracts in the <xref:System.ServiceModel.Description.MetadataImporter.KnownContracts%2A> property instead of importing a contract with the same qualified name from the metadata.  
  
### Importing Policies  
 The <xref:System.ServiceModel.Description.WsdlImporter> type collects the policy expressions attached to the message, operation, and endpoint policy subjects and then uses the <xref:System.ServiceModel.Description.IPolicyImportExtension> implementations in the <xref:System.ServiceModel.Description.MetadataImporter.PolicyImportExtensions%2A> collection to import the policy expressions.  
  
 The policy import logic automatically handles policy references to policy expressions in the same WSDL document and is identified with a `wsu:Id` or `xml:id` attribute. The policy import logic protects applications against circular policy references by limiting the size of a policy expression to 4096 nodes, where a node is a one of the following elements: `wsp:Policy`, `wsp:All`, `wsp:ExactlyOne`, `wsp:policyReference`.  
  
 The policy import logic also automatically normalizes policy expressions. Nested policy expressions and the `wsp:Optional` attribute are not normalized. The amount of normalization processing done is limited to 4096 steps, where each step yields a policy assertion, or a child element of a `wsp:ExactlyOne` element.  
  
 The <xref:System.ServiceModel.Description.WsdlImporter> type tries up to 32 combinations of policy alternatives attached to the different WSDL policy subjects. If no combination imports cleanly, the first combination is used to construct a partial custom binding.  
  
## Error Handling  
 Both the <xref:System.ServiceModel.Description.MetadataExporter> and the <xref:System.ServiceModel.Description.MetadataImporter> types expose an `Errors` property that can contain a collection of error and warning messages encountered during the export and import processes, respectively, that can be used when implementing tools.  
  
 The <xref:System.ServiceModel.Description.WsdlImporter> type generally throws an exception for an exception caught during the import process and adds a corresponding error to its `Errors` property. The <xref:System.ServiceModel.Description.WsdlImporter.ImportAllContracts%2A>, <xref:System.ServiceModel.Description.WsdlImporter.ImportAllBindings%2A>, <xref:System.ServiceModel.Description.WsdlImporter.ImportAllEndpoints%2A>, and <xref:System.ServiceModel.Description.WsdlImporter.ImportEndpoints%2A> methods, however, do not throw these exceptions, so you must check the `Errors` property to determine if any issues occurred when calling these methods.  
  
 The <xref:System.ServiceModel.Description.WsdlExporter> type rethrows any exceptions caught during the export process. These exceptions are not captured as errors in the `Errors` property. Once the <xref:System.ServiceModel.Description.WsdlExporter> throws an exception, it is in a faulted state and cannot be reused. The <xref:System.ServiceModel.Description.WsdlExporter> does add warnings to its `Errors` property when an operation cannot be exported because it uses wildcard actions and when duplicate binding names are encountered.  
  
## In This Section  
 [How to: Import Metadata into Service Endpoints](../../../../docs/framework/wcf/feature-details/how-to-import-metadata-into-service-endpoints.md)  
 Describes how to import downloaded metadata into description objects.  
  
 [How to: Export Metadata from Service Endpoints](../../../../docs/framework/wcf/feature-details/how-to-export-metadata-from-service-endpoints.md)  
 Describes how to export description objects into metadata.  
  
 [ServiceDescription and WSDL Reference](../../../../docs/framework/wcf/feature-details/servicedescription-and-wsdl-reference.md)  
 Describes the mapping between the description objects and WSDL.  
  
 [How to: Use Svcutil.exe to Export Metadata from Compiled Service Code](../../../../docs/framework/wcf/feature-details/how-to-use-svcutil-exe-to-export-metadata-from-compiled-service-code.md)  
 Describes the use of Svcutil.exe to export metadata for services, contracts, and data types in compiled assemblies.  
  
 [Data Contract Schema Reference](../../../../docs/framework/wcf/feature-details/data-contract-schema-reference.md)  
 Describes the subset of the XML Schema (XSD) used by <xref:System.Runtime.Serialization.DataContractSerializer> to describe common language run-time (CLR) types for XML serialization.  
  
## Reference  
 <xref:System.ServiceModel.Description.WsdlExporter>  
  
 <xref:System.ServiceModel.Description.WsdlImporter>  
  
## See Also  
 [Exporting Custom Metadata for a WCF Extension](../../../../docs/framework/wcf/extending/exporting-custom-metadata-for-a-wcf-extension.md)  
 [Importing Custom Metadata for a WCF Extension](../../../../docs/framework/wcf/extending/importing-custom-metadata-for-a-wcf-extension.md)
