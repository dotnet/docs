---
title: "&lt;messageLogging&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1d06a7e6-9633-4a12-8c5d-123adbbc19c5
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;messageLogging&gt;
This element defines the settings for the message-logging capabilities of Windows Communication Foundation (WCF).  
  
 \<system.ServiceModel>  
\<diagnostic>  
\<messageLogging>  
  
## Syntax  
  
```xml  
<system.serviceModel>  
   <diagnostics>  
       <messageLogging logEntireMessage="Boolean"  
          logMalformedMessages="Boolean"  
          logMessagesAtServiceLevel="Boolean"  
          logMessagesAtTransportLevel="Boolean"  
                    maxMessagesToLog="Integer"  
          maxSizeOfMessageToLog="Integer" >  
          <filters>  
                            <clear />  
          </filters>  
       </messageLogging>  
   </diagnostics>  
</system.serviceModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`logEntireMessage`|A Boolean value that specifies whether the entire message (message header and body) is logged. The default is `false`, which means that only the message header is logged. This setting affects all message logging levels (service, transport, and malformed).|  
|`logMalformedMessages`|A Boolean value that specifies whether malformed messages are logged. Malformed messages do not count toward the `maxMessagesToLog`. The default is `false`.|  
|`logMessagesAtServiceLevel`|A Boolean value that specifies whether messages are traced at the service level (before encryption- and transport-related transforms). The default is `false`.|  
|`logMessagesAtTransportLevel`|A Boolean value that specifies whether messages are traced at the transport level. Any filters specified in the config file are applied, and only messages that match the filters are traced. The default is `false`.|  
|`maxMessagesToLog`|A positive integer that specifies the maximum number of messages to log. The default is 1000.|  
|`maxSizeOfMessageToLog`|A positive integer that specifies the maximum size, in bytes, of a message to log. Messages larger than the limit will not be logged. This setting affects all trace levels. The default is 262144(0x4000).|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|filters|The `filters` element holds a collection of XPath filters. When transport message logging is enabled (`logMessagesAtTransportLevel` is `true`), only messages matching the filters will be logged.<br /><br /> Filters are applied only at the transport layer. Service level and malformed message logging are not affected by filters.<br /><br /> The only attribute for this element, `filter`, is an XpathFilter.<br /><br /> `<filters>     <add xmlns:soap="http://www.w3.org/2003/05/soap-envelope">/soap:Envelope</add> </filters>`|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|diagnostics|Defines WCF settings for runtime inspection and control for the administrator.|  
  
## Remarks  
 Messages are logged at three different levels in the stack: service, transport, and malformed. Each level can be activated separately.  
  
 XPath filters can be added to log specific messages at the transport and service levels. If no filters are defined, all messages are logged. Filters are applied only to the headers of the message. The body is ignored. WCF ignores the message body to improve performance. If you want to filter based on the content of the body, you can create a custom listener with a filter that does so.  
  
 You need to create a trace listener to activate message tracing. The listener itself can be any listener that works with the <xref:System.Diagnostics> tracing architecture. The following example demonstrates how to create such a listener.  
  
```xml  
<system.diagnostics>  
    <sources>  
          <source name="System.ServiceModel" switchValue="Verbose">  
              <listeners>  
                    <clear />  
                    <add type="System.Diagnostics.DefaultTraceListener" name="Default"  
                        traceOutputOptions="None" />  
                    <add name="ServiceModel Listener" traceOutputOptions="None" />  
               </listeners>  
        </source>  
            <source name="System.ServiceModel.MessageLogging">  
                <listeners>  
                    <clear />  
                    <add type="System.Diagnostics.DefaultTraceListener" name="Default"  
                        traceOutputOptions="None" />  
                    <add name="MessageLogging Listener" traceOutputOptions="None"/>  
               </listeners>  
        </source>  
    </sources>  
     <sharedListeners>  
            <add initializeData="C:\ItProTools\TraceLog.xml"  
                    type="System.Diagnostics.XmlWriterTraceListener, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"  
                    name="ServiceModel Listener"  
                    traceOutputOptions="LogicalOperationStack, DateTime, Timestamp, ProcessId, ThreadId, Callstack" />  
            <add initializeData="C:\ItProTools\MessageLog.log"  
                    type="System.Diagnostics.XmlWriterTraceListener, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"  
                   name="MessageLogging Listener"  
                   traceOutputOptions="LogicalOperationStack, DateTime, Timestamp, ProcessId, ThreadId, Callstack" />  
    </sharedListeners>  
</system.diagnostics>  
```  
  
## Example  
  
```xml  
<messageLogging logEntireMessage="true"  
    logMalformedMessages="true"  
    logMessagesAtServiceLevel="true"  
    logMessagesAtTransportLevel="true"  
    maxMessagesToLog="42"  
    maxSizeOfMessageToLog="42">  
     <filters>  
         <clear />  
     </filters>  
 </messageLogging>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.DiagnosticSection>  
 <xref:System.ServiceModel.Diagnostics>  
 <xref:System.ServiceModel.Configuration.DiagnosticSection.MessageLogging%2A>  
 <xref:System.ServiceModel.Configuration.MessageLoggingElement>  
 [Configuring Message Logging](../../../../../docs/framework/wcf/diagnostics/configuring-message-logging.md)
