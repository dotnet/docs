---
title: "Tracking Using a Text File"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 56a82682-73c2-4b91-a206-4d8bb12c561b
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Tracking Using a Text File
This sample demonstrates how to extend tracking in [!INCLUDE[wf](../../../../includes/wf-md.md)] by creating a custom tracking participant. Tracking participants are .NET Framework classes that receive tracking records from the runtime as they are emitted. You can create a tracking participant to transport the tracking events to whichever destination is required for your scenario. For example, ETW (Event Tracing for Windows) Tracking Participant is provided as part of the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)]. The tracking participant in this sample writes the records in XML format to a text file.  
  
## Sample details  
 To optimize the usefulness and robustness of your tracking participant, some additional steps must be completed to properly wire the tracking participant to the runtime. The following table describes the classes used in this sample to create a tracking participant that complies with best practices.  
  
|Class|Description|  
|-----------|-----------------|  
|`TextFileTrackingExtensionElement`|A <xref:System.ServiceModel.Configuration.BehaviorExtensionElement> is used to define the configuration section used to configure the text file tracking participant. This allows users to specify the destination of the log file using standard .NET Framework configuration files.|  
|`TextFileTrackingBehavior`|Behaviors in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] allow users to inject extensions into the runtime. This behavior adds the tracking participant to the service when the service starts.|  
|`TextFileTrackingParticipant`|The tracking participant that receives tracking participants at runtime and stores them to a log file as XML.|  
  
## Behavior Extension Elements Configuration  
 One more step is required to make use of the behavior extension element previously described using .NET Framework configuration files. The following configuration must be placed in configuration files where the extension is to be used.  
  
```xml  
<system.serviceModel>  
    <extensions>  
      <behaviorExtensions>  
        <add name="textFileTracking" type="Microsoft.Samples.TextFileTracking.TextFileTrackingExtensionElement, WFStockPriceApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />  
      </behaviorExtensions>  
    </extensions>  
…  
  </system.serviceModel>  
```  
  
> [!NOTE]
>  See the Web.config file in the sample for a complete example usage of behavior extension elements configuration.  
  
## Custom Tracking Records  
 The GetStockPrices.cs file demonstrates how to create custom tracking records from within a <xref:System.Activities.CodeActivity>. Look for this record when running the sample.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the WFStockPriceApplication.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press CTRL+F5.  
  
     The browser window opens and shows the directory listing for the application.  
  
4.  In the browser, click StockPriceService.xamlx.  
  
5.  The browser displays the **StockPriceService** page, which contains the local service wsdl address. Copy this address.  
  
     An example of the local service wsdl address is http://localhost:53797/StockPriceService.xamlx?wsdl.  
  
6.  Using [!INCLUDE[fileExplorer](../../../../includes/fileexplorer-md.md)], go to your [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] folder (the default installation folder is %SystemDrive%\Program Files\Microsoft Visual Studio 10.0). Then locate the Common7\IDE\ subfolder.  
  
7.  Double-click the WcfTestClient.exe file to launch the WCF Test Client.  
  
8.  In the WCF Test Client, select **Add Service…** from the **File** menu.  
  
9. Paste the URL you just copied into the text box.  
  
10. Click **OK** to close the dialog.  
  
11. Test the service using the WCF Test Client.  
  
    1.  In the WCF Test Client, double-click **GetStockPrice()** under the **IStockPriceService** node.  
  
         The **GetStockPrice()** method appears in the right pane, with one parameter.  
  
    2.  Type in Contoso as the value for the parameter.  
  
    3.  Click **Invoke**.  
  
12. See the tracked events in the log file located in your application data directory at %APPDATA%\trackingRecords.log.  
  
    > [!NOTE]
    >  The %APPDATA% is an environment variable that resolves to %SystemDrive%\Users\\<username\>\AppData\Roaming in [!INCLUDE[wv](../../../../includes/wv-md.md)], [!INCLUDE[lserver](../../../../includes/lserver-md.md)], or Windows Server 2008.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Tracking\TextFileTracking`  
  
## See Also  
 [AppFabric Monitoring Samples](http://go.microsoft.com/fwlink/?LinkId=193959)
