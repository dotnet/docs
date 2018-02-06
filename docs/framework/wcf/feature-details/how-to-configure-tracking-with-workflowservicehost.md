---
title: "How to: Configure Tracking with WorkflowServiceHost"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ed1485fe-7529-4351-bca3-8bb915260b17
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Configure Tracking with WorkflowServiceHost
This topic explains how to configure tracking for a [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)] workflow hosted in <xref:System.ServiceModel.Activities.WorkflowServiceHost>. It is configured through a Web.config file by specifying a service behavior.  
  
### Configure Tracking in Configuration  
  
1.  Add the <xref:System.Activities.Tracking.EtwTrackingParticipant> using the <`behavior`> element in a configuration file, as shown in the following example.  
  
    ```xml  
    <behaviors>  
       <serviceBehaviors>  
         <behavior>  
           <etwTracking profileName="Sample Tracking Profile" />  
         </behavior>              
       </serviceBehaviors>  
    <behaviors>  
    ```  
  
    > [!NOTE]
    >  The preceding configuration sample is using simplified configuration. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Simplified Configuration](../../../../docs/framework/wcf/simplified-configuration.md).  
  
     The preceding configuration sample adds a <xref:System.Activities.Tracking.EtwTrackingParticipant> and specifies a tracking profile name. Tracking profiles are created in a <`trackingProfile`> element within a <`tracking`> element. The tracking profile contains tracking queries that permit a tracking participant to subscribe to workflow events that are emitted when the state of a workflow instance changes at runtime. The following example shows how to create a tracking profile.  
  
    ```xml  
    <system.serviceModel>  
        <tracking>   
         <trackingProfile name="Sample Tracking Profile">  
            <workflow activityDefinitionId="*">  
               <workflowInstanceQueries>  
                 <workflowInstanceQuery>  
                    <states>  
                       <state name="Started"/>  
                       <state name="Completed"/>  
                    </states>  
                </workflowInstanceQuery>  
             </workflowInstanceQueries>  
           </workflow>  
         </trackingProfile>   
       </tracking>  
    </system.serviceModel>  
    ```  
  
     [!INCLUDE[crabout](../../../../includes/crabout-md.md)] tracking profiles, see [Tracking Profiles](../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md).  
  
     [!INCLUDE[crabout](../../../../includes/crabout-md.md)] tracking in general, see [Workflow Tracking and Tracing](../../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md).  
  
### Configure Tracking in Code  
  
1.  Add the <xref:System.Activities.Tracking.EtwTrackingParticipant> using the <xref:System.ServiceModel.Activities.Description.EtwTrackingBehavior> behavior in code, as shown in the following example.  
  
    ```csharp  
    host.Description.Behaviors.Add(new EtwTrackingBehavior { ProfileName = "Sample Tracking Profile" });  
    ```  
  
     The preceding code sample adds a <xref:System.Activities.Tracking.EtwTrackingParticipant> and specifies a tracking profile name. Tracking profiles are created in a <`trackingProfile`> element within a <`tracking`> element as shown in the previous section.  
  
     [!INCLUDE[crabout](../../../../includes/crabout-md.md)] tracking profiles, see [Tracking Profiles](../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md).  
  
     [!INCLUDE[crabout](../../../../includes/crabout-md.md)] tracking in general, see [Workflow Tracking and Tracing](../../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md). For an example of configuring tracking programmatically see [Configuring Tracking for a Workflow](../../../../docs/framework/windows-workflow-foundation/configuring-tracking-for-a-workflow.md).  
  
## See Also  
 [Simplified Configuration for WCF Services](../../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md)  
 [Workflow Services](../../../../docs/framework/wcf/feature-details/workflow-services.md)  
 [Tracking Profiles](../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)
