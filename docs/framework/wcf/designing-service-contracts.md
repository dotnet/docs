---
title: "Designing Service Contracts"
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
  - "service contracts [WCF]"
ms.assetid: 8e89cbb9-ac84-4f0d-85ef-0eb6be0022fd
caps.latest.revision: 34
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Designing Service Contracts
This topic describes what service contracts are, how they are defined, what operations are available (and the implications for the underlying message exchanges), what data types are used, and other issues that help you design operations that satisfy the requirements of your scenario.  
  
## Creating a Service Contract  
 Services expose a number of operations. In [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] applications, define the operations by creating a method and marking it with the <xref:System.ServiceModel.OperationContractAttribute> attribute. Then, to create a service contract, group together your operations, either by declaring them within an interface marked with the <xref:System.ServiceModel.ServiceContractAttribute> attribute, or by defining them in a class marked with the same attribute. (For a basic example, see [How to: Define a Service Contract](../../../docs/framework/wcf/how-to-define-a-wcf-service-contract.md).)  
  
 Any methods that do not have a <xref:System.ServiceModel.OperationContractAttribute> attribute are not service operations and are not exposed by [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services.  
  
 This topic describes the following decision points when designing a service contract:  
  
-   Whether to use classes or interfaces.  
  
-   How to specify the data types you want to exchange.  
  
-   The types of exchange patterns you can use.  
  
-   Whether you can make explicit security requirements part of the contract.  
  
-   The restrictions for operation inputs and outputs.  
  
## Classes or Interfaces  
 Both classes and interfaces represent a grouping of functionality and, therefore, both can be used to define a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service contract. However, it is recommended that you use interfaces because they directly model service contracts. Without an implementation, interfaces do no more than define a grouping of methods with certain signatures. Implement a service contract interface and you have implemented a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service.  
  
 All the benefits of managed interfaces apply to service contract interfaces:  
  
-   Service contract interfaces can extend any number of other service contract interfaces.  
  
-   A single class can implement any number of service contracts by implementing those service contract interfaces.  
  
-   You can modify the implementation of a service contract by changing the interface implementation, while the service contract remains the same.  
  
-   You can version your service by implementing the old interface and the new one. Old clients connect to the original version, while newer clients can connect to the newer version.  
  
> [!NOTE]
>  When inheriting from other service contract interfaces, you cannot override operation properties, such as the name or namespace. If you attempt to do so, you create a new operation in the current service contract.  
  
 [!INCLUDE[crexample](../../../includes/crexample-md.md)] using an interface to create a service contract, see [How to: Create a Service with a Contract Interface](../../../docs/framework/wcf/feature-details/how-to-create-a-service-with-a-contract-interface.md).  
  
 You can, however, use a class to define a service contract and implement that contract at the same time. The advantage of creating your services by applying <xref:System.ServiceModel.ServiceContractAttribute> and <xref:System.ServiceModel.OperationContractAttribute> directly to the class and the methods on the class, respectively, is speed and simplicity. The disadvantages are that managed classes do not support multiple inheritance, and as a result they can only implement one service contract at a time. In addition, any modification to the class or method signatures modifies the public contract for that service, which can prevent unmodified clients from using your service. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Implementing Service Contracts](../../../docs/framework/wcf/implementing-service-contracts.md).  
  
 For an example that uses a class to create a service contract and implements it at the same time, see [How to: Create a Service with a Contract Class](../../../docs/framework/wcf/feature-details/how-to-create-a-wcf-contract-with-a-class.md).  
  
 At this point, you should understand the difference between defining your service contract by using an interface and by using a class. The next step is deciding what data can be passed back and forth between a service and its clients.  
  
## Parameters and Return Values  
 Each operation has a return value and a parameter, even if these are `void`. However, unlike a local method, in which you can pass references to objects from one object to another, service operations do not pass references to objects. Instead, they pass copies of the objects.  
  
 This is significant because each type used in a parameter or return value must be serializable; that is, it must be possible to convert an object of that type into a stream of bytes and from a stream of bytes into an object.  
  
 Primitive types are serializable by default, as are many types in the .NET Framework.  
  
> [!NOTE]
>  The value of the parameter names in the operation signature are part of the contract and are case sensitive. If you want to use the same parameter name locally but modify the name in the published metadata, see the <xref:System.ServiceModel.MessageParameterAttribute?displayProperty=nameWithType>.  
  
#### Data Contracts  
 Service-oriented applications like [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] applications are designed to interoperate with the widest possible number of client applications on both Microsoft and non-Microsoft platforms. For the widest possible interoperability, it is recommended that you mark your types with the <xref:System.Runtime.Serialization.DataContractAttribute> and <xref:System.Runtime.Serialization.DataMemberAttribute> attributes to create a data contract, which is the portion of the service contract that describes the data that your service operations exchange.  
  
 Data contracts are opt-in style contracts: No type or data member is serialized unless you explicitly apply the data contract attribute. Data contracts are unrelated to the access scope of the managed code: Private data members can be serialized and sent elsewhere to be accessed publicly. (For a basic example of a data contract, see [How to: Create a Basic Data Contract for a Class or Structure](../../../docs/framework/wcf/feature-details/how-to-create-a-basic-data-contract-for-a-class-or-structure.md).) [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] handles the definition of the underlying SOAP messages that enable the operation's functionality as well as the serialization of your data types into and out of the body of the messages. As long as your data types are serializable, you do not need to think about the underlying message exchange infrastructure when designing your operations.  
  
 Although the typical [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] application uses the <xref:System.Runtime.Serialization.DataContractAttribute> and <xref:System.Runtime.Serialization.DataMemberAttribute> attributes to create data contracts for operations, you can use other serialization mechanisms. The standard <xref:System.Runtime.Serialization.ISerializable>, <xref:System.SerializableAttribute> and <xref:System.Xml.Serialization.IXmlSerializable> mechanisms all work to handle the serialization of your data types into the underlying SOAP messages that carry them from one application to another. You can employ more serialization strategies if your data types require special support. [!INCLUDE[crabout](../../../includes/crabout-md.md)] the choices for serialization of data types in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications, see [Specifying Data Transfer in Service Contracts](../../../docs/framework/wcf/feature-details/specifying-data-transfer-in-service-contracts.md).  
  
#### Mapping Parameters and Return Values to Message Exchanges  
 Service operations are supported by an underlying exchange of SOAP messages that transfer application data back and forth, in addition to the data required by the application to support certain standard security, transaction, and session-related features. Because this is the case, the signature of a service operation dictates a certain underlying *message exchange pattern* (MEP) that can support the data transfer and the features an operation requires. You can specify three patterns in the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] programming model: request/reply, one-way, and duplex message patterns.  
  
##### Request/Reply  
 A request/reply pattern is one in which a request sender (a client application) receives a reply with which the request is correlated. This is the default MEP because it supports an operation in which one or more parameters are passed to the operation and a return value is passed back to the caller. For example, the following C# code example shows a basic service operation that takes one string and returns a string.  
  
```csharp  
[OperationContractAttribute]  
string Hello(string greeting);  
```  
  
 The following is the equivalent Visual Basic code.  
  
```vb  
<OperationContractAttribute()>  
Function Hello (ByVal greeting As String) As String  
```  
  
 This operation signature dictates the form of underlying message exchange. If no correlation existed, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] cannot determine for which operation the return value is intended.  
  
 Note that unless you specify a different underlying message pattern, even service operations that return `void` (`Nothing` in [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]) are request/reply message exchanges. The result for your operation is that unless a client invokes the operation asynchronously, the client stops processing until the return message is received, even though that message is empty in the normal case. The following C# code example shows an operation that does not return until the client has received an empty message in response.  
  
```csharp  
[OperationContractAttribute]  
void Hello(string greeting);  
```  
  
 The following is the equivalent Visual Basic code.  
  
```vb  
<OperationContractAttribute()>  
Sub Hello (ByVal greeting As String)  
```  
  
 The preceding example can slow client performance and responsiveness if the operation takes a long time to perform, but there are advantages to request/reply operations even when they return `void`. The most obvious one is that SOAP faults can be returned in the response message, which indicates that some service-related error condition has occurred, whether in communication or processing. SOAP faults that are specified in a service contract are passed to the client application as a <xref:System.ServiceModel.FaultException%601> object, where the type parameter is the type specified in the service contract. This makes notifying clients about error conditions in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services easy. [!INCLUDE[crabout](../../../includes/crabout-md.md)] exceptions, SOAP faults, and error handling, see [Specifying and Handling Faults in Contracts and Services](../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md). To see an example of a request/reply service and client, see [How to: Create a Request-Reply Contract](../../../docs/framework/wcf/feature-details/how-to-create-a-request-reply-contract.md). [!INCLUDE[crabout](../../../includes/crabout-md.md)] issues with the request-reply pattern, see [Request-Reply Services](../../../docs/framework/wcf/feature-details/request-reply-services.md).  
  
##### One-way  
 If the client of a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service application should not wait for the operation to complete and does not process SOAP faults, the operation can specify a one-way message pattern. A one-way operation is one in which a client invokes an operation and continues processing after [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] writes the message to the network. Typically this means that unless the data being sent in the outbound message is extremely large the client continues running almost immediately (unless there is an error sending the data). This type of message exchange pattern supports event-like behavior from a client to a service application.  
  
 A message exchange in which one message is sent and none are received cannot support a service operation that specifies a return value other than `void`; in this case an <xref:System.InvalidOperationException> exception is thrown.  
  
 No return message also means that there can be no SOAP fault returned to indicate any errors in processing or communication. (Communicating error information when operations are one-way operations requires a duplex message exchange pattern.)  
  
 To specify a one-way message exchange for an operation that returns `void`, set the <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A> property to `true`, as in the following C# code example.  
  
```csharp  
[OperationContractAttribute(IsOneWay=true)]  
void Hello(string greeting);  
```  
  
 The following is the equivalent Visual Basic code.  
  
```vb  
<OperationContractAttribute(IsOneWay := True)>  
Sub Hello (ByVal greeting As String)  
```  
  
 This method is identical to the preceding request/reply example, but setting the <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A> property to `true` means that although the method is identical, the service operation does not send a return message and clients return immediately once the outbound message has been handed to the channel layer. For an example, see [How to: Create a One-Way Contract](../../../docs/framework/wcf/feature-details/how-to-create-a-one-way-contract.md). [!INCLUDE[crabout](../../../includes/crabout-md.md)] the one-way pattern, see [One-Way Services](../../../docs/framework/wcf/feature-details/one-way-services.md).  
  
##### Duplex  
 A duplex pattern is characterized by the ability of both the service and the client to send messages to each other independently whether using one-way or request/reply messaging. This form of two-way communication is useful for services that must communicate directly to the client or for providing an asynchronous experience to either side of a message exchange, including event-like behavior.  
  
 The duplex pattern is slightly more complex than the request/reply or one-way patterns because of the additional mechanism for communicating with the client.  
  
 To design a duplex contract, you must also design a callback contract and assign the type of that callback contract to the <xref:System.ServiceModel.ServiceContractAttribute.CallbackContract%2A> property of the <xref:System.ServiceModel.ServiceContractAttribute> attribute that marks your service contract.  
  
 To implement a duplex pattern, you must create a second interface that contains the method declarations that are called on the client.  
  
 [!INCLUDE[crexample](../../../includes/crexample-md.md)] creating a service, and a client that accesses that service, see [How to: Create a Duplex Contract](../../../docs/framework/wcf/feature-details/how-to-create-a-duplex-contract.md) and [How to: Access Services with a Duplex Contract](../../../docs/framework/wcf/feature-details/how-to-access-services-with-a-duplex-contract.md). For a working sample, see [Duplex](../../../docs/framework/wcf/samples/duplex.md). [!INCLUDE[crabout](../../../includes/crabout-md.md)] issues using duplex contracts, see [Duplex Services](../../../docs/framework/wcf/feature-details/duplex-services.md).  
  
> [!CAUTION]
>  When a service receives a duplex message, it looks at the `ReplyTo` element in that incoming message to determine where to send the reply. If the channel that is used to receive the message is not secured, then an untrusted client could send a malicious message with a target machine's `ReplyTo`, leading to a denial of service (DOS) of that target machine.  
  
##### Out and Ref Parameters  
 In most cases, you can use `in` parameters (`ByVal` in [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]) and `out` and `ref` parameters (`ByRef` in [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]). Because both `out` and `ref` parameters indicate that data is returned from an operation, an operation signature such as the following specifies that a request/reply operation is required even though the operation signature returns `void`.  
  
```csharp  
[ServiceContractAttribute]  
public interface IMyContract  
{  
  [OperationContractAttribute]  
  public void PopulateData(ref CustomDataType data);  
}  
```  
  
 The following is the equivalent Visual Basic code.  
  
```vb  
<ServiceContractAttribute()> _  
Public Interface IMyContract  
  <OperationContractAttribute()> _  
  Public Sub PopulateData(ByRef data As CustomDataType)  
End Interface  
```  
  
 The only exceptions are those cases in which your signature has a particular structure. For example, you can use the <xref:System.ServiceModel.NetMsmqBinding> binding to communicate with clients only if the method used to declare an operation returns `void`; there can be no output value, whether it is a return value, `ref`, or `out` parameter.  
  
 In addition, using `out` or `ref` parameters requires that the operation have an underlying response message to carry back the modified object. If your operation is a one-way operation, an <xref:System.InvalidOperationException> exception is thrown at runtime.  
  
### Specify Message Protection Level on the Contract  
 When designing your contract, you must also decide the message protection level of services that implement your contract. This is necessary only if message security is applied to the binding in the contract's endpoint. If the binding has security turned off (that is, if the system-provided binding sets the <xref:System.ServiceModel.SecurityMode?displayProperty=nameWithType> to the value <xref:System.ServiceModel.SecurityMode.None?displayProperty=nameWithType>) then you do not have to decide on the message protection level for the contract. In most cases, system-provided bindings with message-level security applied provide a sufficient protection level and you do not have to consider the protection level for each operation or for each message.  
  
 The protection level is a value that specifies whether the messages (or message parts) that support a service are signed, signed and encrypted, or sent without signatures or encryption. The protection level can be set at various scopes: At the service level, for a particular operation, for a message within that operation, or a message part. Values set at one scope become the default value for smaller scopes unless explicitly overridden. If a binding configuration cannot provide the required minimum protection level for the contract, an exception is thrown. And when no protection level values are explicitly set on the contract, the binding configuration controls the protection level for all messages if the binding has message security. This is the default behavior.  
  
> [!IMPORTANT]
>  Deciding whether to explicitly set various scopes of a contract to less than the full protection level of <xref:System.Net.Security.ProtectionLevel.EncryptAndSign?displayProperty=nameWithType> is generally a decision that trades some degree of security for increased performance. In these cases, your decisions must revolve around your operations and the value of the data they exchange. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Securing Services](../../../docs/framework/wcf/securing-services.md).  
  
 For example, the following code example does not set either the <xref:System.ServiceModel.ServiceContractAttribute.ProtectionLevel%2A> or the <xref:System.ServiceModel.OperationContractAttribute.ProtectionLevel%2A> property on the contract.  
  
```csharp  
[ServiceContract]  
public interface ISampleService  
{  
  [OperationContractAttribute]  
  public string GetString();  
  
  [OperationContractAttribute]  
  public int GetInt();    
}  
```  
  
 The following is the equivalent Visual Basic code.  
  
```vb  
<ServiceContractAttribute()> _  
Public Interface ISampleService  
  
  <OperationContractAttribute()> _  
  Public Function GetString()As String  
  
  <OperationContractAttribute()> _  
  Public Function GetData() As Integer  
  
End Interface  
```  
  
 When interacting with an `ISampleService` implementation in an endpoint with a default <xref:System.ServiceModel.WSHttpBinding> (the default <xref:System.ServiceModel.SecurityMode?displayProperty=nameWithType>, which is <xref:System.ServiceModel.SecurityMode.Message>), all messages are encrypted and signed because this is the default protection level. However, when an `ISampleService` service is used with a default <xref:System.ServiceModel.BasicHttpBinding> (the default <xref:System.ServiceModel.SecurityMode>, which is <xref:System.ServiceModel.SecurityMode.None>), all messages are sent as text because there is no security for this binding and so the protection level is ignored (that is, the messages are neither encrypted nor signed). If the <xref:System.ServiceModel.SecurityMode> was changed to <xref:System.ServiceModel.SecurityMode.Message>, then these messages would be encrypted and signed (because that would now be the binding's default protection level).  
  
 If you want to explicitly specify or adjust the protection requirements for your contract, set the <xref:System.ServiceModel.ServiceContractAttribute.ProtectionLevel%2A> property (or any of the `ProtectionLevel` properties at a smaller scope) to the level your service contract requires. In this case, using an explicit setting requires the binding to support that setting at a minimum for the scope used. For example, the following code example specifies one <xref:System.ServiceModel.OperationContractAttribute.ProtectionLevel%2A> value explicitly, for the `GetGuid` operation.  
  
```csharp  
[ServiceContract]  
public interface IExplicitProtectionLevelSampleService  
{  
  [OperationContractAttribute]  
  public string GetString();  
  
  [OperationContractAttribute(ProtectionLevel=ProtectionLevel.None)]  
  public int GetInt();    
  [OperationContractAttribute(ProtectionLevel=ProtectionLevel.EncryptAndSign)]  
  public int GetGuid();    
}  
```  
  
 The following is the equivalent Visual Basic code.  
  
```vb  
<ServiceContract()> _   
Public Interface IExplicitProtectionLevelSampleService   
    <OperationContract()> _   
    Public Function GetString() As String   
    End Function   
  
    <OperationContract(ProtectionLevel := ProtectionLevel.None)> _   
    Public Function GetInt() As Integer   
    End Function   
  
    <OperationContractAttribute(ProtectionLevel := ProtectionLevel.EncryptAndSign)> _   
    Public Function GetGuid() As Integer   
    End Function   
  
End Interface  
```  
  
 A service that implements this `IExplicitProtectionLevelSampleService` contract and has an endpoint that uses the default <xref:System.ServiceModel.WSHttpBinding> (the default <xref:System.ServiceModel.SecurityMode?displayProperty=nameWithType>, which is <xref:System.ServiceModel.SecurityMode.Message>) has the following behavior:  
  
-   The `GetString` operation messages are encrypted and signed.  
  
-   The `GetInt` operation messages are sent as unencrypted and unsigned (that is, plain) text.  
  
-   The `GetGuid` operation <xref:System.Guid?displayProperty=nameWithType> is returned in a message that is encrypted and signed.  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] protection levels and how to use them, see [Understanding Protection Level](../../../docs/framework/wcf/understanding-protection-level.md). [!INCLUDE[crabout](../../../includes/crabout-md.md)] security, see [Securing Services](../../../docs/framework/wcf/securing-services.md).  
  
##### Other Operation Signature Requirements  
 Some application features require a particular kind of operation signature. For example, the <xref:System.ServiceModel.NetMsmqBinding> binding supports durable services and clients, in which an application can restart in the middle of communication and pick up where it left off without missing any messages. ([!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Queues in WCF](../../../docs/framework/wcf/feature-details/queues-in-wcf.md).) However, durable operations must take only one `in` parameter and have no return value.  
  
 Another example is the use of <xref:System.IO.Stream> types in operations. Because the <xref:System.IO.Stream> parameter includes the entire message body, if an input or an output (that is, `ref` parameter, `out` parameter, or return value) is of type <xref:System.IO.Stream>, then it must be the only input or output specified in your operation. In addition, the parameter or return type must be either <xref:System.IO.Stream>, <xref:System.ServiceModel.Channels.Message?displayProperty=nameWithType>, or <xref:System.Xml.Serialization.IXmlSerializable?displayProperty=nameWithType>. [!INCLUDE[crabout](../../../includes/crabout-md.md)] streams, see [Large Data and Streaming](../../../docs/framework/wcf/feature-details/large-data-and-streaming.md).  
  
##### Names, Namespaces, and Obfuscation  
 The names and namespaces of the .NET types in the definition of contracts and operations are significant when contracts are converted into WSDL and when contract messages are created and sent. Therefore, it is strongly recommended that service contract names and namespaces are explicitly set using the `Name` and `Namespace` properties of all supporting contract attributes such as the <xref:System.ServiceModel.ServiceContractAttribute>, <xref:System.ServiceModel.OperationContractAttribute>, <xref:System.Runtime.Serialization.DataContractAttribute>,  <xref:System.Runtime.Serialization.DataMemberAttribute>, and other contract attributes.  
  
 One result of this is that if the names and namespaces are not explicitly set, the use of IL obfuscation on the assembly alters the contract type names and namespaces and results in modified WSDL and wire exchanges that typically fail. If you do not set the contract names and namespaces explicitly but do intend to use obfuscation, use the <xref:System.Reflection.ObfuscationAttribute> and <xref:System.Reflection.ObfuscateAssemblyAttribute> attributes to prevent the modification of the contract type names and namespaces.  
  
## See Also  
 [How to: Create a Request-Reply Contract](../../../docs/framework/wcf/feature-details/how-to-create-a-request-reply-contract.md)  
 [How to: Create a One-Way Contract](../../../docs/framework/wcf/feature-details/how-to-create-a-one-way-contract.md)  
 [How to: Create a Duplex Contract](../../../docs/framework/wcf/feature-details/how-to-create-a-duplex-contract.md)  
 [Specifying Data Transfer in Service Contracts](../../../docs/framework/wcf/feature-details/specifying-data-transfer-in-service-contracts.md)  
 [Specifying and Handling Faults in Contracts and Services](../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md)  
 [Using Sessions](../../../docs/framework/wcf/using-sessions.md)  
 [Synchronous and Asynchronous Operations](../../../docs/framework/wcf/synchronous-and-asynchronous-operations.md)  
 [Reliable Services](../../../docs/framework/wcf/reliable-services.md)  
 [Services and Transactions](../../../docs/framework/wcf/services-and-transactions.md)
