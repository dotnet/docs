---
title: "ETW Tracing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ac99a063-e2d2-40cc-b659-d23c2f783f92
caps.latest.revision: 42
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ETW Tracing
This sample demonstrates how to implement End-to-End (E2E) tracing using Event Tracing for Windows (ETW) and the `ETWTraceListener` that is provided with this sample. The sample is based on the [Getting Started](../../../../docs/framework/wcf/samples/getting-started-sample.md) and includes ETW tracing.  
  
> [!NOTE]
>  The set-up procedure and build instructions for this sample are located at the end of this topic.  
  
 This sample assumes that you are familiar with [Tracing and Message Logging](../../../../docs/framework/wcf/samples/tracing-and-message-logging.md).  
  
 Each trace source in the <xref:System.Diagnostics> tracing model can have multiple trace listeners that determine where and how the data is traced. The type of listener defines the format in which trace data is logged. The following code sample shows how to add the listener to configuration.  
  
```xml  
<system.diagnostics>  
    <sources>  
        <source name="System.ServiceModel"   
             switchValue="Verbose,ActivityTracing"  
             propagateActivity="true">  
            <listeners>  
                <add type=  
                   "System.Diagnostics.DefaultTraceListener"  
                   name="Default">  
                   <filter type="" />  
                </add>  
                <add name="ETW">  
                    <filter type="" />  
                </add>  
            </listeners>  
        </source>  
    </sources>  
    <sharedListeners>  
        <add type=  
            "Microsoft.ServiceModel.Samples.EtwTraceListener, ETWTraceListener"  
            name="ETW" traceOutputOptions="Timestamp">  
            <filter type="" />  
       </add>  
    </sharedListeners>  
</system.diagnostics>  
```  
  
 Before using this listener, an ETW Trace Session must be started. This session can be started by using Logman.exe or Tracelog.exe. A SetupETW.bat file is included with this sample so that you can set up the ETW Trace Session along with a CleanupETW.bat file for closing the session and completing the log file.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic. For more information about these tools, see [http://go.microsoft.com/fwlink/?LinkId=56580](http://go.microsoft.com/fwlink/?LinkId=56580)  
  
 When using the ETWTraceListener, traces are logged in binary .etl files. With ServiceModel tracing turned on, all generated traces appear in the same file. Use [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md) for viewing .etl and .svclog log files. The viewer creates an end-to-end view of the system that makes it possible to trace a message from its source to its destination and point of consumption.  
  
 The ETW Trace Listener supports circular logging. To enable this feature, go to **Start**, **Run** and type `cmd` to start a command console. In the following command, replace the `<logfilename>` parameter with the name of your log file.  
  
```  
logman create trace Wcf -o <logfilename> -p "{411a0819-c24b-428c-83e2-26b41091702e}" -f bincirc -max 1000  
```  
  
 The `-f` and `-max` switches are optional. They specify the binary circular format and max log size of 1000MB respectively. The `-p` switch is used to specify the trace provider. In our example, `"{411a0819-c24b-428c-83e2-26b41091702e}"` is the GUID for "XML ETW Sample Provider".  
  
 To start the session, type in the following command.  
  
```  
Logman start Wcf  
```  
  
 After you have finished logging, you can stop the session with the following command.  
  
```  
Logman stop Wcf  
```  
  
 This process generates binary circular logs that you can process with your tool of choice, including [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md) or Tracerpt.  
  
 You can also review the [Circular Tracing](../../../../docs/framework/wcf/samples/circular-tracing.md) sample for more information on an alternative listener to perform circular logging.  
  
### To set up, build, and run the sample  
  
1.  Be sure you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
    > [!NOTE]
    >  To use the RegisterProvider.bat, SetupETW.bat and CleanupETW.bat commands, you must run under a local administrator account. If you are using [!INCLUDE[wv](../../../../includes/wv-md.md)] or later, you must also run the command prompt with elevated privileges. To do so, right-click the command prompt icon, then click **Run as administrator**.  
  
3.  Before running the sample, run RegisterProvider.bat on the client and server. This sets up the resulting ETWTracingSampleLog.etl file to generate traces that can be read by the Service Trace Viewer. This file can be found in the C:\logs folder. If this folder does not exist, it must be created or no traces are generated. Then, run SetupETW.bat on the client and server computers to begin the ETW Trace Session. The SetupETW.bat file can be found under the CS\Client folder.  
  
4.  To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
5.  When the sample is completed, run CleanupETW.bat to complete the creation of the ETWTracingSampleLog.etl file.  
  
6.  Open the ETWTracingSampleLog.etl file from within the Service Trace Viewer. You will be prompted to save the binary formatted file as a .svclog file.  
  
7.  Open the newly created .svclog file from within the Service Trace Viewer to view the ETW and ServiceModel traces.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Management\AnalyticTrace`  
  
## See Also  
 [AppFabric Monitoring Samples](http://go.microsoft.com/fwlink/?LinkId=193959)
