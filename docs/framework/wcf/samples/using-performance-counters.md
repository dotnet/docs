---
title: "Using Performance Counters"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 00a787af-1876-473c-a48d-f52b51e28a3f
caps.latest.revision: 31
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using Performance Counters
This sample demonstrates how to access [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] performance counters and how to create user-defined performance counters. This sample is based on the [Getting Started](../../../../docs/framework/wcf/samples/getting-started-sample.md).  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
 In this sample, the client calls the four methods of the `ICalculator` service. The client continues to do this until it is interrupted by the user. The service remains unchanged.  
  
 Performance counters are enabled in the diagnostics section of the Web.config file for the service, as shown in the following sample configuration.  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <diagnostics performanceCounters="All" />   
  </system.serviceModel>  
</configuration>  
```  
  
 This task can also be done using the [Configuration Editor Tool (SvcConfigEditor.exe)](../../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md).  
  
 When performance counters are enabled, the entire suite of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] performance counters is enabled for the service. The .NET Framework automatically maintains performance data at three levels: `ServiceModelService`, `ServiceModelEndpoint` and `ServiceModelOperation`. Each of these levels has performance counters such as "Calls", "Calls per Second", and "Security Calls Not Authorized".  
  
### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
### To view performance data  
  
1.  Start the Performance Monitor Tool by clicking **Start**, **Run…**, enter `perfmon` and click **OK,** or from Control Panel, select **Administrative Tools** and double-click **Performance**.  
  
    > [!NOTE]
    >  You cannot add counters until the sample code is running.  
  
2.  Remove the performance counters that are listed by selecting them and pressing the Delete key.  
  
3.  Add [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] counters by right-clicking the graph pane and selecting **Add Counters**. In the **Add Counters** dialog box, select **ServiceModelOperation 3.0.0.0, ServiceModelEndpoint 3.0.0.0, or ServiceModelService 3.0.0.0** in the Performance object drop down list box. Select the counters you want to view from the list.  
  
    > [!NOTE]
    >  There are no [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] performance counters for a service if there are no [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services running on the computer.  
  
### To use the Configuration Editor to enable counters  
  
1.  Open an instance of the SvcConfigEditor.exe.  
  
2.  On the File menu, click **Open** and then click **Config file…**.  
  
3.  Navigate to the sample application's service folder and open the Web.config file.  
  
4.  Click **Diagnostics** on the Configuration tree.  
  
5.  Toggle **Performance Counter** in the **Diagnostics** window to show 'All'.  
  
6.  Save the configuration file and exit the editor.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Management\PerfCounters`  
  
## See Also  
 [AppFabric Monitoring Samples](http://go.microsoft.com/fwlink/?LinkId=193959)
