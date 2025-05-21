---
description: "Learn more about: Hosting Workflow Services Overview"
title: "Hosting Workflow Services Overview"
ms.date: "03/30/2017"
ms.assetid: 19f3704f-06bf-4eeb-8724-5224e02d7ead
ms.topic: concept-article
---
# Hosting Workflow Services Overview

Workflow services must be hosted to execute. The <xref:System.ServiceModel.WorkflowServiceHost> is the out-of-the-box workflow host that supports multiple instances, configuration, and WCF messaging (although the workflows aren’t required to use messaging in order to be hosted).  It also integrates with persistence, tracking, and instance control through a set of service behaviors.  Just like WCF’s <xref:System.ServiceModel.ServiceHost>, the <xref:System.ServiceModel.WorkflowServiceHost> can be self-hosted in any managed .NET application, or web-hosted (as a .xamlx file) in IIS / WAS.  Topics in this section describe how to host a workflow service.  
  
## In This Section  

 [Hosting Workflow Services](hosting-workflow-services.md)  
 Describes hosting workflow services.  
  
 [Workflow Service Host Internals](workflow-service-host-internals.md)  
 Describes how <xref:System.ServiceModel.WorkflowServiceHost> processes incoming messages.  
  
 [Workflow Service Host Extensibility](workflow-service-host-extensibility.md)  
 Describes how to extend the functionality of the workflow service host.  
  
 [Workflow Control Endpoint](workflow-control-endpoint.md)  
 Describes how to define an endpoint that allows you to create workflow instances.
  
 [How to: Host a Workflow Service with Windows Server App Fabric](how-to-host-a-workflow-service-with-windows-server-app-fabric.md)  
 Demonstrates how to host an existing workflow service in Windows Server App Fabric.  
  
 [Configuring WorkflowServiceHost](configuring-workflowservicehost.md)  
 Describes how to control persistence, tracking, idle, and unhandled exception behavior.  
  
## Reference  

 <xref:System.ServiceModel.Activities.WorkflowServiceHost>  
  
 <xref:System.ServiceModel.Activities.WorkflowService>  
  
 <xref:System.ServiceModel.Activation.ServiceHostFactory>  
  
 <xref:System.ServiceModel.Activation.ServiceHostFactoryBase>  
  
 <xref:System.ServiceModel.Activation.WorkflowServiceHostFactory>  
  
## Related Sections  

 [Workflow Services](workflow-services.md)
