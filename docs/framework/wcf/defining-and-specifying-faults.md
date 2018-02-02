---
title: "Defining and Specifying Faults"
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
helpviewer_keywords: 
  - "handling faults [WCF], specifying"
  - "handling faults [WCF], defining"
ms.assetid: c00c84f1-962d-46a7-b07f-ebc4f80fbfc1
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Defining and Specifying Faults
SOAP faults convey error condition information from a service to a client and, in the duplex case, from a client to a service in an interoperable way. This topic discusses when and how to define custom fault content and specify which operations can return them. [!INCLUDE[crabout](../../../includes/crabout-md.md)] how a service, or duplex client, can send those faults and how a client or service application handles these faults, see [Sending and Receiving Faults](../../../docs/framework/wcf/sending-and-receiving-faults.md). For an overview of error handling in [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] applications, see [Specifying and Handling Faults in Contracts and Services](../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md).  
  
## Overview  
 Declared SOAP faults are those in which an operation has a <xref:System.ServiceModel.FaultContractAttribute?displayProperty=nameWithType> that specifies a custom SOAP fault type. Undeclared SOAP faults are those that are not specified in the contract for an operation. This topic helps you identify those error conditions and create a fault contract for your service that clients can use to properly handle those error conditions when notified by custom SOAP faults. The basic tasks are, in order:  
  
1.  Define the error conditions that a client of your service should know about.  
  
2.  Define the custom content of the SOAP faults for those error conditions.  
  
3.  Mark your operations so that the specific SOAP faults that they throw are exposed to clients in WSDL.  
  
### Defining Error Conditions That Clients Should Know About  
 SOAP faults are publicly described messages that carry fault information for a particular operation. Because they are described along with other operation messages in WSDL, clients know and, therefore, expect to handle such faults when invoking an operation. But because [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services are written in managed code, deciding which error conditions in managed code are to be converted into faults and returned to the client provides you the opportunity to separate error conditions and bugs in your service from the formal error conversation you have with a client.  
  
 For example, the following code example shows an operation that takes two integers and returns another integer. Several exceptions can be thrown here, so when designing the fault contract, you must determine which error conditions are important for your client. In this case, the service should detect the <xref:System.DivideByZeroException?displayProperty=nameWithType> exception.  
  
```csharp  
[ServiceContract]  
public class CalculatorService  
{  
    [OperationContract]   
    int Divide(int a, int b)  
    {  
      if (b==0) throw new Exception("Division by zero!");  
      return a/b;  
    }  
}  
```  
  
```vb  
<ServiceContract> _  
Public Class CalculatorService  
    <OperationContract]> _  
    Public Function Divide(ByVal a As Integer, ByVal b As Integer) _  
       As Integer  
      If (b==0) Then   
            Throw New Exception("Division by zero!")  
      Return a/b  
    End Function  
End Class  
```  
  
 In the preceding example the operation can either return a custom SOAP fault that is specific to dividing by zero, a custom fault that is specific to math operations but that contains information specific to dividing by zero, multiple faults for several different error situations, or no SOAP fault at all.  
  
### Define the Content of Error Conditions  
 Once an error condition has been identified as one that can usefully return a custom SOAP fault, the next step is to define the contents of that fault and ensure that the content structure can be serialized. The code example in the preceding section shows an error specific to a `Divide` operation, but if there are other operations on the `Calculator` service, then a single custom SOAP fault can inform the client of all calculator error conditions, `Divide` included. The following code example shows the creation of a custom SOAP fault, `MathFault`, which can report errors made using all math operations, including `Divide`. While the class can specify an operation (the `Operation` property) and a value that describes the problem (the `ProblemType` property), the class and these properties must be serializable to be transferred to the client in a custom SOAP fault. Therefore, the <xref:System.Runtime.Serialization.DataContractAttribute?displayProperty=nameWithType> and <xref:System.Runtime.Serialization.DataMemberAttribute?displayProperty=nameWithType> attributes are used to make the type and its properties serializable and as interoperable as possible.  
  
 [!code-csharp[Faults#2](../../../samples/snippets/csharp/VS_Snippets_CFX/faults/cs/service.cs#2)]
 [!code-vb[Faults#2](../../../samples/snippets/visualbasic/VS_Snippets_CFX/faults/vb/service.vb#2)]  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] how to ensure your data is serializable, see [Specifying Data Transfer in Service Contracts](../../../docs/framework/wcf/feature-details/specifying-data-transfer-in-service-contracts.md). For a list of the serialization support that <xref:System.Runtime.Serialization.DataContractSerializer?displayProperty=nameWithType> provides, see [Types Supported by the Data Contract Serializer](../../../docs/framework/wcf/feature-details/types-supported-by-the-data-contract-serializer.md).  
  
### Mark Operations to Establish the Fault Contract  
 Once a serializable data structure that is returned as part of a custom SOAP fault is defined, the last step is to mark your operation contract as throwing a SOAP fault of that type. To do this, use the <xref:System.ServiceModel.FaultContractAttribute?displayProperty=nameWithType> attribute and pass the type of the custom data type that you have constructed. The following code example shows how to use the <xref:System.ServiceModel.FaultContractAttribute> attribute to specify that the `Divide` operation can return a SOAP fault of type `MathFault`. Other math-based operations can now also specify that they can return a `MathFault`.  
  
 [!code-csharp[Faults#1](../../../samples/snippets/csharp/VS_Snippets_CFX/faults/cs/service.cs#1)]
 [!code-vb[Faults#1](../../../samples/snippets/visualbasic/VS_Snippets_CFX/faults/vb/service.vb#1)]  
  
 An operation can specify that it returns more than one custom fault by marking that operation with more than one <xref:System.ServiceModel.FaultContractAttribute> attribute.  
  
 The next step, to implement the fault contract in your operation implementation, is described in the topic [Sending and Receiving Faults](../../../docs/framework/wcf/sending-and-receiving-faults.md).  
  
#### SOAP, WSDL, and Interoperability Considerations  
 In some circumstances, especially when interoperating with other platforms, it may be important to control the way a fault appears in a SOAP message or the way it is described in the WSDL metadata.  
  
 The <xref:System.ServiceModel.FaultContractAttribute> attribute has a <xref:System.ServiceModel.FaultContractAttribute.Name%2A> property that allows control of the WSDL fault element name that is generated in the metadata for that fault.  
  
 According to the SOAP standard, a fault can have an `Action`, a `Code`, and a `Reason`. The `Action` is controlled by the <xref:System.ServiceModel.FaultContractAttribute.Action%2A> property. The <xref:System.ServiceModel.FaultException.Code%2A> property and <xref:System.ServiceModel.FaultException.Reason%2A> property are both properties of the <xref:System.ServiceModel.FaultException?displayProperty=nameWithType> class, which is the parent class of the generic <xref:System.ServiceModel.FaultException%601?displayProperty=nameWithType>. The `Code` property includes a <xref:System.ServiceModel.FaultCode.SubCode%2A> member.  
  
 When accessing non-services that generate faults, certain limitations exist. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] supports only faults with detail types that the schema describes and that are compatible with data contracts. For example, as mentioned above, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] does not support faults that use XML attributes in their detail types, or faults with more than one top-level element in the detail section.  
  
## See Also  
 <xref:System.ServiceModel.FaultContractAttribute>  
 <xref:System.Runtime.Serialization.DataContractAttribute>  
 <xref:System.Runtime.Serialization.DataMemberAttribute>  
 [Specifying and Handling Faults in Contracts and Services](../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md)  
 [Sending and Receiving Faults](../../../docs/framework/wcf/sending-and-receiving-faults.md)  
 [How to: Declare Faults in Service Contracts](../../../docs/framework/wcf/how-to-declare-faults-in-service-contracts.md)  
 [Understanding Protection Level](../../../docs/framework/wcf/understanding-protection-level.md)  
 [How to: Set the ProtectionLevel Property](../../../docs/framework/wcf/how-to-set-the-protectionlevel-property.md)  
 [Specifying Data Transfer in Service Contracts](../../../docs/framework/wcf/feature-details/specifying-data-transfer-in-service-contracts.md)
