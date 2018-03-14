---
title: "ServiceModel Attributes and ServiceDescription Reference"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4ab86b17-eab9-4846-a881-0099f9a7cc64
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ServiceModel Attributes and ServiceDescription Reference
The *description tree* is the hierarchy of types (starting with the <xref:System.ServiceModel.Description.ServiceDescription?displayProperty=nameWithType> class) that together describe every aspect of a service. [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] uses a description tree to build a valid service runtime, to publish Web Services Description Language (WSDL), XML Schema definition language (XSD), and policy assertions (metadata) about the service that clients can use to connect to and use the service, and to generate various code and configuration file representations of the description tree values.  
  
 This topic describes how contract-related properties are obtained from the service contract, and how they are implemented and added to the description tree. In some cases, attribute values are converted into behavior properties and behavior is then inserted into the description tree. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how the description tree values are converted into metadata, see [ServiceDescription and WSDL Reference](../../../../docs/framework/wcf/feature-details/servicedescription-and-wsdl-reference.md).  
  
## Mapping Operations to the Description Tree  
 In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications, service contracts are modeled by interfaces (or classes) that use attributes to mark the interface or class and its methods as a grouping of operations. When a <xref:System.ServiceModel.ServiceHost> class is opened, any service contracts and implementations are reflected over and merged with configuration information into a description tree.  
  
 There are two types of operation models: the *parameter* model and the *message contract* model. The parameter model uses managed methods that do not have a parameter or return value type that is marked by the <xref:System.ServiceModel.MessageContractAttribute?displayProperty=nameWithType> class. In this model, developers control the serialization of parameters and return values, but [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] generates the values that are used to populate the description tree for the service and its contract.  
  
 Bindings specified in configuration files are loaded directly into the <xref:System.ServiceModel.Description.ServiceEndpoint.Binding%2A?displayProperty=nameWithType> property.  
  
|ServiceBehaviorAttribute Property|Description Tree Value Affected|  
|---------------------------------------|-------------------------------------|  
|Name|<xref:System.ServiceModel.Description.ServiceDescription.Name%2A>|  
|Namespace|<xref:System.ServiceModel.Description.ServiceDescription.Namespace%2A>|  
|ConfigurationName|<xref:System.ServiceModel.Description.ServiceDescription.ConfigurationName%2A>|  
|IgnoreExtensionDataObject|Sets the <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior.IgnoreExtensionDataObject%2A> property for all operations.|  
|MaxItemsInObjectGraph|Sets the <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior.MaxItemsInObjectGraph%2A> property for all operations.|  
  
|ServiceContractAttribute Property|Description Tree Value Affected|  
|---------------------------------------|-------------------------------------|  
|CallbackContract|<xref:System.ServiceModel.Description.ContractDescription.CallbackContractType%2A>, <xref:System.ServiceModel.Description.MessageDescription> added to all operations <xref:System.ServiceModel.Description.OperationDescription.Messages%2A>.|  
|ConfigurationName|<xref:System.ServiceModel.Description.ContractDescription.ConfigurationName%2A>|  
|ProtectionLevel|<xref:System.ServiceModel.Description.ContractDescription.ProtectionLevel%2A> and possibly child protection levels. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the protection-level hierarchy, see [Understanding Protection Level](../../../../docs/framework/wcf/understanding-protection-level.md).|  
|SessionMode|<xref:System.ServiceModel.Description.ContractDescription.SessionMode%2A>|  
  
|ServiceKnownTypesAttribute Value|Description Tree Value Affected|  
|--------------------------------------|-------------------------------------|  
|MethodName|<xref:System.ServiceModel.Description.OperationDescription.KnownTypes%2A>|  
  
|OperationContractAttribute Value|Description Tree Value Affected|  
|--------------------------------------|-------------------------------------|  
|Action|<xref:System.ServiceModel.Description.MessageDescription.Action%2A> for the output message or input message, depending upon contract/callback contract.|  
|AsyncPattern|If true, <xref:System.ServiceModel.Description.OperationDescription.BeginMethod%2A> and <xref:System.ServiceModel.Description.OperationDescription.EndMethod%2A>|  
|IsOneWay|Maps to a single <xref:System.ServiceModel.Description.MessageDescription> in <xref:System.ServiceModel.Description.OperationDescription.Messages%2A>|  
|IsInitiating|<xref:System.ServiceModel.Description.OperationDescription.IsInitiating%2A>|  
|IsTerminating|<xref:System.ServiceModel.Description.OperationDescription.IsTerminating%2A>|  
|Name|<xref:System.ServiceModel.Description.OperationDescription.Name%2A>|  
|ProtectionLevel|<xref:System.ServiceModel.Description.OperationDescription.ProtectionLevel%2A> and possibly child protection levels. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the protection-level hierarchy, see [Understanding Protection Level](../../../../docs/framework/wcf/understanding-protection-level.md).|  
|ReplyAction|<xref:System.ServiceModel.Description.MessageDescription.Action%2A> for the output message or input message, depending upon contract/callback contract.|  
  
|FaultContractAttribute Value|Description Tree Value Affected|  
|----------------------------------|-------------------------------------|  
|Action|<xref:System.ServiceModel.Description.FaultDescription.Action%2A> depending upon contract/callback contract.|  
|DetailType|<xref:System.ServiceModel.Description.FaultDescription.DetailType%2A>|  
|Name|<xref:System.ServiceModel.Description.FaultDescription.Name%2A>|  
|Namespace|<xref:System.ServiceModel.Description.FaultDescription.Namespace%2A>|  
|ProtectionLevel|<xref:System.ServiceModel.Description.FaultDescription.ProtectionLevel%2A>|  
  
|DataContractFormatAttribute Value|Description Tree Value Affected|  
|---------------------------------------|-------------------------------------|  
|Use|The <xref:System.ServiceModel.DataContractFormatAttribute.Style%2A> value is set on the <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior> for the operation.|  
  
|XmlSerializerFormatAttribute Value|Description Tree Value Affected|  
|----------------------------------------|-------------------------------------|  
|Style|This <xref:System.ServiceModel.XmlSerializerFormatAttribute> property is set on the <xref:System.ServiceModel.Description.XmlSerializerOperationBehavior> for the operation.|  
|Use|The <xref:System.ServiceModel.XmlSerializerFormatAttribute> is set on the <xref:System.ServiceModel.Description.XmlSerializerOperationBehavior> for the operation.|  
  
|TransactionFlowAttribute Value|Description Tree Value Affected|  
|------------------------------------|-------------------------------------|  
|TransactionFlowOption|The <xref:System.ServiceModel.TransactionFlowAttribute> is added as an operation behavior to the <xref:System.ServiceModel.Description.OperationDescription.Behaviors%2A> property.|  
  
|MessageContractAttribute Value|Description Tree Value Affected|  
|------------------------------------|-------------------------------------|  
|ProtectionLevel|<xref:System.ServiceModel.Description.MessageDescription.ProtectionLevel%2A>|  
|WrapperName|<xref:System.ServiceModel.Description.MessageBodyDescription.WrapperName%2A>|  
|WrapperNamespace|<xref:System.ServiceModel.Description.MessageBodyDescription.WrapperNamespace%2A>|  
  
|MessageHeaderAttribute Value|Description Tree Value Affected|  
|----------------------------------|-------------------------------------|  
|Actor|<xref:System.ServiceModel.Description.MessageHeaderDescription.Actor%2A> for the corresponding header in <xref:System.ServiceModel.Description.MessageDescription.Headers%2A>|  
|MustUnderstand|<xref:System.ServiceModel.Description.MessageHeaderDescription.MustUnderstand%2A> for the corresponding header in <xref:System.ServiceModel.Description.MessageDescription.Headers%2A>|  
|Name|<xref:System.ServiceModel.Description.MessagePartDescription.Name%2A> for the corresponding header in <xref:System.ServiceModel.Description.MessageDescription.Headers%2A>|  
|Namespace|<xref:System.ServiceModel.Description.MessagePartDescription.Namespace%2A> for the corresponding header in <xref:System.ServiceModel.Description.MessageDescription.Headers%2A>|  
|ProtectionLevel|<xref:System.ServiceModel.Description.MessagePartDescription.ProtectionLevel%2A> for the corresponding header in <xref:System.ServiceModel.Description.MessageDescription.Headers%2A>|  
|Relay|<xref:System.ServiceModel.Description.MessageHeaderDescription.Relay%2A> for the corresponding header in <xref:System.ServiceModel.Description.MessageDescription.Headers%2A>|  
  
|MessageBodyMemberAttribute Value|Description Tree Value Affected|  
|--------------------------------------|-------------------------------------|  
|Name|<xref:System.ServiceModel.Description.MessagePartDescription.Name%2A> for the corresponding part in <xref:System.ServiceModel.Description.MessageBodyDescription.Parts%2A>|  
|Namespace|<xref:System.ServiceModel.Description.MessagePartDescription.Namespace%2A> for the corresponding part in <xref:System.ServiceModel.Description.MessageBodyDescription.Parts%2A>|  
|Order|<xref:System.ServiceModel.Description.MessagePartDescription.Index%2A> for the corresponding part in <xref:System.ServiceModel.Description.MessageBodyDescription.Parts%2A>|  
|ProtectionLevel|<xref:System.ServiceModel.Description.MessagePartDescription.ProtectionLevel%2A> for the corresponding part in <xref:System.ServiceModel.Description.MessageBodyDescription.Parts%2A>|  
  
|MessageHeaderArrayAttribute Value|Description Tree Value Affected|  
|---------------------------------------|-------------------------------------|  
|Actor|<xref:System.ServiceModel.Description.MessageHeaderDescription.Actor%2A>|  
|MustUnderstand|<xref:System.ServiceModel.Description.MessageHeaderDescription.MustUnderstand%2A>|  
|Name|<xref:System.ServiceModel.Description.MessagePartDescription.Name%2A>|  
|Namespace|<xref:System.ServiceModel.Description.MessagePartDescription.Namespace%2A>|  
|ProtectionLevel|<xref:System.ServiceModel.Description.MessagePartDescription.ProtectionLevel%2A>|  
|Relay|<xref:System.ServiceModel.Description.MessageHeaderDescription.Relay%2A>|  
  
|MessagePropertyAttribute Value|Description Tree Value Affected|  
|------------------------------------|-------------------------------------|  
|Name|<xref:System.ServiceModel.Description.MessagePartDescription.Name%2A>|  
  
|MessageParameterAttribute Value|Description Tree Value Affected|  
|-------------------------------------|-------------------------------------|  
|Name|<xref:System.ServiceModel.Description.MessagePartDescription.Name%2A> for the corresponding part in <xref:System.ServiceModel.Description.MessageBodyDescription.Parts%2A>|  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how the description tree values are converted into metadata, see [ServiceDescription and WSDL Reference](../../../../docs/framework/wcf/feature-details/servicedescription-and-wsdl-reference.md).  
  
## See Also  
 [ServiceDescription and WSDL Reference](../../../../docs/framework/wcf/feature-details/servicedescription-and-wsdl-reference.md)
