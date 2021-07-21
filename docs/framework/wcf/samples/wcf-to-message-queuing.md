---
description: "Learn more about: Windows Communication Foundation to Message Queuing"
title: "Windows Communication Foundation to Message Queuing"
ms.date: "03/30/2017"
ms.assetid: 78d0d0c9-648e-4d4a-8f0a-14d9cafeead9
---
# Windows Communication Foundation to Message Queuing

The [WcfToMsmq sample](https://github.com/dotnet/samples/tree/main/framework/wcf/Basic/Binding/Net/MSMQIntegration/WcfToMsmq/CS) demonstrates how a Windows Communication Foundation (WCF) application can send a message to a Message Queuing (MSMQ) application. The service is a self-hosted console application to enable you to observe the service receiving queued messages. The service and client do not have to be running at the same time.

The service receives messages from the queue and processes orders. The service creates a transactional queue and sets up a message received message handler, as shown in the following sample code.

```csharp
static void Main(string[] args)
{
    if (!MessageQueue.Exists(
              ConfigurationManager.AppSettings["queueName"]))
       MessageQueue.Create(
           ConfigurationManager.AppSettings["queueName"], true);
        //Connect to the queue
        MessageQueue Queue = new
    MessageQueue(ConfigurationManager.AppSettings["queueName"]);
    Queue.ReceiveCompleted +=
                 new ReceiveCompletedEventHandler(ProcessOrder);
    Queue.BeginReceive();
    Console.WriteLine("Order Service is running");
    Console.ReadLine();
}
```

When a message is received in the queue, the message handler `ProcessOrder` is invoked.

```csharp
public static void ProcessOrder(Object source,
    ReceiveCompletedEventArgs asyncResult)
{
    try
    {
        // Connect to the queue.
        MessageQueue Queue = (MessageQueue)source;
        // End the asynchronous receive operation.
        System.Messaging.Message msg =
                     Queue.EndReceive(asyncResult.AsyncResult);
        msg.Formatter = new System.Messaging.XmlMessageFormatter(
                                new Type[] { typeof(PurchaseOrder) });
        PurchaseOrder po = (PurchaseOrder) msg.Body;
        Random statusIndexer = new Random();
        po.Status = PurchaseOrder.OrderStates[statusIndexer.Next(3)];
        Console.WriteLine("Processing {0} ", po);
        Queue.BeginReceive();
    }
    catch (System.Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}
```

The service extracts the `ProcessOrder` from the MSMQ message body, and processes the order.

The MSMQ queue name is specified in an appSettings section of the configuration file, as shown in the following sample configuration.

```xml
<appSettings>
    <add key="orderQueueName" value=".\private$\Orders" />
</appSettings>
```

> [!NOTE]
> The queue name uses a dot (.) for the local computer and backslash separators in its path.

The client creates a purchase order and submits the purchase order within the scope of a transaction, as shown in the following sample code.

```csharp
// Create the purchase order
PurchaseOrder po = new PurchaseOrder();
// Fill in the details
...

OrderProcessorClient client = new OrderProcessorClient("OrderResponseEndpoint");

MsmqMessage<PurchaseOrder> ordermsg = new MsmqMessage<PurchaseOrder>(po);
using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
{
    client.SubmitPurchaseOrder(ordermsg);
    scope.Complete();
}
Console.WriteLine("Order has been submitted:{0}", po);

//Closing the client gracefully closes the connection and cleans up resources
client.Close();
```

The client uses a custom client in-order to send the MSMQ message to the queue. Because the application that receives and processes the message is an MSMQ application and not a WCF application, there is no implicit service contract between the two applications. So, we cannot create a proxy using the Svcutil.exe tool in this scenario.

The custom client is essentially the same for all WCF applications that use the `MsmqIntegration` binding to send messages. Unlike other clients, it does not include a range of service operations. It is a submit message operation only.

```csharp
[System.ServiceModel.ServiceContractAttribute(Namespace = "http://Microsoft.ServiceModel.Samples")]
public interface IOrderProcessor
{
    [OperationContract(IsOneWay = true, Action = "*")]
    void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> msg);
}

public partial class OrderProcessorClient : System.ServiceModel.ClientBase<IOrderProcessor>, IOrderProcessor
{
    public OrderProcessorClient(){}

    public OrderProcessorClient(string configurationName)
        : base(configurationName)
    { }

    public OrderProcessorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress address)
        : base(binding, address)
    { }

    public void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> msg)
    {
        base.Channel.SubmitPurchaseOrder(msg);
    }
}
```

When you run the sample, the client and service activities are displayed in both the service and client console windows. You can see the service receive messages from the client. Press ENTER in each console window to shut down the service and client. Note that because queuing is in use, the client and service do not have to be up and running at the same time. For example, you could run the client, shut it down, and then start up the service and it would still receive its messages.

> [!NOTE]
> This sample requires the installation of Message Queuing. See the installation instructions in [Message Queuing](/previous-versions/windows/desktop/legacy/ms711472(v=vs.85)).

## Set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. If the service is run first, it will check to ensure that the queue is present. If the queue is not present, the service will create one. You can run the service first to create the queue, or you can create one via the MSMQ Queue Manager. Follow these steps to create a queue in Windows 2008.

    1. Open Server Manager in Visual Studio 2012.

    2. Expand the **Features** tab.

    3. Right-click **Private Message Queues**, and then select **New** > **Private Queue**.

    4. Check the **Transactional** box.

    5. Enter `ServiceModelSamplesTransacted` as the name of the new queue.

3. To build the C# or Visual Basic edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

4. To run the sample in a single-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

## Run the sample across computers

1. Copy the service program files from the \service\bin\ folder, under the language-specific folder, to the service computer.

2. Copy the client program files from the \client\bin\ folder, under the language-specific folder, to the client computer.

3. In the Client.exe.config file, change the client endpoint address to specify the service computer name instead of ".".

4. On the service computer, launch Service.exe from a command prompt.

5. On the client computer, launch Client.exe from a command prompt.

## See also

- [How to: Exchange Messages with WCF Endpoints and Message Queuing Applications](../feature-details/how-to-exchange-messages-with-wcf-endpoints-and-message-queuing-applications.md)
- [Message Queuing](/previous-versions/windows/desktop/legacy/ms711472(v=vs.85))
