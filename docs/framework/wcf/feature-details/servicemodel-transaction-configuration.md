---
title: "ServiceModel Transaction Configuration"
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
  - "transactions [WCF], ServiceModel configuration"
ms.assetid: 5636067a-7fbd-4485-aaa2-8141c502acf3
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ServiceModel Transaction Configuration
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides three attributes for configuring transactions for a service: `transactionFlow`, `transactionProtocol`, and `transactionTimeout`.  
  
## Configuring transactionFlow  
 Most of the predefined bindings [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides contain the `transactionFlow` and `transactionProtocol` attributes, so that you can configure the binding to accept incoming transactions for a specific endpoint using a specific transaction flow protocol. In addition, you can use the `transactionFlow` element and its `transactionProtocol` attribute to build your own custom binding. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] setting the configuration elements, see [\<binding>](../../../../docs/framework/misc/binding.md) and [WCF Configuration Schema](../../../../docs/framework/configure-apps/file-schema/wcf/index.md).  
  
 The `transactionFlow` attribute specifies whether transaction flow is enabled for service endpoints that use the binding.  
  
## Configuring transactionProtocol  
 The `transactionProtocol` attribute specifies the transaction protocol to use with service endpoints that use the binding.  
  
 The following is an example of a configuration section that configures the specified binding to support transaction flow, as well as a use the WS-AtomicTransaction protocol.  
  
```xml  
<netNamedPipeBinding>  
   <binding name="test"  
      closeTimeout="00:00:10"  
      openTimeout="00:00:20"   
      receiveTimeout="00:00:30"  
      sendTimeout="00:00:40"  
      transactionFlow="true"  
      transactionProtocol="WSAtomicTransactionOctober2004"  
      hostNameComparisonMode="WeakWildcard"  
      maxBufferSize="1001"  
      maxConnections="123"   
      maxReceivedMessageSize="1000">  
   </binding>  
</netNamedPipeBinding>  
```  
  
## Configuring transactionTimeout  
 You can configure the `transactionTimeout` attribute for your [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service in the `behavior` element of the configuration file. The following code demonstrates how to do this.  
  
```xml  
<configuration>  
   <system.serviceModel>  
      <behaviors>  
         <behavior name="NewBehavior" transactionTimeout="00:01:00" /> <!-- 1 minute timeout -->  
      </behaviors>  
   </system.serviceModel>  
</configuration>  
```  
  
 The `transactionTimeout` attribute specifies the time period within which a new transaction created at the service must complete. It is used as the <xref:System.Transactions.TransactionScope> time-out for any operation that establishes a new transaction, and if <xref:System.ServiceModel.OperationBehaviorAttribute> is applied, the <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionScopeRequired%2A> property is set to `true`.  
  
 The time-out specifies the duration of time from the creation of the transaction to the completion of phase 1 in the two-phase commit protocol.  
  
 If this attribute is set within a `service` configuration section, you should apply at least one method of the corresponding service with <xref:System.ServiceModel.OperationBehaviorAttribute>, in which the <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionScopeRequired%2A> property is set to `true`.  
  
 Note that the time-out value used is the smaller value between this `transactionTimeout` configuration setting and any <xref:System.ServiceModel.ServiceBehaviorAttribute.TransactionTimeout%2A> property.  
  
## See Also  
 [\<binding>](../../../../docs/framework/misc/binding.md)  
 [WCF Configuration Schema](../../../../docs/framework/configure-apps/file-schema/wcf/index.md)
