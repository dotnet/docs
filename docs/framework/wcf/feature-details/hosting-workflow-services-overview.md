---
title: "Hosting Workflow Services Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 19f3704f-06bf-4eeb-8724-5224e02d7ead
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Hosting Workflow Services Overview
Workflow services must be hosted to execute. The <xref:System.ServiceModel.WorkflowServiceHost> is the out-of-the-box workflow host that supports multiple instances, configuration, and WCF messaging (although the workflows aren’t required to use messaging in order to be hosted).  It also integrates with persistence, tracking, and instance control through a set of service behaviors.  Just like WCF’s <xref:System.ServiceModel.ServiceHost>, the <xref:System.ServiceModel.WorkflowServiceHost> can be self-hosted in any managed .NET application, or web-hosted (as a .xamlx file) in IIS / WAS.  Topics in this section describe how to host a workflow service.  
  
## In This Section  
 [Hosting Workflow Services](../../../../docs/framework/wcf/feature-details/hosting-workflow-services.md)  
 Describes hosting workflow services.  
  
 [Workflow Service Host Internals](../../../../docs/framework/wcf/feature-details/workflow-service-host-internals.md)  
 Describes how <xref:System.ServiceModel.WorkflowServiceHost> processes incoming messages.  
  
 [Workflow Service Host Extensibility](../../../../docs/framework/wcf/feature-details/workflow-service-host-extensibility.md)  
 Describes how to extend the functionality of the workflow service host.  
  
 [Workflow Control Endpoint](../../../../docs/framework/wcf/feature-details/workflow-control-endpoint.md)  
 Describes how to define an endpoint that allows you to create workflow instances.  
  
 [How to: Host a non-service workflow in IIS](../../../../docs/framework/wcf/feature-details/how-to-host-a-non-service-workflow-in-iis.md)  
 Demonstrates hosting a workflow that is not a workflow service in IIS.  
  
 [How to: Host a Workflow Service with Windows Server App Fabric](../../../../docs/framework/wcf/feature-details/how-to-host-a-workflow-service-with-windows-server-app-fabric.md)  
 Demonstrates how to host an existing workflow service in Windows Server App Fabric.  
  
 [Configuring WorkflowServiceHost](../../../../docs/framework/wcf/feature-details/configuring-workflowservicehost.md)  
 Describes how to control persistence, tracking, idle, and unhandled exception behavior.  
  
## Reference  
 <xref:System.ServiceModel.Activities.WorkflowServiceHost>  
  
 <xref:System.ServiceModel.Activities.WorkflowService>  
  
 <xref:System.ServiceModel.Activation.ServiceHostFactory>  
  
 <xref:System.ServiceModel.Activation.ServiceHostFactoryBase>  
  
 <xref:System.ServiceModel.Activation.WorkflowServiceHostFactory>  
  
## Related Sections  
 [Workflow Services](../../../../docs/framework/wcf/feature-details/workflow-services.md)
