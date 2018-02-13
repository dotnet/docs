---
title: "Windows Service Host"
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
  - "NT Service"
  - "NT Service Host Sample [Windows Communication Foundation]"
ms.assetid: 1b2f45c5-2bed-4979-b0ee-8f9efcfec028
caps.latest.revision: 40
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Windows Service Host
This sample demonstrates a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service hosted in a managed Windows Service. Windows Services are controlled using the Services applet in **Control Panel** and can be configured to start up automatically after a system reboot. The sample consists of a client program and an Windows Service program. The service is implemented as an .exe program and contains its own hosting code. In other hosting environments, such as Windows Process Activation Services (WAS) or Internet Information Services (IIS), it is not necessary for you to write hosting code.  
  
> [!NOTE]
>  The set-up procedure and build instructions for this sample are located at the end of this topic.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Services\Hosting\WindowsService`  
  
 After building this service, it must be installed with the Installutil.exe utility like any other Windows Service. If you are going to make changes to the service, you must first uninstall it with `installutil /u`. The Setup.bat and Cleanup.bat files included in this sample are the commands to install and start up the Windows Service, and to shut down and uninstall the Windows Service. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service can only respond to clients if the Windows Service is running. If you stop the Windows Service by using the Services applet from **Control Panel** and run the client, a <xref:System.ServiceModel.EndpointNotFoundException> exception occurs when a client attempts to access the service. If you restart the Windows Service and rerun the client, communication succeeds.  
  
 The service code includes an installer class, a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service implementation class which implements the ICalculator contract, and a Windows Service class that acts as the run-time host. The installer class, which inherits from <xref:System.Configuration.Install.Installer>, allows the program to be installed as an NT service by the Installutil.exe tool. The service implementation class, `WcfCalculatorService`, is an [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service that implements a basic service contract. This [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service is hosted inside a Windows Service class called `WindowsCalculatorService`. To qualify as a Windows Service, the class inherits from <xref:System.ServiceProcess.ServiceBase> and implements the <xref:System.ServiceProcess.ServiceBase.OnStart%28System.String%5B%5D%29> and <xref:System.ServiceProcess.ServiceBase.OnStop> methods. In <xref:System.ServiceProcess.ServiceBase.OnStart%28System.String%5B%5D%29>, a <xref:System.ServiceModel.ServiceHost> object is created for the `WcfCalculatorService` type and opened. In <xref:System.ServiceProcess.ServiceBase.OnStop>, the ServiceHost is closed by calling the <xref:System.ServiceModel.Channels.CommunicationObject.Close%28System.TimeSpan%29> method of the <xref:System.ServiceModel.ServiceHost> object. The host's base address is configured using the [\<add>](../../../../docs/framework/configure-apps/file-schema/wcf/add-of-baseaddresses.md) element, which is a child of [\<baseAddresses>](../../../../docs/framework/configure-apps/file-schema/wcf/baseaddresses.md), which is a child of the [\<host>](../../../../docs/framework/configure-apps/file-schema/wcf/host.md) element, which is a child of the [\<service>](../../../../docs/framework/configure-apps/file-schema/wcf/service.md) element.  
  
 The endpoint that is defined uses the base address and a [\<wsHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md). The following sample shows the configuration of the base address as well as the endpoint that exposes the CalculatorService.  
  
```xml  
<services>  
  <service name="Microsoft.ServiceModel.Samples.WcfCalculatorService"  
           behaviorConfiguration="CalculatorServiceBehavior">  
    <host>  
      <baseAddresses>  
        <add baseAddress="http://localhost:8000/ServiceModelSamples/service"/>  
      </baseAddresses>  
    </host>  
    <!-- This endpoint is exposed at the base address provided by host: http://localhost:8000/ServiceModelSamples/service.  -->  
    <endpoint address=""  
              binding="wsHttpBinding"  
              contract="Microsoft.ServiceModel.Samples.ICalculator" />  
    ...  
  </service>  
</services>  
```  
  
 When you run the sample, the operation requests and responses are displayed in both the service and client console windows. Press ENTER in each console window to shut down the service and client.  
  
### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  After the solution has been built, run Setup.bat from an elevated [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] command prompt to install the Windows service using the Installutil.exe tool. The service should appear in Services.  
  
4.  To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
## See Also  
 [AppFabric Hosting and Persistence Samples](http://go.microsoft.com/fwlink/?LinkId=193961)
