---
title: "Administration and Diagnostics"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Windows Communication Foundation, diagnostics"
  - "Windows Communication Foundation, administration"
  - "diagnostics [WCF]"
  - "WCF, diagnostics"
  - "administration [WCF]"
  - "WCF, administration"
ms.assetid: 34c81c08-0e0f-4fbc-9ae8-91948640ee43
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Administration and Diagnostics
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides a rich set of functionalities that can help you monitor the different stages of an application’s life. For example, you can use configuration to set up services and clients at deployment. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] includes a large set of performance counters to help you gauge your application's performance. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] also exposes inspection data of a service at runtime through a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Windows Management Instrumentation (WMI) provider. When the application experiences a failure or starts acting improperly, you can use the Event Log to see if anything significant has occurred. You can also use Message Logging and Tracing to see what events are happening end-to-end in your application. These features assist both developers and IT professionals to troubleshoot an [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application when it is not behaving correctly.  
  
> [!NOTE]
>  If you are receiving faults with no specific detail information, you should enable the `includeExceptionDetailInFaults` attribute of the [\<serviceDebug>](../../../../docs/framework/configure-apps/file-schema/wcf/servicedebug.md) configuration element. This instructs [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to send exception detail to clients, which enables you to detect many common problems without requiring more advanced diagnosis. For more information, see [Sending and Receiving Faults](../../../../docs/framework/wcf/sending-and-receiving-faults.md).  
  
## Diagnostics Features Provided by WCF  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides the following diagnostics functionalities:  
  
-   End-To-End tracing provides instrumentation data for troubleshooting an application without using a debugger. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] outputs traces for process milestones, as well as error messages. This can include opening a channel factory or sending and receiving messages by a service host. Tracing can be enabled for a running application to monitor its progress. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the [Tracing](../../../../docs/framework/wcf/diagnostics/tracing/index.md) topic. To understand how you can use tracing to debug your application, see the [Using Tracing to Troubleshoot Your Application](../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md) topic.  
  
-   Message logging allows you to see how messages look both before and after transmission. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the [Message Logging](../../../../docs/framework/wcf/diagnostics/message-logging.md) topic.  
  
-   Event tracing writes events in the Event Log for any major issues. You can then use the Event Viewer to examine any abnormalities. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the [Event Logging](../../../../docs/framework/wcf/diagnostics/event-logging/index.md) topic.  
  
-   Performance counters exposed through Performance Monitor enable you to monitor your application and system's health. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the [Performance Counters](../../../../docs/framework/wcf/diagnostics/performance-counters/index.md) topic.  
  
-   The <xref:System.ServiceModel.Configuration> namespace allows you to load configuration files and set up a service or client endpoint. You can use the object model to script changes to many applications when updates must be deployed to many computers. Alternatively, you can use the [Configuration Editor Tool (SvcConfigEditor.exe)](../../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md) to edit the configuration settings using a GUI wizard. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the [Configuring Your Application](../../../../docs/framework/wcf/diagnostics/configuring-your-application.md) topic.  
  
-   WMI enables you to find out what services are listening on a machine and the bindings that are in use. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the [Using Windows Management Instrumentation for Diagnostics](../../../../docs/framework/wcf/diagnostics/wmi/index.md) topic.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] also provides several GUI and command line tools to make it easier for you to create, deploy, and manage [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Windows Communication Foundation Tools](../../../../docs/framework/wcf/tools.md). For example, you can use the [Configuration Editor Tool (SvcConfigEditor.exe)](../../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md) to create and edit [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] configuration settings using a wizard, instead of editing XML directly. You can also use the [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md) to view, group, and filter trace messages so that you can diagnose, repair, and verify issues with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services.  
  
## See Also  
 [Configuring Your Application](../../../../docs/framework/wcf/diagnostics/configuring-your-application.md)  
 [Deploying Services](../../../../docs/framework/wcf/diagnostics/deploying-services.md)  
 [Exceptions Reference](../../../../docs/framework/wcf/diagnostics/exceptions-reference/index.md)  
 [Event Logging](../../../../docs/framework/wcf/diagnostics/event-logging/index.md)  
 [Message Logging](../../../../docs/framework/wcf/diagnostics/message-logging.md)  
 [Configuration Editor Tool (SvcConfigEditor.exe)](../../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md)  
 [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md)  
 [ServiceModel Registration Tool](../../../../docs/framework/wcf/diagnostics/servicemodel-registration-tool.md)  
 [Tracing](../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Windows Management Instrumentation for Diagnostics](../../../../docs/framework/wcf/diagnostics/wmi/index.md)  
 [Performance Counters](../../../../docs/framework/wcf/diagnostics/performance-counters/index.md)  
 [Windows Communication Foundation Tools](../../../../docs/framework/wcf/tools.md)
