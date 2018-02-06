---
title: "Enabling Transaction Flow"
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
  - "transactions [WCF], enabling flow"
ms.assetid: a03f5041-5049-43f4-897c-e0292d4718f7
caps.latest.revision: 17
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Enabling Transaction Flow
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides highly flexible options for controlling transaction flow. A service's transaction flow settings can be expressed using a combination of attributes and configuration.  
  
## Transaction Flow Settings  
 Transaction flow settings are generated for a service endpoint as a result of the intersection of the following three values:  
  
-   The <xref:System.ServiceModel.TransactionFlowAttribute> attribute specified for each method in the service contract.  
  
-   The `TransactionFlow` binding property in the specific binding.  
  
-   The `TransactionFlowProtocol` binding property in the specific binding. The `TransactionFlowProtocol` binding property enables you to choose among two different transaction protocols that you can use to flow a transaction. The following sections briefly describe each of them.  
  
### WS-AtomicTransaction Protocol  
 The WS-AtomicTransaction (WS-AT) protocol is useful for scenarios when interoperability with third-party protocol stacks is required.  
  
### OleTransactions Protocol  
 The OleTransactions protocol is useful for scenarios when interoperability with third-party protocol stacks is not required, and the deployer of a service knows in advance that the WS-AT protocol service is disabled locally or the existing network topology does not favor the usage of WS-AT.  
  
 The following table shows the different types of transaction flows that can be generated using these various combinations.  
  
|TransactionFlow<br /><br /> binding|TransactionFlow binding property|TransactionFlowProtocol binding protocol|Type of transaction flow|  
|---------------------------------|--------------------------------------|----------------------------------------------|------------------------------|  
|Mandatory|true|WS-AT|Transaction must be flowed in the interoperable WS-AT format.|  
|Mandatory|true|OleTransactions|Transaction must be flowed in the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] OleTransactions format.|  
|Mandatory|false|Not applicable|Not applicable because this is an invalid configuration.|  
|Allowed|true|WS-AT|Transaction may be flowed in the interoperable WS-AT format.|  
|Allowed|true|OleTransactions|Transaction may be flowed in the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] OleTransactions format.|  
|Allowed|false|Any value|A transaction is not flowed.|  
|NotAllowed|Any value|Any value|A transaction is not flowed.|  
  
 The following table summarizes the message processing result.  
  
|Incoming message|TransactionFlow setting|Transaction header|Message processing result|  
|----------------------|-----------------------------|------------------------|-------------------------------|  
|Transaction matches expected protocol format|Allowed or Mandatory|`MustUnderstand` equals `true`.|Process|  
|Transaction does not match expected protocol format|Mandatory|`MustUnderstand` equals `false`.|Rejected because a transaction is required|  
|Transaction does not match expected protocol format|Allowed|`MustUnderstand` equals `false`.|Rejected because the header is not understood|  
|Transaction using any protocol format|NotAllowed|`MustUnderstand` equals `false`.|Rejected because the header is not understood|  
|No transaction|Mandatory|N/A|Rejected because a transaction is required|  
|No transaction|Allowed|N/A|Process|  
|No transaction|NotAllowed|N/A|Process|  
  
 While each method on a contract can have different transaction flow requirements, the transaction flow protocol setting is scoped at the level of the binding. This means that all methods that share the same endpoint (and therefore the same binding) also share the same policy allowing or requiring transaction flow, as well as the same transaction protocol if applicable.  
  
## Enabling Transaction Flow at the Method Level  
 Transaction flow requirements are not always the same for all methods in a service contract. Therefore, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] also provides an attribute-based mechanism to allow each method's transaction flow preferences to be expressed. This is achieved by the <xref:System.ServiceModel.TransactionFlowAttribute> that specifies the level in which a service operation accepts a transaction header. You should mark your service contract methods with this attribute if you want to enable transaction flow. This attribute takes one of the values of the <xref:System.ServiceModel.TransactionFlowOption> enumeration, in which the default value is <xref:System.ServiceModel.TransactionFlowOption.NotAllowed>. If any value except <xref:System.ServiceModel.TransactionFlowOption.NotAllowed> is specified, the method is required to not be one-way. A developer can use this attribute to specify method-level transaction flow requirements or constraints at design time.  
  
## Enabling Transaction Flow at the Endpoint Level  
 In addition to the method-level transaction flow setting  the <xref:System.ServiceModel.TransactionFlowAttribute> attribute provides, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides an endpoint-wide setting for transaction flow to allow administrators to control transaction flow at a higher level.  
  
 This is achieved by the <xref:System.ServiceModel.Channels.TransactionFlowBindingElement>, which enables you to enable or disable incoming transaction flow in an endpoint’s binding settings, as well as to specify the desired transaction protocol format for incoming transactions.  
  
 If the binding has disabled transaction flow, but one of the operations on a service contract requires an incoming transaction, then a validation exception is thrown at service startup.  
  
 Most of the standing bindings [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides contain the `transactionFlow` and `transactionProtocol` attributes to enable you to configure the specific binding to accept incoming transactions. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] setting the configuration elements, see [\<binding>](../../../../docs/framework/misc/binding.md).  
  
 An administrator or deployer can use endpoint-level transaction flow to configure transaction flow requirements or constraints at deployment time using the configuration file.  
  
## Security  
 To ensure system security and integrity, you must secure message exchanges when flowing transactions between applications. You should not flow or disclose transaction details to any application that is not entitled to participate in the same transaction.  
  
 When generating [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clients to unknown or untrusted Web services through the use of metadata exchange, calls to operations on these Web services should suppress the current transaction if possible. The following example demonstrates how to do this.  
  
```  
//client code which has an ambient transaction  
using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))  
{  
    // No transaction will flow to this operation  
    untrustedProxy.Operation1(...);  
    scope.Complete();  
}  
//remainder of client code  
```  
  
 In addition, services should be configured to accept incoming transactions only from clients that they have authenticated and authorized. Incoming transactions should only be accepted if they come from highly trusted clients.  
  
## Policy Assertions  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses policy assertions to control transaction flow. Policy assertions can be found in a service’s policy document, which is generated by aggregating contracts, configuration, and attributes. The client can obtain the service’s policy document using an HTTP GET or a WS-MetadataExchange request-reply. Clients can then process the policy document to determine which operations on a service contract may support or require transaction flow.  
  
 Transaction flow policy assertions affect transaction flow by specifying the SOAP headers that a client should send to a service to represent a transaction. All transaction headers must be marked with `MustUnderstand` equal to `true`. Any message with a header marked otherwise is rejected with a SOAP fault.  
  
 Only one transaction-related policy assertion can be present on a single operation. Policy documents with more than one transaction assertion on an operation are considered invalid and are rejected by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. In addition, only a single transaction protocol can be present inside each port type. Policy documents with operations referencing more than one transaction protocol inside a single port type are considered invalid, and are rejected by the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md). Policy documents with transaction assertions present on output messages or one-way input messages are also considered invalid.
