---
description: "Learn more about: Message Queuing to Windows Communication Foundation"
title: "Message Queuing to Windows Communication Foundation"
ms.date: "03/30/2017"
ms.assetid: 6d718eb0-9f61-4653-8a75-d2dac8fb3520
---
# Message Queuing to Windows Communication Foundation

The [MsmqToWcf sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how a Message Queuing (MSMQ) application can send an MSMQ message to a Windows Communication Foundation (WCF) service. The service is a self-hosted console application to enable you to observe the service receiving queued messages.

The service contract is `IOrderProcessor`, which defines a one-way service that is suitable for use with queues. An MSMQ message does not have an Action header, so it is not possible to map different MSMQ messages to operation contracts automatically. Therefore, there can be only one operation contract. If you want to define more than one operation contract for the service, the application must provide information as to which header in the MSMQ message (for example, the label or correlationID) can be used to decide which operation contract to dispatch.

The MSMQ message does not contain information as to which headers are mapped to the different parameters of the operation contract. The parameter is of type <xref:System.ServiceModel.MsmqIntegration.MsmqMessage%601>(`MsmqMessage<T>`), which contains the underlying MSMQ message. The type "T" in the <xref:System.ServiceModel.MsmqIntegration.MsmqMessage%601>(`MsmqMessage<T>`) class represents the data that is serialized into the MSMQ message body. In this sample, the `PurchaseOrder` type is serialized into the MSMQ message body.

The following sample code shows the service contract of the order processing service.

```csharp
// Define a service contract.
[ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
[ServiceKnownType(typeof(PurchaseOrder))]
public interface IOrderProcessor
{
    [OperationContract(IsOneWay = true, Action = "*")]
    void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> msg);
}
```

The service is self hosted. When using MSMQ, the queue used must be created in advance. This can be done manually or through code. In this sample, the service checks for the existence of the queue and creates it if required. The queue name is read from the configuration file.

```csharp
public static void Main()
{
    // Get the MSMQ queue name from the application settings in
    // configuration.
    string queueName = ConfigurationManager.AppSettings["queueName"];
    // Create the MSMQ queue if necessary.
    if (!MessageQueue.Exists(queueName))
        MessageQueue.Create(queueName, true);
    …
}
```

The service creates and opens a <xref:System.ServiceModel.ServiceHost> for the `OrderProcessorService`, as shown in the following sample code.

```csharp
using (ServiceHost serviceHost = new ServiceHost(typeof(OrderProcessorService)))
{
    serviceHost.Open();
    Console.WriteLine("The service is ready.");
    Console.WriteLine("Press <ENTER> to terminate service.");
    Console.ReadLine();
    serviceHost.Close();
}
```

The MSMQ queue name is specified in an appSettings section of the configuration file, as shown in the following sample configuration.

> [!NOTE]
> The queue name uses a dot (.) for the local computer and backslash separators in its path. The WCF endpoint address specifies a msmq.formatname scheme, and uses localhost for the local computer. The address of the queue for each MSMQ Format Name addressing guidelines follows the msmq.formatname scheme.

```xml
<appSettings>
    <add key="orderQueueName" value=".\private$\Orders" />
</appSettings>
```

The client application is an MSMQ application that uses the <xref:System.Messaging.MessageQueue.Send%2A> method to send a durable and transactional message to the queue, as shown in the following sample code.

```csharp
//Connect to the queue.
MessageQueue orderQueue = new MessageQueue(ConfigurationManager.AppSettings["orderQueueName"]);

// Create the purchase order.
PurchaseOrder po = new PurchaseOrder();
po.CustomerId = "somecustomer.com";
po.PONumber = Guid.NewGuid().ToString();

PurchaseOrderLineItem lineItem1 = new PurchaseOrderLineItem();
lineItem1.ProductId = "Blue Widget";
lineItem1.Quantity = 54;
lineItem1.UnitCost = 29.99F;

PurchaseOrderLineItem lineItem2 = new PurchaseOrderLineItem();
lineItem2.ProductId = "Red Widget";
lineItem2.Quantity = 890;
lineItem2.UnitCost = 45.89F;

po.orderLineItems = new PurchaseOrderLineItem[2];
po.orderLineItems[0] = lineItem1;
po.orderLineItems[1] = lineItem2;

// Submit the purchase order.
Message msg = new Message();
msg.Body = po;
//Create a transaction scope.
using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
{

    orderQueue.Send(msg, MessageQueueTransactionType.Automatic);
    // Complete the transaction.
    scope.Complete();

}
Console.WriteLine("Placed the order:{0}", po);
Console.WriteLine("Press <ENTER> to terminate client.");
Console.ReadLine();
```

When you run the sample, the client and service activities are displayed in both the service and client console windows. You can see the service receive messages from the client. Press ENTER in each console window to shut down the service and client. Note that because queuing is in use, the client and service do not have to be up and running at the same time. For example, you could run the client, shut it down, and then start up the service and it would still receive its messages.

## Set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. If the service is run first, it will check to ensure that the queue is present. If the queue is not present, the service will create one. You can run the service first to create the queue, or you can create one via the MSMQ Queue Manager. Follow these steps to create a queue in Windows 2008.

    1. Open Server Manager in Visual Studio 2012.

    2. Expand the **Features** tab.

    3. Right-click **Private Message Queues**, and select **New**, **Private Queue**.

    4. Check the **Transactional** box.

    5. Enter `ServiceModelSamplesTransacted` as the name of the new queue.

3. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

4. To run the sample in a single- computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

## Run the sample across computers

1. Copy the service program files from the \service\bin\ folder, under the language-specific folder, to the service computer.

2. Copy the client program files from the \client\bin\ folder, under the language-specific folder, to the client computer.

3. In the Client.exe.config file, change the orderQueueName to specify the service computer name instead of ".".

4. On the service computer, launch Service.exe from a command prompt.

5. On the client computer, launch Client.exe from a command prompt.

## See also

- [Queues in WCF](../feature-details/queues-in-wcf.md)
- [How to: Exchange Messages with WCF Endpoints and Message Queuing Applications](../feature-details/how-to-exchange-messages-with-wcf-endpoints-and-message-queuing-applications.md)
- [Message Queuing](/previous-versions/windows/desktop/legacy/ms711472(v=vs.85))
