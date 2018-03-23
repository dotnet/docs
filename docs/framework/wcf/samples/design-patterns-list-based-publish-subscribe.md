---
title: "Design Patterns: List-Based Publish-Subscribe"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f4257abc-12df-4736-a03b-0731becf0fd4
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Design Patterns: List-Based Publish-Subscribe
This sample illustrates the List-based Publish-Subscribe pattern implemented as a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] program.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
 The List-based Publish-Subscribe design pattern is described in the Microsoft Patterns & Practices publication, [Integration Patterns](http://go.microsoft.com/fwlink/?LinkId=95894). The Publish-Subscribe pattern passes information to a collection of recipients who have subscribed to an information topic. List-based publish-subscribe maintains a list of subscribers. When there is information to share, a copy is sent to each subscriber on the list. This sample demonstrates a dynamic list-based publish-subscribe pattern, where clients can subscribe or unsubscribe as often as required.  
  
 The List-based Publish-Subscribe sample consists of a client, a service, and a data source program. There can be more than one client and more than one data source program running. Clients subscribe to the service, receive notifications, and unsubscribe. Data source programs send information to the service to be shared with all current subscribers.  
  
 In this sample, the client and data source are console programs (.exe files) and the service is a library (.dll) hosted in Internet Information Services (IIS). Client and data source activity are visible on the desktop.  
  
 The service uses duplex communication. The `ISampleContract` service contract is paired up with an `ISampleClientCallback` callback contract. The service implements Subscribe and Unsubscribe service operations, which clients use to join or leave the list of subscribers. The service also implements the `PublishPriceChange` service operation, which the data source program calls to provide the service with new information. The client program implements the `PriceChange` service operation, which the service calls to notify all subscribers of a price change.  
  
```  
// Create a service contract and define the service operations.  
// NOTE: The service operations must be declared explicitly.  
[ServiceContract(SessionMode=SessionMode.Required,  
      CallbackContract=typeof(ISampleClientContract))]  
public interface ISampleContract  
{  
    [OperationContract(IsOneWay = false, IsInitiating=true)]  
    void Subscribe();  
    [OperationContract(IsOneWay = false, IsTerminating=true)]  
    void Unsubscribe();  
    [OperationContract(IsOneWay = true)]  
    void PublishPriceChange(string item, double price,   
                                     double change);  
}  
  
public interface ISampleClientContract  
{  
    [OperationContract(IsOneWay = true)]  
    void PriceChange(string item, double price, double change);  
}  
```  
  
 The service uses a .NET Framework event as the mechanism to inform all subscribers about new information. When a client joins the service by calling Subscribe, it provides an event handler. When a client leaves, it unsubscribes its event handler from the event. When a data source calls the service to report a price change, the service raises the event. This calls each instance of the service, one for each client that has subscribed, and causes their event handlers to execute. Each event handler passes the information to its client through its callback function.  
  
```  
public class PriceChangeEventArgs : EventArgs  
    {  
        public string Item;  
        public double Price;  
        public double Change;  
    }  
  
    // The Service implementation implements your service contract.  
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]  
    public class SampleService : ISampleContract  
    {  
        public static event PriceChangeEventHandler PriceChangeEvent;  
        public delegate void PriceChangeEventHandler(object sender, PriceChangeEventArgs e);  
  
        ISampleClientContract callback = null;  
  
        PriceChangeEventHandler priceChangeHandler = null;  
  
        //Clients call this service operation to subscribe.  
        //A price change event handler is registered for this client instance.  
  
        public void Subscribe()  
        {  
            callback = OperationContext.Current.GetCallbackChannel<ISampleClientContract>();  
            priceChangeHandler = new PriceChangeEventHandler(PriceChangeHandler);  
            PriceChangeEvent += priceChangeHandler;  
        }  
  
        //Clients call this service operation to unsubscribe.  
        //The previous price change event handler is unregistered.  
  
        public void Unsubscribe()  
        {  
            PriceChangeEvent -= priceChangeHandler;  
        }  
  
        //Information source clients call this service operation to report a price change.  
        //A price change event is raised. The price change event handlers for each subscriber will execute.  
  
        public void PublishPriceChange(string item, double price, double change)  
        {  
            PriceChangeEventArgs e = new PriceChangeEventArgs();  
            e.Item = item;  
            e.Price = price;  
            e.Change = change;  
            PriceChangeEvent(this, e);  
        }  
  
        //This event handler runs when a PriceChange event is raised.  
        //The client's PriceChange service operation is invoked to provide notification about the price change.  
  
        public void PriceChangeHandler(object sender, PriceChangeEventArgs e)  
        {  
            callback.PriceChange(e.Item, e.Price, e.Change);  
        }  
  
    }  
```  
  
 When you run the sample, launch several clients. The clients subscribe to the service. Then run the data source program, which sends information to the service. The service passes on the information to all subscribers. You can see activity on each client console confirming that the information has been received. Press ENTER in the client window to shut down the client.  
  
### To set up and build the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
### To run the sample on the same machine  
  
1.  Test that you can access the service using a browser by entering the following address: http://localhost/servicemodelsamples/service.svc. A confirmation page should be displayed in response.  
  
2.  Run Client.exe from \client\bin\\, from under the language-specific folder. Client activity is displayed on the client console window. Launch several clients.  
  
3.  Run Datasource.exe from \datasource\bin\\, from under the language-specific folder. Data source activity is displayed on the console window. Once the data source sends information to the service, it should be passed on to each client.  
  
4.  If the client, data source, and service programs are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
### To run the sample across machines  
  
1.  Set up the service machine:  
  
    1.  On the service machine, create a virtual directory named ServiceModelSamples. The batch file Setupvroot.bat from the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md) can be used to create the disk directory and virtual directory.  
  
    2.  Copy the service program files from %SystemDrive%\Inetpub\wwwroot\servicemodelsamples to the ServiceModelSamples virtual directory on the service machine. Be sure to include the files in the \bin directory.  
  
    3.  Test that you can access the service from the client machine using a browser.  
  
2.  Set up the client machines:  
  
    1.  Copy the client program files from the \client\bin\ folder, under the language-specific folder, to the client machines.  
  
    2.  In each client configuration file, change the address value of the endpoint definition to match the new address of your service. Replace any references to "localhost" with a fully-qualified domain name in the address.  
  
3.  Set up the data source machine:  
  
    1.  Copy the data source program files from the \datasource\bin\ folder, under the language-specific folder, to the data source machine.  
  
    2.  In the data source configuration file, change the address value of the endpoint definition to match the new address of your service. Replace any references to "localhost" with a fully-qualified domain name in the address.  
  
4.  On the client machines, launch Client.exe from a command prompt.  
  
5.  On the data source machine, launch Datasource.exe from a command prompt.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Scenario\DesignPatterns/ListBasedPublishSubscribe`  
  
## See Also
