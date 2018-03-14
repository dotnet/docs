---
title: "Tracking Events into Event Tracing in Windows"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f812659b-0943-45ff-9430-4defa733182b
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Tracking Events into Event Tracing in Windows
This sample demonstrates how to enable [!INCLUDE[wf](../../../../includes/wf-md.md)] tracking on a workflow service and emit the tracking events in Event Tracing for Windows (ETW). To emit workflow tracking records into ETW, the sample uses the ETW tracking participant (<xref:System.Activities.Tracking.EtwTrackingParticipant>).  
  
 The workflow in the sample receives a request, assigns the reciprocal of the input data to the input variable and returns the reciprocal back to the client. When the input data is 0, a divide by zero exception occurs that is unhandled that causes the workflow to abort. With tracking enabled, the error track record is emitted to ETW, which can help troubleshoot the error later. The ETW tracking participant is configured with a tracking profile to subscribe to tracking records. The tracking profile is defined in the Web.config file and provided as a configuration parameter to the ETW tracking participant. The ETW tracking participant is configured in the Web.config file of the workflow service and is applied to the service as a service behavior. In this sample, you view the tracking events in the event log using Event Viewer.  
  
## Workflow Tracking Details  
 [!INCLUDE[wf2](../../../../includes/wf2-md.md)] provides a tracking infrastructure to track the execution of a workflow instance. The tracking runtime creates a workflow instance to emit events related to the workflow lifecycle, events from workflow activities and custom events. The following table details the primary components of the tracking infrastructure.  
  
|Component|Description|  
|---------------|-----------------|  
|Tracking runtime|Provides the infrastructure to emit tracking records.|  
|Tracking participants|Accesses the tracking records. [!INCLUDE[netfx_current_short](../../../../includes/netfx-current-short-md.md)] ships with a tracking participant that writes tracking records as Event Tracing for Windows (ETW) events.|  
|Tracking profile|A filtering mechanism that allows a tracking participant to subscribe for a subset of the tracking records emitted from a workflow instance.|  
  
 The following table details the tracking records that the workflow runtime emits.  
  
|Tracking record|Description|  
|---------------------|-----------------|  
|Workflow instance tracking records.|Describes the lifecycle of the workflow instance. For example, an instance record is emitted when the workflow starts or completes.|  
|Activity state tracking records.|Details activity execution. These records indicate the state of a workflow activity such as when an activity is scheduled or when the activity completes or when a fault is thrown.|  
|Bookmark resumption record.|Emitted whenever a bookmark within a workflow instance is resumed.|  
|Custom tracking records.|A workflow author can create custom tracking records and emit them within the custom activity.|  
|<xref:System.Activities.Tracking.ActivityScheduledRecord>|This record is emitted when an activity schedules another activity.|  
|<xref:System.Activities.Tracking.FaultPropagationRecord>|This record is emitted when a fault is propagated from an activity.|  
|<xref:System.Activities.Tracking.CancelRequestedRecord>|This record is emitted when an activity is canceled by another activity.|  
  
 The tracking participant subscribes for a subset of the emitted tracking records using tracking profiles. A tracking profile contains tracking queries that allow subscribing for a particular tracking record type. Tracking profiles can be specified in code or in configuration.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the EtwTrackingParticipantSample.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press F5.  
  
     By default, the service is listening on port 53797 (http://localhost:53797/SampleWorkflowService.xamlx).  
  
4.  Using [!INCLUDE[fileExplorer](../../../../includes/fileexplorer-md.md)], open the WCF test client.  
  
     The WCF test client (WcfTestClient.exe) is located in the \<[!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] installation folder>\Common7\IDE\ folder.  
  
     The default [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] installation folder is C:\Program Files\Microsoft Visual Studio 10.0.  
  
5.  In WCF test client, select **Add Service** from the **File** menu.  
  
     Add the endpoint address in the input box. The default is http://localhost:53797/SampleWorkflowService.xamlx.  
  
6.  Open the Event Viewer application.  
  
     Before invoking the service, start Event Viewer from the **Start** menu, select **Run** and type in `eventvwr.exe`. Ensure that the event log is listening for tracking events emitted from the workflow service.  
  
7.  In the tree view of the Event Viewer, navigate to **Event Viewer**, **Applications and Services Logs**, and **Microsoft**. Right-click **Microsoft** and select **View** and then **Show Analytic and Debug Logs** to enable the analytic and debug logs  
  
     Ensure that the **Show Analytic and Debug Logs** option is checked.  
  
8.  In the tree view in Event Viewer, navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**. Right-click **Analytic** and select **Enable Log** to enable the **Analytic** log.  
  
9. Test the service using the WCF test client by double-clicking `GetData`.  
  
     This opens the `GetData` method. The request accepts one parameter and ensures that the value is 0, which is the default.  
  
     Click **Invoke**.  
  
10. Observe the events emitted from the workflow.  
  
     Switch back to Event Viewer and navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**. Right-click **Analytic** and select **Refresh**.  
  
     The workflow events are displayed in the event viewer. Notice that workflow execution events are displayed and that one of them is an unhandled exception that corresponds to the error in workflow. Also, a warning event is emitted from the workflow activity, which indicates that the activity is throwing a fault.  
  
11. Repeat steps 9 and 10 with an input of data other than 0, so that no error is thrown.  
  
 Tracking profiles allow you to subscribe to events that are emitted by the runtime when the state of a workflow instance changes. Depending on your monitoring requirements, you can create a profile that is very coarse, which subscribes to a small set of high-level state changes on a workflow. On the other hand, you can create a very precise profile whose output is rich enough to reconstruct the execution later. The sample demonstrates the events emitted from the workflow runtime to ETW using the `HealthMonitoring Tracking Profile`, which emits a small set of events. A different profile that emits more workflow tracking events is also provided in the Web.config that is named `Troubleshooting Tracking Profile`. When the [!INCLUDE[netfx_current_short](../../../../includes/netfx-current-short-md.md)] is installed, a default profile with an empty name is configured in the Machine.config file. This profile is used by the ETW tracking behavior configuration when no profile name or an empty profile name is specified.  
  
 The health monitoring tracking profile emits workflow instance records and activity fault propagation records. This profile is created by adding the following tracking profile to a Web.config configuration file.  
  
```xml  
<<tracking>  
      <profiles>  
        <trackingProfile name="HealthMonitoring Tracking Profile">  
          <workflow activityDefinitionId="*">  
            <workflowInstanceQueries>  
              <workflowInstanceQuery>  
                <states>  
                  <state name="Started"/>  
                  <state name="Completed"/>  
                  <state name="Aborted"/>  
                  <state name="UnhandledException"/>  
                </states>  
            </workflowInstanceQuery>  
           </workflowInstanceQueries>  
            <faultPropagationQueries>  
              <faultPropagationQuery faultSourceActivityName ="*" faultHandlerActivityName="*"/>  
            </faultPropagationQueries>  
          </workflow>  
        </trackingProfile>  
       </profiles>  
</tracking>  
```  
  
 The profile can be changed by changing the `EtwTrackingParticipant` configuration to the following.  
  
```xml  
<behaviors>  
      <serviceBehaviors>  
        <behavior>  
          <etwTracking profileName="HealthMonitoring Tracking Profile"/>  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
```  
  
#### To clean up (Optional)  
  
1.  Open Event Viewer.  
  
2.  Navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**. Right-click **Analytic** and select **Disable Log**.  
  
3.  Navigate to **Event Viewer**, **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**. Right-click **Analytic** and select **Clear Log**.  
  
4.  Choose the **Clear** option to clear the events.  
  
## Known Issue  
  
> [!NOTE]
>  There is a known issue in the Event Viewer where it may fail to decode ETW events. You may see an error message that looks like the following.  
>   
>  The description for Event ID \<id> from source Microsoft-Windows-Application Server-Applications cannot be found. Either the component that raises this event is not installed on your local computer or the installation is corrupted. You can install or repair the component on the local computer.  
>   
>  If you encounter this error, click refresh in the actions pane. The event should now decode properly.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Tracking\EtwTracking`  
  
## See Also  
 [AppFabric Monitoring Samples](http://go.microsoft.com/fwlink/?LinkId=193959)
