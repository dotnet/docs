---
title: "Message Correlation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3f62babd-c991-421f-bcd8-391655c82a1f
caps.latest.revision: 26
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Message Correlation
This sample demonstrates how a Message Queuing (MSMQ) application can send an MSMQ message to a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service and how messages can be correlated between sender and receiver applications in a request/response scenario. This sample uses the msmqIntegrationBinding binding. The service in this case is a self-hosted console application to allow you to observe the service that receives queued messages. k  
  
 The service processes the message received from the sender and sends a response message back to the sender. The sender correlates the response it received to the request it sent originally. The `MessageID` and `CorrelationID` properties of the message are used to correlate the request and response messages.  
  
 The `IOrderProcessor` service contract defines a one-way service operation that is suitable for use with queuing. An MSMQ message does not have an Action header, so it is not possible to map different MSMQ messages to operation contracts automatically. Therefore, there can be only one operation contract in this case. If you want to define more operation contracts in the service, the application must provide information as to which header in the MSMQ message (for example, the label, or correlationID) can be used to decide which operation contract to dispatch. This is demonstrated in the [Custom Demux](../../../../docs/framework/wcf/samples/custom-demux.md).  
  
 The MSMQ message also does not contain information as to which headers are mapped to the different parameters of the operation contract. Therefore, there can be only one parameter in the operation contract. The parameter is of type <!--zz <xref:System.ServiceModel.MSMQIntegration.MsmqMessage%601>`MsmqMessage<T>`--> , `System.ServiceModel.MSMQIntegration.MsmqMessage` which contains the underlying MSMQ message. The type "T" in the `MsmqMessage<T>` class represents the data that is serialized into the MSMQ message body. In this sample, the `PurchaseOrder` type is serialized into the MSMQ message body.  
  
```  
[ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]  
[ServiceKnownType(typeof(PurchaseOrder))]  
public interface IOrderProcessor  
{  
    [OperationContract(IsOneWay = true, Action = "*")]  
    void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> msg);  
}  
```  
  
 The service operation processes the purchase order and displays the contents of the purchase order and its status in the service console window. The <xref:System.ServiceModel.OperationBehaviorAttribute> configures the operation to enlist in a transaction with the queue and to mark the transaction complete when the operation returns. The `PurchaseOrder` contains the order details that must be processed by the service.  
  
```  
// Service class that implements the service contract.  
public class OrderProcessorService : IOrderProcessor  
{  
   [OperationBehavior(TransactionScopeRequired = true,   
          TransactionAutoComplete = true)]  
   public void SubmitPurchaseOrder(MsmqMessage<PurchaseOrder> ordermsg)  
   {  
       PurchaseOrder po = (PurchaseOrder)ordermsg.Body;  
       Random statusIndexer = new Random();  
       po.Status = PurchaseOrder.OrderStates[statusIndexer.Next(3)];  
       Console.WriteLine("Processing {0} ", po);  
       //Send a response to the client that the order has been received   
         and is pending fullfillment.   
       SendResponse(ordermsg);  
    }  
  
    private void SendResponse(MsmqMessage<PurchaseOrder> ordermsg)  
    {  
        OrderResponseClient client = new OrderResponseClient("OrderResponseEndpoint");  
  
        //Set the correlation ID such that the client can correlate the response to the order.  
        MsmqMessage<PurchaseOrder> orderResponsemsg = new MsmqMessage<PurchaseOrder>(ordermsg.Body);  
        orderResponsemsg.CorrelationId = ordermsg.Id;  
        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))  
        {  
            client.SendOrderResponse(orderResponsemsg);  
            scope.Complete();  
        }  
  
        client.Close();  
    }  
}  
```  
  
 The service uses a custom client `OrderResponseClient` to send the MSMQ message to the queue. Because the application that receives and processes the message is an MSMQ application and not a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application, there is no implicit service contract between the two applications. So we cannot create a proxy using the Svcutil.exe tool in this scenario.  
  
 The custom proxy is essentially the same for all [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications that use the `msmqIntegrationBinding` binding to send messages. Unlike other proxies, it does not include a range of service operations. It is a submit message operation only.  
  
```  
[System.ServiceModel.ServiceContractAttribute(Namespace = "http://Microsoft.ServiceModel.Samples")]  
public interface IOrderResponse  
{  
  
    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "*")]  
    void SendOrderResponse(MsmqMessage<PurchaseOrder> msg);  
}  
  
public partial class OrderResponseClient : System.ServiceModel.ClientBase<IOrderResponse>, IOrderResponse  
{  
  
    public OrderResponseClient()  
    { }  
  
    public OrderResponseClient(string configurationName)  
        : base(configurationName)  
    { }  
  
    public OrderResponseClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress address)  
        : base(binding, address)  
    { }  
  
    public void SendOrderResponse(MsmqMessage<PurchaseOrder> msg)  
    {  
        base.Channel.SendOrderResponse(msg);  
    }  
}  
```  
  
 The service is self hosted. When using the MSMQ integration transport, the queue used must be created in advance. This can be done manually or through code. In this sample, the service contains <xref:System.Messaging> code to check for the existence of the queue and create it if necessary. The queue name is read from the configuration file.  
  
```  
public static void Main()  
{  
       // Get the MSMQ queue name from application settings in configuration.  
      string queueName =   
                ConfigurationManager.AppSettings["orderQueueName"];  
      // Create the transacted MSMQ queue if necessary.  
      if (!MessageQueue.Exists(queueName))  
                MessageQueue.Create(queueName, true);  
     // Create a ServiceHost for the OrderProcessorService type.  
     using (ServiceHost serviceHost = new   
                   ServiceHost(typeof(OrderProcessorService)))  
     {  
            serviceHost.Open();  
            // The service can now be accessed.  
            Console.WriteLine("The service is ready.");  
            Console.WriteLine("Press <ENTER> to terminate service.");  
            Console.ReadLine();  
            // Close the ServiceHost to shutdown the service.  
            serviceHost.Close();  
      }  
}  
```  
  
 The MSMQ queue to which the order requests are sent is specified in the appSettings section of the configuration file. The client and service endpoints are defined in the system.serviceModel section of the configuration file. Both specify the `msmqIntegrationbinding` binding.  
  
```xml  
<appSettings>  
  <add key="orderQueueName" value=".\private$\Orders" />  
</appSettings>  
  
<system.serviceModel>  
  <client>  
    <endpoint    name="OrderResponseEndpoint"   
              address="msmq.formatname:DIRECT=OS:.\private$\OrderResponse"  
              binding="msmqIntegrationBinding"  
              bindingConfiguration="OrderProcessorBinding"   
              contract="Microsoft.ServiceModel.Samples.IOrderResponse">  
    </endpoint>  
  </client>  
  
  <services>  
    <service   
      name="Microsoft.ServiceModel.Samples.OrderProcessorService">  
      <endpoint address="msmq.formatname:DIRECT=OS:.\private$\Orders"  
                            binding="msmqIntegrationBinding"  
                bindingConfiguration="OrderProcessorBinding"   
                contract="Microsoft.ServiceModel.Samples.IOrderProcessor">  
      </endpoint>  
    </service>  
  </services>  
  
  <bindings>  
    <msmqIntegrationBinding>  
      <binding name="OrderProcessorBinding" >  
        <security mode="None" />  
      </binding>  
    </msmqIntegrationBinding>  
  </bindings>  
  
</system.serviceModel>  
```  
  
 The client application uses <xref:System.Messaging> to send a durable and transactional message to the queue. The message's body contains the purchase order.  
  
```  
static void PlaceOrder()  
{  
    //Connect to the queue  
    MessageQueue orderQueue =   
            new MessageQueue(  
                    ConfigurationManager.AppSettings["orderQueueName"])   
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
  
    Message msg = new Message();  
    msg.UseDeadLetterQueue = true;  
    msg.Body = po;  
  
    //Create a transaction scope.  
    using (TransactionScope scope = new      
     TransactionScope(TransactionScopeOption.Required))  
    {  
        // Submit the purchase order.  
        orderQueue.Send(msg, MessageQueueTransactionType.Automatic);  
        // Complete the transaction.  
        scope.Complete();  
    }  
    //Save the messageID for order response correlation.  
    orderMessageID = msg.Id;  
    Console.WriteLine("Placed the order, waiting for response...");  
}  
```  
  
 The MSMQ queue from which the order responses are received is specified in an appSettings section of the configuration file, as shown in the following sample configuration.  
  
> [!NOTE]
>  The queue name uses a dot (.) for the local computer and backslash separators in its path. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint address specifies a msmq.formatname scheme, and uses "localhost" for the local computer. A properly formed format name follows msmq.formatname in the URI according to MSMQ guidelines.  
  
```xml  
<appSettings>  
    <add key=" orderResponseQueueName" value=".\private$\Orders" />  
</appSettings>  
```  
  
 The client application saves the `messageID` of the order request message that it sends to the service and waits for a response from the service. Once a response arrives in the queue the client correlates it with the order message it sent using the `correlationID` property of the message, which contains the `messageID` of the order message that the client sent to the service originally.  
  
```  
static void DisplayOrderStatus()  
{  
    MessageQueue orderResponseQueue = new   
     MessageQueue(ConfigurationManager.AppSettings              
                  ["orderResponseQueueName"]);  
    //Create a transaction scope.  
    bool responseReceived = false;  
    orderResponseQueue.MessageReadPropertyFilter.CorrelationId = true;  
    while (!responseReceived)  
    {  
       Message responseMsg;  
       using (TransactionScope scope2 = new    
         TransactionScope(TransactionScopeOption.Required))  
       {  
          //Receive the Order Response message.  
          responseMsg =   
              orderResponseQueue.Receive  
                   (MessageQueueTransactionType.Automatic);  
          scope2.Complete();  
     }  
     responseMsg.Formatter = new   
     System.Messaging.XmlMessageFormatter(new Type[] {   
         typeof(PurchaseOrder) });  
     PurchaseOrder responsepo = (PurchaseOrder)responseMsg.Body;  
    //Check if the response is for the order placed.  
    if (orderMessageID == responseMsg.CorrelationId)  
    {  
       responseReceived = true;  
       Console.WriteLine("Status of current Order: OrderID-{0},Order   
            Status-{1}", responsepo.PONumber, responsepo.Status);  
    }  
    else  
    {  
       Console.WriteLine("Status of previous Order: OrderID-{0},Order    
            Status-{1}", responsepo.PONumber, responsepo.Status);  
    }  
  }  
}  
```  
  
 When you run the sample, the client and service activities are displayed in both the service and client console windows. You can see the service receive messages from the client and sends a response back to the client. The client displays the response received from the service. Press ENTER in each console window to shut down the service and client.  
  
> [!NOTE]
>  This sample requires the installation of Message Queuing (MSMQ). See the MSMQ installation instructions in the See Also section.  
  
### To setup, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  If the service is run first, it will check to ensure that the queue is present. If the queue is not present, the service will create one. You can run the service first to create the queue, or you can create one via the MSMQ Queue Manager. Follow these steps to create a queue in Windows 2008.  
  
    1.  Open Server Manager in [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)].  
  
    2.  Expand the **Features** tab.  
  
    3.  Right-click **Private Message Queues**, and select **New**, **Private Queue**.  
  
    4.  Check the **Transactional** box.  
  
    5.  Enter `ServiceModelSamplesTransacted` as the name of the new queue.  
  
3.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
4.  To run the sample in a single-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
### To run the sample across computers  
  
1.  Copy the service program files from the \service\bin\ folder, under the language-specific folder, to the service computer.  
  
2.  Copy the client program files from the \client\bin\ folder, under the language-specific folder, to the client computer.  
  
3.  In the Client.exe.config file, change the orderQueueName to specify the service computer name instead of ".".  
  
4.  In the Service.exe.config file, change the client endpoint address to specify the client computer name instead of ".".  
  
5.  On the service computer, launch Service.exe from a command prompt.  
  
6.  On the client computer, launch Client.exe from a command prompt.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Binding\MSMQIntegration\MessageCorrelation`  
  
## See Also  
 [Queuing in WCF](../../../../docs/framework/wcf/feature-details/queuing-in-wcf.md)  
 [Message Queuing](http://go.microsoft.com/fwlink/?LinkId=94968)
