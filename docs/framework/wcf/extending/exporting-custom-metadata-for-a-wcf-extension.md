---
title: "Exporting Custom Metadata for a WCF Extension"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 53c93882-f8ba-4192-965b-787b5e3f09c0
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Exporting Custom Metadata for a WCF Extension
In [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], metadata export is the process of describing service endpoints and projecting them into a parallel, standardized representation that clients can use to understand how to use the service. Custom metadata consists of XML elements that the system-provided metadata exporters cannot export. Typically, this includes custom WSDL elements for user-defined behaviors and binding elements and policy assertions about the capabilities and requirements of bindings and contracts.  
  
 This section describes exporting custom WSDL or policy assertions, and does not focus on the exporting process itself. For more information about how to use the types that export and import metadata regardless of whether the metadata is custom or system-constructed, see [Exporting and Importing Metadata](../../../../docs/framework/wcf/feature-details/exporting-and-importing-metadata.md).  
  
## Overview  
 When metadata is published using the <xref:System.ServiceModel.Description.ServiceMetadataBehavior?displayProperty=nameWithType>, the <xref:System.ServiceModel.Description.ServiceDescription?displayProperty=nameWithType> is examined and XSD and WSDL -- including policy assertions -- are generated for all contracts and bindings that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can support using system-provided attributes and bindings. However, custom behavior attributes or binding elements require support before they can be exported properly.  
  
 This section describes:  
  
1.  How to implement and use the <xref:System.ServiceModel.Description.IWsdlExportExtension?displayProperty=nameWithType> interface, which exposes the WSDL generation data to you prior to publishing the WSDL.  
  
2.  How to implement and use the <xref:System.ServiceModel.Description.IPolicyExportExtension?displayProperty=nameWithType> interface, which exposes the policy data to you prior to exporting the policy assertions in WSDL data.  
  
 For more information about importing custom WSDL and policy assertions, see [Importing Custom Metadata for a WCF Extension](../../../../docs/framework/wcf/extending/importing-custom-metadata-for-a-wcf-extension.md).  
  
## Exporting Custom WSDL Elements  
 Implement the <xref:System.ServiceModel.Description.IWsdlExportExtension> on an operation behavior, contract behavior, endpoint behavior or binding element (<xref:System.ServiceModel.Description.IOperationBehavior>, <xref:System.ServiceModel.Description.IContractBehavior>, <xref:System.ServiceModel.Description.IEndpointBehavior>, or <xref:System.ServiceModel.Channels.BindingElement?displayProperty=nameWithType> respectively) and insert the behaviors or binding elements into the description of the service that you are trying to export. (For more information about inserting behaviors, see [Configuring and Extending the Runtime with Behaviors](../../../../docs/framework/wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md)). The <xref:System.ServiceModel.Description.IWsdlExportExtension> is called for each endpoint and each endpoint exports the contract first if it has not already been exported. You can participate in either export process, depending upon your needs:  
  
-   Use the <xref:System.ServiceModel.Description.WsdlContractConversionContext> to modify the exported metadata in the <xref:System.ServiceModel.Description.IWsdlExportExtension.ExportContract%2A> method.  
  
-   Use the <xref:System.ServiceModel.Description.WsdlEndpointConversionContext> to modify the exported metadata for the endpoint in the <xref:System.ServiceModel.Description.IWsdlExportExtension.ExportEndpoint%2A> method.  
  
 The <xref:System.ServiceModel.Description.IWsdlExportExtension.ExportContract%2A> method is called on all <xref:System.ServiceModel.Description.IWsdlExportExtension> implementations within the <xref:System.ServiceModel.Description.ContractDescription?displayProperty=nameWithType> instance that is being exported.  The <xref:System.ServiceModel.Description.IWsdlExportExtension.ExportEndpoint%2A> method is called on all <xref:System.ServiceModel.Description.IWsdlExportExtension> implementations with the <xref:System.ServiceModel.Description.ServiceEndpoint?displayProperty=nameWithType> instance that is being exported.  
  
 For more information, see [How to: Export Custom WSDL](../../../../docs/framework/wcf/extending/how-to-export-custom-wsdl.md) and the sample [Custom WSDL Publication](../../../../docs/framework/wcf/samples/custom-wsdl-publication.md).  
  
## Exporting Custom Policy Assertions  
 Implement the <xref:System.ServiceModel.Description.IPolicyExportExtension> on a <xref:System.ServiceModel.Channels.BindingElement> and add the binding element to the binding to write custom policy assertions about binding support and contract capabilities into the WSDL. The <xref:System.ServiceModel.Description.IPolicyExportExtension> is called once when exporting the implemented binding element in a binding and passes the <xref:System.ServiceModel.Description.PolicyConversionContext> to the <xref:System.ServiceModel.Description.IPolicyExportExtension.ExportPolicy%2A> method. You can use the methods on the <xref:System.ServiceModel.Description.PolicyConversionContext> instance to add to the policy assertions attached to the WSDL binding at the message, operation or endpoint subjects.  
  
 For more information, see [How to: Export Custom Policy Assertions](../../../../docs/framework/wcf/extending/how-to-export-custom-policy-assertions.md).  
  
## See Also  
 [How to: Export Custom WSDL](../../../../docs/framework/wcf/extending/how-to-export-custom-wsdl.md)  
 [How to: Export Custom Policy Assertions](../../../../docs/framework/wcf/extending/how-to-export-custom-policy-assertions.md)  
 [Importing Custom Metadata for a WCF Extension](../../../../docs/framework/wcf/extending/importing-custom-metadata-for-a-wcf-extension.md)
