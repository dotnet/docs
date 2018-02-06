---
title: "How to: Call Operations Asynchronously Using a Channel Factory"
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
ms.assetid: cc17dd47-b9ad-451c-a362-e36e0aac7ba0
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Call Operations Asynchronously Using a Channel Factory
This topic covers how a client can access a service operation asynchronously when using a <xref:System.ServiceModel.ChannelFactory%601>-based client application. (When using a <xref:System.ServiceModel.ClientBase%601?displayProperty=nameWithType> object to invoke a service you can use the event-driven asynchronous calling model. For more information, see [How to: Call Service Operations Asynchronously](../../../../docs/framework/wcf/feature-details/how-to-call-wcf-service-operations-asynchronously.md). For more information about the event-based asynchronous calling model, see [Multithreaded Programming with the Event-based Asynchronous Pattern](../../../../docs/standard/asynchronous-programming-patterns/multithreaded-programming-with-the-event-based-asynchronous-pattern.md).)  
  
 The service in this topic implements the `ICalculator` interface. The client can call the operations on this interface asynchronously, which means that operations like `Add` are split into two methods, `BeginAdd` and `EndAdd`, the former of which initiates the call and the latter of which retrieves the result when the operation completes. For an example showing how to implement an operation asynchronously in a service, see [How to: Implement an Asynchronous Service Operation](../../../../docs/framework/wcf/how-to-implement-an-asynchronous-service-operation.md). For details about synchronous and asynchronous operations, see [Synchronous and Asynchronous Operations](../../../../docs/framework/wcf/synchronous-and-asynchronous-operations.md).  
  
## Procedure  
  
#### To call WCF service operations asynchronously  
  
1.  Run the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) tool with the `/async` option as shown in the following command.  
  
    ```  
    svcutil /n:http://Microsoft.ServiceModel.Samples,Microsoft.ServiceModel.Samples http://localhost:8000/servicemodelsamples/service/mex /a  
    ```  
  
     This generates an asynchronous client version of the service contract for the operation.  
  
2.  Create a callback function to be called when the asynchronous operation is complete, as shown in the following sample code.  
  
     [!code-csharp[C_How_To_CF_Async#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_how_to_cf_async/cs/client.cs#2)]
     [!code-vb[C_How_To_CF_Async#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_how_to_cf_async/vb/client.vb#2)]  
  
3.  To access a service operation asynchronously, create the client and call the `Begin[Operation]` (for example, `BeginAdd`) and specify a callback function, as shown in the following sample code.  
  
     [!code-csharp[C_How_To_CF_Async#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_how_to_cf_async/cs/client.cs#3)]
     [!code-vb[C_How_To_CF_Async#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_how_to_cf_async/vb/client.vb#3)]  
  
     When the callback function executes, the client calls `End<operation>` (for example, `EndAdd`) to retrieve the result.  
  
## Example  
 The service that is used with the client code that is used in the preceding procedure implements the `ICalculator` interface as shown in the following code. On the service side, the `Add` and `Subtract` operations of the contract are invoked synchronously by the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] run time, even though the preceding client steps are invoked asynchronously on the client. The `Multiply` and `Divide` operations are used to invoke the service asynchronously on the service side, even if the client invokes them synchronously. This example sets the <xref:System.ServiceModel.OperationContractAttribute.AsyncPattern%2A> property to `true`. This property setting, in combination with the implementation of the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] asynchronous pattern, tells the run time to invoke the operation asynchronously.  
  
 [!code-csharp[C_How_To_CF_Async#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_how_to_cf_async/cs/service.cs#4)]
 [!code-vb[C_How_To_CF_Async#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_how_to_cf_async/vb/service.vb#4)]  
  
## See Also  
 [Service Contract: Asynchronous Sample](http://msdn.microsoft.com/library/833db946-f511-4f64-a26f-2759a11217c7)
