---
title: "Durable Duplex"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4e76d1a1-f3d8-4a0f-8746-4a322cdff6eb
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Durable Duplex
This sample demonstrates how to set up and configure durable duplex message exchange using the messaging activities in [!INCLUDE[wf](../../../../includes/wf-md.md)]. A durable duplex message exchange is a two-way message exchange that takes place over a long period of time. The lifetime of the message exchange may be longer than the lifetime of the communication channel and the in-memory lifetime of the service instances.  
  
## Sample Details  
 In this sample, two [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] services implemented using [!INCLUDE[wf2](../../../../includes/wf2-md.md)] are configured to have a durable duplex message exchange. The durable duplex message exchange is composed from two one-way messages sent over MSMQ and correlated using [.NET Context Exchange](http://go.microsoft.com/fwlink/?LinkID=166059). The messages are sent using the <xref:System.ServiceModel.Activities.Send> and <xref:System.ServiceModel.Activities.Receive> messaging activities. .NET Context Exchange is use to specify the callback address on the sent messages. Both services are hosted using Windows Process Activation Services (WAS) and are configured to enable persistence of the services instances.  
  
 The first service (Service1.xamlx) sends a request to the send service (Service2.xamlx) to do some work. Once the work is completed, Service2.xamlx sends a notification back to Service1.xamlx to indicate that the work has been completed. A workflow console application sets up the queues that the services are listening on and sends the initial Start message to activate Service1.xamlx. Once Service1.xamlx receives the notification from Service2.xamlx that the requested work has been completed, Service1.xamlx saves the result to an XML file. While waiting for the callback message, Service1.xamlx persists its instance state using the default <xref:System.ServiceModel.Activities.Description.WorkflowIdleBehavior>. Service2.xamlx persists its instance state as part of completing the work requested by Service1.xamlx.  
  
 To configure the services to use .NET Context Exchange over MSMQ, both services are configured to use a custom binding that consists of the <xref:System.ServiceModel.Channels.ContextBindingElement> and the <xref:System.ServiceModel.Channels.MsmqTransportBindingElement>. A callback address is specified with the <xref:System.ServiceModel.Channels.ContextBindingElement> and is included in a callback context header with all messages sent using a custom binding. The following code example defines the custom binding.  
  
```xml  
<configuration>  
     <system.serviceModel>  
          …  
          <bindings>  
               <customBinding>  
                    <binding name="netMsmqContextBinding">  
                         <context clientCallbackAddress="net.msmq://localhost/private/DurableDuplex/Service1.xamlx"/>  
                         <msmqTransport exactlyOnce="False">  
                              <msmqTransportSecurity msmqAuthenticationMode="None" msmqProtectionLevel="None"/>  
                         </msmqTransport>  
                    </binding>  
               </customBinding>  
          </bindings>  
          …  
     </system.serviceModel>  
</configuration>  
```  
  
> [!NOTE]
>  The binding used by this sample is not secure. When deploying your application you should configure your binding based on the security requirements of your application.  
  
> [!NOTE]
>  The queues used in this sample are not transactional. For a sample that shows how to set up [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message exchanges using transaction queues, see the [MSMQ Activation](../../../../docs/framework/wcf/samples/msmq-activation.md) sample.  
  
 The message sent by Service1.xamlx to Service2.xamlx is sent using a client endpoint configured with the address of Service2.xamlx and the custom binding defined previously. The callback from Service2.xamlx to Service1.xamlx is sent using a client endpoint with no explicitly configured address because the address is taken from the callback context sent by Service1.xamlx. The following code example defines the client endpoints.  
  
```xml  
<?xml version="1.0"?>  
<configuration>  
     <system.serviceModel>  
          …  
          <client>  
               <endpoint address="net.msmq://localhost/private/DurableDuplex/Service2.xamlx" binding="customBinding" bindingConfiguration="netMsmqContextBinding" contract="IDoWork"/>  
               <endpoint binding="customBinding" bindingConfiguration="netMsmqContextBinding" contract="INotify"/>  
          </client>  
          …  
     </system.serviceModel>  
</configuration>  
```  
  
 The following code example exposes endpoints using this custom binding by changing the default protocol mapping for net.msmq base addresses to use this custom binding.  
  
```xml  
<configuration>  
     <system.serviceModel>  
          <protocolMapping>  
               <add scheme="net.msmq" binding="customBinding" bindingConfiguration="netMsmqContextBinding"/>  
          </protocolMapping>  
          …  
     </system.serviceModel>  
</configuration>  
```  
  
 The following code example enables persistence for both services by adding the <xref:System.ServiceModel.Activities.Description.SqlWorkflowInstanceStoreBehavior> behavior to both services and specifying the connection string for the persistence database.  
  
```xml  
<?xml version="1.0"?>  
<configuration>  
    <system.serviceModel>  
          …  
          <behaviors>  
               <serviceBehaviors>  
                    <behavior>  
                         <serviceDebug includeExceptionDetailInFaults="True"/>  
                         <serviceMetadata httpGetEnabled="True"/>  
                         <sqlWorkflowInstanceStore connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=DefaultSampleStore;Integrated Security=True"/>  
                    </behavior>  
               </serviceBehaviors>  
          </behaviors>  
     </system.serviceModel>  
</configuration>  
```  
  
## System Requirements  
 This sample requires the following components.  
  
1.  Internet Information Services.  
  
2.  Internet Information Services -> IIS 6.0 Management Compatibility -> IIS Metabase and IIS 6.0 configuration compatibility.  
  
3.  World Wide Web Services -> Application Development Features -> ASP.NET.  
  
4.  Microsoft Message Queues (MSMQ) Server.  
  
#### To use this sample  
  
1.  Set up the persistence database and the results directory.  
  
    1.  Open a [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt.  
  
    2.  Navigate to the folder for this sample and run Setup.cmd.  
  
2.  Set up the virtual application.  
  
    1.  From a [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt, register ASP.NET by running the following command.  
  
        ```  
        aspnet_regiis -i  
        ```  
  
    2.  Run [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] with administrator permissions by right-clicking [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] and selecting **Run as administrator**.  
  
    3.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the DurableDuplex.sln file.  
  
3.  Set up the service queues.  
  
    1.  To run the DurableDuplex client, press F5.  
  
    2.  Open the **Computer Management** console by running `Compmgmt.msc` from a command prompt.  
  
    3.  Expand **Service and Applications**, **Message Queuing**. **Private Queues**.  
  
    4.  Right-click the durableduplex/service1.xamlx and durableduplex/service2.xamlx queues and select **Properties**.  
  
    5.  Select the **Security** tab and allow **Everyone Receive Message**, **Peek Message** and **Send Message** permissions for both queues.  
  
    6.  Open Internet Information Services (IIS) Manager.  
  
    7.  Browse to **Server**, **Sites**, **Default Web site**, **private**, **Durable Duplex** and select **Advanced Options**.  
  
    8.  Change the **Enabled Protocols** to **http,net.msmq**.  
  
4.  Run the sample.  
  
    1.  Browse to http://localhost/private/durableduplex/service1.xamlx and http://localhost/private/durableduplex/service2.xamlx to ensure that both services are running.  
  
    2.  Press F5 to run DurableDuplexClient.  
  
         When the durable duplex message exchange completes a result.xml file is saved to the C:\Inbox folder and contains the result of the message exchange.  
  
#### To cleanup (Optional)  
  
1.  Run Cleanup.cmd.  
  
    1.  Open a [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt.  
  
    2.  Navigate to the folder for this sample and run Cleanup.cmd.  
  
2.  Remove the virtual application for the services.  
  
    1.  Open the Internet Information Services (IIS) Manager by running `Inetmgr.exe` from a command prompt.  
  
    2.  Browse to the default Web site and remove the **private** virtual directory.  
  
3.  Remove the queues set up for this sample.  
  
    1.  Open the Computer Management console by running `Compmgmt.msc` from a command prompt.  
  
    2.  Expand **Service and Applications**, **Message Queuing**, **Private Queues**.  
  
    3.  Delete the durableduplex/service1.xamlx and durableduplex/service2.xamlx queues.  
  
4.  Remove the C:\Inbox directory.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Services\DurableDuplex`