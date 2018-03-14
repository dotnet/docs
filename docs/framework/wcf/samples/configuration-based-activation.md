---
title: "Configuration-Based Activation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 21bb762e-c43e-4b0c-887b-5e434d665838
caps.latest.revision: 26
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Configuration-Based Activation
This sample demonstrates how to activate [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] services without requiring a .svc file.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Services\Hosting\ConfigBasedActivation`  
  
## Sample Details  
 In this sample, the client is the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] test client and the service is hosted in IIS.  
  
> [!NOTE]
>  The setup and build instructions for this sample are located at the end of this topic.  
  
### Activation of services without requiring a .svc file  
 In [!INCLUDE[netfx35_short](../../../../includes/netfx35-short-md.md)], a .svc file was required for activating a service. This caused additional management overhead, because an additional file was required to be deployed and maintained along with the application. With the release of [!INCLUDE[netfx40_long](../../../../includes/netfx40-long-md.md)], the activation components can be configured using the application configuration file.  
  
 [!INCLUDE[netfx40_short](../../../../includes/netfx40-short-md.md)] introduces a new configuration element (<xref:System.ServiceModel.Configuration.ServiceActivationElement>), in the <xref:System.ServiceModel.Configuration.ServiceHostingEnvironmentSection> of the application configuration file. The <xref:System.ServiceModel.Configuration.ServiceHostingEnvironmentSection> collection accepts a collection of services to activate, as shown in the following code example.  
  
```xml  
<serviceActivations>  
   <add relativeAddress="Calculator.svc" service="Microsoft.ServiceModel.Samples.CalculatorService" />  
  
<serviceActivations>  
```  
  
 The observation to make is the configuration looks very similar to the configuration of .svc files. An additional attribute that is introduced is the `relativeAddress` that provides the address of the service. The relative address is also the virtual path for the service. The host retrieves the Web.config file of the file from the `virtualPath` location, if present; otherwise the host searches its parent folder recursively.  
  
> [!NOTE]
>  This sample requires hosting in IIS to function.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], open the Service.csproj file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  Test the service by running WCFTestClient.exe.  
  
4.  Using [!INCLUDE[fileExplorer](../../../../includes/fileexplorer-md.md)], navigate to the %SystemDrive%\Program Files\Microsoft Visual Studio 10.0\Common7\IDE folder.  
  
5.  Run WcfTestClient.exe.  
  
6.  Set the MEX address of the service.  
  
7.  Press CTRL+SHIFT+A to set the service address.  
  
8.  Set the address to http://localhost/ServiceModelSamples/Calculator.svc.  
  
9. Perform the `Add` operation. Set value on the `n1` parameter to 10 and set value on the `n2` parameter to 15.  
  
10. Press **Invoke**.  
  
     The expected result is 25.  
  
#### To set up, build, and run the sample  
  
1.  Be sure you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  After the solution has been built, run Setup.bat to set up the ServiceModelSamples Application in IIS. The ServiceModelSamples directory should now appear as an IIS Application.  
  
4.  To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
## See Also  
 [AppFabric Hosting and Persistence Samples](http://go.microsoft.com/fwlink/?LinkId=193961)
