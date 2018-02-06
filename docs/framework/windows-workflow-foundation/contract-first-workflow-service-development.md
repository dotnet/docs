---
title: "Contract First Workflow Service Development"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e5dbaa7b-005f-4330-848d-58ac4f42f093
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Contract First Workflow Service Development
Starting with [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], [!INCLUDE[wf](../../../includes/wf-md.md)] features better integration between web services and workflows in the form of contract-first workflow development. The contract-first workflow development tool allows you to design the contract in code first. The tool then automatically generates an activity template in the toolbox for the operations in the contract. This topic provides an overview of how the activities and properties in a workflow service map to the attributes of a service contract. For a step-by-step example of creating a contract-first workflow service, see [How to: Create a workflow service that consumes an existing service contract](../../../docs/framework/windows-workflow-foundation/how-to-create-a-workflow-service-that-consumes-an-existing-service-contract.md).  
  
## In this topic  
  
-   [Mapping service contract attributes to workflow attributes](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#MappingAttributes)  
  
    -   [Service Contract Attributes](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#ServiceContract)  
  
    -   [Operation Contract Attributes](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#OperationContract)  
  
    -   [Message Contract Attributes](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#MessageContract)  
  
    -   [Data Contract Attributes](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#DataContract)  
  
    -   [Fault Contract Attributes](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#FaultContract)  
  
-   [Additional Support and Implementation Information](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#AdditionalSupport)  
  
    -   [Unsupported service contract features](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#UnsupportedFeatures)  
  
    -   [Generation of configured messaging activities](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#ActivityGeneration)  
  
##  <a name="MappingAttributes"></a> Mapping service contract attributes to workflow attributes  
 The tables in the following sections specify the different WCF attributes and properties and how they are mapped to the messaging activities and properties in a contract-first workflow.  
  
-   [Service Contract Attributes](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#ServiceContract)  
  
-   [Operation Contract Attributes](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#OperationContract)  
  
-   [Message Contract Attributes](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#MessageContract)  
  
-   [Data Contract Attributes](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#DataContract)  
  
-   [Fault Contract Attributes](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#FaultContract)  
  
###  <a name="ServiceContract"></a> Service Contract Attributes  
  
|Property Name|Supported|Description|WF Validation|  
|-------------------|---------------|-----------------|-------------------|  
|CallbackContract|No|Gets or sets the type of callback contract when the contract is a duplex contract.|(N/A)|  
|ConfigurationName|No|Gets or sets the name used to locate the service in an application configuration file.|(N/A)|  
|HasProtectionLevel|Yes|Gets a value that indicates whether the member has a protection level assigned.|Receive.ProtectionLevel should not be null.|  
|Name|Yes|Gets or sets the name for the \<portType> element in Web Services Description Language (WSDL).|Receive.ServiceContractName.LocalName should match.|  
|Namespace|Yes|Gets or sets the namespace of the \<portType> element in Web Services Description Language (WSDL).|Receive.ServiceContractName.NameSpace should match|  
|ProtectionLevel|Yes|Specifies whether the binding for the contract must support the value of the ProtectionLevel property.|Receive.ProtectionLevel should match.|  
|SessionMode|No|Gets or sets whether sessions are allowed, not allowed or required.|(N/A)|  
|TypeId|No|When implemented in a derived class, gets a unique identifier for this Attribute. (Inherited from Attribute.)|(N/A)|  
  
 Insert subsection body here.  
  
###  <a name="OperationContract"></a> Operation Contract Attributes  
  
|Property Name|Supported|Description|WF Validation|  
|-------------------|---------------|-----------------|-------------------|  
|Action|Yes|Gets or sets the WS-Addressing action of the request message.|Receive.Action should match.|  
|AsyncPattern|No|Indicates that an operation is implemented asynchronously using a Begin\<methodName> and End\<methodName> method pair in a service contract.|(N/A)|  
|HasProtectionLevel|Yes|Gets a value that indicates whether the messages for this operation must be encrypted, signed, or both.|Receive.ProtectionLevel should not be null.|  
|IsInitiating|No|Gets or sets a value that indicates whether the method implements an operation that can initiate a session on the server(if such a session exists).|(N/A)|  
|IsOneWay|Yes|Gets or sets a value that indicates whether an operation returns a reply message.|(No SendReply for this Receive OR no ReceiveReply for this Send).|  
|IsTerminating|No|Gets or sets a value that indicates whether the service operation causes the server to close the session after the reply message, if any, is sent.|(N/A)|  
|Name|Yes|Gets or sets the name of the operation.|Receive.OperationName should match.|  
|ProtectionLevel|Yes|Gets or sets a value that specifies whether the messages of an operation must be encrypted, signed, or both.|Receive.ProtectionLevel should match.|  
|ReplyAction|Yes|Gets or sets the value of the SOAP action for the reply message of the operation.|SendReply.Action should match.|  
|TypeId|No|When implemented in a derived class, gets a unique identifier for this Attribute. (Inherited from Attribute.)|(N/A)|  
  
###  <a name="MessageContract"></a> Message Contract Attributes  
  
|Property Name|Supported|Description|WF Validation|  
|-------------------|---------------|-----------------|-------------------|  
|HasProtectionLevel|Yes|Gets a value that indicates whether the message has a protection level.|No validation (Receive.Content and SendReply.Content must match the message contract type).|  
|IsWrapped|Yes|Gets or sets a value that specifies whether the message body has a wrapper element.|No validation (Receive.Content and Sendreply.Content must match the message contract type).|  
|ProtectionLevel|No|Gets or sets a value that specified whether the message must be encrypted, signed, or both.|(N/A)|  
|TypeId|Yes|When implemented in a derived class, gets a unique identifier for this Attribute. (Inherited from Attribute.)|No validation (Receive.Content and SendReply.Content must match the message contract type).|  
|WrapperName|Yes|Gets or sets the name of the wrapper element of the message body.|No validation (Receive.Content and SendReply.Content must match the message contract type).|  
|WrapperNamespace|No|Gets or sets the namespace of the message body wrapper element.|(N/A)|  
  
###  <a name="DataContract"></a> Data Contract Attributes  
  
|Property Name|Supported|Description|WF Validation|  
|-------------------|---------------|-----------------|-------------------|  
|IsReference|No|Gets or sets a value that indicates whether to preserve object reference data.|(N/A)|  
|Name|Yes|Gets or sets the name of the data contract for the type.|No validation (Receive.Content and SendReply.Content must match the message contract type).|  
|Namespace|Yes|Gets or sets the namespace for the data contract for the type.|No validation (Receive.Content and SendReply.Content must match the message contract type).|  
|TypeId|No|When implemented in a derived class, gets a unique identifier for this Attribute. (Inherited from Attribute.)|(N/A)|  
  
###  <a name="FaultContract"></a> Fault Contract Attributes  
  
|Property Name|Supported|Description|WF Validation|  
|-------------------|---------------|-----------------|-------------------|  
|Action|Yes|Gets or sets the action of the SOAP fault message that is specified as part of the operation contract.|SendReply.Action should match.|  
|DetailType|Yes|Gets the type of a serializable object that contains error information.|SendReply.Content should match the type|  
|HasProtectionLevel|No|Gets a value that indicates whether the SOAP fault message has a protection level assigned.|(N/A)|  
|Name|No|Gets or sets the name of the fault message in Web Services Description Language (WSDL).|(N/A)|  
|Namespace|No|Gets or sets the namespace of the SOAP fault.|(N/A)|  
|ProtectionLevel|No|Specifies the level of protection the SOAP fault requires from the binding.|(N/A)|  
|TypeId|No|When implemented in a derived class, gets a unique identifier for this Attribute. (Inherited from Attribute.)|(N/A)|  
  
##  <a name="AdditionalSupport"></a> Additional Support and Implementation Information  
  
-   [Unsupported service contract features](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#UnsupportedFeatures)  
  
-   [Generation of configured messaging activities](../../../docs/framework/windows-workflow-foundation/contract-first-workflow-service-development.md#ActivityGeneration)  
  
###  <a name="UnsupportedFeatures"></a> Unsupported service contract features  
  
-   Use of TPL (Task Parallel Library) Tasks in contracts is not supported.  
  
-   Inheritance in Service Contracts is not supported.  
  
###  <a name="ActivityGeneration"></a> Generation of configured messaging activities  
 Two public static methods are added to the <xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.SendReply> activities to support the generation of pre-configured message activities when using contract-first workflow services.  
  
-   <xref:System.ServiceModel.Activities.Receive.FromOperationDescription%2A?displayProperty=nameWithType>  
  
-   <xref:System.ServiceModel.Activities.SendReply.FromOperationDescription%2A?displayProperty=nameWithType>  
  
 The activity generated by these methods should pass contract validation, and therefore these methods are used internally as part of the validation logic for <xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.SendReply>. The <xref:System.ServiceModel.Activities.Receive.OperationName%2A>,  <xref:System.ServiceModel.Activities.Receive.ServiceContractName%2A>,  <xref:System.ServiceModel.Activities.Receive.Action%2A>,  <xref:System.ServiceModel.Activities.Receive.SerializerOption%2A>,  <xref:System.ServiceModel.Activities.Receive.ProtectionLevel%2A>, and <xref:System.ServiceModel.Activities.Receive.KnownTypes%2A> are all pre-configured to match the imported contract. In the content properties page for the activities in the workflow designer, the **Message** or **Parameters** sections are also pre-configured to match the contract.  
  
 WCF fault contracts are also handled by returning a separate set of configured <xref:System.ServiceModel.Activities.SendReply> activities for each of the faults that show up in the <xref:System.ServiceModel.Description.OperationDescription.Faults%2A> <xref:System.ServiceModel.Description.FaultDescriptionCollection>.  
  
 For other parts of <xref:System.ServiceModel.Description.OperationDescription> that are unsupported by WF services today (e.g. WebGet/WebInvoke behaviors, or custom operation behaviors), the API will ignore those values as part of the generation and configuration. No exceptions will be thrown.
