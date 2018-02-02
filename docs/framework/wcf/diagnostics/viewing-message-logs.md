---
title: "Viewing Message Logs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3012fa13-f650-45fb-aaea-c5cca8c7d372
caps.latest.revision: 22
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Viewing Message Logs
This topic describes how you can view message logs.  
  
## Viewing Message Logs in the Service Trace Viewer  
 A message will be transformed as it is processed by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. Therefore, a message being logged reflects only the message's content at the point it was logged, not the content on the wire.  
  
 Since the output of message logging has no relationship to the transfer format of the message, message logging always outputs the decoded message. If you have configured message logging properly, any logged message should be in plain text. For example, the format (plain text) of the logged messages is not affected by the usage of a binary message encoder.  
  
 The output of the XmlWriterTraceListener is a file that contains a sequence of XML fragments. You should be aware that the file is not a valid XML file. It is recommended that you use the [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md) to view the message log files. For more information on how to use this tool, see [Using Service Trace Viewer for Viewing Correlated Traces and Troubleshooting](../../../../docs/framework/wcf/diagnostics/tracing/using-service-trace-viewer-for-viewing-correlated-traces-and-troubleshooting.md).  
  
 In the Service Trace Viewer, messages are listed in the **Message** tab. Messages that have caused, or are related to, a processing error are highlighted in yellow (warning level) or red (error level), depending on the severity of the error. Double-clicking on the message brings up the message trace in the context of the processing request.  
  
> [!NOTE]
>  If a message has no header, no `<header/>` tag is logged.  
  
## Viewing Messages Logged by a Client, a Relay, and a Service  
 Your environment may contain a client, which sends a message to a relay, that subsequently forwards the message to the service. When message logging is enabled on all three locations, and all three message logs are viewed in [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md) simultaneously, the message log exchanges will be incorrectly rendered. This is because the `CorrelationId` and `ActivityId` in the Message header are not unique for every send-receive pair.  
  
 You can use either one of the following methods to resolve this problem.  
  
-   Only view two of the three message logs in the [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md) at any time.  
  
-   If you must view all three logs in the [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md) at the same time, you can modify the relay service by creating a new <xref:System.ServiceModel.Channels.Message> instance. This instance should be a copy of the body of the incoming message, plus all the headers except for the `ActivityId` and `Action` headers. The following example code demonstrates how to do this.  
  
```  
Message outgoingMessage = Message.CreateMessage(incomingMessage.Version, incomingMessage.Headers.Action, incomingMessage.GetReaderAtBodyContents());  
  
for (int i = 0; i < incomingMessage.Headers.Count; i++)  
{  
   if (incomingMessage.Headers[i].Name.Equals("ActivityId", StringComparison.InvariantCultureIgnoreCase) ||  
incomingMessage.Headers[i].Name.Equals("Action", StringComparison.InvariantCultureIgnoreCase))  
   {  
      continue;  
    }  
    outgoingMessage.Headers.CopyHeaderFrom(incomingMessage, i);  
}  
```  
  
## Exceptional Cases for Inaccurate Message Logging Content  
 Under the following conditions, messages being logged might not be the exact representation of the octet stream present on the wire.  
  
-   For BasicHttpBinding, envelope headers are logged for the incoming messages in the /addressing/none namespace.  
  
-   Whitespaces can be mismatched.  
  
-   For incoming messages, empty elements can be represented differently. For example, \<tag>\</tag> instead of  \<tag/>  
  
-   When known PII logging is disabled either by default or explicit setting enableLoggingKnownPii="true".  
  
-   Encoding is enabled for transforming to UTF-8.  
  
## See Also  
 [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md)  
 [Using Service Trace Viewer for Viewing Correlated Traces and Troubleshooting](../../../../docs/framework/wcf/diagnostics/tracing/using-service-trace-viewer-for-viewing-correlated-traces-and-troubleshooting.md)  
 [Message Logging](../../../../docs/framework/wcf/diagnostics/message-logging.md)
