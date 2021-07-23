---
description: "Learn more about: How to: Configure Workflow Unhandled Exception Behavior with WorkflowServiceHost"
title: "How to: Configure Workflow Unhandled Exception Behavior with WorkflowServiceHost"
ms.date: "03/30/2017"
ms.topic: how-to
ms.assetid: 51b25c86-292c-43e4-8d13-273d2badc8ad
---
# How to: Configure Workflow Unhandled Exception Behavior with WorkflowServiceHost

The <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionBehavior> is a behavior that enables you to specify the action to take if an unhandled exception occurs within a workflow hosted in <xref:System.ServiceModel.Activities.WorkflowServiceHost>. This topic shows how to configure this behavior in a configuration file.  
  
### To configure WorkflowUnhandledExceptionBehavior  
  
1. Add a <`workflowUnhandledException`> element in a <`behavior`> element within a <`serviceBehaviors`> element, using the `action` attribute to specify the action to take when an unhandled exception occurs as shown in the following example.  
  
    ```xml  
    <behaviors>  
      <serviceBehaviors>  
        <behavior name="">  
          <workflowUnhandledException action="abandonAndSuspend"/>
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
    ```  
  
    > [!NOTE]
    > The preceding configuration sample is using simplified configuration. For more information, see [Simplified Configuration](../simplified-configuration.md).  
  
     This behavior can be configured in code as shown in the following example.  
  
    ```csharp  
    host.Description.Behaviors.Add(new WorkflowUnhandledExceptionBehavior { Action = WorkflowUnhandledExceptionAction.AbandonAndSuspend });  
    ```  
  
     The `action` attribute of the <`workflowUnhandledException`> element can be set to one of the following values:  
  
     **abandon**  
     Aborts the instance in memory without touching the persisted instance state (that is, roll back to the last persist point).  
  
     **abandonAndSuspend**  
     Aborts the instance in memory and updates the persisted instance to be suspended.  
  
     **cancel**  
     Calls cancellation handlers for the instance and then completes the instance in memory, which may also remove it from the instance store  
  
     **terminate**  
     Completes the instance in memory and removes it from the instance store.  
  
     For more information about <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionBehavior>, see [Workflow Service Host Extensibility](workflow-service-host-extensibility.md).  
  
## See also

- [Workflow Service Host Extensibility](workflow-service-host-extensibility.md)
- [Workflow Services](workflow-services.md)
