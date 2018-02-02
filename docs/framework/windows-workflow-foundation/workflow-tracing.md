---
title: "Workflow Tracing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 18737989-0502-4367-b5f6-617ebfb77c96
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Workflow Tracing
Workflow tracing offers a way to capture diagnostic information using .NET Framework trace listeners. Tracing can be enabled if a problem is detected with the application and then disabled again once the problem is resolved. There are two ways you could enable debug tracing for workflows. You can configure it using the Event Trace viewer or you can use <xref:System.Diagnostics> to send trace events to a file.  
  
## Enabling Debug Tracing in ETW  
 To enable tracing using ETW, enable the Debug channel in Event Viewer:  
  
1.  Navigate to analytic and debug logs node in Event Viewer.  
  
2.  In the tree view in Event Viewer, navigate to **Event Viewer->Applications and Services Logs->Microsoft->Windows->Application Server-Applications**. Right-click **Application Server-Applications** and select **View->Show Analytic and Debug Logs**. Right-click **Debug** and select **Enable Log**.  
  
3.  When a workflow runs the debug and traces are emitted to ETW debug channel, they can be viewed in the Event Viewer. Navigate to **Event Viewer->Applications and Services Logs->Microsoft->Windows->Application Server-Applications**. Right-click **Debug** and select **Refresh**.  
  
4.  The default analytic trace buffer size is only 4 kilobytes (KB); it is recommended to increase the size to 32 KB. To do this, perform the following steps.  
  
    1.  Execute the following command in the current framework directory (for example, C:\Windows\Microsoft.NET\Framework\v4.0.21203): `wevtutil um Microsoft.Windows.ApplicationServer.Applications.man`  
  
    2.  Change the \<bufferSize> value in the Windows.ApplicationServer.Applications.man file to 32.  
  
        ```xml  
        <channel name="Microsoft-Windows-Application Server-Applications/Analytic" chid="ANALYTIC_CHANNEL" symbol="ANALYTIC_CHANNEL" type="Analytic" enabled="false" isolation="Application" message="$(string.MICROSOFT_WINDOWS_APPLICATIONSERVER_APPLICATIONS.channel.ANALYTIC_CHANNEL.message)" >  
                    <publishing>  
                      <bufferSize>32</bufferSize>  
                    </publishing>  
                  </channel>  
        ```  
  
    3.  Execute the following command in the current framework directory (for example, C:\Windows\Microsoft.NET\Framework\v4.0.21203): `wevtutil im Microsoft.Windows.ApplicationServer.Applications.man`  
  
> [!NOTE]
>  If you are using the .NET Framework 4 Client Profile, you must first register the ETW manifest by running the following command from the .NET Framework 4 directory: `ServiceModelReg.exe –i –c:etw`  
  
## Enabling Debug Tracing using System.Diagnostics  
 These listeners can be configured in the App.config file of the workflow application, or the Web.config for a workflow service. In this example, a [TextWriterTraceListener](http://go.microsoft.com/fwlink/?LinkId=165424) is configured to save tracing information to the MyTraceLog.txt file in the current directory.  
  
```xml  
<configuration>  
  <system.diagnostics>  
    <sources>  
      <source name="System.Activities" switchValue="Information">  
        <listeners>  
          <add name="textListener" />  
          <remove name="Default" />  
        </listeners>  
      </source>  
    </sources>  
    <sharedListeners>  
      <add name="textListener"  
           type="System.Diagnostics.TextWriterTraceListener"  
           initializeData="MyTraceLog.txt"  
           traceOutputOptions="ProcessId, DateTime" />  
    </sharedListeners>  
    <trace autoflush="true" indentsize="4">  
      <listeners>  
        <add name="textListener" />  
      </listeners>  
    </trace>  
  </system.diagnostics>  
</configuration>  
```  
  
## See Also  
 [Windows Server App Fabric Monitoring](http://go.microsoft.com/fwlink/?LinkId=201273)  
 [Monitoring Applications with App Fabric](http://go.microsoft.com/fwlink/?LinkId=201275)
