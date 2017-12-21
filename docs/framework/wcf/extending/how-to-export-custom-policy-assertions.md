---
title: "How to: Export Custom Policy Assertions"
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
ms.assetid: 99030386-43b0-4f7b-866d-17ea307f5cbd
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Export Custom Policy Assertions
Policy assertions describe the capabilities and requirements of a service endpoint. Service applications can use custom policy assertions in service metadata to communicate endpoint, binding or contract customization information to the client application. You can use [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] to export assertions in policy expressions attached in WSDL bindings at the endpoint, operation, or message subjects, depending upon the capabilities or requirements you are communicating.  
  
 Custom policy assertions are exported by implementing the <xref:System.ServiceModel.Description.IPolicyExportExtension?displayProperty=nameWithType> interface on a <xref:System.ServiceModel.Channels.BindingElement?displayProperty=nameWithType> and either inserting the binding element directly into the binding of the service endpoint or by registering the binding element in your application configuration file. Your policy export implementation should add your custom policy assertion as a <xref:System.Xml.XmlElement?displayProperty=nameWithType> instance to the appropriate <xref:System.ServiceModel.Description.PolicyAssertionCollection?displayProperty=nameWithType> on the <xref:System.ServiceModel.Description.PolicyConversionContext?displayProperty=nameWithType> passed into the <xref:System.ServiceModel.Description.IPolicyExportExtension.ExportPolicy%2A> method.  
  
 In addition you must check the <xref:System.ServiceModel.Description.MetadataExporter.PolicyVersion%2A> property of the <xref:System.ServiceModel.Description.WsdlExporter> class and export nested policy expressions and policy framework attributes in the correct namespace based on the policy version specified.  
  
 To import custom policy assertions, see <xref:System.ServiceModel.Description.IPolicyImportExtension?displayProperty=nameWithType> and [How to: Import Custom Policy Assertions](../../../../docs/framework/wcf/extending/how-to-import-custom-policy-assertions.md).  
  
### To export custom policy assertions  
  
1.  Implement the <xref:System.ServiceModel.Description.IPolicyExportExtension?displayProperty=nameWithType> interface on a <xref:System.ServiceModel.Channels.BindingElement?displayProperty=nameWithType>. The following code example shows the implementation of a custom policy assertion at the binding level.  
  
     [!code-csharp[CustomPolicySample#14](../../../../samples/snippets/csharp/VS_Snippets_CFX/custompolicysample/cs/policyexporter.cs#14)]
     [!code-vb[CustomPolicySample#14](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/custompolicysample/vb/policyexporter.vb#14)]  
  
2.  Insert the binding element into the endpoint binding either programmatically or using an application configuration file. See the following procedures.  
  
### To insert a binding element using an application configuration file  
  
1.  Implement <xref:System.ServiceModel.Configuration.BindingElementExtensionElement?displayProperty=nameWithType> for your custom policy assertion binding element.  
  
2.  Add the binding element extension to the configuration file using the [\<bindingElementExtensions>](../../../../docs/framework/configure-apps/file-schema/wcf/bindingelementextensions.md) element.  
  
3.  Build a custom binding using the <xref:System.ServiceModel.Channels.CustomBinding?displayProperty=nameWithType>.  
  
### To insert a binding element programmatically  
  
1.  Create a new <xref:System.ServiceModel.Channels.BindingElement?displayProperty=nameWithType> and add it to a <xref:System.ServiceModel.Channels.CustomBinding?displayProperty=nameWithType>.  
  
2.  Add the custom binding from step 1. to a new endpoint and add that new service endpoint to the <xref:System.ServiceModel.ServiceHost?displayProperty=nameWithType> by calling the <xref:System.ServiceModel.ServiceHost.AddServiceEndpoint%2A> method.  
  
3.  Open the <xref:System.ServiceModel.ServiceHost>. The following code example shows the creation of a custom binding and the programmatic insertion of binding elements.  
  
     [!code-csharp[s_imperative#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_imperative/cs/service.cs#1)]
     [!code-vb[s_imperative#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/s_imperative/vb/service.vb#1)]  
  
## See Also  
 <xref:System.ServiceModel.Description.IPolicyImportExtension>  
 <xref:System.ServiceModel.Description.IPolicyExportExtension>  
 [How to: Import Custom Policy Assertions](../../../../docs/framework/wcf/extending/how-to-import-custom-policy-assertions.md)
