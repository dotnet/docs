---
title: "Extract WF Data using Tracking"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e30c68f5-8c6a-495a-bd20-667a4364c68e
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Extract WF Data using Tracking
This sample demonstrates how to use workflow tracking to extract workflow variables and arguments from activities. It also shows the addition of annotations to tracking records and the extraction of data payload within custom tracking records. The sample uses the Event Tracing for Windows (ETW) tracking participant to extract data from the workflow.  
  
## Sample Details  
 [!INCLUDE[wf](../../../../includes/wf-md.md)] provides tracking to gain visibility into the execution of a workflow instance. The tracking runtime emits workflow tracking records during the execution of the workflow. Along with the workflow tracking records, data within the workflow instance can be extracted from the workflow. The following list details the types of data that can be extracted from tracking records:  
  
1.  Workflow variables within an activity and tracking records during activity execution.  
  
     To extract workflow variables, the variables to be extracted are specified in a profile. Variables to be extracted can only be specified with `ActivityStateQueries`. The following code example demonstrates a tracking profile used to extract the workflow variable from an activity.  
  
    ```xml  
    <activityStateQuery activityName="StockPriceService">  
         <states>  
              <state name="Closed"/>  
         </states>  
         <variables>  
              <variable name="symbol"/>  
         </variables>  
    </activityStateQuery>  
    ```  
  
2.  Activity arguments and activity state tracking records.  
  
     Arguments define the way data flows in or out of an activity. Arguments to be extracted are specified using an <xref:System.Activities.Tracking.ActivityStateQuery>.The following code example is a tracking profile that extracts the `Value` argument.  
  
    ```xml  
    <activityStateQuery activityName="GetStockPrice">  
         <states>  
              <state name="Closed"/>  
         </states>  
         <arguments>  
              <argument name="Value"/>  
         </arguments>  
    </activityStateQuery>  
    ```  
  
3.  Annotations are key/value pairs that can be added to any tracking record that is emitted.  
  
     Annotations serve as a tagging mechanism for tracking records. Annotations are added to tracking records through a tracking profile. Annotations can be added to any type of a workflow tracking query. The following code example is a tracking profile that shows how an annotation can be added to a tracking record.  
  
    ```xml  
    <workflowInstanceQuery>  
         <states>  
              <state name="Started"/>  
         </states>  
         <annotations>  
              <annotation name="StockPriceWorkflow" value="Begin"/>  
         </annotations>  
    </workflowInstanceQuery>  
    ```  
  
4.  Custom tracking records are emitted from user-defined activities.  
  
     Custom tracking records can carry payload data defined within this activity. Subscribing for custom tracking records in a tracking profile allows the extraction of the payload within the tracking record. The custom tracking records can be extracted with custom a <xref:System.Activities.Tracking.TrackingQuery>. The following code example is a tracking profile that extracts a custom tracking record along with its payload.  
  
    ```xml  
    <customTrackingQuery name="QuoteLookupEvent" activityName="GetStockPrice"/>  
    ```  
  
 The sample demonstrates the extraction of a variables, arguments, custom records and adding annotations using a profile specified in a Web.config. Tracking is enabled on the sample workflow service by adding an `<etwTracking>` behavior element. The following code example enables tracking for the `ExtractWorkflowVariables` tracking profile.  
  
```xml  
<serviceBehaviors>  
     <behavior>  
               <etwTracking profileName="ExtractWorkflowVariables"/>  
     </behavior>  
</serviceBehaviors>  
```  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the WFStockPriceApplication.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press F5.  
  
     The browser window opens and shows the directory listing for the application.  
  
4.  In the browser, click StockPriceService.xamlx.  
  
5.  The browser displays the StockPriceService page, which contains the local service WSDL address. Copy this address.  
  
     The following example shows a local service WSDL address. `http://localhost:53797/StockPriceService.xamlx?wsdl`  
  
6.  Before invoking the service, start Event Viewer and ensure that the event log is listening for tracking events emitted from the workflow service.  
  
7.  From the **Start** menu, select **Administrative Tools** and then **Event Viewer**.  
  
8.  In the tree view in Event Viewer, navigate to **Event Viewer**, **Applications and Services Logs**, and **Microsoft**. Right-click **Microsoft** and select **View** and then **Show Analytic and Debug Logs**.  
  
     Ensure that the **Show Analytic and Debug Logs** option is checked.  
  
9. In the tree view in Event Viewer, navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**. Right-click **Analytic** and select **Enable Log**.  
  
10. Using [!INCLUDE[fileExplorer](../../../../includes/fileexplorer-md.md)], open the WCF test client.  
  
     The WCF test client (WcfTestClient.exe) is located in the \<[!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] installation folder>\Common7\IDE\ folder.  
  
     The default [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] installation folder is C:\Program Files\Microsoft Visual Studio 10.0.  
  
11. In WCF test client, select **Add Service** from the **File** menu.  
  
     Add the local service WSDL address you copied earlier in the input box.  
  
12. In WCF test client, double-click `GetStockPrice`.  
  
     This opens the `GetStockPrice` method. The request accepts one parameter. Use the value **Contoso**.  
  
13. Click **Invoke**.  
  
14. Switch back to Event Viewer and navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**. Right-click **Analytic** and select **Refresh**. The workflow events are in the event ID ranges 100-199.  
  
     The events contain the annotations, variables, arguments and custom tracking records that can be viewed in the event viewer.  
  
## Cleaning up in the Event Viewer  
 The analytic channel in the event log can be cleaned up in the Event Viewer by doing the following.  
  
#### To clean up (Optional)  
  
1.  Open Event Viewer.  
  
2.  Navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**. Right-click **Analytic** and select **Disable Log**.  
  
3.  Navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**. Right-click **Analytic** and select **Clear Log**.  
  
     Choose the **Clear** option to clear the events.  
  
## Known Issue  
  
> [!NOTE]
>  There is a known issue in the Event Viewer where it may fail to decode ETW events. You may see an error message that looks like the following.  
>   
>  `The description for Event ID <id> from source Microsoft-Windows-Application Server-Applications cannot be found. Either the component that raises this event is not installed on your local computer or the installation is corrupted. You can install or repair the component on the local computer.`  
>   
>  If you encounter this error, click **Refresh** in the actions pane. The event should now decode properly.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Tracking\ExtractWfData`  
  
## See Also  
 [AppFabric Monitoring Samples](http://go.microsoft.com/fwlink/?LinkId=193959)
