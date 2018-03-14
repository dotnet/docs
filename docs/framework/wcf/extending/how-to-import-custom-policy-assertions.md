---
title: "How to: Import Custom Policy Assertions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 1f41d787-accb-4a10-bfc6-a807671d1581
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Import Custom Policy Assertions
Policy assertions describe the capabilities and requirements of a service endpoint.  Client applications can use policy assertions in service metadata to configure the client binding or to customize the service contract for a service endpoint.  
  
 Custom policy assertions are imported by implementing the <xref:System.ServiceModel.Description.IPolicyImportExtension?displayProperty=nameWithType> interface and passing that object to the metadata system or by registering the implementation type in your application configuration file.  Implementations of the <xref:System.ServiceModel.Description.IPolicyImportExtension> interface must provide a default constructor.  
  
### To import custom policy assertions  
  
1.  Implement the <xref:System.ServiceModel.Description.IPolicyImportExtension?displayProperty=nameWithType> interface on a class. See the following procedures.  
  
2.  Insert the custom policy importer either by:  
  
3.  Using a configuration file. See the following procedures.  
  
4.  Using a configuration file with [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md). See the following procedures.  
  
5.  Programmatically inserting the policy importer. See the following procedures.  
  
### To implement the System.ServiceModel.Description.IPolicyImportExtension interface on any class  
  
1.  In the <xref:System.ServiceModel.Description.IPolicyImportExtension.ImportPolicy%2A?displayProperty=nameWithType> method, for each policy subject that you are interested in, find the policy assertions that you want to import by calling the appropriate method (depending upon the scope of the assertion that you want) on the <xref:System.ServiceModel.Description.PolicyConversionContext?displayProperty=nameWithType> object passed to the method. The following code example shows how to use the <xref:System.ServiceModel.Description.PolicyAssertionCollection.Remove%2A?displayProperty=nameWithType> method to locate the custom policy assertion and remove it from the collection in one step. If you use the remove method to locate and remove the assertion, you do not have to perform step 4.  
  
     [!code-csharp[CustomPolicySample#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/custompolicysample/cs/policyimporter.cs#9)]
     [!code-vb[CustomPolicySample#9](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/custompolicysample/vb/policyimporter.vb#9)]  
  
2.  Process the policy assertions. Note that the policy system does not normalize nested policies and `wsp:optional`. You must process these constructs in your policy import extension implementation.  
  
3.  Perform the customization to the binding or contract that supports the capability or requirement specified by the policy assertion. Typically assertions indicate that a binding requires a particular configuration or a specific binding element. Make these modifications by accessing the <xref:System.ServiceModel.Description.PolicyConversionContext.BindingElements%2A?displayProperty=nameWithType> property. Other assertions require that you modify the contract.  You can access and modify the contract using the <xref:System.ServiceModel.Description.PolicyConversionContext.Contract%2A?displayProperty=nameWithType> property.  Note that your policy importer may get called multiple times for the same binding and contract, but different policy alternatives if importing a policy alternative fails. Your code should be resilient to this behavior.  
  
4.  Remove the custom policy assertion from the assertion collection. If you do not remove the assertion [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] assumes that the policy import was unsuccessful and does not import the associated binding. If you used the <xref:System.ServiceModel.Description.PolicyAssertionCollection.Remove%2A?displayProperty=nameWithType> method to locate the custom policy assertion and remove it from the collection in one step you do not have to perform this step.  
  
### To insert the custom policy importer into the metadata System using a configuration file  
  
1.  Add the importer type to the `<extensions>` element inside the [\<policyImporters>](../../../../docs/framework/configure-apps/file-schema/wcf/policyimporters.md) element in the client configuration file.  
  
     [!code-xml[CustomPolicySample#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/custompolicysample/cs/client.exe.config#7)]   
  
2.  In the client application, use the <xref:System.ServiceModel.Description.MetadataResolver?displayProperty=nameWithType> or <xref:System.ServiceModel.Description.WsdlImporter?displayProperty=nameWithType> to resolve the metadata and the importer is invoked automatically.  
  
     [!code-csharp[CustomPolicySample#10](../../../../samples/snippets/csharp/VS_Snippets_CFX/custompolicysample/cs/client.cs#10)]
     [!code-vb[CustomPolicySample#10](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/custompolicysample/vb/client.vb#10)]  
  
### To insert the custom policy importer into the metadata system using Svcutil.exe  
  
1.  Add the importer type to the `<extensions>` element inside the [\<policyImporters>](../../../../docs/framework/configure-apps/file-schema/wcf/policyimporters.md) element in the Svcutil.exe.config configuration file. You can also point Svcutil.exe to load policy importer types registered in a different configuration file by using the `/svcutilConfig` option.  
  
2.  Use [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) to import the metadata and the importer is invoked automatically.  
  
### To insert the custom policy importer into the metadata system programmatically  
  
1.  Add the importer to the <xref:System.ServiceModel.Description.MetadataImporter.PolicyImportExtensions%2A?displayProperty=nameWithType> property (for example, if you are using the <xref:System.ServiceModel.Description.WsdlImporter?displayProperty=nameWithType>) prior to importing the metadata.  
  
## See Also  
 <xref:System.ServiceModel.Description.MetadataResolver?displayProperty=nameWithType>  
 <xref:System.ServiceModel.Description.WsdlImporter?displayProperty=nameWithType>  
 <xref:System.ServiceModel.Description.MetadataResolver?displayProperty=nameWithType>  
 [Extending the Metadata System](../../../../docs/framework/wcf/extending/extending-the-metadata-system.md)
