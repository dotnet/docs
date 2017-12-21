---
title: "Poison Message Handling in MSMQ 4.0"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ec8d59e3-9937-4391-bb8c-fdaaf2cbb73e
caps.latest.revision: 18
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Poison Message Handling in MSMQ 4.0
This sample demonstrates how to perform poison message handling in a service. This sample is based on the [Transacted MSMQ Binding](../../../../docs/framework/wcf/samples/transacted-msmq-binding.md) sample. This sample uses the `netMsmqBinding`. The service is a self-hosted console application to enable you to observe the service receiving queued messages.  
  
 In queued communication, the client communicates to the service using a queue. More precisely, the client sends messages to a queue. The service receives messages from the queue. The service and client therefore, do not have to be running at the same time to communicate using a queue.  
  
 A poison message is a message that is repeatedly read from a queue when the service reading the message cannot process the message and therefore terminates the transaction under which the message is read. In such cases, the message is retried again. This can theoretically go on forever if there is a problem with the message. Note that this can only occur when you use transactions to read from the queue and invoke the service operation.  
  
 Based on the version of MSMQ, the NetMsmqBinding supports limited detection to full detection of poison messages. After the message has been detected as poisoned, then it can be handled in several ways. Again, based on the version of MSMQ, the NetMsmqBinding supports limited handling to full handling of poison messages.  
  
 This sample illustrates the limited poison facilities provided on [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] and [!INCLUDE[wxp](../../../../includes/wxp-md.md)] platform and the full poison facilities provided on [!INCLUDE[wv](../../../../includes/wv-md.md)]. In both samples, the objective is move the poison message out of the queue to another queue which then can be serviced by a poison message service.  
  
## MSMQ v4.0 Poison Handling Sample  
 In [!INCLUDE[wv](../../../../includes/wv-md.md)], MSMQ provides a poison sub-queue facility that can be used to store poison messages. This sample demonstrates the best practice of dealing with poison messages using [!INCLUDE[wv](../../../../includes/wv-md.md)].  
  
 The poison message detection in [!INCLUDE[wv](../../../../includes/wv-md.md)] is quite sophisticated. There are 3 properties that help with detection. The <xref:System.ServiceModel.MsmqBindingBase.ReceiveRetryCount%2A> is number of times a given message is re-read from the queue and dispatched to the application for processing. A message is re-read from the queue when it is put back into the queue because the message cannot be dispatched to the application or the application rolls back the transaction in the service operation. <xref:System.ServiceModel.MsmqBindingBase.MaxRetryCycles%2A> is the number of times the message is moved to the retry queue. When <xref:System.ServiceModel.MsmqBindingBase.ReceiveRetryCount%2A> is reached, the message is moved to the retry queue. The property <xref:System.ServiceModel.MsmqBindingBase.RetryCycleDelay%2A> is the time delay after which the message is moved from the retry queue back to the main queue. The <xref:System.ServiceModel.MsmqBindingBase.ReceiveRetryCount%2A> is reset to 0. The message is tried again. If all attempts to read the message have failed, then the message is marked as poisoned.  
  
 Once the message is marked as poisoned, the message is dealt with according to the settings in the <xref:System.ServiceModel.MsmqBindingBase.ReceiveErrorHandling%2A> enumeration. To reiterate the possible values:  
  
-   Fault (default): To fault the listener and also the service host.  
  
-   Drop: To drop the message.  
  
-   Move: To move the message to the poison message sub-queue. This value is available only on [!INCLUDE[wv](../../../../includes/wv-md.md)].  
  
-   Reject: To reject the message, sending the message back to the sender's dead-letter queue. This value is available only on [!INCLUDE[wv](../../../../includes/wv-md.md)].  
  
 The sample demonstrates using the `Move` disposition for the poison message. `Move` causes the message to move to the poison sub-queue.  
  
 The service contract is `IOrderProcessor`, which defines a one-way service that is suitable for use with queues.  
  
```  
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]  
public interface IOrderProcessor  
{  
    [OperationContract(IsOneWay = true)]  
    void SubmitPurchaseOrder(PurchaseOrder po);  
}  
```  
  
 The service operation displays a message stating it is processing the order. To demonstrate the poison message functionality, the `SubmitPurchaseOrder` service operation throws an exception to rollback the transaction on a random invocation of the service. This causes the message to be put back in the queue. Eventually the message is marked as poison. The configuration is set to move the poison message to the poison sub-queue.  
  
```  
// Service class that implements the service contract.  
// Added code to write output to the console window.  
public class OrderProcessorService : IOrderProcessor  
{  
    static Random r = new Random(137);  
  
    [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]  
    public void SubmitPurchaseOrder(PurchaseOrder po)  
    {  
  
        int randomNumber = r.Next(10);  
  
        if (randomNumber % 2 == 0)  
        {  
            Orders.Add(po);  
            Console.WriteLine("Processing {0} ", po);  
        }  
        else  
        {  
            Console.WriteLine("Aborting transaction, cannot process purchase order: " + po.PONumber);  
            Console.WriteLine();  
            throw new Exception("Cannot process purchase order: " + po.PONumber);  
        }  
    }  
  
    public static void OnServiceFaulted(object sender, EventArgs e)   
    {  
        Console.WriteLine("Service Faulted");  
    }  
  
    // Host the service within this EXE console application.  
    public static void Main()  
    {  
        // Get MSMQ queue name from app settings in configuration.  
        string queueName = ConfigurationManager.AppSettings["queueName"];  
  
        // Create the transacted MSMQ queue if necessary.  
        if (!System.Messaging.MessageQueue.Exists(queueName))  
            System.Messaging.MessageQueue.Create(queueName, true);  
  
        // Get the base address that is used to listen for WS-MetaDataExchange requests.  
        // This is useful to generate a proxy for the client.  
        string baseAddress = ConfigurationManager.AppSettings["baseAddress"];  
  
        // Create a ServiceHost for the OrderProcessorService type.  
        ServiceHost serviceHost = new ServiceHost(typeof(OrderProcessorService), new Uri(baseAddress));  
  
        // Hook on to the service host faulted events.  
        serviceHost.Faulted += new EventHandler(OnServiceFaulted);  
  
        // Open the ServiceHostBase to create listeners and start listening for messages.  
        serviceHost.Open();  
  
        // The service can now be accessed.  
        Console.WriteLine("The service is ready.");  
        Console.WriteLine("Press <ENTER> to terminate service.");  
        Console.WriteLine();  
        Console.ReadLine();  
  
        if(serviceHost.State != CommunicationState.Faulted) {  
            serviceHost.Close();  
        }  
  
    }  
}  
```  
  
 The service configuration includes the following poison message properties: `receiveRetryCount`, `maxRetryCycles`, `retryCycleDelay`, and `receiveErrorHandling` as shown in the following configuration file.  
  
```xml  
<?xml version="1.0" encoding="utf-8" ?>  
<configuration>  
  <appSettings>  
    <!-- Use appSetting to configure MSMQ queue name. -->  
    <add key="queueName" value=".\private$\ServiceModelSamplesPoison" />  
    <add key="baseAddress" value="http://localhost:8000/orderProcessor/poisonSample"/>  
  </appSettings>  
  <system.serviceModel>  
    <services>  
      <service   
              name="Microsoft.ServiceModel.Samples.OrderProcessorService">  
        <!-- Define NetMsmqEndpoint -->  
        <endpoint address="net.msmq://localhost/private/ServiceModelSamplesPoison"  
                  binding="netMsmqBinding"  
                  bindingConfiguration="PoisonBinding"   
                  contract="Microsoft.ServiceModel.Samples.IOrderProcessor" />  
      </service>  
    </services>  
  
    <bindings>  
      <netMsmqBinding>  
        <binding name="PoisonBinding"   
                 receiveRetryCount="0"  
                 maxRetryCycles="1"  
                 retryCycleDelay="00:00:05"                        
                 receiveErrorHandling="Move">  
        </binding>  
      </netMsmqBinding>  
    </bindings>  
  </system.serviceModel>  
</configuration>  
```  
  
## Processing messages from the poison message queue  
 The poison message service reads messages from the final poison message queue and processes them.  
  
 Messages in the poison message queue are messages that are addressed to the service that is processing the message, which could be different from the poison message service endpoint. Therefore, when the poison message service reads messages from the queue, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] channel layer finds the mismatch in endpoints and does not dispatch the message. In this case, the message is addressed to the order processing service but is being received by the poison message service. To continue to receive the message even if the message is addressed to a different endpoint, we must add a `ServiceBehavior` to filter addresses where the match criterion is to match any service endpoint the message is addressed to. This is required to successfully process messages that you read from the poison message queue.  
  
 The poison message service implementation itself is very similar to the service implementation. It implements the contract and processes the orders. The code example is as follows.  
  
```  
// Service class that implements the service contract.  
// Added code to write output to the console window.  
[ServiceBehavior(AddressFilterMode=AddressFilterMode.Any)]  
public class OrderProcessorService : IOrderProcessor  
{  
    [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]  
    public void SubmitPurchaseOrder(PurchaseOrder po)  
    {  
        Orders.Add(po);  
        Console.WriteLine("Processing {0} ", po);  
    }  
  
    public static void OnServiceFaulted(object sender, EventArgs e)   
    {  
        Console.WriteLine("Service Faulted...exiting app");  
        Environment.Exit(1);  
    }  
  
    // Host the service within this EXE console application.  
    public static void Main()  
    {  
  
        // Create a ServiceHost for the OrderProcessorService type.  
        ServiceHost serviceHost = new ServiceHost(typeof(OrderProcessorService));  
  
        // Hook on to the service host faulted events.  
        serviceHost.Faulted += new EventHandler(OnServiceFaulted);  
  
        serviceHost.Open();  
  
        // The service can now be accessed.  
        Console.WriteLine("The poison message service is ready.");  
        Console.WriteLine("Press <ENTER> to terminate service.");  
        Console.WriteLine();  
        Console.ReadLine();  
  
        // Close the ServiceHostBase to shutdown the service.  
        if(serviceHost.State != CommunicationState.Faulted)  
        {  
            serviceHost.Close();  
        }  
    }  
```  
  
 Unlike the order processing service that reads messages from the order queue, the poison message service reads messages from the poison sub-queue. The poison queue is a sub-queue of the main queue, is named "poison" and is automatically generated by MSMQ. To access it, provide the main queue name followed by a ";" and the sub-queue name, in this case -"poison", as shown in the following sample configuration.  
  
> [!NOTE]
>  In the sample for MSMQ v3.0, the poison queue name is not a sub-queue, rather the queue that we moved the message to.  
  
```xml  
<?xml version="1.0" encoding="utf-8" ?>  
<configuration>  
  <system.serviceModel>  
    <services>  
      <service name="Microsoft.ServiceModel.Samples.OrderProcessorService">  
        <!-- Define NetMsmqEndpoint -->  
        <endpoint address="net.msmq://localhost/private/ServiceModelSamplesPoison;poison"  
                  binding="netMsmqBinding"  
                  contract="Microsoft.ServiceModel.Samples.IOrderProcessor" >  
        </endpoint>  
      </service>  
    </services>  
  
  </system.serviceModel>  
</configuration>  
```  
  
 When you run the sample, the client, service, and poison message service activities are displayed in console windows. You can see the service receive messages from the client. Press ENTER in each console window to shut down the services.  
  
 The service starts running, processing orders and at random starts to terminate processing. If the message indicates it has processed the order, you can run the client again to send another message until you see the service has actually terminated a message. Based on the configured poison settings, the message is tried once for processing before moving it to the final poison queue.  
  
```  
The service is ready.  
Press <ENTER> to terminate service.  
  
Processing Purchase Order: 0f063b71-93e0-42a1-aa3b-bca6c7a89546  
        Customer: somecustomer.com  
        OrderDetails  
                Order LineItem: 54 of Blue Widget @unit price: $29.99  
                Order LineItem: 890 of Red Widget @unit price: $45.89  
        Total cost of this order: $42461.56  
        Order status: Pending  
  
Processing Purchase Order: 5ef9a4fa-5a30-4175-b455-2fb1396095fa  
        Customer: somecustomer.com  
        OrderDetails  
                Order LineItem: 54 of Blue Widget @unit price: $29.99  
                Order LineItem: 890 of Red Widget @unit price: $45.89  
        Total cost of this order: $42461.56  
        Order status: Pending  
  
Aborting transaction, cannot process purchase order: 23e0b991-fbf9-4438-a0e2-20adf93a4f89  
```  
  
 Start up the poison message service to read the poisoned message from the poison queue. In this example, the poison message service reads the message and processes it. You could see that the purchase order that was terminated and poisoned is read by the poison message service.  
  
```  
The service is ready.  
Press <ENTER> to terminate service.  
  
Processing Purchase Order: 23e0b991-fbf9-4438-a0e2-20adf93a4f89  
        Customer: somecustomer.com  
        OrderDetails  
                Order LineItem: 54 of Blue Widget @unit price: $29.99  
                Order LineItem: 890 of Red Widget @unit price: $45.89  
        Total cost of this order: $42461.56  
        Order status: Pending  
```  
  
#### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  If the service is run first, it will check to ensure that the queue is present. If the queue is not present, the service will create one. You can run the service first to create the queue, or you can create one via the MSMQ Queue Manager. Follow these steps to create a queue in Windows 2008.  
  
    1.  Open Server Manager in [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)].  
  
    2.  Expand the **Features** tab.  
  
    3.  Right-click **Private Message Queues**, and select **New**, **Private Queue**.  
  
    4.  Check the **Transactional** box.  
  
    5.  Enter `ServiceModelSamplesTransacted` as the name of the new queue.  
  
3.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
4.  To run the sample in a single- or cross-computer configuration, change the queue names to reflect the actual hostname instead of localhost and follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
 By default with the `netMsmqBinding` binding transport, security is enabled. Two properties, `MsmqAuthenticationMode` and `MsmqProtectionLevel`, together determine the type of transport security. By default, the authentication mode is set to `Windows` and the protection level is set to `Sign`. For MSMQ to provide the authentication and signing feature, it must be part of a domain. If you run this sample on a computer that is not part of a domain, you receive the following error: "User's internal message queuing certificate does not exist".  
  
#### To run the sample on a computer joined to a workgroup  
  
1.  If your computer is not part of a domain, turn off transport security by setting the authentication mode and protection level to `None` as shown in the following sample configuration:  
  
    ```xml  
    <bindings>  
        <netMsmqBinding>  
            <binding name="TransactedBinding">  
                <security mode="None"/>  
            </binding>  
        </netMsmqBinding>  
    </bindings>  
    ```  
  
     Ensure the endpoint is associated with the binding by setting the endpoint's bindingConfiguration attribute.  
  
2.  Ensure that you change the configuration on the PoisonMessageServer, server and the client before you run the sample.  
  
    > [!NOTE]
    >  Setting `security mode` to `None` is equivalent to setting `MsmqAuthenticationMode`, `MsmqProtectionLevel`, and `Message` security to `None`.  
  
3.  In order for Meta Data Exchange to work, we register a URL with http binding. This requires that the service run in an elevated command window. Otherwise, you get an exception such as: Unhandled Exception: System.ServiceModel.AddressAccessDeniedException: HTTP could not register URL http://+:8000/ServiceModelSamples/service/. Your process does not have access rights to this namespace (see http://go.microsoft.com/fwlink/?LinkId=70353 for details). ---> System.Net.HttpListenerException: Access is denied.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Binding\Net\MSMQ\Poison\MSMQ4`  
  
## See Also
