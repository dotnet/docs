---
title: "ServiceDescription and WSDL Reference"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: eedc025d-abd9-46b1-bf3b-61d2d5c95fd6
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ServiceDescription and WSDL Reference
This topic describes how [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] maps Web Services Description Language (WSDL) documents to and from <xref:System.ServiceModel.Description.ServiceDescription> instances.  
  
## How ServiceDescription Maps to WSDL 1.1  
 You can use [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to export WSDL documents from a <xref:System.ServiceModel.Description.ServiceDescription> instance for your service. WSDL documents are automatically generated for your service when you publish metadata endpoints.  
  
 You can also import <xref:System.ServiceModel.Description.ServiceEndpoint> instances, <xref:System.ServiceModel.Description.ContractDescription> instances, and <xref:System.ServiceModel.Channels.Binding> instances from WSDL documents using the `WsdlImporter` type.  
  
 The WSDL documents, exported by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], import any XML Schema definitions used from external XML Schema documents. A separate XML Schema document is exported for each target namespace the data types use in the service. Likewise, a separate WSDL document is exported for each target namespace the service contracts use.  
  
### ServiceDescription  
 A <xref:System.ServiceModel.Description.ServiceDescription> instance maps to a `wsdl:service` element. A <xref:System.ServiceModel.Description.ServiceDescription> instance contains a collection of <xref:System.ServiceModel.Description.ServiceEndpoint> instances that each map to individual `wsdl:port` elements.  
  
|Properties|WSDL mapping|  
|----------------|------------------|  
|`Name`|The `wsdl:service`/@name value for the service.|  
|`Namespace`|The targetNamespace for the `wsdl:service` definition for the service.|  
|`Endpoints`|The `wsdl:port` definitions for the service.|  
  
### ServiceEndpoint  
 A <xref:System.ServiceModel.Description.ServiceEndpoint> instance maps to a `wsdl:port` element. A <xref:System.ServiceModel.Description.ServiceEndpoint> instance contains an address, a binding, and a contract.  
  
 Endpoint behaviors that implement the <xref:System.ServiceModel.Description.IWsdlExportExtension> interface can modify the `wsdl:port` element for the endpoint they are attached to.  
  
|Properties|WSDL mapping|  
|----------------|------------------|  
|`Name`|The `wsdl:port`/@name value for the endpoint and the `wsdl:binding`/@name value for the endpoint binding.|  
|`Address`|The address for the `wsdl:port` definition for the endpoint.<br /><br /> The transport for the endpoint determines the format of the address. For example, for [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]-supported transports it could be a SOAP address or an endpoint reference.|  
|`Binding`|The `wsdl:binding` definition for the endpoint.<br /><br /> Unlike `wsdl:binding` definitions, bindings in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] are not tied to any one contract.|  
|`Contract`|The `wsdl:portType` definition for the endpoint.|  
|`Behaviors`|Endpoint behaviors that implement the <xref:System.ServiceModel.Description.IWsdlExportExtension> interface can modify the `wsdl:port` for the endpoint.|  
  
### Bindings  
 The binding instance for a `ServiceEndpoint` instance maps to a `wsdl:binding` definition. Unlike `wsdl:binding` definitions, which must be associated with a specific `wsdl:portType` definition, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] bindings are independent of any contract.  
  
 A binding is made up of a collection of binding elements. Each element describes some aspect of how the endpoint communicates with clients. Additionally, a binding has a <xref:System.ServiceModel.Channels.MessageVersion> that indicates the <xref:System.ServiceModel.EnvelopeVersion> and <xref:System.ServiceModel.Channels.AddressingVersion> for the endpoint.  
  
|Properties|WSDL mapping|  
|----------------|------------------|  
|`Name`|Used in the default name of an endpoint, which is the binding name with the contract name appended separated by an underscore.|  
|`Namespace`|The `targetNamespace` for the `wsdl:binding` definition.<br /><br /> On import, if a policy is attached to the WSDL port, the imported binding namespace maps to the `targetNamespace` for the `wsdl:port` definition.|  
|`BindingElementCollection`, as returned by the `CreateBindingElements`() method|Various domain-specific extensions to the `wsdl:binding` definition, typically policy assertions.|  
|`MessageVersion`|The `EnvelopeVersion` and `AddressingVersion` for the endpoint.<br /><br /> When `MessageVersion.None` is specified, the WSDL binding does not contain a SOAP binding and the WSDL port does not contain WS-Addressing content. This setting is typically used for plain old XML (POX) endpoints.|  
  
#### BindingElements  
 The binding elements for an endpoint binding map to various WSDL extensions in the `wsdl:binding`, such as policy assertions.  
  
 The <xref:System.ServiceModel.Channels.TransportBindingElement> for the binding determines the transport Uniform Resource Identifier (URI) for a SOAP binding.  
  
#### AddressingVersion  
 The `AddressingVersion` on a binding maps to the version of addressing used in the `wsd:port`. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports SOAP 1.1 and SOAP 1.2 addresses, and WS-Addressing 08/2004 and WS-Addressing 1.0 endpoint references.  
  
#### EnvelopeVersion  
 The `EnvelopeVersion` on a binding maps to the version of SOAP used in the `wsdl:binding`. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports SOAP 1.1 and SOAP 1.2 bindings.  
  
### Contracts  
 The <xref:System.ServiceModel.Description.ContractDescription> instance for a `ServiceEndpoint` instance maps to a `wsdl:portType`. A `ContractDescription` instance describes all of the operations for a given contract.  
  
|Properties|WSDL mapping|  
|----------------|------------------|  
|`Name`|The `wsdl:portType`/@name value for the contract.|  
|`Namespace`|The targetNamespace for the `wsdl:portType` definition.|  
|`SessionMode`|The `wsdl:portType`/@msc:usingSession value for the contract. This attribute is a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] extension for WSDL 1.1.|  
|`Operations`|The `wsdl:operation` definitions for the contract.|  
  
### Operations  
 An <xref:System.ServiceModel.Description.OperationDescription> instance maps to a `wsdl:portType`/`wsdl:operation`. An `OperationDescription` contains a collection of `MessageDescription` instances that describe the messages for the operation.  
  
 Two operation behaviors participate heavily in how an `OperationDescription` is mapped to a WSDL document: `DataContractSerializerOperationBehavior` and `XmlSerializerOperationBehavior`.  
  
|Properties|WSDL mapping|  
|----------------|------------------|  
|`Name`|The `wsdl:portType`/`wsdl:operation`/@name value for the operation.|  
|`ProtectionLevel`|Protection assertions in security policy attached to the `wsdl:binding/wsdl:operation` messages for this operation.|  
|`IsInitiating`|The `wsdl:portType`/`wsdl:operation`/@msc:isInitiating value for the operation. This attribute is a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] extension for WSDL 1.1.|  
|`IsTerminating`|The `wsdl:portType`/`wsdl:operation`/@msc:isTerminating value for the operation. This attribute is a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] extension for WSDL 1.1.|  
|`Messages`|The `wsdl:portType`/`wsdl:operation`/`wsdl:input` and `wsdl:portType`/`wsdl:operation`/`wsdl:output` messages for the operation.|  
|`Faults`|The `wsdl:portType`/`wsdl:operation`/`wsdl:fault` definitions for the operation.|  
|`Behaviors`|The `DataContractSerializerOperationBehavior` and `XmlSerializerOperationBehavior` deal with the operation binding and the operation messages.|  
  
#### The DataContractSerializerOperationBehavior  
 The `DataContractSerializerOperationBehavior` for an operation is an `IWsdlExportExtension` implementation that exports the WSDL messages and binding for that operation. The XML Schema types are exported using the `XsdDataContractExporter`. The `DataContractSerializerOperationBehavior` also determines the use, style, and schema exporter and importer to use for that operation.  
  
|Properties|WSDL Mapping|  
|----------------|------------------|  
|`DataContractFormatAttribute`|The `Style` property for this attribute maps to the `wsdl:binding`/`wsdl:operation`/`soap:operation`/@style value for the operation.<br /><br /> The `DataContractSerializerOperationBehavior` supports only the literal use of the schema types in the WSDL.|  
  
#### The XmlSerializerOperationBehavior  
 The `XmlSerializerOperationBehavior` for an operation is an `IWsdlExportExtension` implementation that exports the WSDL messages and binding for that operation. The XML Schema types are exported using the `XmlSchemaExporter`. The `XmlSerializerOperationBehavior` also determines the use, style, and schema exporter and importer to use for that operation.  
  
|Properties|WSDL mapping|  
|----------------|------------------|  
|`XmlSerializerFormatAttribute`|The `Style` property for this attribute maps to the `wsdl:binding`/`wsdl:operation`/`soap:operation`/@style value for the operation.<br /><br /> The `Use` property for this attribute maps to the `wsdl:binding`/`wsdl:operation`/`soap:operation`/*/@use values for all messages in the operation.|  
  
### Messages  
 A `MessageDescription` instance maps to a `wsdl:message` that is referenced by a `wsdl:portType`/`wsdl:operation`/`wsdl:input` or a `wsdl:portType`/`wsdl:operation`/`wsdl:output` message in an operation. A `MessageDescription` has a body and headers.  
  
|Properties|WSDL Mapping|  
|----------------|------------------|  
|`Action`|The SOAP or WS-Addressing action for the message.<br /><br /> Note that operations that use the Action string "*" are not represented in WSDL.|  
|`Direction`|`MessageDirection.Input` maps to `wsdl:input`.<br /><br /> `MessageDirection.Output` maps to `wsdl:output`.|  
|`ProtectionLevel`|Protection assertions in security policy attached to the `wsdl:message` definition for this message.|  
|`Body`|The message body for the message.|  
|`Headers`|The headers for the message.|  
|`ContractDescription.Name`, `OperationContract.Name`|On export, used to derive the `wsdl:message`/@name value.|  
  
#### Message Body  
 A `MessageBodyDescription` instance maps to the `wsdl:message`/`wsdl:part` definitions for the body of a message. The message body may be wrapped or bare.  
  
|Properties|WSDL Mapping|  
|----------------|------------------|  
|`WrapperName`|If the style is not RPC, then the `WrapperName` maps to the element name referenced by the `wsdl:message`/`wsdl:part` with @name set to "parameters".|  
|`WrapperNamespace`|If the style is not RPC, then the `WrapperNamespace` maps to the element namespace for the `wsdl:message`/`wsdl:part` with @name set to "parameters".|  
|`Parts`|The message parts for this message body.|  
|`ReturnValue`|The child element of the wrapper element if a wrapper element exists (document wrapped style, or RPC style), otherwise the first `wsdl:message`/`wsdl:part` in the message.|  
  
#### Message Parts  
 A `MessagePartDescription` instance maps to a `wsdl:message`/`wsdl:part` and the XML schema type or element that the message part points to.  
  
|Properties|WSDL mapping|  
|----------------|------------------|  
|`Name`|The `wsd:message`/`wsdl:part`/@name value for the message part and the name of the element that the message part points to.|  
|`Namespace`|The namespace of the element that the message part points to.|  
|`Index`|The index of the `wsdl:message`/`wsdl:part` for the message.|  
|`ProtectionLevel`|Protection assertions in security policy attached to the `wsdl:message` definition for this message part. The policy is parameterized to point to the specific message part.|  
|`MessageType`|The XML Schema type of the element that the message part points to.|  
  
#### Message Headers  
 A `MessageHeaderDescription` instance is a message part that also maps to a `soap:header` binding for the message part.  
  
### Faults  
 A `FaultDescription` instance maps to a `wsdl:portType`/`wsdl:operation`/`wsdl:fault` definition and its associated `wsdl:message` definition. The `wsdl:message` is added to the same target namespace as its associated WSDL port type. The `wsdl:message` has a single message part named "detail" that points to the XML Schema element that corresponds to the `DefaultType` property value for the `FaultDescription` instance.  
  
|Properties|WSDL mapping|  
|----------------|------------------|  
|`Name`|The `wsdl:portType`/`wsdl:operation`/`wsdl:fault`/@name value for the fault.|  
|`Namespace`|The namespace of the XML Schema element that the fault detail message part points to.|  
|`Action`|The SOAP or WS-Addressing action for the fault.|  
|`ProtectionLevel`|Protection assertions in security policy attached to the `wsdl:message` definition for this fault.|  
|`DetailType`|The XML Schema type of the element that the detail message part points to.|  
|`Name, ContractDescription.Name, OperationDescription.Name,`|Used to derive the `wsdl:message`/@name value for the fault message.|  
  
## See Also  
 <xref:System.ServiceModel.Description>
