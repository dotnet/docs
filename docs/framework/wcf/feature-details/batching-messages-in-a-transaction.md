---
title: "Batching Messages in a Transaction"
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
  - "batching messages [WCF]"
ms.assetid: 53305392-e82e-4e89-aedc-3efb6ebcd28c
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Batching Messages in a Transaction
Queued applications use transactions to ensure correctness and reliable delivery of messages. Transactions, however, are expensive operations and can dramatically reduce message throughput. One way to improve message throughput is to have an application read and process multiple messages within a single transaction. The trade-off is between performance and recovery: as the number of messages in a batch increases, so does the amount of recovery work that required if transactions are rolled back. It is important to note the difference between batching messages in a transaction and sessions. A *session* is a grouping of related messages that are processed by a single application and committed as a single unit. Sessions are generally used when a group of related messages must be processed together. An example of this is an online shopping Web site. *Batches* are used to process multiple, unrelated messages in a way that increases message throughput. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] sessions, see [Grouping Queued Messages in a Session](../../../../docs/framework/wcf/feature-details/grouping-queued-messages-in-a-session.md). Messages in a batch are also processed by a single application and committed as a single unit, but there may be no relationship between the messages in the batch. Batching messages in a transaction is an optimization that does not change how the application runs.  
  
## Entering Batching Mode  
 The <xref:System.ServiceModel.Description.TransactedBatchingBehavior> endpoint behavior controls batching. Adding this endpoint behavior to a service endpoint tells [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] to batch messages in a transaction. Not all messages require a transaction, so only messages that require a transaction are placed in a batch, and only messages sent from operations marked with `TransactionScopeRequired` = `true` and `TransactionAutoComplete` = `true` are considered for a batch. If all operations on the service contract are marked with `TransactionScopeRequired` = `false` and `TransactionAutoComplete` = `false`, then batching mode is never entered.  
  
## Committing a Transaction  
 A batched transaction is committed based on the following:  
  
-   `MaxBatchSize`. A property of the <xref:System.ServiceModel.Description.TransactedBatchingBehavior> behavior. This property determines the maximum number of messages that are placed into a batch. When this number is reached, the batch is committed. This is value is not a strict limit, it is possible to commit a batch before receiving this number of messages.  
  
-   `Transaction Timeout`. After 80 percent of the transaction's time-out has elapsed, the batch is committed and a new batch is created. This means that if 20 percent or less of the time given for a transaction to complete remains, the batch is committed.  
  
-   `TransactionScopeRequired`. When processing a batch of messages, if [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] finds one that has `TransactionScopeRequired` = `false`, it commits the batch and reopens a new batch on receipt of the first message with `TransactionScopeRequired` = `true` and `TransactionAutoComplete` = `true`.  
  
-   If no more messages exist in the queue, then the current batch is committed, even if the `MaxBatchSize` has not been reached or 80 percent of the transaction's time-out has not elapsed.  
  
## Leaving Batching Mode  
 If a message in a batch causes the transaction to abort, the following steps occur:  
  
1.  The entire batch of messages is rolled back.  
  
2.  Messages are read one at a time until the number of messages read exceeds twice the maximum batch size.  
  
3.  Batch mode is re-entered.  
  
## Choosing the Batch Size  
 The size of a batch is application-dependent. The empirical method is the best way to arrive at an optimal batch size for the application. It is important to remember when choosing a batch size to choose the size according to your application's actual deployment model. For example, when deploying the application, if you need an SQL server on a remote machine and a transaction that spans the queue and the SQL server, then the batch size is best determined by running this exact configuration.  
  
## Concurrency and Batching  
 To increase throughput, you can also have many batches run concurrently. By setting `ConcurrencyMode.Multiple` in `ServiceBehaviorAttribute`, you enable concurrent batching.  
  
 *Service throttling* is a service behavior that is used to indicate how many maximum concurrent calls can be made on the service. When used with batching, this is interpreted as how many concurrent batches can be run. If the service throttling is not set, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] defaults the maximum concurrent calls to 16. Thus, if batching behavior were added by default, a maximum of 16 batches can be active at the same time. It is best to tune the service throttling and batching based on your capacity. For example, if the queue has 100 messages and a batch of 20 is desired, having the maximum concurrent calls set to 16 is not useful because, depending on throughput, 16 transactions could be active, similar to not having batching turned on. Therefore, when fine-tuning for performance, either do not have concurrent batching or have concurrent batching with the correct service throttle size.  
  
## Batching and Multiple Endpoints  
 An endpoint is composed of an address and a contract. There may be multiple endpoints that share the same binding. It is possible for two endpoints to share the same binding and listen Uniform Resource Identifier (URI), or queue address. If two endpoints are reading from the same queue, and transacted batching behavior is added to both endpoints, a conflict in the batch sizes specified could arise. This is resolved by implementing batching using the minimal batch size specified between the two transacted batching behaviors. In this scenario, if one of the endpoints does not specify transacted batching, then both endpoints would not use batching.  
  
## Example  
 The following example shows how to specify the `TransactedBatchingBehavior` in a configuration file.  
  
```xml  
<behaviors>
  <endpointBehaviors>
    <behavior name="TransactedBatchingBehavior"
              maxBatchSize="100" />
  </endpointBehaviors>
</behaviors>
```  
  
 The following example shows how to specify the <xref:System.ServiceModel.Description.TransactedBatchingBehavior> in code.  
  
```csharp
using (ServiceHost serviceHost = new ServiceHost(typeof(OrderProcessorService)))
{
     ServiceEndpoint sep = ServiceHost.AddServiceEndpoint(typeof(IOrderProcessor), new NetMsmqBinding(), "net.msmq://localhost/private/ServiceModelSamplesTransacted");
     sep.Behaviors.Add(new TransactedBatchingBehavior(100));
     
     // Open the ServiceHost to create listeners and start listening for messages.
    serviceHost.Open();
  
    // The service can now be accessed.
    Console.WriteLine("The service is ready.");
    Console.WriteLine("Press <ENTER> to terminate service.");
    Console.WriteLine();
    Console.ReadLine();
  
    // Close the ServiceHostB to shut down the service.
    serviceHost.Close();
}  
```  
  
## See Also  
 [Queues Overview](../../../../docs/framework/wcf/feature-details/queues-overview.md)  
 [Queuing in WCF](../../../../docs/framework/wcf/feature-details/queuing-in-wcf.md)
