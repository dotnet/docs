---
title: "MSMQ Activation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e3834149-7b8c-4a54-806b-b4296720f31d
caps.latest.revision: 29
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# MSMQ Activation
This sample demonstrates how to host applications in Windows Process Activation Service (WAS) that are read from a message queue. This sample uses the `netMsmqBinding` and is based on the [Two-Way Communication](../../../../docs/framework/wcf/samples/two-way-communication.md) sample. The service in this case is a Web-hosted application and the client is self-hosted and outputs to the console to observe the status of purchase orders submitted.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
> [!NOTE]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  \<InstallDrive>:\WF_WCF_Samples  
>   
>  If this directory does not exist, go to [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] HYPERLINK "http://go.microsoft.com/fwlink/?LinkId=150780" \t "_blank"  and [!INCLUDE[wf](../../../../includes/wf-md.md)] Samples for [!INCLUDE[netfx40_long](../../../../includes/netfx40-long-md.md)] to download all [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  \<InstallDrive>:\Samples\WCFWFCardSpace\WCF\Basic\Services\Hosting\WASHost\MsmqActivation.  
  
 Windows Process Activation Service (WAS), the new process activation mechanism for [!INCLUDE[lserver](../../../../includes/lserver-md.md)], provides IIS-like features that were previously only available to HTTP-based applications to applications that use non-HTTP protocols. [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] uses the Listener Adapter interface to communicate activation requests that are received over the non-HTTP protocols supported by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], such as TCP, Named Pipes, and MSMQ. The functionality for receiving requests over non-HTTP protocols is hosted by managed Windows services running in SMSvcHost.exe.  
  
 The Net.Msmq Listener Adapter service (NetMsmqActivator) activates queued applications based on messages in the queue.  
  
 The client sends purchase orders to the service from within the scope of a transaction. The service receives the orders in a transaction and processes them. The service then calls back the client with the status of the order. To facilitate two-way communication the client and service both use queues to enqueue purchase orders and order status.  
  
 The service contract `IOrderProcessor` defines the one-way service operations that work with queuing. The service operation uses the reply endpoint to send order statuses to the client. The reply endpoint's address is the URI of the queue used to send the order status back to the client. The order processing application implements this contract.  
  
```csharp  
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]  
public interface IOrderProcessor  
{  
    [OperationContract(IsOneWay = true)]  
    void SubmitPurchaseOrder(PurchaseOrder po,   
                                           string reportOrderStatusTo);  
}  
```  
  
 The reply contract to send order status to is specified by the client. The client implements the order status contract. The service uses the generated client of this contract to send order status back to the client.  
  
```csharp  
[ServiceContract]  
public interface IOrderStatus  
{  
    [OperationContract(IsOneWay = true)]  
    void OrderStatus(string poNumber, string status);  
}  
```  
  
 The service operation processes the submitted purchase order. The <xref:System.ServiceModel.OperationBehaviorAttribute> is applied to the service operation to specify automatic enlistment in the transaction that is used to receive the message from the queue and automatic completion of the transaction on completion of the service operation. The `Orders` class encapsulates order processing functionality. In this case, it adds the purchase order to a dictionary. The transaction that the service operation enlisted in is available to the operations in the `Orders` class.  
  
 The service operation, in addition to processing the submitted purchase order, replies back to the client about the status of the order.  
  
```csharp  
public class OrderProcessorService : IOrderProcessor  
{  
    [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]  
    public void SubmitPurchaseOrder(PurchaseOrder po, string reportOrderStatusTo)  
    {  
        Orders.Add(po);  
        Console.WriteLine("Processing {0} ", po);  
        Console.WriteLine("Sending back order status information");  
        NetMsmqBinding msmqCallbackBinding = new NetMsmqBinding();  
        msmqCallbackBinding.Security.Mode = NetMsmqSecurityMode.None;  
        OrderStatusClient client = new OrderStatusClient(msmqCallbackBinding, new EndpointAddress(reportOrderStatusTo));  
        // please note that the same transaction that is used to dequeue purchase order is used  
        // to send back order status  
        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))  
        {  
            client.OrderStatus(po.PONumber, po.Status);  
            scope.Complete();  
        }  
    }  
```  
  
 The client binding to use is specified using a configuration file.  
  
 The MSMQ queue name is specified in an appSettings section of the configuration file. The endpoint for the service is defined in the System.serviceModel section of the configuration file.  
  
> [!NOTE]
>  The MSMQ queue name and endpoint address use slightly different addressing conventions. The MSMQ queue name uses a dot (.) for the local computer and backslash separators in its path. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] endpoint address specifies a net.msmq: scheme, uses "localhost" for the local computer, and uses forward slashes in its path. To read from a queue that is hosted on the remote computer, replace the "." and "localhost" to the remote computer name.  
  
 A .svc file with the name of the class is used to host the service code in WAS.  
  
 The Service.svc file itself contains a directive to create the `OrderProcessorService`.  
  
```xml  
<%@ServiceHost language="c#" Debug="true" Service="Microsoft.ServiceModel.Samples.OrderProcessorService"%>  
```  
  
 The Service.svc file also contains an assembly directive to ensure that System.Transactions.dll is loaded.  
  
```xml  
<%@Assembly name="System.Transactions, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"%>  
```  
  
 The client creates a transaction scope. Communication with the service takes place within the scope of the transaction, causing it to be treated as an atomic unit where all messages succeed or fail. The transaction is committed by calling `Complete` on the transaction scope.  
  
```csharp  
using (ServiceHost serviceHost = new ServiceHost(typeof(OrderStatusService)))  
{  
    // Open the ServiceHostBase to create listeners and start listening   
    // for order status messages.  
    serviceHost.Open();  
  
    // Create a proxy with given client endpoint configuration  
    OrderProcessorClient client = new OrderProcessorClient();  
  
    // Create the purchase order  
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
  
    //Create a transaction scope.  
    using (TransactionScope scope = new   
        TransactionScope(TransactionScopeOption.Required))  
    {  
        // Make a queued call to submit the purchase order  
        client.SubmitPurchaseOrder(po,   
       "net.msmq://localhost/private/ServiceModelSamplesOrder/OrderStatus");  
        // Complete the transaction.  
        scope.Complete();  
    }  
  
    //Closing the client gracefully closes the connection and cleans up   
    //resources  
    client.Close();  
  
    Console.WriteLine();  
    Console.WriteLine("Press <ENTER> to terminate client.");  
    Console.ReadLine();  
  
    // Close the ServiceHostBase to shutdown the service.  
    serviceHost.Close();  
    }  
```  
  
 The client code implements the `IOrderStatus` contract to receive order status from the service. In this case, it prints out the order status.  
  
```csharp  
[ServiceBehavior]  
public class OrderStatusService : IOrderStatus  
{  
    [OperationBehavior(TransactionAutoComplete = true,   
                        TransactionScopeRequired = true)]  
    public void OrderStatus(string poNumber, string status)  
    {  
        Console.WriteLine("Status of order {0}:{1} ",   
                                         poNumber , status);  
    }  
}  
```  
  
 The order status queue is created in the `Main` method. The client configuration includes the order status service configuration to host the order status service, as shown in the following sample configuration.  
  
```csharp  
<appSettings>  
    <!-- use appSetting to configure MSMQ queue name -->  
    <add key="targetQueueName" value=".\private$\ServiceModelSamples/service.svc" />  
    <add key="responseQueueName" value=".\private$\ServiceModelSamples/OrderStatus" />  
  </appSettings>  
  
<system.serviceModel>  
  
    <services>  
      <service   
         name="Microsoft.ServiceModel.Samples.OrderStatusService">  
        <!-- Define NetMsmqEndpoint -->  
        <endpoint address="net.msmq://localhost/private/ServiceModelSamples/OrderStatus"  
                  binding="netMsmqBinding"  
                  contract="Microsoft.ServiceModel.Samples.IOrderStatus" />  
      </service>  
    </services>  
  
    <client>  
      <!-- Define NetMsmqEndpoint -->  
      <endpoint name="OrderProcessorEndpoint"  
                address="net.msmq://localhost/private/ServiceModelSamples/service.svc"   
                binding="netMsmqBinding"   
                contract="Microsoft.ServiceModel.Samples.IOrderProcessor" />  
    </client>  
  
  </system.serviceModel>  
```  
  
 When you run the sample, the client and service activities are displayed in both the server and client console windows. You can see the server receive messages from the client. Press ENTER in each console window to shut down the server and client.  
  
 The client displays the order status information sent by the server:  
  
```Output  
Press <ENTER> to terminate client.  
Status of order 70cf9d63-3dfa-4e69-81c2-23aa4478ebed :Pending  
```  
  
### To set up, build, and run the sample  
  
1.  Ensure that [!INCLUDE[iisver](../../../../includes/iisver-md.md)] is installed, as it is required for WAS activation.  
  
2.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md). In addition, you must install the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] non-HTTP activation components:  
  
    1.  From the **Start** menu, choose **Control Panel**.  
  
    2.  Select **Programs and Features**.  
  
    3.  Click **Turn Windows Features on or off**.  
  
    4.  Under **Features Summary**, click **Add Features**.  
  
    5.  Expand the **Microsoft .NET Framework 3.0** node and check the **Windows Communication Foundation Non-HTTP Activation** feature.  
  
3.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
4.  Run the client by executing client.exe from a command window. This creates the queue and sends a message to it. Leave the client running to see the result of the service reading the message  
  
5.  The MSMQ activation service runs as Network Service by default. Therefore, the queue that is used to activate the application must have receive and peek permissions for Network Service. This can be added by using the Message Queuing MMC:  
  
    1.  From the **Start** menu, click **Run**, then type `Compmgmt.msc` and press ENTER.  
  
    2.  Under **Services and Applications**, expand **Message Queuing**.  
  
    3.  Click **Private Queues**.  
  
    4.  Right-click the queue (servicemodelsamples/Service.svc) and choose **Properties**.  
  
    5.  On the **Security** tab, click **Add** and give peek and receive permissions to Network Service.  
  
6.  Configure the Windows Process Activation Service (WAS) to support MSMQ activation.  
  
     As a convenience, the following steps are implemented in a batch file called AddMsmqSiteBinding.cmd located in the sample directory.  
  
    1.  To support net.msmq activation, the default Web site must first be bound to the net.msmq protocol. This can be done using appcmd.exe, which is installed with the [!INCLUDE[iisver](../../../../includes/iisver-md.md)] management toolset. From an elevated (administrator) command prompt, run the following command.  
  
        ```  
        %windir%\system32\inetsrv\appcmd.exe set site "Default Web Site"   
        -+bindings.[protocol='net.msmq',bindingInformation='localhost']  
        ```  
  
        > [!NOTE]
        >  This command is a single line of text.  
  
         This command adds a net.msmq site binding to the default Web site.  
  
    2.  Although all applications within a site share a common net.msmq binding, each application can enable net.msmq support individually. To enable net.msmq for the /servicemodelsamples application, run the following command from an elevated command prompt.  
  
        ```  
        %windir%\system32\inetsrv\appcmd.exe set app "Default Web Site/servicemodelsamples" /enabledProtocols:http,net.msmq  
        ```  
  
        > [!NOTE]
        >  This command is a single line of text.  
  
         This command enables the /servicemodelsamples application to be accessed using http://localhost/servicemodelsamples and net.msmq://localhost/servicemodelsamples.  
  
7.  If you have not done so previously, ensure that the MSMQ activation service is enabled. From the **Start** menu, click **Run**, and type `Services.msc`. Search the list of services for the **Net.Msmq Listener Adapter**. Right-click and select **Properties**. Set the **Startup Type** to **Automatic**, click **Apply** and click the **Start** button. This step must only be done once prior to the first usage of the Net.Msmq Listener Adapter service.  
  
8.  To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md). Additionally, change the code on the client that submits the purchase order to reflect the computer name in the URI of the queue when submitting the purchase order. Use the following code:  
  
    ```  
    client.SubmitPurchaseOrder(po, "net.msmq://localhost/private/ServiceModelSamples/OrderStatus");  
    ```  
  
9. Remove the net.msmq site binding you added for this sample.  
  
     As a convenience, the following steps are implemented in a batch file called RemoveMsmqSiteBinding.cmd located in the sample directory:  
  
    1.  Remove net.msmq from the list of enabled protocols by running the following command from an elevated command prompt.  
  
        ```  
        %windir%\system32\inetsrv\appcmd.exe set app "Default Web Site/servicemodelsamples" /enabledProtocols:http  
        ```  
  
        > [!NOTE]
        >  This command is a single line of text.  
  
    2.  Remove the net.msmq site binding by running the following command from an elevated command prompt.  
  
        ```  
        %windir%\system32\inetsrv\appcmd.exe set site "Default Web Site" --bindings.[protocol='net.msmq',bindingInformation='localhost']  
        ```  
  
        > [!NOTE]
        >  This command is a single line of text.  
  
    > [!WARNING]
    >  Running the batch file will reset the DefaultAppPool to run using .NET Framework version 2.0.  
  
 By default with the `netMsmqBinding` binding transport, security is enabled. Two properties, `MsmqAuthenticationMode` and `MsmqProtectionLevel`, together determine the type of transport security. By default the authentication mode is set to `Windows` and the protection level is set to `Sign`. For MSMQ to provide the authentication and signing feature, it must be part of a domain. If you run this sample on a computer that is not part of a domain, the following error is received: "User's internal message queuing certificate does not exist".  
  
### To run the sample on a computer joined to a workgroup  
  
1.  If your computer is not part of a domain, turn off transport security by setting the authentication mode and protection level to none as shown in the following sample configuration.  
  
    ```xml  
    <bindings>  
        <netMsmqBinding>  
            <binding configurationName="TransactedBinding">  
                <security mode="None"/>  
            </binding>  
        </netMsmqBinding>  
    </bindings>  
    ```  
  
2.  Change the configuration on both the server and the client before you run the sample.  
  
    > [!NOTE]
    >  Setting `security mode` to `None` is equivalent to setting `MsmqAuthenticationMode`, `MsmqProtectionLevel` and `Message` security to `None`.  
  
3.  To enable activation in a computer joined to a workgroup, both the activation service and the worker process must be run with a specific user account (must be same for both) and the queue must have ACLs for the specific user account.  
  
     To change the identity that the worker process runs under:  
  
    1.  Run Inetmgr.exe.  
  
    2.  Under **Application Pools**, right-click the **AppPool** (typically **DefaultAppPool**) and choose **Set Application Pool Defaults…**.  
  
    3.  Change the Identity properties to use the specific user account.  
  
     To change the identity that the Activation Service runs under:  
  
    1.  Run Services.msc.  
  
    2.  Right-click the **Net.MsmqListener Adapter**, and choose **Properties**.  
  
4.  Change the account in the **LogOn** tab.  
  
5.  In workgroup, the service must also run using an unrestricted token. To do this, run the following in a command window:  
  
    ```  
    sc sidtype netmsmqactivator unrestricted  
    ```  
  
## See Also  
 [AppFabric Hosting and Persistence Samples](http://go.microsoft.com/fwlink/?LinkId=193961)
