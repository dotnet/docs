---
title: "UDP Activation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4b0ccd10-0dfb-4603-93f9-f0857c581cb7
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# UDP Activation
This sample is based on the [Transport: UDP](../../../../docs/framework/wcf/samples/transport-udp.md) sample. It extends the [Transport: UDP](../../../../docs/framework/wcf/samples/transport-udp.md) sample to support process activation using the Windows Process Activation Service (WAS).  
  
 The sample consists of three major pieces:  
  
-   A UDP Protocol Activator, a standalone process that receives UDP messages on behalf of applications that are to be activated.  
  
-   A client that uses the UDP custom transport to send messages.  
  
-   A service (hosted in a worker process activated by WAS) that receives messages over the UDP custom transport.  
  
## UDP Protocol Activator  
 The UDP Protocol Activator is a bridge between the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client and the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service. It provides data communication through the UDP protocol at the transport layer. It has two major functions:  
  
-   WAS Listener Adapter (LA), which collaborates with WAS to activate processes in response to incoming messages.  
  
-   UDP Protocol Listener, which accepts UDP messages on behalf of applications that are to be activated.  
  
 The activator must be running as a standalone program on the server machine. Normally, WAS listener adapters (such as the NetTcpActivator and the NetPipeActivator) are implemented in long-running Windows services. However, for simplicity and clarity, this sample implements the protocol activator as a standalone application.  
  
### WAS Listener Adapter  
 The WAS Listener Adapter for UDP is implemented in the `UdpListenerAdapter` class. It is the module that interacts with WAS to perform application activation for the UDP protocol. This is achieved by calling the following Webhost APIs:  
  
-   `WebhostRegisterProtocol`  
  
-   `WebhostUnregisterProtocol`  
  
-   `WebhostOpenListenerChannelInstance`  
  
-   `WebhostCloseAllListenerChannelInstances`  
  
 After initially calling `WebhostRegisterProtocol`, the listener adapter receives the callback `ApplicationCreated` from WAS for all of the applications registered in applicationHost.config (located in %windir%\system32\inetsrv). In this sample, we only handle the applications with the UDP protocol (with the protocol id as "net.udp") enabled. Other implementations may handle this differently if such implementations respond to dynamic configuration changes to the application (for example, an application transition from disabled to enabled).  
  
 When the callback `ConfigManagerInitializationCompleted` is received, it indicates that WAS has finished all of the notifications for the initialization of the protocol. At this time, the listener adapter is ready to process activation requests.  
  
 When a new request comes in the first time for an application, the listener adapter calls `WebhostOpenListenerChannelInstance` into WAS, which starts the worker process if it is not started yet. Then the protocol handlers are loaded and the communication between the listener adapter and the virtual application can start.  
  
 The listener adapter is registered in the %SystemRoot%\System32\inetsrv\ApplicationHost.config in the <`listenerAdapters`> section as following:  
  
```xml  
<add name="net.udp" identity="S-1-5-21-2127521184-1604012920-1887927527-387045" />  
```  
  
### Protocol Listener  
 The UDP protocol listener is a module inside the protocol activator that listens at a UDP endpoint on behalf of the virtual application. It is implemented in the class `UdpSocketListener`. The endpoint is represented as `IPEndpoint` for which the port number is extracted from the binding of the protocol for the site.  
  
### Control Service  
 In this sample, we use [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to communicate between the activator and the WAS worker process. The service that resides in the activator is called the Control Service.  
  
## Protocol Handlers  
 After the listener adapter calls `WebhostOpenListenerChannelInstance`, the WAS process manager starts the worker process if it is not started. The application manager inside the worker process then loads the UDP Process Protocol Handler (PPH) with the request for that `ListenerChannelId`. The PPH in turns calls `IAdphManager`.`StartAppDomainProtocolListenerChannel` to start the UDP AppDomain Protocol Handler (ADPH).  
  
## HostedUDPTransportConfiguration  
 The information is registered in the Web.config as follows:  
  
```xml  
<serviceHostingEnvironment>  
<add name="net.udp" transportConfigurationType="Microsoft.ServiceModel.Samples.Hosting.HostedUdpTransportConfiguration, UdpActivation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=6fa904d2da1848d6" />  
</serviceHostingEnvironment>  
```  
  
## Special Setup for This Sample  
 This sample can be only built and run on Windows Vista, Windows Server 2008, or Windows 7. To run the sample, you must first get all of the components set up correctly. Use the following steps to install the sample.  
  
#### To set up this sample  
  
1.  Install [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] 4.0 using the following command.  
  
    ```  
    %windir%\Microsoft.NET\Framework\v4.0.XXXXX\aspnet_regiis.exe /i /enable  
    ```  
  
2.  Build the project on Windows Vista. After compilation, it also performs the following operations in the post-build phase:  
  
    -   Installs the UDP binding to the site "Default Web Site".  
  
    -   Creates the virtual application "ServiceModelSamples" to point to the physical path: "%SystemDrive%\inetpub\wwwroot\servicemodelsamples".  
  
    -   It also enables "net.udp" protocol for this virtual application.  
  
3.  Start the user interface application "WasNetActivator.exe". Click the **Setup** tab, check the following check boxes and then click **Install** to install them:  
  
    -   UDP Listener Adapter  
  
    -   UDP Protocol Handlers  
  
4.  Click the **Activation** tab of the user interface application "WasNetActivator.exe". Click the **Start** button to start the listener adapter. Now you are ready to run the program.  
  
    > [!NOTE]
    >  When you are finished with this sample, you must run Cleanup.bat to remove the net.udp binding from the "Default Web Site".  
  
## Sample Usage  
 After compilation, there are four different binaries generated:  
  
-   Client.exe: The client code. The App.config is compiled into the client configuration file Client.exe.config.  
  
-   UDPActivation.dll: the library that contains all of the major UDP implementations.  
  
-   Service.dll: The service code. This is copied to the \bin directory of the virtual application ServiceModelSamples. The service file is Service.svc and the configuration file is Web.config. After compilation, they are copied to the following location: %SystemDrive%\Inetpub\wwwroot\ServiceModelSamples.  
  
-   WasNetActivator: The UDP activator program.  
  
-   Ensure that all of the required pieces are installed correctly. The following steps show how to run the sample:  
  
1.  Ensure that the following Windows services have been started:  
  
    -   Windows Process Activation Service (WAS).  
  
    -   Internet Information Services (IIS): W3SVC.  
  
2.  Then start the activator, WasNetActivator.exe. Under the **Activation** tab, the only protocol, **UDP**, is selected in the drop down list. Click the **Start** button to start the activator.  
  
3.  Once the activator is started, you can run the client code by running Client.exe from a command window. The following is the sample output:  
  
    ```  
    Testing Udp Activation.  
    Start the status service.  
    Sending UDP datagrams.  
    Type a word that you want to say to the server: Hello, world!  
        Sending datagram: Hello, world![0]  
        Sending datagram: Hello, world![1]  
        Sending datagram: Hello, world![2]  
        Sending datagram: Hello, world![3]  
        Sending datagram: Hello, world![4]  
    Calling UDP duplex contract (ICalculatorContract).  
        0 + 0 = 0  
        1 + 2 = 3  
        2 + 4 = 6  
        3 + 6 = 9  
        4 + 8 = 12  
    Getting status and dump server traces:  
        Operation 'Hello' is called: Hello, world![0]  
        Operation 'Hello' is called: Hello, world![1]  
        Operation 'Hello' is called: Hello, world![2]  
        Operation 'Hello' is called: Hello, world![3]  
        Operation 'Hello' is called: Hello, world![4]  
        Operation 'Add' is called: 0 + 0  
        Operation 'Add' is called: 1 + 2  
        Operation 'Add' is called: 2 + 4  
        Operation 'Add' is called: 3 + 6  
        Operation 'Add' is called: 4 + 8  
    Press <ENTER> to complete test.  
    ```  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Transport\UdpActivation`  
  
## See Also
