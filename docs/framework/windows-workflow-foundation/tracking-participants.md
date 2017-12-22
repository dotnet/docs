---
title: "Tracking Participants"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f13e360c-eeb7-4a49-98a0-8f6a52d64f68
caps.latest.revision: 24
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Tracking Participants
Tracking participants are extensibility points that allow a workflow developer to access <xref:System.Activities.Tracking.InteropTrackingRecord.TrackingRecord%2A> objects and process them. [!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] includes a standard tracking participant that writes tracking records as Event Tracing for Windows (ETW) events. If that does not meet your requirements, you can also write a custom tracking participant.  
  
## Tracking Participants  
 The tracking infrastructure allows the application of a filter on the outgoing tracking records such that a participant can subscribe to a subset of the records. The mechanism to apply a filter is through a tracking profile.  
  
 [!INCLUDE[wf](../../../includes/wf-md.md)] in [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] provides a tracking participant that writes the tracking records to an ETW session. The participant is configured on a workflow service by adding a tracking-specific behavior in a configuration file. Enabling an ETW tracking participant allows tracking records to be viewed in the event viewer. The SDK sample for ETW-based tracking is a good way to get familiar with WF tracking using the ETW-based tracking participant.  
  
## ETW Tracking Participant  
 [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] includes an ETW Tracking Participant that writes the tracking records to an ETW session. This is done in a very efficient manner with minimal impact to the application’s performance or to the server’s throughput. An advantage of using the standard ETW tracking participant is that the tracking records it receives can be viewed with the other application and system logs in the Windows Event Viewer.  
  
 The standard ETW tracking participant is configured in the Web.config file as shown in the following example.  
  
```xml  
<configuration>  
  <system.web>  
    <compilation debug="true" targetFramework="4.0" />  
  </system.web>  
  <system.serviceModel>  
    <behaviors>  
      <serviceBehaviors>  
        <behavior>  
          <etwTracking profileName="Sample Tracking Profile"/>  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
   <tracking>  
      <profiles>  
        <trackingProfile name="Sample Tracking Profile">  
        ….  
       </trackingProfile>  
      </profiles>  
    </tracking>  
  </system.serviceModel>  
</configuration>  
```  
  
> [!NOTE]
>  If a `trackingProfile` name is not specified, such as just `<etwTracking/>` or `<etwTracking profileName=""/>`, then the default tracking profile installed with the [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] in the Machine.config file is used.  
  
 In the Machine.config file, the default tracking profile subscribes to workflow instance records and faults.  
  
 In ETW, events are written to the ETW session through a provider ID. The provider ID that the ETW tracking participant uses for writing the tracking records to ETW is defined in the diagnostics section of the Web.config file (under `<system.serviceModel><diagnostics>`). By default, the ETW tracking participant uses a default provider ID when one has not been specified, as shown in the following example.  
  
```xml  
<system.serviceModel>  
        <diagnostics etwProviderId="52A3165D-4AD9-405C-B1E8-7D9A257EAC9F" />  
```  
  
 The following illustration shows the flow of tracking data through the ETW tracking participant. Once the tracking data reaches the ETW session, it can be accessed in a number of ways. One of the most useful ways to access these events is through Event Viewer, a common Windows tool used for viewing logs and traces from applications and services.  
  
 ![The flow of Tracking and ETW Tracking Provider](../../../docs/framework/windows-workflow-foundation/media/trackingdatathroughetwparticipant.gif "TrackingDatathroughETWParticipant")  
  
## Tracking Participant Event Data  
 A tracking participant serializes tracked event data to an ETW session in the format of one event per tracking record.  An event is identified using an ID within the range of 100 through 199. For definitions of the tracking event records emitted by a tracking participant, see the [Tracking Events Reference](../../../docs/framework/windows-workflow-foundation/tracking-events-reference.md) topic.  
  
 The size of an ETW event is limited by the ETW buffer size, or the by the maximum payload for an ETW event, whichever value is smaller. If the size of the event exceeds either of these ETW limits, the event is truncated and its content removed in an arbitrary manner. Variables, arguments, annotations and custom data are not selectively removed. In the case of truncation, all of these are truncated regardless of the value that caused the event size to exceed the ETW limit.  The removed data is replaced with `<item>..<item>`.  
  
 Complex types in variables, arguments, and custom data items are serialized to the ETW event record using the [NetDataContractSerializer Class](http://go.microsoft.com/fwlink/?LinkId=177537). This class includes CLR-type information in the serialized XML steam.  
  
 Truncation of payload data due to ETW limits can result in duplicate tracking records being sent to an ETW session. This can occur if more than one session is listening for the events and the sessions have different payload limits for the events.  
  
 For  the session with the lower limit the event may be truncated. The ETW tracking participant does not have any knowledge of the number of sessions listening for the events; if an event is truncated for a session then the ETW participant retries sending the event once. In this case the session that is configured to accept a larger payload size will get the event twice (the non-truncated and truncated event). Duplication can be prevented by configuring all the ETW sessions with same buffer size limits.  
  
## Accessing Tracking Data from an ETW Participant in the Event Viewer  
 Events that are written to an ETW session by the ETW tracking participant can be accessed through the Event Viewer (when using the default provider ID). This allows for rapidly viewing of tracking records that have been emitted by the workflow.  
  
> [!NOTE]
>  Tracking record events emitted to an ETW session use event IDs in the range of 100 through 199.  
  
#### To enable viewing the Tracking Records in Event Viewer  
  
1.  Start the Event Viewer (EVENTVWR.EXE)  
  
2.  Select **Event Viewer, Applications and Services Logs, Microsoft, Windows, Application Server-Applications**.  
  
3.  Right-click and ensure that **View, Show Analytic and Debug logs** is selected. If not, select it so the check mark appears next to it. This displays the **Analytic**, **Perf**, and **Debug** logs.  
  
4.  Right-click the **Analytic** log and then select **Enable Log**. The log will exist in the %SystemRoot%\System32\Winevt\Logs\Microsoft-Windows-Application Server-Applications%4Analytic.etl file.  
  
## Custom Tracking Participant  
 The tracking participant API allows extension of the tracking runtime with a user-provided tracking participant that can include custom logic to handle tracking records emitted by the workflow runtime. To write a custom tracking participant, the developer must implement the `Track` method on the <xref:System.Activities.Tracking.TrackingParticipant> class. This method is called when a tracking record is emitted by the workflow runtime.  
  
 Tracking participants derive from the <xref:System.Activities.Tracking.TrackingParticipant> class. The system-provided <xref:System.Activities.Tracking.EtwTrackingParticipant> emits an Event Tracking for Windows (ETW) event for each tracking record that is received. To create a custom tracking participant, a class is created that derives from <xref:System.Activities.Tracking.TrackingParticipant>. To provide basic tracking functionality, override <xref:System.Activities.Tracking.TrackingParticipant.Track%2A>. <xref:System.Activities.Tracking.TrackingParticipant.Track%2A> is called when a tracking record is sent by the runtime and can be processed in the desired manner. In the following example, a custom tracking participant class is defined that emits all tracking records to the console window. You can also implement a <xref:System.Activities.Tracking.TrackingParticipant> object that processes the tracking records asynchronously using its `BeginTrack` and `EndTrack` methods  
  
```csharp  
class ConsoleTrackingParticipant : TrackingParticipant  
{  
    protected override void Track(TrackingRecord record, TimeSpan timeout)  
    {  
        if (record != null)  
        {  
            Console.WriteLine("=================================");  
            Console.WriteLine(record);  
        }  
    }  
}  
```  
  
 To use a particular tracking participant, register it with the workflow instance that you want to track, as shown in the following example.  
  
```csharp  
myInstance.Extensions.Add(new ConsoleTrackingParticipant());  
```  
  
 In the following example, a workflow that consists of a <xref:System.Activities.Statements.Sequence> activity that contains a <xref:System.Activities.Statements.WriteLine> activity is created. The `ConsoleTrackingParticipant` is added to the extensions and the workflow is invoked.  
  
```csharp  
Activity activity= new Sequence()  
{  
    Activities =  
    {  
        new WriteLine()  
        {  
            Text = "Hello World."  
        }  
    }  
};  
  
WorkflowApplication instance = new WorkflowApplication(activity);  
  
instance.Extensions.Add(new ConsoleTrackingParticipant());  
  instance.Completed = delegate(WorkflowApplicationCompletedEventArgs e)  
            {  
                Console.WriteLine("workflow instance completed, Id = " + instance.Id);  
                resetEvent.Set();  
            };  
            instance.Run();  
            Console.ReadLine();  
```  
  
## See Also  
 [Windows Server App Fabric Monitoring](http://go.microsoft.com/fwlink/?LinkId=201273)  
 [Monitoring Applications with App Fabric](http://go.microsoft.com/fwlink/?LinkId=201275)
