---
title: "WCF Analytic Tracing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6029c7c7-3515-4d36-9d43-13e8f4971790
caps.latest.revision: 21
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Analytic Tracing
This sample demonstrates how to add your own tracing events into the stream of analytic traces that [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] writes to ETW in [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)]. Analytic traces are meant to make it easy to get visibility into your services without paying a high performance penalty. This sample shows how to use the <xref:System.Diagnostics.Eventing?displayProperty=nameWithType> APIs to write events that integrate with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the <xref:System.Diagnostics.Eventing?displayProperty=nameWithType> APIs, see <xref:System.Diagnostics.Eventing?displayProperty=nameWithType>.  
  
 To learn more about event tracing in Windows, see [Improve Debugging and Performance Tuning with ETW](http://go.microsoft.com/fwlink/?LinkId=166488).  
  
## Disposing EventProvider  
 This sample uses the <xref:System.Diagnostics.Eventing.EventProvider?displayProperty=nameWithType> class, which implements <xref:System.IDisposable?displayProperty=nameWithType>. When implementing tracing for a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service, it is likely that you may use the <xref:System.Diagnostics.Eventing.EventProvider>’s resources for the lifetime of the service. For this reason, and for readability, this sample never disposes of the wrapped <xref:System.Diagnostics.Eventing.EventProvider>. If for some reason your service has different requirements for tracing and you must dispose of this resource, then you should modify this sample in accordance with the best practices for disposing of unmanaged resources. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] disposing unmanaged resources, see [Implementing a Dispose Method](http://go.microsoft.com/fwlink/?LinkId=166436).  
  
## Self-Hosting vs. Web Hosting  
 For Web-hosted services, WCF’s analytic traces provide a field, called "HostReference", which is used to identify the service that is emitting the traces. The extensible user traces can participate in this model and this sample demonstrates best practices for doing so. The format of a Web host reference when the pipe ‘&#124;’ character actually appears in the resulting string can be any one of the following:  
  
-   If the application is not at the root.  
  
     \<SiteName>\<ApplicationVirtualPath>&#124;\<ServiceVirtualPath>&#124;\<ServiceName>  
  
-   If the application is at the root.  
  
     \<SiteName>&#124;\<ServiceVirtualPath>&#124;\<ServiceName>  
  
 For self-hosted services, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]’s analytic traces do not populate the "HostReference" field. The `WCFUserEventProvider` class in this sample behaves consistently when used by a self-hosted service.  
  
## Custom Event Details  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]’s ETW Event Provider manifest defines three events that are designed to be emitted by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service authors from within service code. The following table shows a breakdown of the three events.  
  
|Event|Description|Event ID|  
|-----------|-----------------|--------------|  
|UserDefinedInformationEventOccurred|Emit this event when something of note happens in your service that is not a problem. For example, you might emit an event after successfully making a call to a database.|301|  
|UserDefinedWarningOccurred|Emit this event when a problem occurs that may result in a failure in the future. For example, you may emit a warning event when a call to a database fails but you were able to recover by falling back to a redundant data store.|302|  
|UserDefinedErrorOccurred|Emit this event when your service fails to behave as expected. For example, you might emit an event if a call to a database fails and you could not retrieve the data from elsewhere.|303|  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)], open the WCFAnalyticTracingExtensibility.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press CTRL+F5.  
  
     In the Web browser, click **Calculator.svc**. The URI of the WSDL document for the service should appear in the browser. Copy that URI.  
  
4.  Run the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] test client (WcfTestClient.exe).  
  
     The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] test client (WcfTestClient.exe) is located in the \<[!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Install Dir>\Common7\IDE\ WcfTestClient.exe (default [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] install dir is C:\Program Files\Microsoft Visual Studio 10.0).  
  
5.  Within the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] test client, add the service by selecting **File**, and then **Add Service**.  
  
     Add the endpoint address in the input box.  
  
6.  Click **OK** to close the dialog.  
  
     The ICalculator service is added in the left pane under **My Service Projects**.  
  
7.  Open the Event Viewer application.  
  
     Before invoking the service, start Event Viewer and ensure that the event log is listening for tracking events emitted from the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
8.  From the **Start** menu, select **Administrative Tools**, and then **Event Viewer**. Enable the **Analytic** and **Debug** logs.  
  
9. In the tree view in Event Viewer, navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, and then **Application Server-Applications**. Right-click **Application Server-Applications**, select **View**, and then **Show Analytic and Debug Logs**.  
  
     Ensure that the **Show Analytic and Debug Logs** option is checked. Enable the **Analytic** log.  
  
     In the tree view in Event Viewer, navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**, and then **Analytic**. Right-click **Analytic** and select **Enable Log**.  
  
10. Test the service using the WCF Test Client.  
  
    1.  In the WCF Test Client, double-click **Add()** under the ICalculator service node.  
  
         The **Add()** method appears in the right pane with two parameters.  
  
    2.  Type in 2 for the first parameter and 3 for the second parameter.  
  
    3.  Click **Invoke** to invoke the method.  
  
11. Go to the **Event Viewer** window that you have already opened. Navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**.  
  
12. Right-click the **Analytic** node and select **Refresh**.  
  
     The events appear in the right pane.  
  
13. Locate the event with the ID of 303 and double-click it to open it up and inspect its contents.  
  
     This event was emitted by the `Add()` method of the ICalculator service and has a payload equal to "2+3=5".  
  
#### To clean up (Optional)  
  
1.  Open **Event Viewer**.  
  
2.  Navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, and then **Application-Server-Applications**. Right-click **Analytic** and select **Disable Log**.  
  
3.  Navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application-Server-Applications**, and then **Analytic**. Right-click **Analytic** and select **Clear Log**.  
  
4.  Click **Clear** to clear the events.  
  
## Known Issue  
 There is a known issue in the **Event Viewer** where it may fail to decode ETW events. You may see an error message that says: "The description for Event ID \<id> from source Microsoft-Windows-Application Server-Applications cannot be found. Either the component that raises this event is not installed on your local computer or the installation is corrupted. You can install or repair the component on the local computer." If you encounter this error, select **Refresh** from the **Actions** menu. The event should then decode properly.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Management\ETWTrace`  
  
## See Also  
 [AppFabric Monitoring Samples](http://go.microsoft.com/fwlink/?LinkId=193959)
