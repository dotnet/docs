---
title: "Administration and Diagnostics"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Windows Communication Foundation, diagnostics"
  - "Windows Communication Foundation, administration"
  - "diagnostics [WCF]"
  - "WCF, diagnostics"
  - "administration [WCF]"
  - "WCF, administration"
ms.assetid: 34c81c08-0e0f-4fbc-9ae8-91948640ee43
---
# Administration and Diagnostics
Windows Communication Foundation (WCF) provides a rich set of functionalities that can help you monitor the different stages of an application’s life. For example, you can use configuration to set up services and clients at deployment. WCF includes a large set of performance counters to help you gauge your application's performance. WCF also exposes inspection data of a service at runtime through a WCF Windows Management Instrumentation (WMI) provider. When the application experiences a failure or starts acting improperly, you can use the Event Log to see if anything significant has occurred. You can also use Message Logging and Tracing to see what events are happening end-to-end in your application. These features assist both developers and IT professionals to troubleshoot an WCF application when it is not behaving correctly.  
  
> [!NOTE]
>  If you are receiving faults with no specific detail information, you should enable the `includeExceptionDetailInFaults` attribute of the [\<serviceDebug>](../../../../docs/framework/configure-apps/file-schema/wcf/servicedebug.md) configuration element. This instructs WCF to send exception detail to clients, which enables you to detect many common problems without requiring more advanced diagnosis. For more information, see [Sending and Receiving Faults](../../../../docs/framework/wcf/sending-and-receiving-faults.md).  
  
## Diagnostics Features Provided by WCF  
 WCF provides the following diagnostics functionalities:  
  
-   End-To-End tracing provides instrumentation data for troubleshooting an application without using a debugger. WCF outputs traces for process milestones, as well as error messages. This can include opening a channel factory or sending and receiving messages by a service host. Tracing can be enabled for a running application to monitor its progress. For more information, see the [Tracing](../../../../docs/framework/wcf/diagnostics/tracing/index.md) topic. To understand how you can use tracing to debug your application, see the [Using Tracing to Troubleshoot Your Application](../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md) topic.  
  
-   Message logging allows you to see how messages look both before and after transmission. For more information, see the [Message Logging](../../../../docs/framework/wcf/diagnostics/message-logging.md) topic.  
  
-   Event tracing writes events in the Event Log for any major issues. You can then use the Event Viewer to examine any abnormalities. For more information, see the [Event Logging](../../../../docs/framework/wcf/diagnostics/event-logging/index.md) topic.  
  
-   Performance counters exposed through Performance Monitor enable you to monitor your application and system's health. For more information, see the [Performance Counters](../../../../docs/framework/wcf/diagnostics/performance-counters/index.md) topic.  
  
-   The <xref:System.ServiceModel.Configuration> namespace allows you to load configuration files and set up a service or client endpoint. You can use the object model to script changes to many applications when updates must be deployed to many computers. Alternatively, you can use the [Configuration Editor Tool (SvcConfigEditor.exe)](../../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md) to edit the configuration settings using a GUI wizard. For more information, see the [Configuring Your Application](../../../../docs/framework/wcf/diagnostics/configuring-your-application.md) topic.  
  
-   WMI enables you to find out what services are listening on a machine and the bindings that are in use. For more information, see the [Using Windows Management Instrumentation for Diagnostics](../../../../docs/framework/wcf/diagnostics/wmi/index.md) topic.  
  
 WCF also provides several GUI and command line tools to make it easier for you to create, deploy, and manage WCF applications. For more information, see [Windows Communication Foundation Tools](../../../../docs/framework/wcf/tools.md). For example, you can use the [Configuration Editor Tool (SvcConfigEditor.exe)](../../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md) to create and edit WCF configuration settings using a wizard, instead of editing XML directly. You can also use the [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md) to view, group, and filter trace messages so that you can diagnose, repair, and verify issues with WCF services.  
  
## See also
- [Configuring Your Application](../../../../docs/framework/wcf/diagnostics/configuring-your-application.md)
- [Deploying Services](../../../../docs/framework/wcf/diagnostics/deploying-services.md)
- [Exceptions Reference](../../../../docs/framework/wcf/diagnostics/exceptions-reference/index.md)
- [Event Logging](../../../../docs/framework/wcf/diagnostics/event-logging/index.md)
- [Message Logging](../../../../docs/framework/wcf/diagnostics/message-logging.md)
- [Configuration Editor Tool (SvcConfigEditor.exe)](../../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md)
- [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md)
- [ServiceModel Registration Tool](../../../../docs/framework/wcf/diagnostics/servicemodel-registration-tool.md)
- [Tracing](../../../../docs/framework/wcf/diagnostics/tracing/index.md)
- [Using Windows Management Instrumentation for Diagnostics](../../../../docs/framework/wcf/diagnostics/wmi/index.md)
- [Performance Counters](../../../../docs/framework/wcf/diagnostics/performance-counters/index.md)
- [Windows Communication Foundation Tools](../../../../docs/framework/wcf/tools.md)
