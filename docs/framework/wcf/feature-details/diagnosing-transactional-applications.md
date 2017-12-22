---
title: "Diagnosing Transactional Applications"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4a993492-1088-4d10-871b-0c09916af05f
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Diagnosing Transactional Applications
This topic describes how to use the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] management and diagnostics feature to troubleshoot a transactional application.  
  
## Performance Counters  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides a standard set of performance counters for you to measure your transactional application's performance. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Performance Counters](../../../../docs/framework/wcf/diagnostics/performance-counters/index.md).  
  
 Performance counters are scoped to three different levels: service, endpoint, and operation, as described in the following tables.  
  
### Service Performance Counters  
  
|Performance counter|Description|  
|-------------------------|-----------------|  
|Transactions Flowed|The number of transactions that flowed to operations in this service. This counter is incremented any time a transaction is present in the message that is sent to the service.|  
|Transactions Flowed Per Second|The number of transactions that flowed to operations in this service within each second. This counter is incremented any time a transaction is present in the message that is sent to the service.|  
|Transacted Operations Committed|The number of transacted operations performed, whose transaction has completed with the outcome committed in this service. Work done under such operations is fully committed. Resources are updated in accordance with the work done in the operation.|  
|Transacted Operations Committed Per Second|The number of transacted operations performed, whose transaction has completed with the outcome committed in this service within each second. Work done under such operations is fully committed. Resources are updated in accordance with the work done in the operation.|  
|Transacted Operations Aborted|The number of transacted operations performed, whose transaction has completed with the outcome aborted in this service. Work done under such operations is rolled back. Resources are reverted to their previous state.|  
|Transacted Operations Aborted Per Second|The number of transacted operations performed, whose transaction has completed with the outcome aborted in this service within each second. Work done under such operations is rolled back. Resources are reverted to their previous state.|  
|Transacted Operations In Doubt|The number of transacted operations performed, whose transaction has completed with an outcome in doubt in this service. Work done with an outcome in doubt is in an indeterminate state. Resources are held pending outcome.|  
|Transacted Operations In Doubt Per Second|The number of transacted operations performed, whose transaction has completed with an outcome in doubt in this service within each second. Work done with an outcome in doubt is in an indeterminate state. Resources are held pending outcome.|  
  
### Endpoint Performance Counters  
  
|Performance counter|Description|  
|-------------------------|-----------------|  
|Transactions Flowed|The number of transactions that flowed to operations at this endpoint. This counter is incremented any time a transaction is present in the message that is sent to the endpoint.|  
|Transactions Flowed Per Second|The number of transactions that flowed to operations at this endpoint within each second. This counter is incremented any time a transaction is present in the message that is sent to the endpoint.|  
  
### Operation Performance Counters  
  
|Performance counter|Description|  
|-------------------------|-----------------|  
|Transactions Flowed|The number of transactions that flowed to operations at this endpoint. This counter is incremented any time a transaction is present in the message that is sent to the endpoint.|  
|Transactions Flowed Per Second|The number of transactions that flowed to operations at this endpoint within each second. This counter is incremented any time a transaction is present in the message that is sent to the endpoint.|  
  
## Windows Management Instrumentation  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] exposes inspection data of a service at run time through a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Windows Management Instrumentation (WMI) provider. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] accessing WMI data, see [Using Windows Management Instrumentation for Diagnostics](../../../../docs/framework/wcf/diagnostics/wmi/index.md).  
  
 A number of read-only WMI properties indicate the applied transaction settings for a service. The following tables list all of these settings.  
  
 On a service, the `ServiceBehaviorAttribute` has the following properties.  
  
|Name|Type|Description|  
|----------|----------|-----------------|  
|ReleaseServiceInstanceOnTransactionComplete|Boolean|Specifies whether the service object is recycled when the current transaction completes.|  
|TransactionAutoCompleteOnSessionClose|Boolean|Specifies whether pending transactions are completed when the current session closes.|  
|TransactionIsolationLevel|A string that contains a valid value of the <xref:System.Transactions.IsolationLevel> enumeration.|Specifies the transaction isolation level that this service supports.|  
|TransactionTimeout|<xref:System.DateTime>|Specifies the period within which a transaction must complete.|  
  
 The `ServiceTimeoutsBehavior` has the following property.  
  
|Name|Type|Description|  
|----------|----------|-----------------|  
|TransactionTimeout|<xref:System.DateTime>|Specifies the period within which a transaction must complete.|  
  
 On a binding, the `TransactionFlowBindingElement` has the following properties.  
  
|Name|Type|Description|  
|----------|----------|-----------------|  
|TransactionProtocol|A string that contains a valid value of the <xref:System.ServiceModel.TransactionProtocol> type.|Specifies the transaction protocol to use in flowing a transaction.|  
|TransactionFlow|Boolean|Specifies whether incoming transaction flow is enabled.|  
  
 On an operation, the `OperationBehaviorAttribute` has the following properties:  
  
|Name|Type|Description|  
|----------|----------|-----------------|  
|TransactionAutoComplete|Boolean|Specifies whether to automatically commit the current transaction if no unhandled exceptions occur.|  
|TransactionScopeRequired|Boolean|Specifies whether the operation requires a transaction.|  
  
 On an operation, the `TransactionFlowAttribute` has the following properties.  
  
|Name|Type|Description|  
|----------|----------|-----------------|  
|TransactionFlowOption|A string that contains a valid value of the <xref:System.ServiceModel.TransactionFlowOption> enumeration.|Specifies the extent to which transaction flow is required.|  
  
## Tracing  
 Traces enable you to monitor and analyze faults in your transactional applications. You can enable tracing using the following ways:  
  
-   Standard [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] tracing  
  
     This type of tracing is the same as tracing any [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Configuring Tracing](../../../../docs/framework/wcf/diagnostics/tracing/configuring-tracing.md).  
  
-   WS-AtomicTransaction tracing  
  
     WS-AtomicTransaction tracing can be enabled by using the [WS-AtomicTransaction Configuration Utility (wsatConfig.exe)](../../../../docs/framework/wcf/ws-atomictransaction-configuration-utility-wsatconfig-exe.md). Such tracing provides insight into the state of transactions and participants within a system. To also enable internal Service Model tracing, you can set the `HKLM\SOFTWARE\Microsoft\WSAT\3.0\ServiceModelDiagnosticTracing` registry key to a valid value of the <xref:System.Diagnostics.SourceLevels> enumeration. You can enable message logging in the same way as other [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications.  
  
-   `System.Transactions` tracing  
  
     When using the OleTransactions protocol, protocol messages cannot be traced. The tracing support the <xref:System.Transactions> infrastructure provides (which uses OleTransactions) allows users to view events that occurred to the transactions. To enable tracing for a <xref:System.Transactions> application, include the following code in the `App.config` configuration file.  
  
    ```xml  
    <configuration>  
      <system.diagnostics>  
         <sources>  
            <source name="System.Transactions" switchValue="Verbose, ActivityTracing">  
               <listeners>  
                  <add name="Text"  
                     type="System.Diagnostics.XmlWriterTraceListener"  
                     initializeData="SysTx.log"  
                     traceOutputOptions="Callstack" />  
               </listeners>  
            </source>  
         </sources>  
         <trace autoflush="true" indentsize="4">  
         </trace>  
      </system.diagnostics>  
    </configuration>  
    ```  
  
     This also enables [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] tracing, as [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] also utilizes the <xref:System.Transactions> infrastructure.  
  
## See Also  
 [Administration and Diagnostics](../../../../docs/framework/wcf/diagnostics/index.md)  
 [Configuring Tracing](../../../../docs/framework/wcf/diagnostics/tracing/configuring-tracing.md)  
 [WS-AtomicTransaction Configuration Utility (wsatConfig.exe)](../../../../docs/framework/wcf/ws-atomictransaction-configuration-utility-wsatconfig-exe.md)
