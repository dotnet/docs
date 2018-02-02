---
title: "Using Message Contracts"
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
  - "message contracts [WCF]"
ms.assetid: 1e19c64a-ae84-4c2f-9155-91c54a77c249
caps.latest.revision: 46
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using Message Contracts
Typically when building [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] applications, developers pay close attention to the data structures and serialization issues and do not need to concern themselves with the structure of the messages in which the data is carried. For these applications, creating data contracts for the parameters or return values is straightforward. ([!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Specifying Data Transfer in Service Contracts](../../../../docs/framework/wcf/feature-details/specifying-data-transfer-in-service-contracts.md).)  
  
 However, sometimes complete control over the structure of a SOAP message is just as important as control over its contents. This is especially true when interoperability is important or to specifically control security issues at the level of the message or message part. In these cases, you can create a *message contract* that enables you to specify the structure of the precise SOAP message required.  
  
 This topic discusses how to use the various message contract attributes to create a specific message contract for your operation.  
  
## Using Message Contracts in Operations  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports operations modeled on either the *remote procedure call (RPC) style* or the *messaging style*. In an RPC-style operation, you can use any serializable type, and you have access to the features that are available to local calls, such as multiple parameters and `ref` and `out` parameters. In this style, the form of serialization chosen controls the structure of the data in the underlying messages, and the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] runtime creates the messages to support the operation. This enables developers who are not familiar with SOAP and SOAP messages to quickly and easily create and use service applications.  
  
 The following code example shows a service operation modeled on the RPC style.  
  
```csharp  
[OperationContract]  
public BankingTransactionResponse PostBankingTransaction(BankingTransaction bt);  
```  
  
 Normally, a data contract is sufficient to define the schema for the messages. For instance, in the preceding example, it is sufficient for most applications if `BankingTransaction` and `BankingTransactionResponse` have data contracts to define the contents of the underlying SOAP messages. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] data contracts, see [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md).  
  
 However, occasionally it is necessary to precisely control how the structure of the SOAP message transmitted over the wire. The most common scenario for this is inserting custom SOAP headers. Another common scenario is to define security properties for the message's headers and body, that is, to decide whether these elements are digitally signed and encrypted. Finally, some third-party SOAP stacks require messages be in a specific format. Messaging-style operations provide this control.  
  
 A messaging-style operation has at most one parameter and one return value where both types are message types; that is, they serialize directly into a specified SOAP message structure. This may be any type marked with the <xref:System.ServiceModel.MessageContractAttribute> or the <xref:System.ServiceModel.Channels.Message> type. The following code example shows an operation similar to the preceding RCP-style, but which uses the messaging style.  
  
 For example, if `BankingTransaction` and `BankingTransactionResponse` are both types that are message contracts, then the code in the following operations is valid.  
  
```csharp  
[OperationContract]  
BankingTransactionResponse Process(BankingTransaction bt);  
[OperationContract]  
void Store(BankingTransaction bt);  
[OperationContract]  
BankingTransactionResponse GetResponse();  
```  
  
 However, the following code is invalid.  
  
```csharp  
[OperationContract]  
bool Validate(BankingTransaction bt);  
// Invalid, the return type is not a message contract.  
[OperationContract]  
void Reconcile(BankingTransaction bt1, BankingTransaction bt2);  
// Invalid, there is more than one parameter.  
```  
  
 An exception is thrown for any operation that involves a message contract type and that does not follow one of the valid patterns. Of course, operations that do not involve message contract types are not subject to these restrictions.  
  
 If a type has both a message contract and a data contract, only its message contract is considered when the type is used in an operation.  
  
## Defining Message Contracts  
 To define a message contract for a type (that is, to define the mapping between the type and a SOAP envelope), apply the <xref:System.ServiceModel.MessageContractAttribute> to the type. Then apply the <xref:System.ServiceModel.MessageHeaderAttribute> to those members of the type you want to make into SOAP headers, and apply the <xref:System.ServiceModel.MessageBodyMemberAttribute> to those members you want to make into parts of the SOAP body of the message.  
  
 The following code provides an example of using a message contract.  
  
```csharp  
[MessageContract]  
public class BankingTransaction  
{  
  [MessageHeader] public Operation operation;  
  [MessageHeader] public DateTime transactionDate;  
  [MessageBodyMember] private Account sourceAccount;  
  [MessageBodyMember] private Account targetAccount;  
  [MessageBodyMember] public int amount;  
}  
```  
  
 When using this type as an operation parameter, the following SOAP envelope is generated:  
  
```xml  
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">  
  <s:Header>  
    <h:operation xmlns:h="http://tempuri.org/" xmlns="http://tempuri.org/">Deposit</h:operation>  
    <h:transactionDate xmlns:h="http://tempuri.org/" xmlns="http://tempuri.org/">2012-02-16T16:10:00</h:transactionDate>  
  </s:Header>  
  <s:Body xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">  
    <BankingTransaction xmlns="http://tempuri.org/">  
      <amount>0</amount>  
      <sourceAccount xsi:nil="true"/>  
      <targetAccount xsi:nil="true"/>  
    </BankingTransaction>  
  </s:Body>  
</s:Envelope>  
```  
  
 Notice that `operation` and `transactionDate` appear as SOAP headers and the SOAP body consists of a wrapper element `BankingTransaction` containing `sourceAccount`,`targetAccount`, and `amount`.  
  
 You can apply the <xref:System.ServiceModel.MessageHeaderAttribute> and <xref:System.ServiceModel.MessageBodyMemberAttribute> to all fields, properties, and events, regardless of whether they are public, private, protected, or internal.  
  
 The <xref:System.ServiceModel.MessageContractAttribute> allows you to specify the WrapperName and WrapperNamespace attributes which control the name of the wrapper element in the body of the SOAP message. By default the name of the message contract type is used for the wrapper and the namespace in which the message contract is defined  `HYPERLINK "http://tempuri.org/" http://tempuri.org/` is used as the default namespace.  
  
> [!NOTE]
>  <xref:System.Runtime.Serialization.KnownTypeAttribute> attributes are ignored in message contracts. If a <xref:System.Runtime.Serialization.KnownTypeAttribute> is required, place it on the operation that is using the message contract in question.  
  
## Controlling Header and Body Part Names and Namespaces  
 In the SOAP representation of a message contract, each header and body part maps to an XML element that has a name and a namespace.  
  
 By default, the namespace is the same as the namespace of the service contract that the message is participating in, and the name is determined by the member name to which the <xref:System.ServiceModel.MessageHeaderAttribute> or the <xref:System.ServiceModel.MessageBodyMemberAttribute> attributes are applied.  
  
 You can change these defaults by manipulating the <xref:System.ServiceModel.MessageContractMemberAttribute.Name%2A?displayProperty=nameWithType> and <xref:System.ServiceModel.MessageContractMemberAttribute.Namespace%2A?displayProperty=nameWithType> (on the parent class of the <xref:System.ServiceModel.MessageHeaderAttribute> and <xref:System.ServiceModel.MessageBodyMemberAttribute> attributes).  
  
 Consider the class in the following code example.  
  
```csharp  
[MessageContract]  
public class BankingTransaction  
{  
  [MessageHeader] public Operation operation;  
  [MessageHeader(Namespace="http://schemas.contoso.com/auditing/2005")] public bool IsAudited;  
  [MessageBodyMember(Name="transactionData")] public BankingTransactionData theData;  
}  
```  
  
 In this example, the `IsAudited` header is in the namespace specified in the code, and the body part that represents the `theData` member is represented by an XML element with the name `transactionData`. The following shows the XML generated for this message contract.  
  
```xml  
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">  
  <s:Header>  
    <h:IsAudited xmlns:h="http://schemas.contoso.com/auditing/2005" xmlns="http://schemas.contoso.com/auditing/2005">false</h:IsAudited>  
    <h:operation xmlns:h="http://tempuri.org/" xmlns="http://tempuri.org/">Deposit</h:operation>  
  </s:Header>  
  <s:Body xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">  
    <AuditedBankingTransaction xmlns="http://tempuri.org/">  
      <transactionData/>  
    </AuditedBankingTransaction>  
  </s:Body>  
</s:Envelope>  
```  
  
## Controlling Whether the SOAP Body Parts Are Wrapped  
 By default, the SOAP body parts are serialized inside a wrapped element. For example, the following code shows the `HelloGreetingMessage` wrapper element generated from the name of the <xref:System.ServiceModel.MessageContractAttribute> type in the message contract for the `HelloGreetingMessage` message.  
  
 [!code-csharp[MessageHeaderAttribute#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/messageheaderattribute/cs/services.cs#3)]
 [!code-vb[MessageHeaderAttribute#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/messageheaderattribute/vb/services.vb#3)]  
  
 To suppress the wrapper element, set the <xref:System.ServiceModel.MessageContractAttribute.IsWrapped%2A> property to `false`. To control the name and the namespace of the wrapper element, use the <xref:System.ServiceModel.MessageContractAttribute.WrapperName%2A> and <xref:System.ServiceModel.MessageContractAttribute.WrapperNamespace%2A> properties.  
  
> [!NOTE]
>  Having more than one message body part in messages that are not wrapped is not compliant with WS-I Basic Profile 1.1 and is not recommended when designing new message contracts. However, it may be necessary to have more than one unwrapped message body part in certain specific interoperability scenarios. If you are going to transmit more than one piece of data in a message body, it is recommended to use the default (wrapped) mode. Having more than one message header in unwrapped messages is completely acceptable.  
  
## Using Custom Types Inside Message Contracts  
 Each individual message header and message body part is serialized (turned into XML) using the chosen serialization engine for the service contract where the message is used. The default serialization engine, the `XmlFormatter`, can handle any type that has a data contract, either explicitly (by having the <xref:System.Runtime.Serialization.DataContractAttribute?displayProperty=nameWithType>) or implicitly (by being a primitive type, having the <xref:System.SerializableAttribute?displayProperty=nameWithType>, and so on). [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md).  
  
 In the preceding example, the `Operation` and `BankingTransactionData` types must have a data contract, and `transactionDate` is serializable because <xref:System.DateTime> is a primitive (and so has an implicit data contract).  
  
 However, it is possible to switch to a different serialization engine, the `XmlSerializer`. If you make such a switch, you should ensure that all of the types used for message headers and body parts are serializable using the `XmlSerializer`.  
  
## Using Arrays Inside Message Contracts  
 You can use arrays of repeating elements in message contracts in two ways.  
  
 The first is to use a <xref:System.ServiceModel.MessageHeaderAttribute> or a <xref:System.ServiceModel.MessageBodyMemberAttribute> directly on the array. In this case, the entire array is serialized as one element (that is, one header or one body part) with multiple child elements. Consider the class in the following example.  
  
```csharp  
[MessageContract]  
public class BankingDepositLog  
{  
  [MessageHeader] public int numRecords;  
  [MessageHeader] public DepositRecord[] records;  
  [MessageHeader] public int branchID;  
}  
```  
  
 This results in SOAP headers is similar to the following.  
  
```xml  
<BankingDepositLog>  
<numRecords>3</numRecords>  
<records>  
  <DepositRecord>Record1</DepositRecord>  
  <DepositRecord>Record2</DepositRecord>  
  <DepositRecord>Record3</DepositRecord>  
</records>  
<branchID>20643</branchID>  
</BankingDepositLog>  
```  
  
 An alternative to this is to use the <xref:System.ServiceModel.MessageHeaderArrayAttribute>. In this case, each array element is serialized independently and so that each array element has one header, similar to the following.  
  
```xml  
<numRecords>3</numRecords>  
<records>Record1</records>  
<records>Record2</records>  
<records>Record3</records>  
<branchID>20643</branchID>  
```  
  
 The default name for array entries is the name of the member to which the <xref:System.ServiceModel.MessageHeaderArrayAttribute> attributes is applied.  
  
 The <xref:System.ServiceModel.MessageHeaderArrayAttribute> attribute inherits from the <xref:System.ServiceModel.MessageHeaderAttribute>. It has the same set of features as the non-array attributes, for example, it is possible to set the order, name, and namespace for an array of headers in the same way you set it for a single header. When you use the `Order` property on an array, it applies to the entire array.  
  
 You can apply the <xref:System.ServiceModel.MessageHeaderArrayAttribute> only to arrays, not collections.  
  
## Using Byte Arrays in Message Contracts  
 Byte arrays, when used with the non-array attributes (<xref:System.ServiceModel.MessageBodyMemberAttribute> and <xref:System.ServiceModel.MessageHeaderAttribute>), are not treated as arrays but as a special primitive type represented as Base64-encoded data in the resulting XML.  
  
 When you use byte arrays with the array attribute <xref:System.ServiceModel.MessageHeaderArrayAttribute>, the results depend on the serializer in use. With the default serializer, the array is represented as an individual entry for each byte. However, when the `XmlSerializer` is selected, (using the <xref:System.ServiceModel.XmlSerializerFormatAttribute> on the service contract), byte arrays are treated as Base64 data regardless of whether the array or non-array attributes are used.  
  
## Signing and Encrypting Parts of the Message  
 A message contract can indicate whether the headers and/or body of the message should be digitally signed and encrypted.  
  
 This is done by setting the <xref:System.ServiceModel.MessageContractMemberAttribute.ProtectionLevel%2A?displayProperty=nameWithType> property on the <xref:System.ServiceModel.MessageHeaderAttribute> and <xref:System.ServiceModel.MessageBodyMemberAttribute> attributes. The property is an enumeration of the <xref:System.Net.Security.ProtectionLevel?displayProperty=nameWithType> type and can be set to <xref:System.Net.Security.ProtectionLevel.None> (no encryption or signature), <xref:System.Net.Security.ProtectionLevel.Sign> (digital signature only), or <xref:System.Net.Security.ProtectionLevel.EncryptAndSign> (both encryption and a digital signature). The default is <xref:System.Net.Security.ProtectionLevel.EncryptAndSign>.  
  
 For these security features to work, you must properly configure the binding and behaviors. If you use these security features without the proper configuration (for example, attempting to sign a message without supplying your credentials), an exception is thrown at validation time.  
  
 For message headers, the protection level is determined individually for each header.  
  
 For message body parts, the protection level can be thought of as the "minimum protection level." The body has only one protection level, regardless of the number of body parts. The protection level of the body is determined by the highest <xref:System.ServiceModel.MessageContractMemberAttribute.ProtectionLevel%2A> property setting of all the body parts. However, you should set the protection level of each body part to the actual minimum protection level required.  
  
 Consider the class in the following code example.  
  
```csharp  
[MessageContract]  
public class PatientRecord  
{  
   [MessageHeader(ProtectionLevel=None)] public int recordID;  
   [MessageHeader(ProtectionLevel=Sign)] public string patientName;  
   [MessageHeader(ProtectionLevel=EncryptAndSign)] public string SSN;  
   [MessageBodyMember(ProtectionLevel=None)] public string comments;  
   [MessageBodyMember(ProtectionLevel=Sign)] public string diagnosis;  
   [MessageBodyMember(ProtectionLevel=EncryptAndSign)] public string medicalHistory;  
}  
```  
  
 In this example, the `recordID` header is not protected, `patientName` is `signed`, and `SSN` is encrypted and signed. At least one body part, `medicalHistory`, has <xref:System.Net.Security.ProtectionLevel.EncryptAndSign> applied, and thus the entire message body is encrypted and signed, even though the comments and diagnosis body parts specify lower protection levels.  
  
## SOAP Action  
 SOAP and related Web services standards define a property called `Action` that can be present for every SOAP message sent. The operation's <xref:System.ServiceModel.OperationContractAttribute.Action%2A?displayProperty=nameWithType> and <xref:System.ServiceModel.OperationContractAttribute.ReplyAction%2A?displayProperty=nameWithType> properties control the value of this property.  
  
## SOAP Header Attributes  
 The SOAP standard defines the following attributes that may exist on a header:  
  
-   `Actor/Role` (`Actor` in SOAP 1.1, `Role` in SOAP 1.2)  
  
-   `MustUnderstand`  
  
-   `Relay`  
  
 The `Actor` or `Role` attribute specifies the Uniform Resource Identifier (URI) of the node for which a given header is intended. The `MustUnderstand` attribute specifies whether the node processing the header must understand it. The `Relay` attribute specifies whether the header is to be relayed to downstream nodes. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not perform any processing of these attributes on incoming messages, except for the `MustUnderstand` attribute, as specified in the "Message Contract Versioning" section later in this topic. However, it allows you to read and write these attributes as necessary, as in the following description.  
  
 When sending a message, these attributes are not emitted by default. You can change this in two ways. First, you may statically set the attributes to any desired values by changing the <xref:System.ServiceModel.MessageHeaderAttribute.Actor%2A?displayProperty=nameWithType>, <xref:System.ServiceModel.MessageHeaderAttribute.MustUnderstand%2A?displayProperty=nameWithType>, and <xref:System.ServiceModel.MessageHeaderAttribute.Relay%2A?displayProperty=nameWithType> properties, as shown in the following code example. (Note that there is no `Role` property; setting the <xref:System.ServiceModel.MessageHeaderAttribute.Actor%2A> property emits the `Role` attribute if you are using SOAP 1.2).  
  
```csharp  
[MessageContract]  
public class BankingTransaction  
{  
  [MessageHeader(Actor="http://auditingservice.contoso.com", MustUnderstand=true)] public bool IsAudited;  
  [MessageHeader] public Operation operation;  
  [MessageBodyMember] public BankingTransactionData theData;  
}  
```  
  
 The second way to control these attributes is dynamically, through code. You can achieve this by wrapping the desired header type in the <xref:System.ServiceModel.MessageHeader%601> type (be sure not to confuse this type with the non-generic version) and by using the type together with the <xref:System.ServiceModel.MessageHeaderAttribute>. Then, you can use properties on the <xref:System.ServiceModel.MessageHeader%601> to set the SOAP attributes, as shown in the following code example.  
  
```csharp  
[MessageContract]  
public class BankingTransaction  
{  
  [MessageHeader] public MessageHeader<bool> IsAudited;  
  [MessageHeader] public Operation operation;  
  [MessageBodyMember] public BankingTransactionData theData;  
}  
// application code:  
BankingTransaction bt = new BankingTransaction();  
bt.IsAudited = new MessageHeader<bool>();  
bt.IsAudited.Content = false; // Set IsAudited header value to "false"  
bt.IsAudited.Actor="http://auditingservice.contoso.com";  
bt.IsAudited.MustUnderstand=true;  
```  
  
 If you use both the dynamic and the static control mechanisms, the static settings are used as a default but can later be overridden by using the dynamic mechanism, as shown in the following code.  
  
```csharp  
[MessageHeader(MustUnderstand=true)] public MessageHeader<Person> documentApprover;  
// later on in the code:  
BankingTransaction bt = new BankingTransaction();  
bt.documentApprover = new MessageHeader<Person>();  
bt.documentApprover.MustUnderstand = false; // override the static default of 'true'  
```  
  
 Creating repeated headers with dynamic attribute control is allowed, as shown in the following code.  
  
```csharp  
[MessageHeaderArray] public MessageHeader<Person> documentApprovers[];  
```  
  
 On the receiving side, reading these SOAP attributes can only be done if the <xref:System.ServiceModel.MessageHeader%601> class is used for the header in the type. Examine the `Actor`, `Relay`, or `MustUnderstand` properties of a header of the <xref:System.ServiceModel.MessageHeader%601> type to discover the attribute settings on the received message.  
  
 When a message is received and then sent back, the SOAP attribute settings only go round-trip for headers of the <xref:System.ServiceModel.MessageHeader%601> type.  
  
## Order of SOAP Body Parts  
 In some circumstances, you may need to control the order of the body parts. The order of the body elements is alphabetical by default, but can be controlled by the <xref:System.ServiceModel.MessageBodyMemberAttribute.Order%2A?displayProperty=nameWithType> property. This property has the same semantics as the <xref:System.Runtime.Serialization.DataMemberAttribute.Order%2A?displayProperty=nameWithType> property, except for the behavior in inheritance scenarios (in message contracts, base type body members are not sorted before the derived type body members). [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Data Member Order](../../../../docs/framework/wcf/feature-details/data-member-order.md).  
  
 In the following example, `amount` would normally come first because it is first alphabetically. However, the <xref:System.ServiceModel.MessageBodyMemberAttribute.Order%2A> property puts it into the third position.  
  
```csharp  
[MessageContract]  
public class BankingTransaction  
{  
  [MessageHeader] public Operation operation;  
  [MessageBodyMember(Order=1)] public Account sourceAccount;  
  [MessageBodyMember(Order=2)] public Account targetAccount;  
  [MessageBodyMember(Order=3)] public int amount;  
}  
```  
  
## Message Contract Versioning  
 Occasionally, you may need to change message contracts. For example, a new version of your application may add an extra header to a message. Then, when sending from the new version to the old, the system must deal with an extra header, as well as a missing header when going in the other direction.  
  
 The following rules apply for versioning headers:  
  
-   [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not object to the missing headers—the corresponding members are left at their default values.  
  
-   [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] also ignores unexpected extra headers. The one exception to this rule is if the extra header has a `MustUnderstand` attribute set to `true` in the incoming SOAP message—in this case, an exception is thrown because a header that must be understood cannot be processed.  
  
 Message bodies have similar versioning rules—both missing and additional message body parts are ignored.  
  
## Inheritance Considerations  
 A message contract type can inherit from another type, as long as the base type also has a message contract.  
  
 When creating or accessing a message using a message contract type that inherits from other message contract types, the following rules apply:  
  
-   All of the message headers in the inheritance hierarchy are collected together to form the full set of headers for the message.  
  
-   All of the message body parts in the inheritance hierarchy are collected together to form the full message body. The body parts are ordered according to the usual ordering rules (by <xref:System.ServiceModel.MessageBodyMemberAttribute.Order%2A?displayProperty=nameWithType> property and then alphabetical), with no relevance to their place in the inheritance hierarchy. Using message contract inheritance where message body parts occur at multiple levels of the inheritance tree is strongly discouraged. If a base class and a derived class define a header or a body part with the same name, the member from the base-most class is used to store the value of that header or body part.  
  
 Consider the classes in the following code example.  
  
```csharp  
[MessageContract]  
public class PersonRecord  
{  
  [MessageHeader(Name="ID")] public int personID;  
  [MessageBodyMember] public string patientName;  
}  
  
[MessageContract]  
public class PatientRecord : PersonRecord  
{  
  [MessageHeader(Name="ID")] public int patientID;  
  [MessageBodyMember] public string diagnosis;  
}  
```  
  
 The `PatientRecord` class describes a message with one header called `ID`. The header corresponds to the `personID` and not the `patientID` member, because the base-most member is chosen. Thus, the `patientID` field is useless in this case. The body of the message contains the `diagnosis` element followed by the `patientName` element, because that is the alphabetical order. Notice that the example shows a pattern that is strongly discouraged: both the base and the derived message contracts have message body parts.  
  
## WSDL Considerations  
 When generating a Web Services Description Language (WSDL) contract from a service that uses message contracts, it is important to remember that not all message contract features are reflected in the resulting WSDL. Consider the following points:  
  
-   WSDL cannot express the concept of an array of headers. When creating messages with an array of headers using the <xref:System.ServiceModel.MessageHeaderArrayAttribute>, the resulting WSDL reflects only one header instead of the array.  
  
-   The resulting WSDL document may not reflect some protection-level information.  
  
-   The message type generated in the WSDL has the same name as the class name of the message contract type.  
  
-   When using the same message contract in multiple operations, multiple message types are generated in the WSDL document. The names are made unique by adding the numbers "2", "3", and so on, for subsequent uses. When importing back the WSDL, multiple message contract types are created and are identical except for their names.  
  
## SOAP Encoding Considerations  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] allows you to use the legacy SOAP encoding style of XML, however, its use is not recommended. When using this style (by setting the `Use` property to `Encoded` on the <xref:System.ServiceModel.XmlSerializerFormatAttribute?displayProperty=nameWithType> applied to the service contract), the following additional considerations apply:  
  
-   The message headers are not supported; this means that the attribute <xref:System.ServiceModel.MessageHeaderAttribute> and the array attribute <xref:System.ServiceModel.MessageHeaderArrayAttribute> are incompatible with SOAP encoding.  
  
-   If the message contract is not wrapped, that is, if the property <xref:System.ServiceModel.MessageContractAttribute.IsWrapped%2A> is set to `false`, the message contract can have only one body part.  
  
-   The name of the wrapper element for the request message contract must match the operation name. Use the `WrapperName` property of the message contract for this.  
  
-   The name of the wrapper element for the response message contract must be the same as the name of the operation suffixed by 'Response'. Use the <xref:System.ServiceModel.MessageContractAttribute.WrapperName%2A> property of the message contract for this.  
  
-   SOAP encoding preserves object references. For example, consider the following code.  
  
    ```csharp  
    [MessageContract(WrapperName="updateChangeRecord")]  
    public class ChangeRecordRequest  
    {  
      [MessageBodyMember] Person changedBy;  
      [MessageBodyMember] Person changedFrom;  
      [MessageBodyMember] Person changedTo;  
    }  
  
    [MessageContract(WrapperName="updateChangeRecordResponse")]  
    public class ChangeRecordResponse  
    {  
      [MessageBodyMember] Person changedBy;  
      [MessageBodyMember] Person changedFrom;  
      [MessageBodyMember] Person changedTo;  
    }  
  
    // application code:  
    ChangeRecordRequest cr = new ChangeRecordRequest();  
    Person p = new Person("John Doe");  
    cr.changedBy=p;  
    cr.changedFrom=p;  
    cr.changedTo=p;  
    ```  
  
 After serializing the message using SOAP encoding, `changedFrom` and `changedTo` do not contain their own copies of `p`, but instead point to the copy inside the `changedBy` element.  
  
## Performance Considerations  
 Every message header and message body part is serialized independently of the others. Therefore, the same namespaces can be declared again for each header and body part. To improve performance, especially in terms of the size of the message on the wire, consolidate multiple headers and body parts into a single header or body part. For example, instead of the following code:  
  
```csharp  
[MessageContract]  
public class BankingTransaction  
{  
  [MessageHeader] public Operation operation;  
  [MessageBodyMember] public Account sourceAccount;  
  [MessageBodyMember] public Account targetAccount;  
  [MessageBodyMember] public int amount;  
}  
```  
  
 Use this code.  
  
```csharp  
[MessageContract]  
public class BankingTransaction  
{  
  [MessageHeader] public Operation operation;  
  [MessageBodyMember] public OperationDetails details;  
}  
  
[DataContract]  
public class OperationDetails  
{  
  [DataMember] public Account sourceAccount;  
  [DataMember] public Account targetAccount;  
  [DataMember] public int amount;  
}  
```  
  
### Event-based Asynchronous and Message Contracts  
 The design guidelines for the event-based asynchronous model state that if more than one value is returned, one value is returned as the `Result` property and the others are returned as properties on the <xref:System.EventArgs> object. One result of this is that if a client imports metadata using the event-based asynchronous command options and the operation returns more than one value, the default <xref:System.EventArgs> object returns one value as the `Result` property and the remainder are properties of the <xref:System.EventArgs> object.  
  
 If you want to receive the message object as the `Result` property and have the returned values as properties on that object, use the `/messageContract` command option. This generates a signature that returns the response message as the `Result` property on the <xref:System.EventArgs> object. All internal return values are then properties of the response message object.  
  
## See Also  
 [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md)  
 [Designing and Implementing Services](../../../../docs/framework/wcf/designing-and-implementing-services.md)
