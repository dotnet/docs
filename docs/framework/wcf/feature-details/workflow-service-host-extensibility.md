---
title: "Workflow Service Host Extensibility"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c0e8f7bb-cb13-49ec-852f-b85d7c23972f
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Workflow Service Host Extensibility
[!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)] provides the <xref:System.ServiceModel.Activities.WorkflowServiceHost> class for hosting workflow services. This class is used when you are self-hosting a workflow service in a managed application or a Windows service. This class is also used when hosting a workflow service with Internet Information Services (IIS) or Windows Process Activation Service (WAS). The <xref:System.ServiceModel.Activities.WorkflowServiceHost> class provides extension points that allow you to add custom extensions, change the idle behavior, and host non-service workflows (workflows that do not use messaging activities).  
  
## Workflow Service Host Extensions  
 The <xref:System.ServiceModel.Activities.WorkflowServiceHost> contains a <xref:System.ServiceModel.Activities.WorkflowServiceHost.WorkflowExtensions%2A> property of type <xref:System.Activities.Hosting.WorkflowInstanceExtensionManager> that provides methods to add extensions to the <xref:System.ServiceModel.Activities.WorkflowServiceHost>. Use the <xref:System.Activities.Hosting.WorkflowInstanceExtensionManager.Add%2A> method to add an extension for each workflow service instance. The delegate specified is called to create a new extension when a workflow service instance is created or loaded from a persistence store. Use the <xref:System.Activities.Hosting.WorkflowInstanceExtensionManager.Add%2A> method to add an extension for each workflow service host, one instance of the extension is shared for all workflow service instances.  
  
## React to Unhandled Exceptions  
 The <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionBehavior> enables you to specify the action to take if an unhandled exception occurs within a workflow service. The <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionBehavior.Action%2A> property specifies one of the <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionAction> values:  
  
-   <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionAction.Abandon> – Aborts the workflow service instance.  
  
-   <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionAction.AbandonAndSuspend> – Rolls back to the last persisted state and suspends the workflow service instance. This only occurs if the workflow has already been persisted at least once. If not the workflow instance is aborted.  
  
-   <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionAction.Cancel> – Cancels the instance.  
  
-   <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionAction.Terminate> – Terminates the instance.  
  
 This behavior can be configured in code as shown in the following example.  
  
```csharp  
host.Description.Behaviors.Add(new WorkflowUnhandledExceptionBehavior { Action = WorkflowUnhandledExceptionAction.Abandon });  
```  
  
 It can also be configured in a configuration file as shown in the following example.  
  
```xml
<behaviors>  
      <serviceBehaviors>  
        <behavior>  
          <serviceMetadata httpGetEnabled="True"/>  
          <serviceDebug includeExceptionDetailInFaults="False" />  
          <workflowUnhandledExceptionBehavior action="Abandon" />        
        </behavior>  
      </serviceBehaviors>  
```  
  
## Hosting Non-Service Workflows  
 <xref:System.ServiceModel.Activities.WorkflowServiceHost> can be used to host non-service workflows, or workflows that either do not begin with a <xref:System.ServiceModel.Activities.Receive> activity or workflows that do not use the messaging activities. Workflow services normally begin with a <xref:System.ServiceModel.Activities.Receive> activity. When the <xref:System.ServiceModel.Activities.WorkflowServiceHost> receives a message for a workflow service, if it is not already running (or persisted) a new workflow service instance is created. If a workflow does not begin with a Receive activity, it cannot be started by sending a message because there is no activity to receive the message. To host a non-service workflow, derive a class from <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint> and override <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint.OnGetInstanceId%2A>, <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint.OnGetCreationContext%2A>, and <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint.OnResolveBookmark%2A>. Override <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint.OnGetInstanceId%2A> if you want to provide a preferred instance ID. Override <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint.OnGetCreationContext%2A> to create a custom workflow creation context or populate an instance of the existing <xref:System.ServiceModel.Activities.WorkflowCreationContext>. Override <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint.OnResolveBookmark%2A> to manually extract the bookmark from the incoming message. If you override this method, you must invoke <xref:System.ServiceModel.Activities.WorkflowHostingResponseContext.SendResponse%2A> in its body so as to respond to the message sent to the WorkflowHostingEndpoint. If you do not do so, a <xref:System.ServiceModel.Description.ServiceThrottlingBehavior.MaxConcurrentCalls%2A> limit may be eventually exceeded. In two-way contracts, you may be able to detect your   failure to invoke <xref:System.ServiceModel.Activities.WorkflowHostingResponseContext.SendResponse%2A> because of the client’s failure to receive a response. In one-way contracts, you may not recognize the mistake of failing to call <xref:System.ServiceModel.Activities.WorkflowHostingResponseContext.SendResponse%2A> until it’s too late, after the <xref:System.ServiceModel.Description.ServiceThrottlingBehavior.MaxConcurrentCalls%2A> throttle limit is exceeded. For more information, please see the [WorkflowHostingEndpoint Resume Bookmark](../../../../docs/framework/windows-workflow-foundation/samples/workflowhostingendpoint-resume-bookmark.md)To create a new instance of a non-service workflow, declare a service contract that defines an operation that creates a new instance. The creation operation should take an IDictionary\<string, object> to pass any required workflow parameters. This contract is implicitly implemented by the <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint>-derived class. When hosting the workflow, add an instance of the <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint>-derived class to the host by calling <xref:System.ServiceModel.Activities.WorkflowServiceHost.AddServiceEndpoint%2A> and call <!--zz xref:System.ServiceModel.Activities.WorkflowServiceHost.Open%2A--> `System.ServiceModel.Activities.WorkflowServiceHost.Open`. To create an instance of the workflow, create a <xref:System.ServiceModel.ChannelFactory%601> of your service contract type and call <xref:System.ServiceModel.ChannelFactory%601.CreateChannel%2A>. You can then call the create operation defined in your service contract.  
  
## See Also  
 [Workflow Services](../../../../docs/framework/wcf/feature-details/workflow-services.md)  
 [Messaging Activities](../../../../docs/framework/wcf/feature-details/messaging-activities.md)
